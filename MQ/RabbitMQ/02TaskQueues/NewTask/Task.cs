using RabbitMQ.Client;
using System;
using System.Text;

namespace NewTask
{
    class Program
    {
        private const string EXCHANGE_NAEM = "exchange_demo";
        private const string ROUTING_KEY = "routingkey_demo";
        private const string QUEUE_NAME = "queue_demo";
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
                    //创建exchange交换机,
                    //消息持久化需要两个条件，队列和消息标注为持久化
                    //创建消息队列
                    channel.QueueDeclare(queue: "task_queue",
                                 durable: true,   //队列持久化，rabbitQm宕机后依然可以从磁盘中加载到队列上
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

                    //交换机与消息队绑定路由 使用默认的
                    var msg = GetMessages(args);
                    var body = Encoding.UTF8.GetBytes(msg);

                    //发布消息
                    //将消息标记为持久性
                    var properties = channel.CreateBasicProperties();
                    properties.Persistent = true;

                    channel.BasicPublish(exchange: "", routingKey: "task_queue", basicProperties: properties, body: body);//exchange: "",表示使用默认的交换机
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
