using System;
using System.Collections.Generic;
using System.Text;

namespace GuletHolidayApp.Models
{
    public class OptionsListResponseDto
    {
        public string status { get; set; }
        public List<UuidDto> reservations { get; set; }
    }
}
