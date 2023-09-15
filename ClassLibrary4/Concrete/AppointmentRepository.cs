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
                    var appointment = GetAppointmentByDate(a.Date, a.Title, a.ReceiverId);

                    appointment.Status = "pending";
                    appointment.SenderId = a.SenderId;
                    appointment.Description = a.Description;
                    appointment.DescriptionFromDoctor = "";
                    UserDbCtx.Apppointments.Update(appointment);
                    UserDbCtx.SaveChanges();

                    return appointment;
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
                appointmentEntry.DescriptionFromDoctor = a.DescriptionFromDoctor;
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

        //public List<AppointmentWithUser> GetAllAppointments()
        //{
        //    using (var UserDbCtx = new UserDbContext())
        //    {
        //        var appointmentsWithUsers = UserDbCtx.Apppointments
        //    .Where(appointment => appointment.Id != null) // Filter out appointments with no receiver
        //    .Select(appointment => new
        //    {
        //        Appointment = appointment,
        //        ReceiverUser = UserDbCtx.Users.FirstOrDefault(user => user.Id == appointment.ReceiverId)
        //    })
        //    .ToList();

        //        return appointmentsWithUsers;
        //    }
        //}

        public List<AppointmentWithUser> GetAllAppointments()
        {
            using (var UserDbCtx = new UserDbContext())
            {
                var appointmentsWithUsers = UserDbCtx.Apppointments
                    .Where(appointment => appointment.ReceiverId != null)
                    .Select(appointment => new AppointmentWithUser
                    {
                        AppointmentId = appointment.Id,
                        Title = appointment.Title,
                        Name = UserDbCtx.Users.FirstOrDefault(user => user.Id == appointment.ReceiverId).Name,
                        ReceiverUser = UserDbCtx.Doctors.FirstOrDefault(user => user.Id == appointment.ReceiverId),
                        Description = appointment.Description,
                        DescriptionFromDoctor = appointment.DescriptionFromDoctor,
                        EventType = appointment.EventType,
                        Status = appointment.Status, // Set the default status,
                        SenderId = appointment.SenderId,
                        Date = appointment.Date
                    })
                    .ToList();

                return appointmentsWithUsers;
            }
        }
        public List<AppointmentWithUser> GetAppointmentsFromSelected(int receiverId)
        {
                using (var UserDbCtx = new UserDbContext())
                {
                    var appointmentsWithUsers = UserDbCtx.Apppointments
                        .Where(appointment => appointment.ReceiverId == receiverId)
                        .Select(appointment => new AppointmentWithUser
                        {
                            AppointmentId = appointment.Id,
                            Title = appointment.Title,
                            Name = UserDbCtx.Users.FirstOrDefault(user => user.Id == appointment.ReceiverId).Name,
                            ReceiverUser = UserDbCtx.Doctors.FirstOrDefault(user => user.Id == appointment.ReceiverId),
                            Description = appointment.Description,
                            DescriptionFromDoctor = appointment.DescriptionFromDoctor,
                            EventType = appointment.EventType,
                            Status = appointment.Status, // Set the default status,
                            ReceiverId = receiverId,
                            SenderId = appointment.SenderId,
                            Date = appointment.Date,
                            IsSeen = appointment.IsSeen,
                            OperationTime = appointment.OperationTime
                        })
                        .ToList();

                    return appointmentsWithUsers;
                }
        }

        public List<AppointmentWithUser> GetAppointmentsFromSelectedForUser(int senderId)
        {
            using (var UserDbCtx = new UserDbContext())
            {
                var appointmentsWithUsers = UserDbCtx.Apppointments
                        .Where(appointment => appointment.SenderId == senderId)
                        .Select(appointment => new AppointmentWithUser
                        {
                            AppointmentId = appointment.Id,
                            Title = appointment.Title,
                            Name = UserDbCtx.Users.FirstOrDefault(user => user.Id == appointment.ReceiverId).Name,
                            ReceiverUser = UserDbCtx.Doctors.FirstOrDefault(doctor => doctor.UserId == appointment.ReceiverId),
                            Description = appointment.Description,
                            DescriptionFromDoctor = appointment.DescriptionFromDoctor,
                            EventType = appointment.EventType,
                            Status = appointment.Status, // Set the default status,
                            ReceiverId = appointment.ReceiverId,
                            SenderId = appointment.SenderId,
                            Date = appointment.Date
                        })
                        .ToList();

                return appointmentsWithUsers;
            }
        }

        public Appointment UpdateAppointment(Appointment a)
        {
            using (var UserDbCtx = new UserDbContext())
            {
                a.Status = "pending";
                a.IsSeen = false;
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
                appointmentEntry.DescriptionFromDoctor = a.DescriptionFromDoctor;
                UserDbCtx.Apppointments.Update(appointmentEntry);
                UserDbCtx.SaveChanges();
                return a;
            }
        }
        public List<Appointment> CancelAppointmentForTheDateOld(DateTime date, int receiverId)
        {
            using (var UserDbCtx = new UserDbContext())
            {

                List<Appointment> appointmentEntryList = UserDbCtx.Apppointments.Where(e => e.Date.Date == date.Date && e.Date.TimeOfDay == date.TimeOfDay && e.ReceiverId == receiverId).ToList();
                


                //appointmentEntry.Status = "deleted";
                //appointmentEntry.DescriptionFromDoctor = a.DescriptionFromDoctor;
                //UserDbCtx.Apppointments.Update(appointmentEntry);
                //UserDbCtx.SaveChanges();
                return appointmentEntryList;
            }
        }

        public void SeenAllNotifications(int senderId)
        {

            using (var UserDbCtx = new UserDbContext())
            {
                var appointmentsToUpdate = UserDbCtx.Apppointments.Where(u => u.IsSeen == false && u.SenderId == senderId);
                foreach (var appointment in appointmentsToUpdate)
                {
                    appointment.IsSeen = true;
                }
                UserDbCtx.SaveChanges();
            }
        }

        public List<Appointment> CancelAppointmentForTheDate(DateTime date, int receiverId)
        {
            using (var UserDbCtx = new UserDbContext())
            {
                // Define the time slots for the day
                var timeSlots = new List<TimeSpan>
        {
            TimeSpan.FromHours(9),  // 09:00 AM
            TimeSpan.FromHours(10), // 10:00 AM
            TimeSpan.FromHours(11), // 11:00 AM
            TimeSpan.FromHours(13),  // 12:00 PM
            TimeSpan.FromHours(14),  // 09:00 AM
            TimeSpan.FromHours(15), // 10:00 AM
            // Add more time slots as needed
        };

                foreach (var timeSlot in timeSlots)
                {
                    // Check if an appointment already exists for the given date and time slot
                    var existingAppointment = UserDbCtx.Apppointments.FirstOrDefault(e =>
                        e.Date.Date == date.Date && e.Date.TimeOfDay == timeSlot && e.ReceiverId == receiverId);

                    if (existingAppointment == null)
                    {
                        // Create a new appointment for the time slot with "canceled" status
                        var newAppointment = new Appointment
                        {
                            Title = (timeSlot+"").Substring(0, 5) + "",
                            Date = date.Date.Add(timeSlot), // Set the date and time
                            Status = "canceled",
                            ReceiverId = receiverId,
                            SenderId = 0,
                            OperationTime = DateTime.UtcNow
                        };

                        UserDbCtx.Apppointments.Add(newAppointment);
                    }
                    else
                    {
                        // Modify the existing appointment (e.g., change status or other properties)
                        existingAppointment.Status = "canceled";
                        existingAppointment.OperationTime = DateTime.UtcNow;
                        // Modify other properties as needed
                    }
                }

                UserDbCtx.SaveChanges();

                return UserDbCtx.Apppointments.Where(e =>
                            e.Date.Date == date.Date && e.ReceiverId == receiverId).ToList();
            }

        }

    }
}
