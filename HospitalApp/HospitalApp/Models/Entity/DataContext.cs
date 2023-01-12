using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HospitalApp.Models.Entity
{
    public class DataContext:DbContext
    {
        public DataContext() : base("hospitalConnection2") { }  //burada verdğin adı webcondgide yaz

        public DbSet<Department> Department { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Prescription> Prescription { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<PatientRegistration> PatientRegistration { get; set; }
        public DbSet<Procedure> Procedure { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<User> User { get; set; }
    }
}