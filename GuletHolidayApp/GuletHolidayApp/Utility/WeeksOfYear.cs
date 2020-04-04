using GuletHolidayApp.Models;
using System;
using System.Collections.Generic;

namespace GuletHolidayApp.Utility
{
    class WeeksOfYear
    {
        public List<ReservationDto> GetWeeksOfYear(int yachtId, string year)
        {

            List<ReservationDto> reservations = new List<ReservationDto>();

            DateTime startDate = DateTime.Parse(year + "-01-01T00:00:00");
            DateTime endDate = DateTime.Parse(year + "-12-31T00:00:00");
            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                if (date.DayOfWeek == DayOfWeek.Saturday)
                {
                    ReservationDto dto = new ReservationDto();
                    dto.yachtId = yachtId;
                    dto.periodFrom = date.ToString("dd.MM.yyyy");
                    dto.periodTo = date.AddDays(7).ToString("dd.MM.yyyy");
                    dto.reservationType = ShipConstants.ReservationTypeFree;
                    reservations.Add(dto);
                }
            }
            return reservations;
        }
    }
}
