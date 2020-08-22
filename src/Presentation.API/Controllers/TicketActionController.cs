namespace Presentation.API.Controllers
{
    using BLL.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Models.Domain.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class TicketActionController : ControllerBase
    {
        private ITicketActionService _service;

        public TicketActionController(ITicketActionService service)
        {
            this._service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TicketAction>> GetAll()
        {
            return this._service.Get();
        }

        [HttpGet("{id}")]
        public ActionResult<TicketAction> Get(string id)
        {
            return this._service.Get(id);
        }
    }
}
