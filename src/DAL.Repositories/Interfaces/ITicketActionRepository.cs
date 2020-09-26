namespace DAL.Repositories.Interfaces
{
    using Models.Domain.Models;
    using Models.Filters;
    using System.Collections.Generic;

    public interface ITicketActionRepository
    {
        List<TicketAction> Get();
        TicketAction Get(string id);
        TicketAction Create(TicketAction model);
        List<TicketAction> Search(TicketActionFilter filter);
        long Count(TicketActionFilter filter);
    }
}
