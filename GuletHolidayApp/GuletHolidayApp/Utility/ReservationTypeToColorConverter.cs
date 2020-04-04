using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace GuletHolidayApp.Utility
{
    class ReservationTypeToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string color = null;
            string reservationType = (string)value;

            if (reservationType.Equals(ShipConstants.ReservationTypeFree))
            {
                color = ShipConstants.GreyColor;
            }
            else if (reservationType.Equals(ShipConstants.ReservationTypeReserved))
            {
                color = ShipConstants.LightRedColor;
            }
            else
            {
                color = ShipConstants.LightBlueColor;
            }
            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
