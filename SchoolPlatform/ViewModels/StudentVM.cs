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
    public class StudentVM
    {
        StudentBLL StudentBLL { get; set; }
        public ObservableCollection<Student> Students { get; set; }
        public List<Class> Classes { get; set; }

        public StudentVM()
        {
            StudentBLL = new();
            Students = new(StudentBLL.GetAll());
            Classes = new(App.ClassDAL.GetAll());
        }

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new GenericRelayCommand<Student>(student =>
                    {
                        StudentBLL.AddStudent(student);
                        Students.Add(student);
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
                    updateCommand = new GenericRelayCommand<Student>(student =>
                    {
                        StudentBLL.UpdateStudent(student);
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
                    deleteCommand = new GenericRelayCommand<Student>(student =>
                    {
                        StudentBLL.DeleteStudent(student);
                        Students.Remove(student);
                    });
                }
                return deleteCommand;
            }
        }
    }
}
