using SchoolPlatform.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SchoolPlatform.Converters
{
    public class GradeConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var grade = values[0] as string ?? string.Empty;
            Student student = values[1] as Student;
            Subject subject = values[2] as Subject;
            bool isSemestrial = (bool)values[3];

            if (values[0].ToString() == string.Empty)
            {
                grade = "0";
            }

            if (!int.TryParse(grade, out int gradeint))
            {
                throw new ArgumentException("");
            }

            return new Grade { Value = gradeint, Student = student, Subject = subject, IsSemestrial = isSemestrial };
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
