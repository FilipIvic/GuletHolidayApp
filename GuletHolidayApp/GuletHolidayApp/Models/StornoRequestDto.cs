using System;
using System.Collections.Generic;
using System.Text;

namespace GuletHolidayApp.Models
{
    public class StornoRequestDto
    {
        public CredentialsDto credentials { get; set; }
        public int id { get; set; }
        public string uuid { get; set; }
    }
}
