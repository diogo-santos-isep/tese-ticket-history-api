namespace DAL.RabbitMQ.Consumers.Implementations
{
    using DAL.RabbitMQ.Consumers.Bodies;
    using DAL.RabbitMQ.Consumers.Bodies;
    using DAL.RabbitMQ.Consumers.Extensions;
    using DAL.RabbitMQ.Consumers.Helpers;
    using global::RabbitMQ.Client;
    using global::RabbitMQ.Client.Events;
    using Infrastructure.CrossCutting.Settings.Implementations;
    using Newtonsoft.Json;
    using System;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TicketStateChangedConsumer
    {
        private readonly string QUEUENAME = "TicketStateChangedQueue";
        private IConnectionFactory factory;

        public TicketStateChangedConsumer(RabbitMQSettings settings)
        {
            this.factory = settings.ToFactory();
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
                        var message = JsonConvert.DeserializeObject<TicketStateChangedBody>(json);
                        Console.WriteLine(Environment.NewLine + $"[TicketStateChanged Message Received]");

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
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something Went Wrong! {ex.Message}");
            }
        }
        private static void Consumer_Received(
   object sender, BasicDeliverEventArgs e)
        {
            var message = Converter.FromByteArray<TicketStateChangedBody>(e.Body);
            Console.WriteLine(Environment.NewLine + $"[TicketStateChanged Message Received]");
        }
    }
}
