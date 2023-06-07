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
    public class StudentConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string firstName = values[0] as string ?? string.Empty;
            string lastName = values[1] as string ?? string.Empty;

            var @class = values[2] as Class;

            return new Student { FirstName = firstName, LastName = lastName , Class = @class};
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
