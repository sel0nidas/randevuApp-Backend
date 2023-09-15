using System;
using System.Collections.Generic;
using System.Text;
using UserFinder.Entities;

namespace UserFinder.Business.Abstract
{
    public interface IDoctorService
    {
        List<DoctorWithUser> GetAllDoctors();

        Doctor GetDoctorById(int id);

        Doctor GetDoctorByUserId(int userid);

        Doctor CreateDoctor(Doctor d);
        Doctor UpdateDoctor(Doctor d);
        void DeleteDoctor(int id);
    }
}
