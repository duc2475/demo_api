using demo_api_swagger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace demo_api_swagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecruimentController : ControllerBase
    {
        // GET: api/<RecruimentController>


        private readonly DemoContext _context;
        public RecruimentController(DemoContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("GetAllRecruiment")]
        public IActionResult GetAll()
        {
            try
            {
                if(_context.tblRecruiment == null)
                {
                    return Ok(new
                    {
                        result = "No Recruiment"
                    });
                }
                else
                {
                    return Ok(new { 
                        result = "success",
                        data = _context.tblRecruiment.ToArray()
                    });
                }
            }
            catch (Exception ex)
            {
                return NotFound(new
                {
                    result = ex.Message,
                });
            }
        }

        // GET api/<RecruimentController>/5
        [HttpGet("GetRecruiment/{id}")]

        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var recruiment = await _context.tblRecruiment.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
                if (recruiment != null)
                {
                    return Ok(new
                    {
                        result = "Success",
                        data = recruiment
                    });
                }
                else
                {
                    return NotFound(new
                    {
                        result = "Not Found"
                    });
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST api/<RecruimentController>
        [HttpPost]
        [Route("Create")]
        public IActionResult Post([FromBody] Recruitment recruitment)
        {
            try
            {
                _context.tblRecruiment.Add(recruitment);
                _context.SaveChanges();
                return Ok(new
                {
                    result = "success",
                    data = recruitment
                });
            }
            catch
            {
                return BadRequest();
            }

        }

        // PUT api/<RecruimentController>/5
        [HttpPut("Repair/{id}")]

        public IActionResult Put(int id, [FromBody] Recruitment recruitment)
        {
            try
            {
                var temp = _context.tblRecruiment.AsNoTracking().FirstOrDefault(m => m.Id == id);
                if (temp == null)
                {
                    return NotFound();
                }
                else
                {
                    temp.rName = recruitment.rName;
                    temp.rCat = recruitment.rCat;
                    temp.rLocation = recruitment.rLocation;
                    temp.rEndDate = recruitment.rEndDate;
                    _context.Update(temp);
                    _context.SaveChanges();
                    return Ok(new
                    {
                        result = "success",
                        data = recruitment
                    });
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE api/<RecruimentController>/5
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (_context.tblRecruiment.FirstOrDefault(m => m.Id == id) != null)
                {
                    _context.tblRecruiment.Remove(_context.tblRecruiment.FirstOrDefault(m => m.Id == id));
                    _context.SaveChanges();
                    return Ok(new
                    {
                        result = "success"
                    });
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
