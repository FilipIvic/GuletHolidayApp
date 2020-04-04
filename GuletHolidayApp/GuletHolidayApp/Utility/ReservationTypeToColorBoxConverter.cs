using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace GuletHolidayApp.Utility
{
    class ReservationTypeToColorBoxConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string color = null;
            string reservationType = (string)value;

            if (reservationType.Equals(ShipConstants.ReservationTypeFree))
            {
                color = ShipConstants.DarkGreyColor;
            }
            else if (reservationType.Equals(ShipConstants.ReservationTypeReserved))
            {
                color = ShipConstants.DarkRedColor;
            }
            else
            {
                color = ShipConstants.DarkBlueColor;
            }
            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
