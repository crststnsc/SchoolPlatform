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
    public class StudentMenuVM
    {
        public static Student Student { get; set; }

        public StudentMenuVM()
        {
            
        }
        
        public void OpenGrades()
        {
            StudentGrades studentGrades = new();
            studentGrades.Show();
        }
        
        private ICommand _openGrade;
        public ICommand OpenGrade
        {
            get
            {
                if(_openGrade == null)
                {
                    _openGrade = new RelayCommand(OpenGrades);
                }
                return _openGrade;
            }
        }

        public void OpenAttendances()
        {
            StudentAttendance studentAttendance = new StudentAttendance();
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
