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
    public class SpecializationBLL
    {
        public SpecializationDAL SpecializationDAL { get; set; }

        public SpecializationBLL()
        {
            SpecializationDAL = App.SpecializationDAL;
        }

        public void AddSpecialization(Specialization specialization)
        {
            if (specialization.Name == null)
            {
                throw new Exception("Specialization name required");
            }
            SpecializationDAL.Add(specialization);
        }

        public ObservableCollection<Specialization> GetAll()
        {
            ObservableCollection<Specialization> values = new(SpecializationDAL.GetAll());
            return values;
        }

        public void UpdateSpecialization(Specialization specialization)
        {
            if (specialization == null)
            {
                //throw exception

            }
            SpecializationDAL.Update(specialization);
        }

        public void DeleteSpecialization(Specialization specialization)
        {
            if (specialization == null)
            {
                //throw exception
            }
            SpecializationDAL.Delete(specialization);
        }
    }
}

