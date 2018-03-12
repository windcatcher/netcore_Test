using RabbitMQ.Client;
using System;
using System.Linq;
using System.Text;

namespace EmitLogTopic
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
                    //创建topic类型的主题交换机
                    channel.ExchangeDeclare(exchange: "topic_logs", type: "topic");

                    var routingKey = (args.Length > 0) ? args[0] : "anonymous.info";

                    var msg = (args.Length > 1)
                         ? string.Join(" ", args.Skip(1).ToArray())
                         : "Hello World!";
                    var body = Encoding.UTF8.GetBytes(msg);

                    //发布消息,使用主题交换机，根据主题的匹配键使用不同的绑定，使用默认的临时队列
                    channel.BasicPublish(exchange: "topic_logs", routingKey: routingKey, basicProperties: null, body: body);
                    Console.WriteLine(" [x] Sent '{0}':'{1}'", routingKey, msg);
                }
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }

    }
}
