using AutoMapper;
using MedEx.Data.Models;
using MedEx.Services.Mapping;
using System;

namespace MedEx.Web.ViewModels.AppointmentViewModels
{
    public class AppointmentViewModel : IMapFrom<Appointment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public int DoctorId { get; set; }

        public string DoctorFullName { get; set; }

        public string DoctorTownName { get; set; }

        public string DoctorAddress { get; set; }

        public bool? Confirmed { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Appointment, AppointmentViewModel>()
                .ForMember(vm => vm.DoctorFullName, opt =>
                    opt.MapFrom(a => a.Doctor.FirstName + " " + a.Doctor.LastName));
        }
    }
}
