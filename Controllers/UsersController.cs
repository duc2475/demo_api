using demo_api_swagger.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace demo_api_swagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly DemoContext _context;

        public static List<User> Users = new List<User>();

        public UsersController(DemoContext context)
        {
            _context = context;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            Users = await _context.tblUser.ToListAsync();
            return Ok(Users);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = Users.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return BadRequest();
            }
        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromBody] List<User> users)
        {
            foreach (var item in users)
            {
                Users.Add(item);
            }
            return Ok(new { Success = true, Data = Users });
        }
        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }

    }
}
