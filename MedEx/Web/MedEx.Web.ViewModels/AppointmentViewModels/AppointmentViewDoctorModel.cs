using AutoMapper;
using MedEx.Common;
using MedEx.Data.Models;
using MedEx.Services.Mapping;

namespace MedEx.Web.ViewModels.AppointmentViewModels
{
    public class AppointmentViewDoctorModel : IMapFrom<Appointment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string DateTime { get; set; }

        public int DoctorId { get; set; }

        public string DoctorFullName { get; set; }

        public string DoctorTownName { get; set; }

        public string DoctorAddress { get; set; }

        public bool? Confirmed { get; set; }

        public bool IsRated { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Appointment, AppointmentViewDoctorModel>()
                .ForMember(vm => vm.DateTime, opt =>
                    opt.MapFrom(a => a.DateTime.ToString(GlobalConstants.DateTimeFormats.DateTimeFormat)))
                .ForMember(vm => vm.DoctorFullName, opt =>
                    opt.MapFrom(a => a.Doctor.FirstName + " " + a.Doctor.LastName));
        }
    }
}
