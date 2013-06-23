using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RechnungComp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HESCommunicationLib
{
    public class HAPSARConnector
    {
        private string hostname;
        private string queuename;
        private IRechnung rechnungsKomp;
        /// <summary>
        /// Starts the HAPSARConnector in a own Thread
        /// </summary>
        public HAPSARConnector(IRechnung rechnungsKomp,String hostname, string queuename)
        {
            this.rechnungsKomp = rechnungsKomp;
            this.hostname = hostname;
            this.queuename = queuename;

            Thread service = new Thread(new ThreadStart(startRecieveService));
            service.Start();
        }

        /// <summary>
        /// Delegates to the RechnungsKomp
        /// </summary>
        /// <param name="rnr"></param>
        /// <param name="betrag"></param>
        private void zahlungsEingangBuchen(String rnr, double betrag)
        {
            rechnungsKomp.zahlungseingangBuchen(betrag, rnr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="duration">Duration in milis for the Service </param>
        public void startRecieveService()
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.HostName = hostname;

            using (IConnection connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                channel.QueueDeclare(queuename, false, false, false, null);

                QueueingBasicConsumer consumer = new QueueingBasicConsumer(channel);
                channel.BasicConsume(queuename, true, consumer);

                System.Console.WriteLine(" [*] Waiting for messages." +
                                            "To exit press CTRL+C");
                while (true)
                {
                    BasicDeliverEventArgs ea =
                        (BasicDeliverEventArgs)consumer.Queue.Dequeue();

                    byte[] body = ea.Body;
                    string[] message = System.Text.Encoding.UTF8.GetString(body).Split(';');
                    System.Console.WriteLine(" [x] Received {0}", message);
                    zahlungsEingangBuchen(message[0], Double.Parse(message[1]));
                }
            }
        }
        
    }
}
