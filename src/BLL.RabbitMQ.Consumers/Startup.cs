namespace BLL.RabbitMQ.Consumers
{
    using BLL.RabbitMQ.Consumers.Implementations;
    public class Startup
    {
        private TicketStateChangedEventConsumer ticketStateConsumer;
        private TicketCreatedEventConsumer ticketCreatedConsumer;
        private TicketReassignedEventConsumer ticketReassignedConsumer;
        private TicketFieldsUpdatedEventConsumer ticketFieldsUpdatedConsumer;

        public Startup(TicketStateChangedEventConsumer ticketStateConsumer, TicketCreatedEventConsumer ticketCreatedConsumer
            , TicketReassignedEventConsumer ticketReassignedConsumer, TicketFieldsUpdatedEventConsumer ticketFieldsUpdatedConsumer)
        {
            this.ticketStateConsumer = ticketStateConsumer;
            this.ticketCreatedConsumer = ticketCreatedConsumer;
            this.ticketReassignedConsumer = ticketReassignedConsumer;
            this.ticketFieldsUpdatedConsumer = ticketFieldsUpdatedConsumer;
        }
        public void StartConsumers()
        {
            _ = this.ticketStateConsumer.Start();
            _ = this.ticketCreatedConsumer.Start();
            _ = this.ticketReassignedConsumer.Start();
            _ = this.ticketFieldsUpdatedConsumer.Start();
        }
    }
}
