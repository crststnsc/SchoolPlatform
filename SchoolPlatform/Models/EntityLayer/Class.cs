using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.Models.EntityLayer
{
    public class Class : BaseEntity
    {
        public string Name { get; set; }
        public Specialization Specialization { get; set; }
        public List<Student> Students { get; set; }
        public Teacher? Teacher { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
