using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SistemPerMenaxhiminESpitalit.Auth;
using SistemPerMenaxhiminESpitalit.Models;

namespace SistemPerMenaxhiminESpitalit.Controllers
{
    [ApiController]
    [Route("api/patient")]
    public class PatientController : ControllerBase
    {
        private readonly ILogger<PatientController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        ApplicationDbContext _context;

        public PatientController(ILogger<PatientController> logger, UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _logger = logger;
            _userManager = userManager;
            _context = context;

        }
        [HttpGet("get-patients")]
        public async Task<IActionResult> GetPatients()
        {
            string roleName = "patient";
            return Ok(await _userManager.GetUsersInRoleAsync(roleName));
        }

        [HttpDelete("delete-patient/{id}")]
        public async Task<IActionResult> DeletePatients(string id)
        {
            try
            {
                ApplicationUser user = await _userManager.FindByIdAsync(id);
                string roleName = "patient";
                return Ok(await _userManager.DeleteAsync(user));
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
                var user = await _context.Users.FindAsync(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut(template: "{id}")]
        public async Task<IActionResult> UpdatePatients(string id, [FromBody] UpdatePatientModel model)
        {

            try
            {
                var user = await _context.Users.FindAsync(id);
                user.Name = model.Name;
                user.Surename = model.Surname;
                user.Address = model.Address;
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
