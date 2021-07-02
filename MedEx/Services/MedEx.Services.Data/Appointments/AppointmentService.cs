using MedEx.Data.Common.Repositories;
using MedEx.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedEx.Services.Data.Appointments
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IDeletableEntityRepository<Appointment> _appointmentsRepository;

        public AppointmentService(IDeletableEntityRepository<Appointment> appointmentsRepository)
        {
            _appointmentsRepository = appointmentsRepository;
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
