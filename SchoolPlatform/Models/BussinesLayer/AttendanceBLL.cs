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
    public class AttendanceBLL
    {
        public AttendanceDAL AttendanceDAL { get; set; }

        public AttendanceBLL(){
            AttendanceDAL = App.AttendanceDAL;
        }

        public void AddAttendance(Attendance attendance)
        {
            if (attendance.Student == null || attendance.Subject == null)
            {
                throw new Exception("Student and subject required");
            }
            AttendanceDAL.Add(attendance);
        }

        public ObservableCollection<Attendance> GetAll()
        {
            ObservableCollection<Attendance> values = new(AttendanceDAL.GetAll());
            return values;
        }

        public void UpdateAttendance(Attendance attendance)
        {
            if (attendance == null)
            {
                //throw exception

            }
            AttendanceDAL.Update(attendance);
        }

        public void DeleteAttendance(Attendance attendance)
        {
            if (attendance == null)
            {
                //throw exception
            }
            AttendanceDAL.Delete(attendance);
        }
    }
}
