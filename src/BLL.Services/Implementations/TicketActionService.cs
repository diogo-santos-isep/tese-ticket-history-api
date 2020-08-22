using BLL.Services.Interfaces;
using DAL.Repositories.Interfaces;
using Models.Domain.Models;
using System;
using System.Collections.Generic;

namespace BLL.Services.Implementations
{
    public class TicketActionService : ITicketActionService
    {
        private ITicketActionRepository _repo;

        public TicketActionService(ITicketActionRepository _repo)
        {
            this._repo = _repo;
        }
        public TicketAction Create(TicketAction model)
        {
            return _repo.Create(model);
        }

        public List<TicketAction> Get() => _repo.Get();

        public TicketAction Get(string id) => _repo.Get(id);

    }
}
