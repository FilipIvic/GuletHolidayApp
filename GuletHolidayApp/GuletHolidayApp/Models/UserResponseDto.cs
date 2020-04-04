using System;
using System.Collections.Generic;
using System.Text;

namespace GuletHolidayApp.Models
{
    public class UserResponseDto
    {
        public string status { get; set; }
        public string message { get; set; }
        public UserDto user { get; set; }

    }
}
