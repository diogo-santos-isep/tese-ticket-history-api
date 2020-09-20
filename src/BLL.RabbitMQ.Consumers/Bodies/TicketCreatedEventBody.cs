namespace BLL.RabbitMQ.Consumers.Bodies
{
    using Models.Domain.Models;
    using System;

    [Serializable]
    public class TicketCreatedEventBody : TicketActionBody
    {
        protected override string GetActionDescription() => $"Ticket foi criado";
    }
}
