using SchoolPlatform.Models.EntityLayer;
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
    public class ClassMasterVM
    {
        public static Teacher Teacher { get; set; }

        public ClassMasterVM() { }

        public void OpenGrades()
        {
            GradeView studentGrades = new();
            studentGrades.Show();
        }

        private ICommand _openGrade;
        public ICommand OpenGrade
        {
            get
            {
                if (_openGrade == null)
                {
                    _openGrade = new RelayCommand(OpenGrades);
                }
                return _openGrade;
            }
        }

        public void OpenAttendances()
        {
            AttendanceView studentAttendance = new();
            studentAttendance.Show();
        }

        private ICommand _openAttendance;
        public ICommand OpenAttendance
        {
            get
            {
                if (_openAttendance == null)
                {
                    _openAttendance = new RelayCommand(OpenAttendances);
                }
                return _openAttendance;
            }
        }
    }
}
