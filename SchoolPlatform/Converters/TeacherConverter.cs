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
    public class TeacherConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var firstname = values[0] as string ?? string.Empty;
            var lastname = values[1] as string ?? string.Empty;

            return new Teacher { FirstName= firstname, LastName = lastname };
        } 

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
