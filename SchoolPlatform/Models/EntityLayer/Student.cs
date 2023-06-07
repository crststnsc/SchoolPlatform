using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.Models.EntityLayer
{
    public class Student : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Class Class { get; set; }
        public List<Grade> Grades { get; set; }
        public List<Attendance> Attendances { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
