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

        [HttpPost("search")]
        [ScopeAndRoleAuthorization(Scopes.TicketHistoryScope)]
        public ActionResult<TicketActionGrid> Search(string ticket_id, [FromBody]TicketActionFilter filter)
        {
            filter.TicketId = ticket_id;
            return this._service.Search(filter);
        }

        [HttpGet]
        [ScopeAndRoleAuthorization(Scopes.TicketHistoryScope)]
        public ActionResult<IEnumerable<TicketAction>> GetAll()
        {
            return this._service.Get();
        }

        [HttpGet("{id}")]
        [ScopeAndRoleAuthorization(Scopes.TicketHistoryScope)]
        public ActionResult<TicketAction> Get(string id)
        {
            return this._service.Get(id);
        }
    }
}
