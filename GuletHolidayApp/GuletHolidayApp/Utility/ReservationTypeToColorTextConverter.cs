using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace GuletHolidayApp.Utility
{
    class ReservationTypeToColorTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string color = null;
            string reservationType = (string)value;

            if (reservationType.Equals(ShipConstants.ReservationTypeFree))
            {
                color = "Black";
            }
            else if (reservationType.Equals(ShipConstants.ReservationTypeReserved))
            {
                color = "White";
            }
            else
            {
                color = "White";
            }
            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
