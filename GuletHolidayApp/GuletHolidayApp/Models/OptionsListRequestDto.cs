using System;
using System.Collections.Generic;
using System.Text;

namespace GuletHolidayApp.Models
{
    //koristimo listu i za listu svih opcija te za listu svih rezervacija
    public class OptionsListRequestDto
    {
        public CredentialsDto credentials { get; set; }
        public string periodFrom { get; set; }
        public string periodTo { get; set; }
    }
}
