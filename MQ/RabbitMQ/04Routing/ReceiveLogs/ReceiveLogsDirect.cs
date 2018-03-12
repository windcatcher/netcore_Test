using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;

namespace ReceiveLogsDirect
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
                    channel.ExchangeDeclare(exchange: "direct_logs",
                                     type: "direct");
                    //使用默认的临时队列
                    var queueName = channel.QueueDeclare().QueueName;


                    if (args.Length < 1)
                    {
                        Console.Error.WriteLine("Usage: {0} [info] [warning] [error]",
                                                Environment.GetCommandLineArgs()[0]);
                        Console.WriteLine(" Press [enter] to exit.");
                        Console.ReadLine();
                        Environment.ExitCode = 1;
                        return;
                    }

                    //使用不同日志级别的路由绑定severity
                    foreach (var severity in args)
                    {
                        channel.QueueBind(queue: queueName,
                                          exchange: "direct_logs",
                                          routingKey: severity);
                    }

                    Console.WriteLine(" [*] Waiting for messages.");

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);
                        var routingKey = ea.RoutingKey;
                        Console.WriteLine(" [x] Received '{0}':'{1}'",
                                          routingKey, message);
                    };
                    channel.BasicConsume(queue: queueName,
                                         autoAck: true,
                                         consumer: consumer);

                    Console.WriteLine(" Press [enter] to exit.");
                    Console.ReadLine();
                }
            }

        }
    }
}