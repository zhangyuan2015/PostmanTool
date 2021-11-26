namespace PostmanTool.Service.PostmanDto
{
    public class Info
    {
        /// <summary>
        /// 
        /// </summary>
        public string _postman_id { get; set; }
        /// <summary>
        /// MIA推送MES
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string schema { get; set; }
    }

    public class Raw
    {
        /// <summary>
        /// 
        /// </summary>
        public string language { get; set; }
    }

    public class Options
    {
        /// <summary>
        /// 
        /// </summary>
        public Raw raw { get; set; }
    }

    public class Body
    {
        /// <summary>
        /// 
        /// </summary>
        public string mode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string raw { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Options options { get; set; }
    }

    public class Url
    {
        /// <summary>
        /// 
        /// </summary>
        public string raw { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string protocol { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> host { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> path { get; set; }
    }

    public class Request
    {
        /// <summary>
        /// 
        /// </summary>
        public string method { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> header { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Body body { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Url url { get; set; }
    }

    public class ItemItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Request request { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> response { get; set; }
    }

    public class Root
    {
        /// <summary>
        /// 
        /// </summary>
        public Info info { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<ItemItem> item { get; set; }
    }
}
