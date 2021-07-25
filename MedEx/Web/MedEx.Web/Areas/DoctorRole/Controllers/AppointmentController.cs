using MedEx.Services.Data.Appointments;
using MedEx.Services.Data.Doctors;
using MedEx.Web.ViewModels.AppointmentViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using MedEx.Services.Data.Patients;

namespace MedEx.Web.Areas.DoctorRole.Controllers
{
    public class AppointmentController : DoctorRoleController
    {
        private readonly IPatientService _patientService;
        private readonly IAppointmentService _appointmentService;
        private readonly IDoctorService _doctorService;

        public AppointmentController(IPatientService patientService, IAppointmentService appointmentService, IDoctorService doctorService)
        {
            _patientService = patientService;
            _appointmentService = appointmentService;
            _doctorService = doctorService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var doctorId = _doctorService.GetDoctorIdByUserId(userId);

            var viewModel = new AppointmentsListPatientViewModel
            {
                Appointments = await _appointmentService.GetUpcomingByPatientAsync<AppointmentViewPatientModel>(doctorId.Value),
                PastAppointments = await _appointmentService.GetPastByPatientAsync<AppointmentViewPatientModel>(doctorId.Value)
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
