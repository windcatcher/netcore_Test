using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;

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
                    channel.QueueDeclare(queue: "task_queue",
                                 durable: true,   //队列持久化，rabbitQm宕机后依然可以从磁盘中加载到队列上
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

                    channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

                    Console.WriteLine(" [*] Waiting for messages.");
                    //创建消息监听事件
                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        var msg = Encoding.UTF8.GetString(body);
                        Console.WriteLine(" [x] Recive {0}", msg);

                        int dots = msg.Split('.').Length - 1;
                        Thread.Sleep(dots * 1000);
                        Console.WriteLine(" [x] Done");

                        //增加消息确认 ，如果一个worker挂了，我们希望把这个任务交给另一个工作者
                        channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                    };
                    //向消息服务中心发送消费消息确认
                    // channel.BasicConsume(queue: "task_queue", autoAck: true, consumer: consumer);
                    channel.BasicConsume(queue: "task_queue", autoAck: false, consumer: consumer); //autoAck: true改为false
                    Console.WriteLine(" Press [enter] to exit.");
                    Console.ReadLine();
                }
            }
          
        }
    }
}