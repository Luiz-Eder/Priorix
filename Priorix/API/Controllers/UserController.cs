using Microsoft.AspNetCore.Mvc;
using Priorix.Core.Entities;
using Priorix.Core.Interfaces.Services;

namespace Priorix.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetUsers() => Ok(_service.GetUsers());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _service.FindById(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpGet("email/{email}")]
        public IActionResult GetByEmail(string email)
        {
            var user = _service.GetUserByEmail(email);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Add([FromBody] User user)
        {
            _service.AddUser(user);
            return Ok(user);
        }

        [HttpPut]
        public IActionResult Update([FromBody] User user)
        {
            _service.UpdateUser(user);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteUser(id);
            return Ok();
        }

        [HttpGet("exists/{id}")]
        public IActionResult Exists(int id)
        {
            var exists = _service.UserExists(id);
            return Ok(exists);
        }
    }
}
