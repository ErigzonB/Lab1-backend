using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemPerMenaxhiminESpitalit.Data;
using SistemPerMenaxhiminESpitalit.Models;

namespace SistemPerMenaxhiminESpitalit.Controllers
{
    [Route("api/specialisations")]
    [ApiController]
    public class SpecialisationController : ControllerBase
    {

        ApplicationDbContext _context;

        public SpecialisationController(ApplicationDbContext context)
        {
            _context = context;
        
        }

        [HttpGet()]
        public List<Specialisation> GetAllSpecialisations()
        {
            var documentTypes = _context.specialisations.ToList();

            return documentTypes;
        }
     
        [HttpPost()]
        public async  Task<IActionResult> CreateSpecialisations([FromBody] SpecialisationModel data)
        {
            Specialisation specialisation = new()
            {
                SpecialisationId = Guid.NewGuid().ToString(),
                Name = data.Name
            };

            var spec = await _context.specialisations.AddAsync(specialisation);
            await _context.SaveChangesAsync();
            return Ok("success");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpecialisations(string id)
        {
           try
            {
                var spec = await _context.specialisations.FindAsync(id);
                _context.specialisations.Remove(spec);
                await _context.SaveChangesAsync();
                return Ok("success");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
           try
            {
                var spec = await _context.specialisations.FindAsync(id);
                return Ok(spec);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSpecialisations(string id, [FromBody] SpecialisationModel data)
        {
           try
            {
                var spec = await _context.specialisations.FindAsync(id);
                spec.Name = data.Name;
                _context.specialisations.Update(spec);
                await _context.SaveChangesAsync();
                return Ok("success");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
