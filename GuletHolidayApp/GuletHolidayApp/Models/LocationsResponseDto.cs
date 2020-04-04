using System;
using System.Collections.Generic;
using System.Text;

namespace GuletHolidayApp.Models
{
    public class LocationsResponseDto
    {
        public string status { get; set; }
        public List<LocationDto> locations { get; set; }
    }
}
