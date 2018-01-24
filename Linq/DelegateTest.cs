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
            var method = new Action<string>(p => { Console.WriteLine(p); });
            method(value);
        }

        //Predicate泛型委托, 布尔
        public void TestPredicate()
        {
            var arr = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
            var isMore = new Predicate<int>(p=> { return p > 3; });
            //var printMethod = new Action<IList<int>, Predicate<int>>(arr, )
        }

        public void TestFunc()
        {
            var method = new Func<int, int, string>((a, b) =>
             {
                 var c = a + b;
                 return (c).ToString();
             });
            Console.WriteLine("Func<int, int, string>((a, b) 的计算加法结果" + method(1, 2));
        }

        static bool More(int item)
        {
            return item > 3;
        }
        static bool Less(int item)
        {
            return item < 3;
        }

    }
}
