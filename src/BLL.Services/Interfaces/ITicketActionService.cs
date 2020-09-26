namespace BLL.Services.Interfaces
{
    using Models.Domain.Models;
    using Models.DTO.Grids;
    using Models.Filters;
    using System.Collections.Generic;

    public interface ITicketActionService
    {
        TicketAction Create(TicketAction model);
        List<TicketAction> Get();
        TicketAction Get(string id);
        TicketActionGrid Search(TicketActionFilter filter);
    }
}
