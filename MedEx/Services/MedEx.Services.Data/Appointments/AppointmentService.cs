using MedEx.Data.Common.Repositories;
using MedEx.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using MedEx.Services.Mapping;

namespace MedEx.Services.Data.Appointments
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IDeletableEntityRepository<Appointment> _appointmentsRepository;
        private readonly IDeletableEntityRepository<Doctor> _doctorRepository;

        public AppointmentService(IDeletableEntityRepository<Appointment> appointmentsRepository, IDeletableEntityRepository<Doctor> doctorRepository)
        {
            _appointmentsRepository = appointmentsRepository;
            _doctorRepository = doctorRepository;
        }

        public async Task<bool> AddAsync(int doctorId, int patientId, DateTime date)
        {
            var doctorAppointment = _doctorRepository.AllAsNoTracking()
                .FirstOrDefault(d => d.Id == doctorId && d.Appointments.Any(a => a.DateTime == date));

            if (doctorAppointment != null)
            {
                return false;
            }

            await _appointmentsRepository.AddAsync(new Appointment
            {
                DateTime = date,
                DoctorId = doctorId,
                PatientId = patientId
            });

            await _appointmentsRepository.SaveChangesAsync();
            return true;
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

        public async Task<T> GetByIdAsync<T>(int id)
        {
            var appointment =
                await _appointmentsRepository
                    .All()
                    .Where(x => x.Id == id)
                    .To<T>().FirstOrDefaultAsync();
            return appointment;
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
