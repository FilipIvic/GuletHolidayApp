using System;
using System.Collections.Generic;
using System.Text;

namespace GuletHolidayApp.Models
{
    public class LocationDto
    {
        public int id { get; set; }
        public LoactionNameDto name { get; set; }
        public double lon { get; set; }
        public double lat { get; set; }
        public int regionId { get; set; }

        public override bool Equals(object obj)
        {
            if ((obj == null) && (!this.GetType().Equals(obj.GetType())))
                return false;
            LocationDto dto = (LocationDto)obj;
            if (id == dto.id)
                return true;
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "id=" + id
                + ", lon=" + lon
                + ", lat=" + lat
                + ", name=" + name.textHR
                + ", regionId=" + regionId;                
        }
    }
}
