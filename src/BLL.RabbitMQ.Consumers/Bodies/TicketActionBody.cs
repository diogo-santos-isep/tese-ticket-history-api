namespace BLL.RabbitMQ.Consumers.Bodies
{
    using Models.Domain.Models;
    using System;

    public abstract class TicketActionBody : RabbitMQMessageBody
    {
        public string Ticket_Id { get; set; }
        public string Ticket_Code { get; set; }
        public DateTime Date { get; set; }
        public string User_Id { get; set; }
        public string User_Name { get; set; }

        public TicketAction BuildTicketAction()
        {
            return new TicketAction
            {
                TicketId = Ticket_Id,
                TicketCode = Ticket_Code,
                Date = Date,
                UserId = User_Id,
                UserName = User_Name,
                ActionDescription = this.GetActionDescription()
            };
        }

        protected abstract string GetActionDescription();
    }
}
