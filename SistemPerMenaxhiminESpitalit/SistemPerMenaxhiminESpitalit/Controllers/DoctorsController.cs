using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SistemPerMenaxhiminESpitalit.Auth;
using SistemPerMenaxhiminESpitalit.Models;

namespace SistemPerMenaxhiminESpitalit.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    public class DoctorsController : ControllerBase
    {
        private readonly ILogger<DoctorsController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        ApplicationDbContext _context;

        public DoctorsController(ILogger<DoctorsController> logger, UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _logger = logger;
            _userManager = userManager;
            _context = context;
        }

        [HttpGet("get-doctors")]
        public async Task<IActionResult> GetDoctors()
        {
            string roleName = "doctor";
            return Ok(await _userManager.GetUsersInRoleAsync(roleName));
        }
        [HttpDelete("delete-doctor/{id}")]
        public async Task<IActionResult> DeleteDoctors(string id)
        {
            try {
                ApplicationUser user = await _userManager.FindByIdAsync(id);
                string roleName = "doctor";
                return Ok(await _userManager.DeleteAsync(user));
            } catch (Exception ex)
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
        public async Task<IActionResult> UpdateDoctors(string id, [FromBody] UpdateDoctorModel model)
        {

            try
            {
                var spec = await _context.specialisations.FindAsync(model.Specialisationid);
                

                var user = await _context.Users.FindAsync(id);
                user.Name = model.Name;
                user.Surename = model.Surname;
                user.Address = model.Address;
                user.SpecialisationId = spec.SpecialisationId;
                user.Specialisation = spec;
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