using System.Security.Claims;
using System.Threading.Tasks;
using MedEx.Services.Data.Appointments;
using MedEx.Services.Data.Patients;
using MedEx.Web.ViewModels.AppointmentViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MedEx.Web.Areas.DoctorRole.Controllers
{
    public class DashboardController : DoctorRoleController
    {
        private readonly IPatientService _patientService;
        private readonly IAppointmentService _appointmentService;

        public DashboardController(IPatientService patientService, IAppointmentService appointmentService)
        {
            _patientService = patientService;
            _appointmentService = appointmentService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var patientId = _patientService.GetPatientId(userId);

            if (patientId == null)
            {
                return NotFound();
            }

            var viewModel = new AppointmentsListPatientViewModel
            {
                Appointments =
                    await _appointmentService.GetUpcomingByUserAsync<AppointmentViewPatientModel>(patientId.Value),
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmAppointment(int appointmentId)
        {
            await _appointmentService.ConfirmAsync(appointmentId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeclineAppointment(int appointmentId)
        {
            await _appointmentService.DeclineAsync(appointmentId);
            return RedirectToAction("Index");
        }
    }
}
