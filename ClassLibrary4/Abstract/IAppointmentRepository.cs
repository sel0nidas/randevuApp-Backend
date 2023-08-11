using System;
using System.Collections.Generic;
using System.Text;
using UserFinder.Entities;

namespace UserFinder.DataAccess.Abstract
{
    interface IAppointmentRepository
    {
        List<Appointment> GetAllAppointments();

        List<Appointment> GetAppointmentsFromSelected(int receiverId);

        Appointment GetAppointmentById(int id);

        Appointment GetAppointmentByDate(DateTime date, String time, int receiverId);

        bool CheckAppointmentLimitByDate(DateTime date, int id);

        Appointment CreateAppointment(Appointment a);

        Appointment UpdateAppointment(Appointment a);
        
        Appointment AcceptAppointment(Appointment a);

        Appointment RejectAppointment(Appointment a);


        Appointment DeleteAppointment(int id);
    }
}
