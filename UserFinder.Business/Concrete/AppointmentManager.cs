using System;
using System.Collections.Generic;
using System.Text;
using UserFinder.Business.Abstract;
using UserFinder.DataAccess.Concrete;
using UserFinder.Entities;

namespace UserFinder.Business.Concrete
{
    public class AppointmentManager : IAppointmentService
    {

        private AppointmentRepository _appointmentRepository;


        public AppointmentManager()
        {
            _appointmentRepository = new AppointmentRepository();
        }

        public Appointment AcceptAppointment(Appointment a)
        {
            return _appointmentRepository.AcceptAppointment(a);
        }

        public Appointment CreateAppointment(Appointment a)
        {
            return _appointmentRepository.CreateAppointment(a);
        }

        public Appointment DeleteAppointment(int id)
        {
            return _appointmentRepository.DeleteAppointment(id);
        }

        public List<AppointmentWithUser> GetAllAppointments()
        {
            return _appointmentRepository.GetAllAppointments();
        }
        public List<AppointmentWithUser> GetAppointmentsFromSelected(int receiverId)
        {
            return _appointmentRepository.GetAppointmentsFromSelected(receiverId);
        }

        public List<AppointmentWithUser> GetAppointmentsFromSelectedForUser(int receiverId)
        {
            return _appointmentRepository.GetAppointmentsFromSelectedForUser(receiverId);
        }

        public Appointment GetAppointmentById(int id)
        {
            return _appointmentRepository.GetAppointmentById(id);
        }
        
        public Appointment GetAppointmentByDate(DateTime date, String time, int receiverId)
        {
            return _appointmentRepository.GetAppointmentByDate(date, time, receiverId);
        }
        public bool CheckAppointmentLimitByDate(DateTime date, int id)
        {
            return _appointmentRepository.CheckAppointmentLimitByDate(date, id);
        }

        public Appointment RejectAppointment(Appointment a)
        {
            return _appointmentRepository.RejectAppointment(a);
        }

        public Appointment UpdateAppointment(Appointment a)
        {
            return _appointmentRepository.UpdateAppointment(a);
        }

        public List<Appointment> CancelAppointmentForTheDate(DateTime date, int receiverId)
        {
            return _appointmentRepository.CancelAppointmentForTheDate(date, receiverId);
        }

        public void SeenAllNotifications(int senderId)
        {
            _appointmentRepository.SeenAllNotifications(senderId);
        }


    }
}
