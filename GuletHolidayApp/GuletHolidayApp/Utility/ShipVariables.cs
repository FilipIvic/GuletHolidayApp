using GuletHolidayApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuletHolidayApp.Utility
{
    class ShipVariables
    {
        public static List<LocationDto> locations { get; set; }
        public static List<PeriodPriceDto> PeriodPrice { get; set; }
        public static bool StartApp { get; set; } = true;

    }
}
