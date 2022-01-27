using PostmanTool.Service.Model;

namespace PostmanTool.Service
{
    public static class GroupingService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileStream"></param>
        public static void GroupingByStream(Stream fileStream)
        {
            string jsonText = "";
            using (StreamReader reader = new StreamReader(fileStream))
            {
                jsonText = reader.ReadToEnd();
            }
            GroupingCore(jsonText);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        public static string GroupingByPath(string filePath)
        {
            var jsonText = LoadFile(filePath);
            return GroupingCore(jsonText);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jsonText"></param>
        public static string GroupingCore(string jsonText)
        {
            dynamic groupingObjRoot = Deserialize<dynamic>(jsonText);

            List<dynamic> requestObjs = new List<dynamic>();
            foreach (dynamic collection in groupingObjRoot.collections)
            {
                requestObjs.AddRange(collection.requests);
            }

            Dictionary<string, string> collectionDic = new Dictionary<string, string>();
            collectionDic.Add("202.83.83.52", "AU");

            Dictionary<string, string> folderDic = new Dictionary<string, string>();

            List<GroupingCollectionDto> collections = new List<GroupingCollectionDto>();
            foreach (dynamic requestObj in requestObjs)
            {
                if (requestObj.url == null)
                    continue;

                string url = requestObj.url;
                if (string.IsNullOrWhiteSpace(url))
                    continue;

                Uri uri = null;
                try
                {
                    uri = new Uri(url);
                }
                catch (Exception)
                {
                    continue;
                }

                GroupingRequestDto requestDto = new GroupingRequestDto
                {
                    requestId = requestObj.id,
                    requestName = uri.AbsoluteUri,
                    requestObj = requestObj
                };

                string collectionName = "";
                collectionDic.TryGetValue(uri.Host, out collectionName);
                if (string.IsNullOrWhiteSpace(collectionName))
                    collectionName = uri.Host;

                var collection = collections.FirstOrDefault(a => a.collectionName.Equals(collectionName));
                if (collection == null)
                {
                    collection = new GroupingCollectionDto
                    {
                        collectionId = Guid.NewGuid().ToString(),
                        collectionName = collectionName,
                        requests = new List<GroupingRequestDto>()
                    };
                    collection.requests.Add(requestDto);
                    collections.Add(collection);
                }
                else
                {
                    collection.requests.Add(requestDto);
                }
            }

            PostmanDto postmanDto = new PostmanDto
            {
                version = 1,
                collections = new List<CollectionsItem>()
            };

            foreach (var collection in collections)
            {
                CollectionsItem collectionsItem = new CollectionsItem
                {
                    createdAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                    id = collection.collectionId,
                    name = collection.collectionName,
                    uid = getUid(collection.collectionId),
                    requests = new List<dynamic>(),
                    folders = new List<FoldersItem>()
                };
                if (collection.folders != null)
                {
                    collectionsItem.folders_order = collection.folders?.Select(a => a.folderId).ToList();

                    foreach (var folder in collection.folders)
                    {
                        var foldersItem = new FoldersItem
                        {
                            collection = collection.collectionId,
                            collectionId = collection.collectionId,
                            createdAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                            folderId = folder.folderId,
                            id = folder.folderId,
                            name = folder.folderName,
                            uid = getUid(folder.folderId),
                            order = folder.requests.Select(a => a.requestId).ToList()
                        };

                        collectionsItem.folders.Add(foldersItem);

                        foreach (var request in folder.requests)
                        {
                            var requestObj = request.requestObj;
                            requestObj.id = request.requestId;
                            requestObj.uid = getUid(request.requestId);
                            requestObj.folder = folder.folderId;
                            requestObj.collectionId = collection.collectionId;
                            collectionsItem.requests.Add(requestObj);
                        }
                    }
                }

                if (collection.requests != null)
                {
                    collectionsItem.order = collection.requests?.Select(a => a.requestId).ToList();

                    foreach (var request in collection.requests)
                    {
                        var requestObj = request.requestObj;
                        requestObj.id = request.requestId;
                        requestObj.uid = getUid(request.requestId);
                        requestObj.folder = null;
                        requestObj.collectionId = collection.collectionId;
                        collectionsItem.requests.Add(requestObj);
                    }
                }

                postmanDto.collections.Add(collectionsItem);
            }

            return SerializeObject(postmanDto);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private static string getUid(string id)
        {
            return $"0-{id}";
        }

        private static string LoadFile(string filePath)
        {
            var jsonText = File.ReadAllText(filePath);
            return jsonText;
        }

        private static T Deserialize<T>(string jsonText)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonText);
        }

        private static string SerializeObject(object obj)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }
    }
}