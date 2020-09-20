namespace BLL.RabbitMQ.Consumers.Bodies
{
    using Models.Domain.Models;
    using System;

    [Serializable]
    public class TicketReassignedEventBody : TicketActionBody
    {
        public string NewDepartment_Id { get; set; }
        public string NewDepartment_Description { get; set; }
        public string NewCollaborator_Id { get; set; }
        public string NewCollaborator_Name { get; set; }
        protected override string GetActionDescription() => $"Ticket foi atribuído ao departamento {NewDepartment_Description}, colaborador {NewCollaborator_Name}";
    }
}
