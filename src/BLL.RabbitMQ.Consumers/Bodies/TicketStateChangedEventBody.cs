namespace BLL.RabbitMQ.Consumers.Bodies
{
    using Models.Domain.Enums;
    using Models.Domain.Helpers;
    using Models.Domain.Models;
    using System;

    [Serializable]
    public class TicketStateChangedEventBody : TicketActionBody
    {
        public ETicketState NewState { get; set; }

        protected override string GetActionDescription() => $"Estado do ticket foi alterado para {NewState.Translation()}";
    }
}
