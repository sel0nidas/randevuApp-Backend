using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserFinder.DataAccess.Abstract;
using UserFinder.Entities;

namespace UserFinder.DataAccess.Concrete
{
    public class DoctorRepository : IDoctorRepository
    {
        public Doctor CreateDoctor(Doctor d)
        {
            using (var UserDbCtx = new UserDbContext())
            {
                UserDbCtx.Doctors.Add(d);
                UserDbCtx.SaveChanges();
            }

            return d;
        }

        public void DeleteDoctor(int id)
        {
            throw new NotImplementedException();
        }

        public List<DoctorWithUser> GetAllDoctors()
        {
            using (var UserDbCtx = new UserDbContext())
            {
                var DoctorWithUsers = UserDbCtx.Doctors
                       .Select(doctor => new DoctorWithUser
                       {
                           DoctorId = doctor.Id,
                           Name = UserDbCtx.Users.FirstOrDefault(user => user.Id == doctor.UserId).Name,
                           UserId = doctor.UserId,
                           Password = "",
                           Gender = UserDbCtx.Users.FirstOrDefault(user=>user.Id == doctor.UserId).Gender,
                           DoctorType = doctor.DoctorType
                       })
                       .ToList();
                return DoctorWithUsers.ToList();
            }
        }

        public Doctor GetDoctorById(int id)
        {
            throw new NotImplementedException();
        }

        public Doctor GetDoctorByUserId(int userid)
        {
            using (var UserDbCtx = new UserDbContext())
            {
                return UserDbCtx.Doctors.FirstOrDefault(d=>d.UserId == userid);
            }
        }

        public Doctor UpdateDoctor(Doctor d)
        {
            using (var UserDbCtx = new UserDbContext())
            {
                var doctorObj = UserDbCtx.Doctors.FirstOrDefault(doc => doc.UserId == d.UserId);
                doctorObj.Workdays = d.Workdays;
                doctorObj.Worktimes = d.Worktimes;
                UserDbCtx.Doctors.Update(doctorObj);
                UserDbCtx.SaveChanges();
                return UserDbCtx.Doctors.FirstOrDefault(doc => doc.UserId == d.UserId);
            }
        }
    }
}
