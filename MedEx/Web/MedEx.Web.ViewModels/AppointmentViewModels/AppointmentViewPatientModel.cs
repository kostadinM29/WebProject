using AutoMapper;
using MedEx.Data.Models;
using MedEx.Services.Mapping;
using System;
using MedEx.Common;

namespace MedEx.Web.ViewModels.AppointmentViewModels
{
    public class AppointmentViewPatientModel : IMapFrom<Appointment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string DateTime { get; set; }

        public int DoctorId { get; set; }

        public string PatientFullName { get; set; }

        public string PatientTownName { get; set; }

        public string PatientPhoneNumber { get; set; }

        public bool? Confirmed { get; set; }

        public int? Rating { get; set; }

        public string RatingComment { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Appointment, AppointmentViewPatientModel>()
                .ForMember(vm => vm.DateTime, opt =>
                      opt.MapFrom(a => a.DateTime.ToString(GlobalConstants.DateTimeFormats.DateTimeFormat)))
                .ForMember(vm => vm.PatientFullName, opt =>
                    opt.MapFrom(a => a.Patient.FirstName + " " + a.Patient.LastName))
                .ForMember(vm => vm.Rating, opt =>
                    opt.MapFrom(a => a.Rating.Number))
                .ForMember(vm => vm.RatingComment, opt =>
                    opt.MapFrom(a => a.Rating.Comment));
        }
    }
}
