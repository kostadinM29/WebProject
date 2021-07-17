using MedEx.Services.Data.Appointments;
using MedEx.Services.Data.Doctors;
using MedEx.Web.ViewModels.AppointmentViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MedEx.Web.Areas.DoctorRole.Controllers
{
    public class DashboardController : DoctorRoleController
    {
        private readonly IDoctorService _doctorService;
        private readonly IAppointmentService _appointmentService;

        public DashboardController(IDoctorService doctorService, IAppointmentService appointmentService)
        {
            _doctorService = doctorService;
            _appointmentService = appointmentService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var doctorId = _doctorService.GetDoctorIdByUserId(userId);

            var viewModel = new AppointmentsListPatientViewModel
            {
                Appointments = await _appointmentService.GetUpcomingByPatientAsync<AppointmentViewPatientModel>(doctorId.Value),
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmAppointment(int appointmentId)
        {
            await _appointmentService.ConfirmAsync(appointmentId);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> DeclineAppointment(int appointmentId)
        {
            await _appointmentService.DeclineAsync(appointmentId);
            return RedirectToAction(nameof(Index));
        }
    }
}
