namespace BLL.Services.Interfaces
{
    using Models.Domain.Models;
    using System.Collections.Generic;

    public interface ITicketActionService
    {
        TicketAction Create(TicketAction model);
        List<TicketAction> Get();
        TicketAction Get(string id);
    }
}
