using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Group_3_Week_11_DB_API.Controllers
{
   

    [Route("api/[controller]")]
    [ApiController]
    public class Login : ControllerBase
    {
        private readonly JwtAuthenticationManager jwtAuthenticationManager;

        public Login(JwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult AuthUser([FromBody] User usr)
        {
            var token = jwtAuthenticationManager.Authenticate(usr.Username, usr.Password);
            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }


        

    }

    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
