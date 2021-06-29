using System;
using System.Collections.Generic;
using System.IO;

namespace PostmanTool.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.Write("加载文件，输入文件路径：");
            var filePath = System.Console.ReadLine();

            var contentArr = File.ReadAllLines(filePath);

            List<Model.ItemItem> items = new List<Model.ItemItem>();

            foreach (var content in contentArr)
            {
                System.Console.Write(content);

                var contentSplArr = content.Split('^');
                Guid mstId = new Guid(contentSplArr[0]);
                string orderCode = contentSplArr[1];

                Model.ItemItem item = new Model.ItemItem
                {
                    name = "LMSRule/Storage/SyncMES - " + orderCode,
                    request = new Model.Request
                    {
                        method = "POST",
                        header = new List<string>(),
                        url = new Model.Url
                        {
                            raw = "https://lms.djicorp.com/LMSRule/Storage/SyncMES",
                            host = new List<string> { "lms", "djicorp", "com" },
                            path = new List<string> { "LMSRule", "Storage", "SyncMES" },
                            protocol = "https"
                        },
                        body = new Model.Body
                        {
                            mode = "raw",
                            options = new Model.Options
                            {
                                raw = new Model.Raw
                                {
                                    language = "json"
                                }
                            },
                            raw = Newtonsoft.Json.JsonConvert.SerializeObject(new { MstGuid = mstId })
                        }
                    }
                };
                items.Add(item);
            }

            Model.Root root = new Model.Root
            {
                info = new Model.Info
                {
                    name = "MIA推送MES",
                    schema = "https://schema.getpostman.com/json/collection/v2.1.0/collection.json",
                    _postman_id = "ebcd6dcd-4258-4f71-9ba6-6fa0b448fd63"
                },
                item = items
            };

            File.WriteAllText("E:\\Users\\yvan.zhang\\Desktop\\20210629 历史MIA单推送MES\\res.txt", Newtonsoft.Json.JsonConvert.SerializeObject(root));

            System.Console.Write("处理成功");
            System.Console.ReadLine();
        }
    }
}
