using System;
using System.Collections.Generic;
using System.Text;
using UserFinder.Entities;

namespace UserFinder.Business.Abstract
{
    public interface IAppointmentService
    {
        List<AppointmentWithUser> GetAllAppointments();

        List<AppointmentWithUser> GetAppointmentsFromSelected(int receiverId);

        List<AppointmentWithUser> GetAppointmentsFromSelectedForUser(int senderId);

        Appointment GetAppointmentById(int id);

        Appointment GetAppointmentByDate(DateTime date, String time, int receiverId);
        
        bool CheckAppointmentLimitByDate(DateTime date, int id);

        Appointment CreateAppointment(Appointment a);

        Appointment UpdateAppointment(Appointment a);
        
        Appointment AcceptAppointment(Appointment a);
        
        Appointment RejectAppointment(Appointment a);

        Appointment DeleteAppointment(int id);

        List<Appointment> CancelAppointmentForTheDate(DateTime date, int receiverId);

        void SeenAllNotifications(int senderId);
    }
}
