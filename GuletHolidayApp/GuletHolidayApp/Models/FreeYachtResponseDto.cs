using System;
using System.Collections.Generic;
using System.Text;

namespace GuletHolidayApp.Models
{
    public class FreeYachtResponseDto
    {
        public string status { get; set; }
        public string periodFrom { get; set; }
        public string periodTo { get; set; }
        public List<FreeYachtDto> freeYachts { get; set; }
    }
}
