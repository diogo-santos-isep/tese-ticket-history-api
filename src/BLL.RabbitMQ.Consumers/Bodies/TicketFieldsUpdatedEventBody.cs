namespace BLL.RabbitMQ.Consumers.Bodies
{
    using Models.Domain.Models;
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class TicketFieldsUpdatedEventBody : TicketActionBody
    {
        public IEnumerable<string> ChangedFields { get; set; }
        protected override string GetActionDescription() => $"O(s) campo(s): {String.Join(", ",ChangedFields)} foram alterados";
    }
}
