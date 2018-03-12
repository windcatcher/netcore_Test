using RabbitMQ.Client;
using System;
using System.Text;

namespace EmitLog
{
    class Program
    {
        private const string EXCHANGE_NAEM = "logs";
        private const string ROUTING_KEY = "";//默认的路由
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
                    //创建扇形exchange交换机,把消息发送给它所知道的所有队列
                    channel.ExchangeDeclare(exchange: EXCHANGE_NAEM, type: "fanout");
                    
                    var msg = GetMessages(args);
                    var body = Encoding.UTF8.GetBytes(msg);

                    //发布消息,使用默认的绑定，使用默认的临时队列
                    channel.BasicPublish(exchange: EXCHANGE_NAEM, routingKey: "", basicProperties: null, body: body);
                    Console.WriteLine(" [x] Sent {0}", msg);
                }
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }

        private static string GetMessages(string[] args)
        {
            return args.Length > 0 ? string.Join(" ", args) : "Hello World!";
        }
    }
}
