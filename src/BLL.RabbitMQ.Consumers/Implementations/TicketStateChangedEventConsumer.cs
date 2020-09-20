namespace BLL.RabbitMQ.Consumers.Implementations
{
    using BLL.RabbitMQ.Consumers.Bodies;
    using BLL.RabbitMQ.Consumers.Extensions;
    using BLL.RabbitMQ.Consumers.Helpers;
    using BLL.Services.Implementations;
    using BLL.Services.Interfaces;
    using DAL.Repositories.Implementations;
    using global::RabbitMQ.Client;
    using global::RabbitMQ.Client.Events;
    using Infrastructure.CrossCutting;
    using Infrastructure.CrossCutting.Settings.Implementations;
    using Newtonsoft.Json;
    using System;
    using System.Text;
    using System.Threading.Tasks;

    public class TicketStateChangedEventConsumer
    {
        private readonly string QUEUENAME = "TicketStateChangedQueue";
        private IConnectionFactory factory;
        private MongoDBConnection dbConnectionSettings;

        public TicketStateChangedEventConsumer(RabbitMQSettings settings, MongoDBConnection dbConnectionSettings)
        {
            this.factory = settings.ToFactory();
            this.dbConnectionSettings = dbConnectionSettings;
        }

        public async Task Start()
        {
            try
            {
                var connection = factory.CreateConnection();
                var channel = connection.CreateModel();
                channel.QueueDeclare(queue: QUEUENAME,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (ch, ea) =>
                {
                    try
                    {
                        string json = Encoding.UTF8.GetString(ea.Body);
                        var message = JsonConvert.DeserializeObject<TicketStateChangedEventBody>(json);
                        Console.WriteLine(Environment.NewLine + $"[TicketStateChanged Message Received]");

                        var ticketAction = message.BuildTicketAction();
                        var service = new TicketActionService(new TicketActionRepository(dbConnectionSettings.Connect()));
                        service.Create(ticketAction);

                        channel.BasicAck(ea.DeliveryTag, false);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(Environment.NewLine + $"Error Processing Message!!! {ex.Message}");
                        channel.BasicAck(ea.DeliveryTag, false);
                    }
                };
                channel.BasicConsume(queue: QUEUENAME,
                     autoAck: false,
                     consumer: consumer);
                Console.WriteLine("TicketStateChanged Consumer Started");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something Went Wrong! {ex.Message}");
            }
        }
        private static void Consumer_Received(
   object sender, BasicDeliverEventArgs e)
        {
            var message = Converter.FromByteArray<TicketStateChangedEventBody>(e.Body);
            Console.WriteLine(Environment.NewLine + $"[TicketStateChanged Message Received]");
        }
    }
}
