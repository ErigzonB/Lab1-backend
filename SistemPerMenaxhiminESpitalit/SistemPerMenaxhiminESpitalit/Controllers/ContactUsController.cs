using Microsoft.AspNetCore.Mvc;
using SistemPerMenaxhiminESpitalit.Data;
using SistemPerMenaxhiminESpitalit.Models;

namespace SistemPerMenaxhiminESpitalit.Controllers
{
    [Route("api/contacts")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
        ApplicationDbContext _context;

        public ContactUsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet()]
        public List<ContactUs> getMessage()
        {
            var documentTypes = _context.contactus.ToList();

            return documentTypes;
        }
        [HttpPost()]
        public async Task<IActionResult> createContact( [FromBody] ContactUsModel model )
        {
            try
            {
                ContactUs contactUs = new ContactUs()
                {
                    id = Guid.NewGuid().ToString(),
                    name = model.name,
                    email = model.email,
                    message = model.message,
                };
                var con = await _context.contactus.AddAsync(contactUs);
                _context.SaveChanges();
                return Ok("Success");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteContact(string id)
        {
            try
            {
                var con = await _context.contactus.FindAsync(id);
                _context.contactus.Remove(con);
                _context.SaveChanges();
                return Ok("Success");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        } 

    }
}
