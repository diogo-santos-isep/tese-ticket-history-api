namespace BLL.RabbitMQ.Consumers
{
    using BLL.RabbitMQ.Consumers.Implementations;
    public class Startup
    {
        private TicketStateChangedEventConsumer ticketStateConsumer;
        private TicketCreatedEventConsumer ticketCreatedConsumer;
        private TicketReassignedEventConsumer ticketReassignedConsumer;

        public Startup(TicketStateChangedEventConsumer ticketStateConsumer, TicketCreatedEventConsumer ticketCreatedConsumer
            , TicketReassignedEventConsumer ticketReassignedConsumer)
        {
            this.ticketStateConsumer = ticketStateConsumer;
            this.ticketCreatedConsumer = ticketCreatedConsumer;
            this.ticketReassignedConsumer = ticketReassignedConsumer;
        }
        public void StartConsumers()
        {
            _ = this.ticketStateConsumer.Start();
            _ = this.ticketCreatedConsumer.Start();
            _ = this.ticketReassignedConsumer.Start();
        }
    }
}
