namespace DAL.Repositories.Interfaces
{
    using Models.Domain.Models;
    using System.Collections.Generic;

    public interface ITicketActionRepository
    {
        List<TicketAction> Get();
        TicketAction Get(string id);
        TicketAction Create(TicketAction model);
    }
}
