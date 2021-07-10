using MedEx.Services.Data.Appointments;
using MedEx.Services.Data.Patients;
using MedEx.Services.DateTimeParser;
using MedEx.Web.ViewModels.AppointmentViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MedEx.Web.Controllers
{
    public class AppointmentController : BaseController
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IDateTimeParserService _dateTimeParserService;
        private readonly IPatientService _patientService;

        public AppointmentController(IAppointmentService appointmentService, IDateTimeParserService dateTimeParserService, IPatientService patientService)
        {
            _appointmentService = appointmentService;
            _dateTimeParserService = dateTimeParserService;
            _patientService = patientService;
        }

        public IActionResult Index()
        {
            //var user = await this.userManager.GetUserAsync(this.HttpContext.User);
            //var userId = await this.userManager.GetUserIdAsync(user);

            //var viewModel = new AppointmentsListViewModel
            //{
            //    Appointments =
            //        await this.appointmentsService.GetUpcomingByUserAsync<AppointmentViewModel>(userId),
            //};
            //return this.View(viewModel);
            return View();
        }

        public IActionResult MakeAnAppointment(int doctorId)
        {
            var viewModel = new AppointmentInputModel
            {
               DoctorId = doctorId
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> MakeAnAppointment(AppointmentInputModel input)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("MakeAnAppointment", new { input.DoctorId });
            }

            DateTime dateTime;
            try
            {
                dateTime = _dateTimeParserService.ConvertStrings(input.Date, input.Time);
            }
            catch (System.Exception)
            {
                return RedirectToAction("MakeAnAppointment", new { input.DoctorId });
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var patientId = _patientService.GetPatientId(userId); // add error if user is not a patient

            await _appointmentService.AddAsync(input.DoctorId, patientId, dateTime);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            await _appointmentService.DeleteAsync(id);

            return RedirectToAction("Index");
        }

        public IActionResult CancelAppointment(int id)
        {
            var viewModel = _appointmentService.GetByIdAsync<AppointmentViewModel>(id);

            if (viewModel == null)
            {
                return new StatusCodeResult(404);
            }

            return View(viewModel);
        }
    }
}
