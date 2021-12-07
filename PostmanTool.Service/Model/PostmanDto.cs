namespace PostmanTool.Service.Model
{
    public class PostmanDto
    {
        /// <summary>
        /// 
        /// </summary>
        public int version { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<CollectionsItem> collections { get; set; }
    }

    public class CollectionsItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string uid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string auth { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string events { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string variables { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> order { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> folders_order { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ProtocolProfileBehavior protocolProfileBehavior { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string createdAt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<FoldersItem> folders { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<dynamic> requests { get; set; }
    }

    public class ProtocolProfileBehavior
    {
    }

    public class FoldersItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string uid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string auth { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string events { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string collection { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string folder { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> order { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> folders_order { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string owner { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ProtocolProfileBehavior protocolProfileBehavior { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string createdAt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string collectionId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string folderId { get; set; }
    }
}