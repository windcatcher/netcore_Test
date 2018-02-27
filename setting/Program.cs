using System;
using Microsoft.Extensions.Configuration;
namespace setting
{
    class Program
    {
        public static IConfiguration Configuration { set; get; }

        static void Main(string[] args)
        {
            InitSetting();
        }


        static void InitSetting()
        {
            var builder = new ConfigurationBuilder();

            builder.AddJsonFile("setting.json");
            Configuration = builder.Build();
            Console.WriteLine($"option1={Configuration["option1"]}");
            Console.WriteLine($"option2={Configuration["option2"]}");
            Console.WriteLine("students:");
            Console.Write($"{Configuration["student:0:name"]}, ");
            Console.Write($"{Configuration["student:0:age"]}, ");
            Console.Write($"{Configuration["student:1:name"]}, ");
            Console.Write($"{Configuration["student:1:age"]}, ");
            Console.ReadKey();
        }
    }
}
