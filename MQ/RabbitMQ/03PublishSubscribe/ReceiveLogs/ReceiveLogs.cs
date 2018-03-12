using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;

namespace ReceiveLogs
{
    class Program
    {
        private const string EXCHANGE_NAEM = "logs";
        private const string ROUTING_KEY = "";
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
                    channel.ExchangeDeclare(exchange: EXCHANGE_NAEM, type: "fanout");
                    var queueName = channel.QueueDeclare().QueueName;
                    channel.QueueBind(queue: queueName, exchange: EXCHANGE_NAEM, routingKey: "");

                    Console.WriteLine(" [*] Waiting for logs.");
                    //创建消息监听事件
                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        var msg = Encoding.UTF8.GetString(body);
                        Console.WriteLine(" [x] Recive {0}", msg);
                    };
                    //向消息服务中心发送消费消息确认
                    channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);
                    Console.WriteLine(" Press [enter] to exit.");
                    Console.ReadLine();
                }
            }

        }
    }
}