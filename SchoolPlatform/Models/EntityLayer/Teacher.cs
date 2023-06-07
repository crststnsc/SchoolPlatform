using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.Models.EntityLayer
{
    public class Teacher : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<SubjectClass> SubjectClasses { get; set; }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}
