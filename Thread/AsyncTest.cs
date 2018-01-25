using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadTest
{
    public class AsyncTest
    {

        public static void TestAsync()
        {
            DoClickAsync();
            Console.WriteLine("不等待异步方法，直接执行");
            Console.ReadKey();
        }
        private static async void DoClickAsync()
        {
            Task<int> result = OperateAsync();
            Console.WriteLine("从OperateAsync方法中控制权限返回调用方DoClickAsync");
            int resultValue = await result;
            Console.WriteLine("耗时操作结果" + resultValue.ToString());

        }

        private static async Task<int> OperateAsync()
        {
            HttpClient client = new HttpClient();
            //执行异步方法 GetStringAsync
            Task<string> getStringTask = client.GetStringAsync("https://msdn.microsoft.com");
            //由于下面的非异步方法不依赖上面异步方法结果，因此可以先执行，假设在这里执行一些非异步的操作
            DoIndependentWork();
            //等待操作挂起方法 OperateAsync，直到 getStringTask 完成，OperateAsync 方法才会继续执行
            //同时，控制将返回到 OperateAsync 方法的调用方，直到 getStringTask 完成后，将在这里恢复控制。
            //然后从 getStringTask 拿到字符串结果
            string urlContents = await getStringTask;
            Console.WriteLine("方法OperateAsync");
            return urlContents.Length;
        }


       

        //private static async Task<int> OperateAsync()
        //{
        //    HttpClient client = new HttpClient();

        //    //执行异步方法 GetStringAsync
        //    Task<string> getStringTask = client.GetStringAsync("https://msdn.microsoft.com");

        //    //由于下面的非异步方法不依赖上面异步方法结果，因此可以先执行，假设在这里执行一些非异步的操作
        //    DoIndependentWork();

        //    //等待操作挂起方法 OperateAsync，直到 getStringTask 完成，OperateAsync 方法才会继续执行
        //    //同时，控制将返回到 OperateAsync 方法的调用方，直到 getStringTask 完成后，将在这里恢复控制。
        //    //然后从 getStringTask 拿到字符串结果
        //    string urlContents = await getStringTask;

        //    Console.WriteLine("方法OperateAsync");
        //    //返回字符串的长度（int 类型）
        //    return urlContents.Length;

        //}

        private static void DoIndependentWork()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("主线程执行内容" + i);
                
                Thread.Sleep(1000);
            }
        }

    }
}
