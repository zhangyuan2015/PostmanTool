namespace PostmanTool.Service.Model
{
    public class GroupingRequestDto
    {
        /// <summary>
        /// 
        /// </summary>
        public string requestId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string requestName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public dynamic requestObj { get; set; }
    }

    public class GroupingCollectionDto
    {
        /// <summary>
        /// 
        /// </summary>
        public string collectionId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string collectionName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<GroupingRequestDto> requests { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<GroupingFolderDto> folders { get; set; }
    }

    public class GroupingFolderDto
    {
        public string folderId { get; set; }
        public string folderName { get; set; }
        public List<GroupingRequestDto> requests { get; set; }
    }
}