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
    public class GradeVM
    {
        GradeBLL GradeBLL { get; set; }
        StudentBLL StudentBLL { get; set; }
        SubjectBLL SubjectBLL { get; set; }
        public ObservableCollection<Grade> Grades { get; set; }
        public List<Student> Students { get; set; }
        public List<Subject> Subjects { get; set; }

        public GradeVM()
        {
            GradeBLL = new();
            StudentBLL = new();
            SubjectBLL = new();

            Grades = GradeBLL.GetAll();
            Students = new(StudentBLL.GetAll());
            Subjects = new(SubjectBLL.GetAll());

            //if the teacher from the teachermenuvm is not null , we filter the grades to only the subjectclass the teacher is teaching
            if(TeacherMenuVM.Teacher != null)
            {
                List<SubjectClass>? subjectClasses = TeacherMenuVM.Teacher.SubjectClasses;

                List<Subject> subjects = new();
                List<Class> classes = new();
                foreach(SubjectClass subjectClass in subjectClasses)
                {
                    subjects.Add(subjectClass.Subject);
                    classes.Add(subjectClass.Class);
                }
                Grades = new(Grades.Where(grade => subjects.Contains(grade.Subject) && classes.Contains(grade.Student.Class)));
            }
            if(ClassMasterVM.Teacher != null)
            {
                List<Class> classes = new(App.ClassDAL.GetAll());

                Class currentClass = new();

                foreach(Class @class in classes)
                {
                    if(@class.Teacher.Id == ClassMasterVM.Teacher.Id)
                    {
                        currentClass = @class;
                        break;
                    }
                }

                List<Student> students = currentClass.Students;

                Grades = new(Grades.Where(grade => students.Contains(grade.Student)));
            }
        }

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new GenericRelayCommand<Grade>(grade =>
                    {
                        GradeBLL.AddGrade(grade);
                        Grades.Add(grade);
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
                    updateCommand = new GenericRelayCommand<Grade>(grade =>
                    {
                        GradeBLL.UpdateGrade(grade);
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
                    deleteCommand = new GenericRelayCommand<Grade>(grade =>
                    {
                        GradeBLL.DeleteGrade(grade);
                        Grades.Remove(grade);
                    });
                }
                return deleteCommand;
            }
        }
    }
}
