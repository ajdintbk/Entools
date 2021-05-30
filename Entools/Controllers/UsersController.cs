using Entools.Model;
using Entools.Model.Requests.Users;
using Entools.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entools.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUsers _service;
        public UsersController(IUsers service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult<Users> AddUser(AddUserRequest req)
        {
            var user = _service.AddUser(req);
            if (user != null)
            {
                return user;
            }
            else
            {
                return BadRequest("Username already exists.");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Users> GetById(int id)
        {
            var user = _service.GetById(id);
            if (user != null)
            {
                return user;
            }
            else
            {
                return BadRequest("User not found");
            }
        }

        [HttpGet]
        public ActionResult<List<Users>> Get([FromQuery] UserSearchRequest req)
        {
            var user = _service.Get(req);
            if (user != null)
            {
                return user;
            }
            else
            {
                return BadRequest("Something went wrong.");
            }
        }
        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login([FromBody] UserLoginRequest request)
        {
            var user = _service.Authenticate(request);

            if (user == null)
                return BadRequest(new { message = "Email ili lozinka nisu ispravni!" });

            return Ok(user.Username);
        }
    }
}
