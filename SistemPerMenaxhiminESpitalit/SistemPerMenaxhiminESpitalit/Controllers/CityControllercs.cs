using Microsoft.AspNetCore.Mvc;
using SistemPerMenaxhiminESpitalit.Data;
using SistemPerMenaxhiminESpitalit.Models;
namespace SistemPerMenaxhiminESpitalit.Controllers
{
    [Route("api/cities")]
    [ApiController]
    public class CityControllercs : ControllerBase
    {
        ApplicationDbContext _context;

        public CityControllercs(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet()]
        public List<City> GetCities()
        {
            var documentTypes = _context.cities.ToList();

            return documentTypes;
        }

        [HttpPost()]
        public async Task<IActionResult> CreateCity([FromBody] CityModel model)
        {
            try
            {
                City city = new City()
                {
                    CityId = Guid.NewGuid().ToString(),
                    Name = model.Name,
                };
                var c = await _context.cities.AddAsync(city);
                await _context.SaveChangesAsync();
                return Ok("success");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteCity(string id)
        {
            try
            {
                var c = await _context.cities.FindAsync(id);
                _context.cities.Remove(c);
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
                var c = await _context.cities.FindAsync(id);
                return Ok(c);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateCity(string id, [FromBody] CityModel data)
        {
            try
            {
                var c = await _context.cities.FindAsync(id);
                c.Name = data.Name;
                _context.cities.Update(c);
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
