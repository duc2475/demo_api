using demo_api_swagger.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace demo_api_swagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly DemoContext _context;
        public ContactController(DemoContext context)
        {
            _context = context;
        }
        // GET: api/<ContactController>
        [HttpGet]
        [Route("GetAllContact")]
        public IActionResult GetAll()
        {
            if(_context.tblContact != null)
            {
                var contacts = _context.tblContact.ToList();
                return Ok(new
                {
                    result = "true",
                    data = contacts
                });
            }
            else
            {
                return NotFound();
            }
        }

        // GET api/<ContactController>/5
        [HttpGet("GetContact/{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ContactController>
        [HttpPost]
        [Route("CrateContact")]
        public IActionResult Post([FromBody] Contact contact)
        {
            try
            {
                _context.tblContact.Add(contact);
                _context.SaveChanges();
                return Ok(new
                {
                    result = "success",
                    data = contact
                });
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ContactController>/5
       /* [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
