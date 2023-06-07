using SchoolPlatform.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.Models.DataAccessLayer
{
    public class StudentDAL : BaseDAL<Student>
    {
        public StudentDAL(SchoolDataContext context) : base(context)
        {
        }
    }
}
