using Dtos;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace WineAppliaction_Git.Controllers.User
{
    [ApiController]
    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly IUserServices _service;
        public UserController(IUserServices service)
        {
            _service = service;
        }
        [HttpPost]
        public IActionResult CreateUser(UserGlobalDTO AuserDto)

        {
            _service.CreateUser(AuserDto);
            return Ok("user registrado correctamente.");
        }
        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_service.GetUsers());
        }
    }
}

