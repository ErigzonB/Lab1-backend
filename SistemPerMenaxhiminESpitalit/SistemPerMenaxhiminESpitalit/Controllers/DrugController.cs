using Microsoft.AspNetCore.Mvc;
using SistemPerMenaxhiminESpitalit.Data;
using SistemPerMenaxhiminESpitalit.Models;
namespace SistemPerMenaxhiminESpitalit.Controllers
{
    [ApiController]
    [Route("api/drugs")]
    public class DrugController : ControllerBase
    {
        ApplicationDbContext _context;
        public DrugController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet()]
        public List<Drug> GetDrugs()
        {
            var documentTypes = _context.drugs.ToList();

            return documentTypes;
        }

        [HttpPost()]
        public async Task<IActionResult> CreateDrug([FromBody] DrugModel model)
        {
            try
            {
                Drug drug = new Drug()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = model.Name,
                    Date = model.Date,
                };
                var c = await _context.drugs.AddAsync(drug);
                await _context.SaveChangesAsync();
                return Ok("success");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteDrug(string id)
        {
            try
            {
                var d = await _context.drugs.FindAsync(id);
                _context.drugs.Remove(d);
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
                var d = await _context.drugs.FindAsync(id);
                return Ok(d);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateDrug(string id, [FromBody] DrugModel data)
        {
            try
            {
                var d = await _context.drugs.FindAsync(id);
                d.Name = data.Name;
                d.Date = data.Date;
                _context.drugs.Update(d);
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
