using MedEx.Data.Models;
using MedEx.Services.Data.Appointments;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MedEx.Services.Data.Tests
{
    public class AppointmentServiceTests : BaseServiceTests
    {
        private Random Random => new Random();

        private IAppointmentService Service => ServiceProvider.GetRequiredService<IAppointmentService>();

        /*
            int? GetDoctorIdByAppointmentId(int appointmentId);
           
           Task<IEnumerable<T>> GetPastByPatientAsync<T>(int patientId);
           
           Task<IEnumerable<T>> GetUpcomingByPatientAsync<T>(int patientId);
           
           Task<Appointment> GetByUserIdAsync(string userId, int appointmentId);
           
           Task<T> GetByIdAsync<T>(int id);
         */

        [Fact]
        public async Task AddAsyncShouldAddCorrectly()
        {
            await CreateAppointmentAsync();

            var dateTime = DateTime.UtcNow.AddDays(5);
            var patientId = Random.Next(50);
            var doctorId = Random.Next(50);

            await Service.AddAsync(doctorId, patientId, dateTime);

            var appointmentCount = await DbContext.Appointments.CountAsync();
            Assert.Equal(2, appointmentCount);
        }

        [Fact]
        public async Task DeleteAsyncShouldDeleteCorrectly()
        {
            var appointment = await CreateAppointmentAsync();

            await Service.DeleteAsync(appointment.Id);

            var appointmentsCount = DbContext.Appointments.Where(x => !x.IsDeleted).ToArray().Count();
            var deletedAppointment = await DbContext.Appointments.FirstOrDefaultAsync(x => x.Id == appointment.Id);
            Assert.Equal(0, appointmentsCount);
            Assert.Null(deletedAppointment);
        }

        [Fact]
        public async Task ConfirmAsyncShouldConfirmCorrectly()
        {
            var appointment = await CreateAppointmentAsync();

            await Service.ConfirmAsync(appointment.Id);

            var result = await DbContext.Appointments.Where(x => x.Id == appointment.Id).Select(x => x.Confirmed).FirstOrDefaultAsync();

            Assert.True(result);
        }

        [Fact]
        public async Task DeclineAsyncShouldDeclineCorrectly()
        {
            var appointment = await CreateAppointmentAsync();

            await Service.DeclineAsync(appointment.Id);

            var result = await DbContext.Appointments.Where(x => x.Id == appointment.Id).Select(x => x.Confirmed).FirstOrDefaultAsync();

            Assert.True(!result);
        }

        //[Fact]
        //public async Task GetPastByPatientAsyncShouldReturnCorrectAppointments()
        //{
        //    var patientId = 2;
        //    await Service.AddAsync(1, patientId, DateTime.UtcNow.AddDays(-5));
        //    await Service.AddAsync(1, patientId, DateTime.UtcNow.AddDays(-3));

        //    var appointments = await Service.GetPastByPatientAsync<AppointmentViewPatientModel>(patientId);
        //    var result = appointments.Count();

        //    Assert.Equal(2, result);
        //}

        private async Task<Appointment> CreateAppointmentAsync()
        {
            var appointment = new Appointment
            {
                Id = Random.Next(50),
                DateTime = DateTime.UtcNow.AddDays(5),
                DoctorId = Random.Next(50),
                PatientId = Random.Next(50),
                IsRated = false,
            };

            await DbContext.Appointments.AddAsync(appointment);
            await DbContext.SaveChangesAsync();
            DbContext.Entry(appointment).State = EntityState.Detached;
            return appointment;
        }
    }
}
