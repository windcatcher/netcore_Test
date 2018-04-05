using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPipeLine
{


    class Program
    {
        public static IList<Func<RequestDelegate, RequestDelegate>> _list = new List<Func<RequestDelegate, RequestDelegate>>();
        static void Main(string[] args)
        {
            //使用use装配
            Use((next) =>
            {
                return (context) =>
                {
                    Console.WriteLine("1");
                    return next.Invoke(context);
                    //return Task.CompletedTask;
                };
            });

            Use((next) =>
            {
                return (context) =>
                {
                    Console.WriteLine("2");
                    return next.Invoke(context);
                };
            });

            RequestDelegate end = (context) =>
            {
                Console.WriteLine("end....");
                return Task.CompletedTask;
            };

            //构建
            foreach (var midWare in _list.Reverse())
            {
                end = midWare.Invoke(end);
            }

            end.Invoke(new Context());
            Console.ReadLine();
        }


        public static IList<Func<RequestDelegate, RequestDelegate>> Use(Func<RequestDelegate, RequestDelegate> midWare)
        {
            _list.Add(midWare);
            return _list;
        }


    }
}
