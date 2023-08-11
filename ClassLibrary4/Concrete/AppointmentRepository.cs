using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserFinder.DataAccess.Abstract;
using UserFinder.Entities;

namespace UserFinder.DataAccess.Concrete
{
    public class AppointmentRepository : IAppointmentRepository
    {
        public Appointment CreateAppointment(Appointment a)
        {
            using (var UserDbCtx = new UserDbContext())
            {
            if (GetAppointmentByDate(a.Date, a.Title, a.ReceiverId) == null && GetAppointmentById(a.Id) == null)
                {
                UserDbCtx.Apppointments.Add(a);
                UserDbCtx.SaveChanges();

                return a;
                }
            else
            {
                    return null;
            }
            }
        }

        public Appointment DeleteAppointment(int id)
        {
            using (var UserDbCtx = new UserDbContext())
            {
                var AppointmenttoDelete = GetAppointmentById(id);
                if(AppointmenttoDelete != null)
                {
                    UserDbCtx.Apppointments.Remove(AppointmenttoDelete);
                    UserDbCtx.SaveChanges();
                }
                
                return AppointmenttoDelete;
            }
        }

        public Appointment AcceptAppointment(Appointment a)
        {
            using (var UserDbCtx = new UserDbContext())
            {
                var appointmentEntry = GetAppointmentById(a.Id);
                a.Status = "accepted";
                appointmentEntry.Status = "accepted";
                UserDbCtx.Apppointments.Update(appointmentEntry);
                UserDbCtx.SaveChanges();
                return a;
            }
        }

        public Appointment GetAppointmentById(int id)
        {
            using (var UserDbCtx = new UserDbContext())
            {
                return UserDbCtx.Apppointments.FirstOrDefault(e=>e.Id == id);
            }
        }

        public Appointment GetAppointmentByDate(DateTime date, String time, int receiverId)
        {
            using (var UserDbCtx = new UserDbContext())
            {
                return UserDbCtx.Apppointments.FirstOrDefault(e => e.Date == date && e.Title == time && e.ReceiverId == receiverId);
            }
        }

        public bool CheckAppointmentLimitByDate(DateTime date, int id)
        {
            using (var UserDbCtx = new UserDbContext())
            {
                return UserDbCtx.Apppointments.Any(e => e.Date.Date == date.Date && e.SenderId == id);
            }
        }

        public List<Appointment> GetAllAppointments()
        {
            using (var UserDbCtx = new UserDbContext())
            {
                return UserDbCtx.Apppointments.ToList();
            }
        }
        public List<Appointment> GetAppointmentsFromSelected(int receiverId)
        {
            using (var UserDbCtx = new UserDbContext())
            {
                return UserDbCtx.Apppointments.Where(e=>e.ReceiverId == receiverId).ToList();
            }
        }

        public Appointment UpdateAppointment(Appointment a)
        {
            using (var UserDbCtx = new UserDbContext())
            {
                a.Status = "pending";
                UserDbCtx.Apppointments.Update(a);
                UserDbCtx.SaveChanges();
                return a;
            }
        }

        public Appointment RejectAppointment(Appointment a)
        {
            using (var UserDbCtx = new UserDbContext())
            {
                var appointmentEntry = GetAppointmentById(a.Id);
                a.Status = "rejected";
                appointmentEntry.Status = "rejected";
                UserDbCtx.Apppointments.Update(appointmentEntry);
                UserDbCtx.SaveChanges();
                return a;
            }
        }
    }
}
