using SchoolPlatform.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SchoolPlatform.Converters
{
    public class SubjectClassConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var @class = values[0] as Class;
            var subject = values[1] as Subject;
            var teacher = values[2] as Teacher;

            return new SubjectClass { Class = @class, Subject = subject, Teacher = teacher };
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
