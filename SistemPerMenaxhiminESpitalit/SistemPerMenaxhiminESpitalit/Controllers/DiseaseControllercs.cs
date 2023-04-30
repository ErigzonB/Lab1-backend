using Microsoft.AspNetCore.Mvc;
using SistemPerMenaxhiminESpitalit.Data;
using SistemPerMenaxhiminESpitalit.Models;
namespace SistemPerMenaxhiminESpitalit.Controllers
{
    [ApiController]
    [Route("api/diseases")]
    public class DiseaseController : ControllerBase
    {
        ApplicationDbContext _context;
        public DiseaseController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet()]
        public List<Disease> GetDiseases()
        {
            var documentTypes = _context.diseases.ToList();

            return documentTypes;
        }

        [HttpPost()]
        public async Task<IActionResult> CreateDisease([FromBody] DiseaseModelcs model)
        {
            try
            {
                Disease disease = new Disease()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = model.Name
                };
                var c = await _context.diseases.AddAsync(disease);
                await _context.SaveChangesAsync();
                return Ok("success");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteDisease(string id)
        {
            try
            {
                var d = await _context.diseases.FindAsync(id);
                _context.diseases.Remove(d);
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
                var d = await _context.diseases.FindAsync(id);
                return Ok(d);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateDisease(string id, [FromBody] DiseaseModelcs data)
        {
            try
            {
                var d = await _context.diseases.FindAsync(id);
                d.Name = data.Name;
                _context.diseases.Update(d);
                await _context.SaveChangesAsync();
                return (Ok("success"));

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}