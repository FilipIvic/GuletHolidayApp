using System;
using System.Collections.Generic;
using System.Text;

namespace GuletHolidayApp.Models
{
    public class FreeYachtRequestDto
    {
        public CredentialsDto credentials { get; set; }
        public string periodFrom { get; set; }
        public string periodTo { get; set; }
        public List<int> yachts { get; set; }
    }
}
