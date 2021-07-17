﻿using System.ComponentModel.DataAnnotations;

namespace MedEx.Web.ViewModels.AppointmentViewModels
{
    public class AppointmentRateFormModel
    {
        [Required]
        [Range(1, 10)]
        public int Number { get; set; }

        [MaxLength(50)]
        public string Comment { get; set; }

        public int AppointmentId { get; set; }

        public int DoctorId { get; set; }

        public int PatientId { get; set; }
    }
}