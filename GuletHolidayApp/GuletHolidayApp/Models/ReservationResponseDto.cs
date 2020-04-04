using System.Collections.Generic;

namespace GuletHolidayApp.Models
{
    public class ReservationResponseDto
    {
        public string status { get; set; }
        public int companyId { get; set; }
        public int year { get; set; }
        public List<ReservationDto> reservations { get; set; }

        public override string ToString()
        {
            return "status=" + status
                + ", companyId=" + companyId
                + ", year=" + year
                + ", number of reservation=" + reservations.Count;
        }

    }
}
