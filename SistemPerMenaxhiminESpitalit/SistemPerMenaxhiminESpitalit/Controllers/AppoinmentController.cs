using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SistemPerMenaxhiminESpitalit.Data;
using SistemPerMenaxhiminESpitalit.Auth;
using SistemPerMenaxhiminESpitalit.Models;
namespace SistemPerMenaxhiminESpitalit.Controllers
{
    [ApiController]
    [Route("api/appointment")]
    public class AppoinmentController : ControllerBase
    {
        ApplicationDbContext _context;
        public AppoinmentController( ApplicationDbContext context) { 

            _context = context;
        }
        [HttpPost]
        [Route("create-appointment")]
       

        [HttpGet]
        public List<Appointment> getAppointment()
        {
            var documentTypes = _context.appointment.ToList();

            return documentTypes;
        }


    }
}
