using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.Models.EntityLayer
{
    public class Attendance : BaseEntity
    {
        public Student Student { get; set; }
        public Subject Subject { get; set; }
        public DateTime Date { get; set; }
        public bool? IsPresent { get; set; }
        public bool? IsMotivated { get; set; }
    }
}
