using SchoolPlatform.Exceptions;
using SchoolPlatform.Models.DataAccessLayer;
using SchoolPlatform.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.Models.BussinesLayer
{
    public class GradeBLL
    {
        public GradeDAL GradeDAL { get; set; }

        public GradeBLL()
        {
            GradeDAL = App.GradeDAL;
        }

        public void AddGrade(Grade grade)
        {
            if (grade.Student == null || grade.Subject == null)
            {
                throw new Exception("Student and subject required");
            }
            GradeDAL.Add(grade);
        }

        public ObservableCollection<Grade> GetAll()
        {
            ObservableCollection<Grade> values = new(GradeDAL.GetAll());
            return values;
        }

        public void UpdateGrade(Grade grade)
        {
            if (grade == null)
            {
                //throw exception

            }
            GradeDAL.Update(grade);
        }

        public void DeleteGrade(Grade grade)
        {
            if (grade == null)
            {
                //throw exception
            }
            GradeDAL.Delete(grade);
        }
    }
}

