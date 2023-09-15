using System;
using System.Collections.Generic;
using System.Text;
using UserFinder.Business.Abstract;
using UserFinder.DataAccess.Concrete;
using UserFinder.Entities;

namespace UserFinder.Business.Concrete
{
    public class DoctorManager : IDoctorService
    {
        private DoctorRepository _doctorRepository;

        public DoctorManager()
        {
            _doctorRepository = new DoctorRepository();
        }

        public Doctor CreateDoctor(Doctor d)
        {
            return _doctorRepository.CreateDoctor(d);
        }

        public void DeleteDoctor(int id)
        {
            _doctorRepository.DeleteDoctor(id);
        }

        public List<DoctorWithUser> GetAllDoctors()
        {
            return _doctorRepository.GetAllDoctors();
        }

        public Doctor GetDoctorById(int id)
        {
            return _doctorRepository.GetDoctorById(id);
        }
        public Doctor GetDoctorByUserId(int userid)
        {
            return _doctorRepository.GetDoctorByUserId(userid);
        }


        public Doctor UpdateDoctor(Doctor d)
        {
            return _doctorRepository.UpdateDoctor(d);
        }
    }
}
