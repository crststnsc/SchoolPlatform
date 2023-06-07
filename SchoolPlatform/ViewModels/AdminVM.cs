using Microsoft.Identity.Client;
using SchoolPlatform.ViewModels.Commands;
using SchoolPlatform.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchoolPlatform.ViewModels
{
    public class AdminVM
    {
        #region User
        private ICommand userCommand;
        public ICommand UserCommand
        {
            get
            {
                if (userCommand == null)
                {
                    userCommand = new RelayCommand(OpenUsers);
                }
                return userCommand;
            }
        }
        void OpenUsers()
        {
            UsersView usersView = new();
            usersView.Show();
        }
        #endregion

        #region Attendance
        private ICommand attendanceCommand;
        public ICommand AttendanceCommand
        {
            get
            {
                if (attendanceCommand == null)
                {
                    attendanceCommand = new RelayCommand(OpenAttendances);
                }
                return attendanceCommand;
            }
        }
        void OpenAttendances()
        {
            AttendanceView attendanceView = new();
            attendanceView.Show();
        }
        #endregion

        #region Specialization
        private ICommand specializationCommand;
        public ICommand SpecializationCommand
        {
            get
            {
                if(specializationCommand == null)
                {
                    specializationCommand = new RelayCommand(OpenSpecializations);
                }
                return specializationCommand;
            }          
        }
        void OpenSpecializations()
        {
            SpecializationView specializationView = new();
            specializationView.Show();
        }
        #endregion

        #region Class
        private ICommand classCommnad;
        public ICommand ClassCommnad
        {
            get
            {
                if(classCommnad == null)
                {
                    classCommnad = new RelayCommand(OpenClasses);
                }
                return classCommnad;
            }
        }
        void OpenClasses()
        {
            ClassView classView = new();
            classView.Show();
        }
        #endregion

        #region Student
        private ICommand studentCommand;
        public ICommand StudentCommand
        {
            get
            {
                if(studentCommand == null)
                {
                    studentCommand = new RelayCommand(OpenStudents);
                }
                return studentCommand;
            }
        }
        void OpenStudents()
        {
            StudentView studentView = new();
            studentView.Show();
        }
        #endregion

        #region Grade
        private ICommand gradeCommand;
        public ICommand GradeCommand
        {
            get
            {
                if(gradeCommand == null)
                {
                    gradeCommand = new RelayCommand(OpenGrades);
                }
                return gradeCommand;
            }
        }
        void OpenGrades()
        {
            GradeView gradeView = new();
            gradeView.Show();
        }
        #endregion 

        #region Subject
        private ICommand subjectCommand;
        public ICommand SubjectCommand
        {
            get
            {
                if(subjectCommand == null)
                {
                    subjectCommand = new RelayCommand(OpenSubjects);
                }
                return subjectCommand;
            }
        }
        void OpenSubjects()
        {
            SubjectView subjectView = new();
            subjectView.Show();
        }
        #endregion

        #region Teacher
        public void OpenTeachers()
        {
            TeacherWindow teacherWindow = new TeacherWindow();
            teacherWindow.Show();
        }

        private ICommand teacherCommand;
        public ICommand TeacherCommand
        {
            get
            {
                if(teacherCommand == null)
                {
                    teacherCommand = new RelayCommand(OpenTeachers);
                }
                return teacherCommand;
            }
        }
        #endregion

        #region SubjectClasse
        public void OpenSubjectClasses()
        {
            SubjectClassView subjectClassView = new SubjectClassView();
            subjectClassView.Show();
        }
        private ICommand subjectClassCommand;
        public ICommand SubjectClassCommand
        {
            get
            {
                if(subjectClassCommand == null)
                {
                    subjectClassCommand = new RelayCommand(OpenSubjectClasses);
                }
                return subjectClassCommand;
            }
        }
        #endregion
    }
}
