using RabbitMQ.Client;
using System;
using System.Linq;
using System.Text;

namespace EmitLogDirect
{
    class Program
    {
        private const string IP_ADDRESS = "127.0.0.1";
        private const int PORT = 5672;//服务端默认端口
        private const string USER_NAME = "guest";
        private const string PASSWORD = "guest";
        static void Main(string[] args)
        {
            //1.创建factory
            var factory = new ConnectionFactory
            {
                HostName = IP_ADDRESS,
                Port = PORT,
                UserName = USER_NAME,
                Password = PASSWORD
            };
            //2.创建connection
            using (var con = factory.CreateConnection())
            {
                //创建channel
                using (var channel = con.CreateModel())
                {
                    //创建direct类型的直连交换机
                    channel.ExchangeDeclare(exchange: "direct_logs", type: "direct");

                    var severity = (args.Length > 0) ? args[0] : "info";
                    var msg = (args.Length > 1)
                         ? string.Join(" ", args.Skip(1).ToArray())
                         : "Hello World!";
                    var body = Encoding.UTF8.GetBytes(msg);

                    //发布消息,使用直连交换机，使用不同日志级别的路由绑定severity，使用默认的临时队列
                    channel.BasicPublish(exchange: "direct_logs", routingKey: severity, basicProperties: null, body: body);
                    Console.WriteLine(" [x] Sent '{0}':'{1}'", severity, msg);
                }
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }

    }
}
