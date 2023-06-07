using SchoolPlatform.Models.DataAccessLayer;
using SchoolPlatform.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.Models.BussinesLayer
{
    public class TeacherBLL
    {
        public TeacherDAL TeacherDAL { get; set; }

        public TeacherBLL()
        {
            TeacherDAL = App.TeacherDAL;
        }

        public void AddTeacher(Teacher teacher)
        {
            if (teacher.FirstName == null || teacher.LastName == null)
            {
                throw new Exception("Name and lastname required");
            }
            TeacherDAL.Add(teacher);
        }

        public List<Teacher> GetAll()
        {
            List<Teacher> values = new(TeacherDAL.GetAll());
            return values;
        }

        public void UpdateTeacher(Teacher teacher)
        {
            if (teacher == null)
            {
                //throw exception

            }
            TeacherDAL.Update(teacher);
        }

        public void DeleteTeacher(Teacher teacher)
        {
            if (teacher == null)
            {
                //throw exception
            }
            TeacherDAL.Delete(teacher);
        }
    }
}
