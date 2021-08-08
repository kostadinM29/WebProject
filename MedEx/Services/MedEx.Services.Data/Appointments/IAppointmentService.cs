using MedEx.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedEx.Services.Data.Appointments
{
    public interface IAppointmentService
    {
        int? GetDoctorIdByAppointmentId(int appointmentId);

        Task<IEnumerable<T>> GetPastByPatientAsync<T>(int patientId);

        Task<IEnumerable<T>> GetUpcomingByPatientAsync<T>(int patientId);

        Task<bool> AddAsync(int doctorId, int patientId, DateTime date);

        Task DeleteAsync(int appointmentId);

        Task ConfirmAsync(int appointmentId);

        Task DeclineAsync(int appointmentId);

        Task<Appointment> GetByUserIdAsync(string userId, int appointmentId);

        Task<T> GetByIdAsync<T>(int id);
    }
}
