using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolPlatform.Models.EntityLayer;

namespace SchoolPlatform.Models
{
    public class SchoolDataContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<SubjectClass> SubjectClasses { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=SchoolPlatform;Integrated Security=SSPI;TrustServerCertificate=True");
        }
    }
}
