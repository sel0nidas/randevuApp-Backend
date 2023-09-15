using System;
using System.Collections.Generic;
using System.Text;
using UserFinder.Entities;

namespace UserFinder.DataAccess.Abstract
{
    interface IDoctorRepository
    {
        List<DoctorWithUser> GetAllDoctors();

        Doctor GetDoctorById(int id);

        Doctor GetDoctorByUserId(int userid);

        Doctor CreateDoctor(Doctor d);
        Doctor UpdateDoctor(Doctor d);
        void DeleteDoctor(int id);

    }
}
