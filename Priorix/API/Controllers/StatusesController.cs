using Microsoft.AspNetCore.Mvc;
using Priorix.Core.Entities;
using Priorix.Core.Interfaces.Services;

namespace Priorix.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusesController : ControllerBase
    {
        private readonly IStatusesService _service;

        public StatusesController(IStatusesService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetStatuses());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var status = _service.FindById(id);
            if (status == null) return NotFound();
            return Ok(status);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Statuses status)
        {
            _service.CreateStatus(status);
            return Ok(status);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Statuses status)
        {
            _service.UpdateStatus(status);
            return Ok(status);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteStatus(id);
            return Ok();
        }
    }
}
