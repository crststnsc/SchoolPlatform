using SchoolPlatform.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace SchoolPlatform.Converters
{
    public class AttendanceConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            //converter for attendance class

            // Convert the values to strings. Handle null values.
            
            
            var student = values[0] as Student;
            var subject = values[1] as Subject;
            
            DateTime? dateTime = values[2] as DateTime?;

            bool ispresent = (bool)values[3];
            bool ismotivated = (bool)values[4];

            return new Attendance
            {
                Student = student,
                Subject = subject,
                Date = dateTime ?? DateTime.Now,
                IsPresent = ispresent,
                IsMotivated = ismotivated
            };
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
