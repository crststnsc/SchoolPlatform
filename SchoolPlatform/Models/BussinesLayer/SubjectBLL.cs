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
    public class SubjectBLL
    {
        public SubjectDAL SubjectDAL { get; set; }

        public SubjectBLL()
        {
            SubjectDAL = App.SubjectDAL;
        }

        public void AddSubject(Subject subject)
        {
            if (subject.Name == null)
            {
                throw new Exception("Name required");
            }
            SubjectDAL.Add(subject);
        }

        public ObservableCollection<Subject> GetAll()
        {
            ObservableCollection<Subject> values = new(SubjectDAL.GetAll());
            return values;
        }

        public void UpdateSubject(Subject subject)
        {
            if (subject == null)
            {
                //throw exception

            }
            SubjectDAL.Update(subject);
        }

        public void DeleteSubject(Subject subject)
        {
            if (subject == null)
            {
                //throw exception
            }
            SubjectDAL.Delete(subject);
        }
    }
}
