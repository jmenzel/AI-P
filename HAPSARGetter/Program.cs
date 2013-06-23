using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAPSARGetter
{
    class Program
    {
        static void Main(string[] args)
        {
            
            ConnectionFactory factory = new ConnectionFactory();
            factory.HostName = "localhost";
            
            using (IConnection connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                channel.QueueDeclare("HAPSAR", false, false, false, null);

                QueueingBasicConsumer consumer = new QueueingBasicConsumer(channel);
                channel.BasicConsume("HAPSAR", true, consumer);

                System.Console.WriteLine(" [*] Waiting for messages." +
                                         "To exit press CTRL+C");
                while (true)
                {
                    BasicDeliverEventArgs ea =
                        (BasicDeliverEventArgs)consumer.Queue.Dequeue();

                    byte[] body = ea.Body;
                    string message = System.Text.Encoding.UTF8.GetString(body);
                    System.Console.WriteLine(" [x] Received {0}", message);
                }
            }
        }
        }
    }