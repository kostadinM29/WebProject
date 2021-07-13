using AutoMapper;
using MedEx.Data.Models;
using MedEx.Services.Mapping;
using System;

namespace MedEx.Web.ViewModels.AppointmentViewModels
{
    public class AppointmentViewPatientModel : IMapFrom<Appointment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public int DoctorId { get; set; }

        public string PatientFullName { get; set; }

        public string PatientTownName { get; set; }

        public string PatientPhoneNumber { get; set; }

        public bool? Confirmed { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Appointment, AppointmentViewPatientModel>()
                .ForMember(vm => vm.PatientFullName, opt =>
                    opt.MapFrom(a => a.Doctor.FirstName + " " + a.Doctor.LastName));
        }
    }
}
