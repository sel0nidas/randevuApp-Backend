using System;
using System.Collections.Generic;
using System.Text;

namespace UserFinder.Entities
{
    public class DoctorWithUser
    {

        public int DoctorId { get; set; }

        public int UserId { get; set; }

        public String Name { get; set; }

        public String Gender { get; set; }

        public string Password { get; set; }

        public string DoctorType { get; set; }
    }
}
