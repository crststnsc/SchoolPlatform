using SchoolPlatform.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace SchoolPlatform.Converters
{
    public class UserConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length != 4)
                throw new ArgumentException("Four values need to be bound for conversion.");

            // Convert the values to strings. Handle null values.
            string username = values[0] as string ?? string.Empty;
            string password = values[1] as string ?? string.Empty;

            // Convert the userRole and userId to integers
            var comboBoxItem = values[2] as ComboBoxItem;

            if (comboBoxItem == null)
                comboBoxItem = new ComboBoxItem { Content = UserRole.Student };

            if (!Enum.TryParse(comboBoxItem.Content.ToString(), out UserRole userRole))
                throw new ArgumentException("userRole needs to be an UserRole enum.");


            string userId = values[3].ToString();
            if (values[3].ToString() == string.Empty)
            {
                userId = "-1";
            }

            if (!int.TryParse(userId, out int userid))
                throw new ArgumentException("userId needs to be an integer.");

            return new User { Username = username, Password = password, UserRole = userRole, UserId = userid };
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
