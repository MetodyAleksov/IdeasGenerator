using IdeasGenerator.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace IdeasGenerator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("Public")]
        public IActionResult Public()
        {
            return Ok("You are on public propety");
        }

        [HttpGet("Admins")]
        [Authorize(Roles = "admin")]
        public IActionResult AdminsEndpoint()
        {
            var currUser = GetCurrentUser();

            return Ok($"Hi {currUser.Username}");
        }

        private User GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity; 

            if(identity != null)
            {
                var userClaims = identity.Claims;

                return new User
                {
                    Username = userClaims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier)?.Value,
                    Role = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value
                };
            }

            return null;
        }
    }
}
