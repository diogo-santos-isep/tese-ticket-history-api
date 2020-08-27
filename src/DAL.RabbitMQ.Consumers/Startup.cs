namespace DAL.RabbitMQ.Consumers
{
    using DAL.RabbitMQ.Consumers.Implementations;
    public class Startup
    {
        private TicketStateChangedConsumer ticketStateConsumer;

        public Startup(TicketStateChangedConsumer ticketStateConsumer)
        {
            this.ticketStateConsumer = ticketStateConsumer;
        }
        public void StartConsumers()
        {
            _ = this.ticketStateConsumer.Start();
        }
    }
}
