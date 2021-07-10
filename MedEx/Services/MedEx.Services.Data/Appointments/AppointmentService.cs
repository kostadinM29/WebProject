using MedEx.Data.Common.Repositories;
using MedEx.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MedEx.Services.Data.Appointments
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IDeletableEntityRepository<Appointment> _appointmentsRepository;

        public AppointmentService(IDeletableEntityRepository<Appointment> appointmentsRepository)
        {
            _appointmentsRepository = appointmentsRepository;
        }

        public async Task AddAsync(int doctorId, int patientId, DateTime date)
        {
            await _appointmentsRepository.AddAsync(new Appointment
            {
                DateTime = date,
                DoctorId = doctorId,
                PatientId = patientId
            });

            await _appointmentsRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int appointmentId)
        {
            var appointment =
                await _appointmentsRepository
                    .AllAsNoTracking()
                    .Where(x => x.Id == appointmentId)
                    .FirstOrDefaultAsync();
            _appointmentsRepository.Delete(appointment);
            await _appointmentsRepository.SaveChangesAsync();
        }

        public async Task ConfirmAsync(int appointmentId)
        {
            var appointment =
                await _appointmentsRepository
                    .All()
                    .Where(x => x.Id == appointmentId)
                    .FirstOrDefaultAsync();
            appointment.Confirmed = true;
            await _appointmentsRepository.SaveChangesAsync();
        }

        public async Task DeclineAsync(int appointmentId)
        {
            var appointment =
                await _appointmentsRepository
                    .All()
                    .Where(x => x.Id == appointmentId)
                    .FirstOrDefaultAsync();
            appointment.Confirmed = false;
            await _appointmentsRepository.SaveChangesAsync();
        }

        /*
         * getallappointmentsbypatientid
         *
         * getallappointmentsbydoctorid
         *
         * addappointment
         *
         * deleteappointment
         */
    }
}
