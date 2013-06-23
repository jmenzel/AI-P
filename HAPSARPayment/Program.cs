using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HAPSARPayment
{
    /// <summary>
    /// Dummy zum schieben von Nachrichten in die QUEUE
    /// </summary>
    class Program : IDisposable
    {
        //Setting Connection Propertys
        private readonly String connectionHost = "localhost";
        private readonly String queueName = "HAPSAR";
        private ConnectionFactory factory;
        private IConnection connection;
        private IModel model;


        static void Main(string[] args)
        {
            Program hapsar = new Program();
            String input = "";

            if (hapsar.initializeConnection())
            {

                Console.WriteLine("Zum Beenden 'exit' eingeben");

                while (true)
                {
                    input = Console.ReadLine();

                    switch (input)
                    {
                        case "exit":
                            hapsar.closeConnection();
                            break;
                        case "start":
                            hapsar.initializeConnection();
                            break;
                        default:
                            hapsar.sendMsg(input);
                            input = "";
                            break;
                    }
                }
            }
            else { Console.WriteLine("Setting up the Connection failed"); }

        }

        /// <summary>
        /// Creates or uses an existing ConnectionSocket if allready opened
        /// </summary>
        /// <returns></returns>
        private Boolean initializeConnection()
        {
            try
            {
                factory = new ConnectionFactory();
                factory.HostName = connectionHost;
                connection = factory.CreateConnection();
                model = connection.CreateModel();
                model.QueueDeclare(queueName, false, false, false, null);
       
                Console.WriteLine("Connection established.....");

                return true;
            }
            catch (Exception ex) { return false; }
        }

        /// <summary>
        /// Closes a Connection if opened
        /// </summary>
        private void closeConnection()
        {
            if (connection.IsOpen) connection.Close();
            if (model.IsOpen) model.Close();
            Console.WriteLine("Connection closed.....");
        }



        /// <summary>
        /// Sends a Message to the declared Channel
        /// </summary>
        /// <param name="msg">Message to be published</param>
        /// <returns></returns>
        private void sendMsg(String msg)
        {
            try
            {
                model.BasicPublish("","HAPSAR",null,System.Text.Encoding.UTF8.GetBytes(msg));
                Console.WriteLine(" [x] Sent {0}", msg); 
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(" [x] NOT Sent {0}", msg);
                Console.WriteLine("Zum starten 'start' eingeben");
            }
        }

        #region RabbitMQ Server

        private Boolean startRabbitMQServer()
        {
            return false;
        }

        #endregion

        public void Dispose() { closeConnection(); }
    }
}
