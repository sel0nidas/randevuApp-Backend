﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UserFinder.Entities
{
    public class Doctor
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50)]
        public string DoctorType { get; set; }

        [StringLength(50)]
        public string Workdays { get; set; }

        [StringLength(50)]
        public string Worktimes { get; set; }

        public int UserId { get; set; }
    }
}
