using System;
using System.Collections.Generic;
using System.Text;

namespace GuletHolidayApp.Models
{
    public class PeriodPriceDto : IEquatable<PeriodPriceDto>
    {
        public string periodFrom { get; set; }
        public string priceListPrice { get; set; }
        public string clientPrice { get; set; }

        public bool Equals(PeriodPriceDto other)
        {
            if ((other == null) && (!this.GetType().Equals(other.GetType())))
                return false;
            PeriodPriceDto dto = (PeriodPriceDto)other;
            if (other.periodFrom == null)
                return false;
            if (periodFrom.Equals(other.periodFrom))
                return true;
            return false;
        }
    }
}
