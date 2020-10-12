namespace Presentation.API.Controllers
{
    using BLL.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Models.Domain.Models;
    using Models.DTO.Grids;
    using Models.Filters;
    using Presentation.API.Auth;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/ticket/{ticket_id}/history")]
    [ApiController]
    public class TicketActionController : ControllerBase
    {
        private ITicketActionService _service;

        public TicketActionController(ITicketActionService service)
        {
            this._service = service;
        }

        /// <summary>
        /// Performs a Search on ticket history events
        /// | scope: ticket.history
        /// </summary>
        /// <param name="ticket_id"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpPost("search")]
        [ScopeAndRoleAuthorization(Scopes.TicketHistoryScope)]
        public ActionResult<TicketActionGrid> Search(string ticket_id, [FromBody]TicketActionFilter filter)
        {
            filter.TicketId = ticket_id;
            return this._service.Search(filter);
        }

        /// <summary>
        /// Gets all the ticket history events
        /// | scope: ticket.history
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ScopeAndRoleAuthorization(Scopes.TicketHistoryScope)]
        public ActionResult<IEnumerable<TicketAction>> GetAll()
        {
            return this._service.Get();
        }

        /// <summary>
        /// Gets a ticket history event
        /// | scope: ticket.history
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ScopeAndRoleAuthorization(Scopes.TicketHistoryScope)]
        public ActionResult<TicketAction> Get(string id)
        {
            return this._service.Get(id);
        }
    }
}
