using MedEx.Common;
using MedEx.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedEx.Data.Seeding.CustomSeeders
{
    public class AppointmentsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Appointments.Any())
            {
                return;
            }

            var appointments = new List<Appointment>();

            // Get patient
            var patient = await dbContext.Patients.FirstOrDefaultAsync();

            // Get doctor
            var doctor = await dbContext.Doctors.FirstOrDefaultAsync();
            {
                // Add Upcoming Appointments
                appointments.Add(new Appointment
                {
                    DateTime = DateTime.UtcNow.AddDays(5),
                    Doctor = doctor,
                    Patient = patient,
                    IsRated = false,
                });

                // Add Past Appointments
                appointments.Add(new Appointment
                {
                    DateTime = DateTime.UtcNow.AddDays(-5),
                    Doctor = doctor,
                    Patient = patient,
                    IsRated = false,
                    Confirmed = true
                });

                // More Past Appointments for testing the RatePastAppointment option
                appointments.Add(new Appointment
                {
                    DateTime = DateTime.UtcNow.AddDays(-10),
                    Doctor = doctor,
                    Patient = patient,
                    IsRated = false,
                    Confirmed = true
                });

                await dbContext.AddRangeAsync(appointments);
            }
        }
    }
}
