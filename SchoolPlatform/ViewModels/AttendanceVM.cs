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
    public class AttendanceVM
    {
        AttendanceBLL AttendanceBLL { get; set; }
        public ObservableCollection<Attendance> Attendances { get; set; }
        public List<Subject> Subjects { get; set; }
        public List<Student> Students { get; set; }

        public AttendanceVM()
        {
            AttendanceBLL = new();
            Attendances = AttendanceBLL.GetAll();
            Subjects = new(App.SubjectDAL.GetAll());
            Students = new(App.StudentDAL.GetAll());

            //if the teacher in teachermenuvm is not null 
            //then get the subjects and students for that teacher
            if (TeacherMenuVM.Teacher != null)
            {
                List<SubjectClass>? subjectClasses = TeacherMenuVM.Teacher.SubjectClasses;

                List<Subject> subjects = new();
                List<Class> classes = new();
                foreach (SubjectClass subjectClass in subjectClasses)
                {
                    subjects.Add(subjectClass.Subject);
                    classes.Add(subjectClass.Class);
                }

                //change the Attendances
                Attendances = new(Attendances.Where(attendance => subjects.Contains(attendance.Subject) && classes.Contains(attendance.Student.Class)));
            }
        }
           

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new GenericRelayCommand<Attendance>(attendance =>
                    {
                        AttendanceBLL.AddAttendance(attendance);
                        Attendances.Add(attendance);
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
                    updateCommand = new GenericRelayCommand<Attendance>(attendance =>
                    {
                        AttendanceBLL.UpdateAttendance(attendance);
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
                    deleteCommand = new GenericRelayCommand<Attendance>(attendance =>
                    {
                        AttendanceBLL.DeleteAttendance(attendance);
                        Attendances.Remove(attendance);
                    });
                }
                return deleteCommand;
            }
        }
    }
}
