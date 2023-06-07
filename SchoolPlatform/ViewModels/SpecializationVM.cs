using SchoolPlatform.Models.BussinesLayer;
using SchoolPlatform.Models.EntityLayer;
using SchoolPlatform.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchoolPlatform.ViewModels
{
    public class SpecializationVM
    {
        SpecializationBLL SpecializationBLL { get; set; }
        public ObservableCollection<Specialization> Specializations { get; set; }

        public SpecializationVM()
        {
            SpecializationBLL = new();
            Specializations = SpecializationBLL.GetAll();
        }

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new GenericRelayCommand<string>(name =>
                    {
                        Specialization specialization = new()
                        {
                            Name = name
                        };
                        SpecializationBLL.AddSpecialization(specialization);
                        Specializations.Add(specialization);
                    });
                }
                return addCommand;
            }
        }

        private ICommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                {
                    updateCommand = new GenericRelayCommand<Specialization>(specialization =>
                    {
                        SpecializationBLL.UpdateSpecialization(specialization);
                    });
                }
                return updateCommand;
            }
        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new GenericRelayCommand<Specialization>(specialization =>
                    {
                        SpecializationBLL.DeleteSpecialization(specialization);
                        Specializations.Remove(specialization);
                    });
                }
                return deleteCommand;
            }
        }
    }
}

