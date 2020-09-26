using BLL.Services.Interfaces;
using DAL.Repositories.Implementations;
using DAL.Repositories.Interfaces;
using Infrastructure.CrossCutting.Settings.Implementations;
using Models.Domain.Models;
using Models.DTO.Grids;
using Models.Filters;
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
        public TicketActionGrid Search(TicketActionFilter filter)
        {
            return new TicketActionGrid
            {
                List = _repo.Search(filter),
                Count = Convert.ToInt32(_repo.Count(filter))
            };
        }

        public List<TicketAction> Get() => _repo.Get();

        public TicketAction Get(string id) => _repo.Get(id);

    }
}
