using Microsoft.AspNetCore.Mvc;
using Priorix.Core.Entities;
using Priorix.Core.Interfaces.Services;
using Priorix.Core.Services;

namespace Priorix.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _service;

        public StatusController(IStatusService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetStatus());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var status = _service.FindById(id);
            if (status == null) return NotFound();
            return Ok(status);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Status status)
        {
            _service.CreateStatus(status);
            return Ok(status);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Status status)
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
