using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UserFinder.Entities;

namespace UserFinder.DataAccess
{
    public class UserDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=GVY785;Database=randevuAppDb;Trusted_Connection=True;");
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Appointment> Apppointments { get; set; }
    }
}
