using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.Models.EntityLayer
{
    public class SubjectClass : BaseEntity
    {
        public Subject Subject { get; set; }
        public Class Class { get; set; }
        public Teacher Teacher { get; set; }
    }
}
