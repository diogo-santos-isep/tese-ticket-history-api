namespace DAL.RabbitMQ.Consumers.Bodies
{
    using Models.Domain.Enums;

    public class TicketStateChangedBody : RabbitMQMessageBody
    {
        public string TicketId { get; set; }
        public ETicketState NewState { get; set; }
    }
}
