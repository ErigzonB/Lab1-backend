using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemPerMenaxhiminESpitalit.Data;
using SistemPerMenaxhiminESpitalit.Models;
namespace SistemPerMenaxhiminESpitalit.Controllers
{
    [Route("api/countries")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        ApplicationDbContext _context;

        public CountryController(ApplicationDbContext context)
        {
            _context = context;

        }

        [HttpGet()]
        public List<Country> GetCountries()
        {
            
            var documentTypes = _context.countries.ToList();

            return documentTypes;
        }

        [HttpPost()]
        public async Task<IActionResult> CreateCountry([FromBody] CountryModel model)
        {
            try
            {
                Country country = new Country()
                {
                    CountryId = Guid.NewGuid().ToString(),
                    Name = model.Name,
                };
                var coun = await _context.countries.AddAsync(country);
                await _context.SaveChangesAsync();
                return Ok("success");
            } catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(string id)
        {
            try
            {
                var coun = await _context.countries.FindAsync(id);
                _context.countries.Remove(coun);
                await _context.SaveChangesAsync();
                return Ok("success");
            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                var coun = await _context.countries.FindAsync(id);
                return Ok(coun);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCountry(string id, [FromBody] CountryModel data)
        {
            try
            {
                var coun = await _context.countries.FindAsync(id);
                coun.Name = data.Name;
                _context.countries.Update(coun);
                await _context.SaveChangesAsync();  
                return (Ok("success")); 
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }
    }
}
