using System.IO;

namespace PostmanTool.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.Write("加载文件，输入文件路径：");
            var filePath = System.Console.ReadLine();

            var jsonText = File.ReadAllText(filePath);


            
            System.Console.Write("处理成功");
            System.Console.ReadLine();
        }
    }
}