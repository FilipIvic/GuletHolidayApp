using System;
using System.Collections.Generic;
using System.Text;

namespace GuletHolidayApp.Models
{
    public class BookingResponseDto
    {
        public string status { get; set; }
        public int id { get; set; }
        public string uuid { get; set; }
        public string reservationStatus { get; set; }
        public int yachtId { get; set; }
        public string optionTill { get; set; }
        public string periodFrom { get; set; }
        public string periodTo { get; set; }

        //ima ih još,al trenutno ih ne koristimo
    }
}
