using GuletHolidayApp.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace GuletHolidayApp.Utility
{
    class IdToLocationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            foreach (LocationDto dto in ShipVariables.locations)
            {
                if ((int)value == dto.id)
                    return dto.name.textHR + "\n" + dto.name.textHR;
            }
            //return ShipConstants.ReservationReserveNow;
            return ShipConstants.ReservationReserveNow;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
