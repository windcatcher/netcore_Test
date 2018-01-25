using Linq;
using System;
using System.Collections.Generic;
using Xunit;

namespace XUnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            DelegateTest.TestAction();
        }

        [Fact]
        public void TestPredicate()
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
    }
}
