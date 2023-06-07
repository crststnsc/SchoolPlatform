using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.Models.EntityLayer
{
    public class Subject : BaseEntity
    {
        public string Name { get; set; }
        public List<Grade> Grades { get; set; }
        public List<Attendance> Attendances { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
