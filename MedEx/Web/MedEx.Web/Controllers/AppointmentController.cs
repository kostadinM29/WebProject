using MedEx.Services.Data.Appointments;
using MedEx.Services.Data.Patients;
using MedEx.Services.DateTimeParser;
using MedEx.Web.ViewModels.AppointmentViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using MedEx.Services.Data.Ratings;

namespace MedEx.Web.Controllers
{
    public class AppointmentController : BaseController
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IDateTimeParserService _dateTimeParserService;
        private readonly IPatientService _patientService;
        private readonly IRatingService _ratingService;

        public AppointmentController(IAppointmentService appointmentService, IDateTimeParserService dateTimeParserService, IPatientService patientService, IRatingService ratingService)
        {
            _appointmentService = appointmentService;
            _dateTimeParserService = dateTimeParserService;
            _patientService = patientService;
            _ratingService = ratingService;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var patientId = _patientService.GetPatientIdByUserId(userId);

            if (patientId == null)
            {
                return NotFound("patient id not found"); // ?? idk bout that
            }

            var viewModel = new AppointmentsListDoctorViewModel
            {
                PastAppointments = await _appointmentService.GetPastByPatientAsync<AppointmentViewDoctorModel>(patientId.Value),
                Appointments = await _appointmentService.GetUpcomingByPatientAsync<AppointmentViewDoctorModel>(patientId.Value),
            };
            return View(viewModel);
        }

        [Authorize]
        public IActionResult MakeAnAppointment(int doctorId)
        {
            var viewModel = new AppointmentMakeFormModel
            {
                DoctorId = doctorId
            };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> MakeAnAppointment(AppointmentMakeFormModel input)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("MakeAnAppointment", new { input.DoctorId });
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var patientId = _patientService.GetPatientIdByUserId(userId); // add error if user is not a patient
            if (patientId == null)
            {
                return NotFound();
            }

            DateTime dateTime;
            try
            {
                dateTime = _dateTimeParserService.ConvertStrings(input.Date, input.Time);
            }
            catch (Exception)
            {
                return RedirectToAction("MakeAnAppointment", new { input.DoctorId });
            }

            return await _appointmentService.AddAsync(input.DoctorId, patientId.Value, dateTime) == false ? RedirectToAction("MakeAnAppointment", new { input.DoctorId }) : RedirectToAction("Index");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            await _appointmentService.DeleteAsync(id);

            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CancelAppointment(int id)
        {
            var viewModel = await _appointmentService.GetByIdAsync<AppointmentViewDoctorModel>(id);

            if (viewModel == null)
            {
                return new StatusCodeResult(404);
            }

            return View(viewModel);
        }

        [Authorize]
        public IActionResult RateAppointment(int appointmentId)
        {
            var viewModel = new AppointmentRateFormModel
            {
                AppointmentId = appointmentId
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> RateAppointment(AppointmentRateFormModel input)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(RateAppointment), new { input.DoctorId });
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var patientId = _patientService.GetPatientIdByUserId(userId);
            if (patientId == null)
            {
                return NotFound();
            }

            var doctorId = _appointmentService.GetDoctorIdByAppointmentId(input.AppointmentId);
            if (doctorId == null)
            {
                return NotFound();
            }


            await _ratingService.AddAsync(input.AppointmentId, doctorId.Value, patientId.Value, input.Number, input.Comment);

            return RedirectToAction(nameof(Index));
        }
    }
}
