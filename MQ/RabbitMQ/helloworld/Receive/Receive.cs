using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Receive
{

    public static class Receive
    {

        private const string EXCHANGE_NAEM = "exchange_demo";
        private const string ROUTING_KEY = "routingkey_demo";
        private const string QUEUE_NAME = "queue_demo";
        private const string IP_ADDRESS = "127.0.0.1";
        private const int PORT = 5672;//服务端默认端口
        private const string USER_NAME = "guest";
        private const string PASSWORD = "guest";

        public static void Consumer()
        {
            IConnection con = null;
            IModel channel = null;
            try
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
                con = factory.CreateConnection();
                //3.创建channel
                channel = con.CreateModel();
                //创建一个持久的、非排他的、非自动删除的队列,注意匹配Send发布者的队列
                //请注意，我们也在这里声明队列。 因为我们可能会在发布者之前启动消费者，所以我们要确保队列存在，然后再尝试从中消费消息。
                channel.QueueDeclare(QUEUE_NAME, true, false, false, null);
                //设置队列最大接受未未ack的消息的个数
                // channel.BasicQos(64, 1000, true);
                //创建消费者-监听模式
                //告诉服务器将队列中的消息传递给我们。 由于它将异步地推送我们的邮件，所以我们提供一个回调
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    //处理接收后的消息
                    Run(body);
                    //var msg = Encoding.UTF8.GetString(body);
                    //Console.WriteLine($" [x] received {msg}");
                    channel.BasicAck(ea.DeliveryTag, false);
                };
                channel.BasicConsume(QUEUE_NAME, false, consumer);
                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
            catch (IOException ioE)
            {
                // throw;
            }
            catch (SocketException socketEx)//RabbitMQ 用TCP协议，这里除了socket异常  
            {
                // throw;
            }
            catch (Exception)
            {

                //throw;
            }
            finally
            {
                //05关闭资源
                channel?.Close();
                con?.Close();

            }

        }
        private static void Run(byte[] body)
        {
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine(" [x] Received {0}", message);
        }

    }

}