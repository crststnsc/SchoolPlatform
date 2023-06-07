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
    public class SubjectClassBLL
    {
        public SubjectClassDAL SubjectClassDAL { get; set; }

        public SubjectClassBLL()
        {
            SubjectClassDAL = App.SubjectClassDAL;
        }

        public void AddSubjectClass(SubjectClass subjectClass)
        {
            if (subjectClass.Subject == null || subjectClass.Class == null)
            {
                throw new Exception("Subject and class required");
            }
            SubjectClassDAL.Add(subjectClass);
        }

        public ObservableCollection<SubjectClass> GetAll()
        {
            ObservableCollection<SubjectClass> values = new(SubjectClassDAL.GetAll());
            return values;
        }

        public void UpdateSubjectClass(SubjectClass subjectClass)
        {
            if (subjectClass == null)
            {
                //throw exception

            }
            SubjectClassDAL.Update(subjectClass);
        }

        public void DeleteSubjectClass(SubjectClass subjectClass)
        {
            if (subjectClass == null)
            {
                //throw exception
            }
            SubjectClassDAL.Delete(subjectClass);
        }
    }
}
