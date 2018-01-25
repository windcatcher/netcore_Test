using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Linq;

namespace Linq
{
    public class LinqTest
    {

        //选择结果
        public void TestSelect()
        {



        }

        //where
        public void TestWhere()
        {
            var arr = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var result = arr.Where<int>((p) => { return p > 3; }) as List<int>;
            Console.WriteLine("大于3的项");
            result.ForEach(p => { Console.WriteLine(p); });
        }
    }
}
