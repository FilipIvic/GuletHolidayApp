using GuletHolidayApp.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace GuletHolidayApp.Utility
{
    class IdToSingleLocationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            foreach (LocationDto dto in ShipVariables.locations)
            {
                if ((int)value == dto.id)
                    return dto.name.textHR;
            }
            //return ShipConstants.ReservationReserveNow;
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
