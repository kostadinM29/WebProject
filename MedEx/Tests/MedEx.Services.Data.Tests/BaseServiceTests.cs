using MedEx.Data;
using MedEx.Data.Common.Repositories;
using MedEx.Data.Repositories;
using MedEx.Services.Data.Appointments;
using MedEx.Services.Data.Doctors;
using MedEx.Services.Data.Home;
using MedEx.Services.Data.Messages;
using MedEx.Services.Data.Patients;
using MedEx.Services.Data.Ratings;
using MedEx.Services.Data.Specializations;
using MedEx.Services.Data.Towns;
using MedEx.Services.Data.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MedEx.Services.Data.Tests
{
    public abstract class BaseServiceTests : IDisposable
    {
        protected BaseServiceTests()
        {
            var services = SetServices();

            ServiceProvider = services.BuildServiceProvider();
            DbContext = ServiceProvider.GetRequiredService<ApplicationDbContext>();
        }

        protected IServiceProvider ServiceProvider { get; set; }

        protected ApplicationDbContext DbContext { get; set; }

        public void Dispose()
        {
           DbContext.Database.EnsureDeleted();
           SetServices();
        }

        private static ServiceCollection SetServices()
        {
            var services = new ServiceCollection();

            services.AddDbContext<ApplicationDbContext>(
                options => options.UseInMemoryDatabase(Guid.NewGuid().ToString()));

            // Data repositories
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

            // Application services
            services.AddTransient<IHomeService, HomeService>();
            services.AddTransient<IDoctorService, DoctorService>();
            services.AddTransient<IAppointmentService, AppointmentService>();
            services.AddTransient<IPatientService, PatientService>();
            services.AddTransient<ISpecializationService, SpecializationService>();
            services.AddTransient<ITownService, TownService>();
            services.AddTransient<IRatingService, RatingService>();
            services.AddTransient<IMessageService, MessageService>();
            services.AddTransient<IUserService, UserService>();

            return services;
        }
    }
}
