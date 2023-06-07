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
    public class TeacherVM
    {
        TeacherBLL TeacherBLL { get; set; }
        public ObservableCollection<Teacher> Teachers { get; set; }

        public TeacherVM()
        {
            TeacherBLL = new();
            Teachers = new(TeacherBLL.GetAll());
        }

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new GenericRelayCommand<Teacher>(teacher =>
                    {
                        TeacherBLL.AddTeacher(teacher);
                        Teachers.Add(teacher);
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
                    updateCommand = new GenericRelayCommand<Teacher>(teacher =>
                    {
                        TeacherBLL.UpdateTeacher(teacher);
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
                    deleteCommand = new GenericRelayCommand<Teacher>(teacher => {             
                        TeacherBLL.DeleteTeacher(teacher);
                        Teachers.Remove(teacher);
                    });
                }
                return deleteCommand;
            }
        }
    }
}
