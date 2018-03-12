using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using RabbitMQ.Client;

namespace Send
{

    public static class Send
    {

        private const string EXCHANGE_NAEM = "exchange_demo";
        private const string ROUTING_KEY = "routingkey_demo";
        private const string QUEUE_NAME = "queue_demo";
        private const string IP_ADDRESS = "127.0.0.1";
        private const int PORT = 5672;//服务端默认端口
        private const string USER_NAME = "guest";
        private const string PASSWORD = "guest";


        // 要发送，我们必须申报一个队列给我们发送; 那么我们可以将消息发布到队列中：
        public static void pubblicer()
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
                //创建一个Typ="direct" 持久化的、非自动删除的交换器
                channel.ExchangeDeclare(EXCHANGE_NAEM, "direct", true, false, null);
                //创建一个持久的、非排他的、非自动删除的队列
                channel.QueueDeclare(QUEUE_NAME, true, false, false, null);
                //将交换器与队列通过路由键绑定
                channel.QueueBind(QUEUE_NAME, EXCHANGE_NAEM, ROUTING_KEY, null);
                //4.创建消息并发送
                var msg = "hello world";
                var body = Encoding.UTF8.GetBytes(msg);
                var porps = channel.CreateBasicProperties();
                porps.Persistent = true;
                channel.BasicPublish(EXCHANGE_NAEM, ROUTING_KEY, porps, body);
                Console.WriteLine(" [x] Sent {0}", msg);
                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
            catch (IOException ioE)
            {
                throw;
            }
            catch (SocketException socketEx)//RabbitMQ 用TCP协议，这里除了socket异常  
            {
                throw;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                //05关闭资源
                channel?.Close();
                con?.Close();

            }

        }


    }

}