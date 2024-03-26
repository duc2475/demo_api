using demo_api_swagger.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace demo_api_swagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly DemoContext _context;
        public LoginController(DemoContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Login login)
        {
            var user = _context.tblUser.FirstOrDefault(m => m.UserEmail == login.UserEmail);
            if (user != null && login.UserPassword == user.UserPassword) 
            {
                return Ok(new
                {
                    Result = "true",
                    Data = login,
                    IsAdmin = true
                });
            }
            return BadRequest(new
            {
                message ="flase"
            });
            
        }
    }
}
