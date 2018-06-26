using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventureLearn.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdventureLearn.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        private readonly UserService _user;

        public UserController()
        {
            _user = new UserService();
        }

        [HttpGet("{email}")]
        public IActionResult Get(string email)
        {
            var user = _user.GetUser(email);
            if (user == null)
            {
                return NotFound();
            }

            return new ObjectResult(user);
        }
    }
}