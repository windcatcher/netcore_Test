using System;
using System.Collections.Generic;
using System.Text;

namespace Linq
{
    public class DelegateTest
    {
        public static void TestAction()
        {
            string value = "Action Delegate";
            var method = new Action<string>((p) =>
            {
                Console.WriteLine(p);
            });
            method(value);

            Console.ReadKey();
        }

        //Predicate泛型委托, 布尔
        public static void TestPredicate()
        {
            var arr = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
            var isMore = new Predicate<int>(p => { return p > 3; });
            var printMethod = new Action<List<int>, Predicate<int>>((pArr, pPredi) =>
                {
                    Console.WriteLine("Predicate 测试");
                    pArr.FindAll(pPredi).ForEach(p => { Console.WriteLine("数据内大于3的项={0}", p); });
                    Console.ReadKey();
                });
            printMethod(arr, isMore);
        }

        /// <summary>
        /// Func是多参数能返回值的委托申明
        /// </summary>
        public static void TestFunc()
        {
            var method = new Func<int, int, string>((a, b) =>
             {
                 var c = a + b;
                 return (c).ToString();
             });
            var resultStr = "Func<int, int, string>((a, b) 的计算加法结果" + method(1, 2);
            Console.WriteLine(resultStr);
            Console.ReadKey();
        }


    }
}
