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
    public class SubjectClassVM
    {
        SubjectClassBLL SubjectClassBLL { get; set; }
        public ObservableCollection<SubjectClass> SubjectClasses { get; set; }
        public List<Subject> Subjects { get; set; }
        public List<Class> Classes { get; set; }
        public List<Teacher> Teachers { get; set; }

        public SubjectClassVM()
        {
            SubjectClassBLL = new();
            SubjectClasses = new(SubjectClassBLL.GetAll());

            Subjects = new(App.SubjectDAL.GetAll());
            Classes = new(App.ClassDAL.GetAll());
            Teachers = new(App.TeacherDAL.GetAll());
        }

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new GenericRelayCommand<SubjectClass>(subjectClass =>
                    {
                        SubjectClassBLL.AddSubjectClass(subjectClass);
                        SubjectClasses.Add(subjectClass);
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
                    updateCommand = new GenericRelayCommand<SubjectClass>(subjectClass =>
                    {
                        SubjectClassBLL.UpdateSubjectClass(subjectClass);
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
                    deleteCommand = new GenericRelayCommand<SubjectClass>(subjectClass =>
                    {
                        SubjectClassBLL.DeleteSubjectClass(subjectClass);
                        SubjectClasses.Remove(subjectClass);
                    });
                }
                return deleteCommand;
            }
        }
    }
}
