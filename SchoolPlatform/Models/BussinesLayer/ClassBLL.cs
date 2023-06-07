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
    public class ClassBLL
    {
        public ClassDAL ClassDAL { get; set; }

        public ClassBLL()
        {
            ClassDAL = App.ClassDAL;
        }

        public void AddClass(Class @class)
        {
            if (@class.Name == null || @class.Specialization == null)
            {
                throw new Exception("Name and specialization required");
            }
            ClassDAL.Add(@class);
        }

        public ObservableCollection<Class> GetAll()
        {
            ObservableCollection<Class> values = new(ClassDAL.GetAll());
            return values;
        }

        public void UpdateClass(Class @class)
        {
            if (@class == null)
            {
                //throw exception

            }
            ClassDAL.Update(@class);
        }

        public void DeleteClass(Class @class)
        {
            if (@class == null)
            {
                //throw exception
            }
            ClassDAL.Delete(@class);
        }
    }
}
