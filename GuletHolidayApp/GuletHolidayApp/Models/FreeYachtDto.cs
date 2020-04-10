using System.Collections.Generic;

namespace GuletHolidayApp.Models
{
    public class FreeYachtDto
    {
        public string periodFrom { get; set; }
        public string periodTo { get; set; }
        public int yachtId { get; set; }
        public int locationFromId { get; set; }
        public int locationToId { get; set; }
        public PriceDto price { get; set; }

        public override bool Equals(object obj)
        {
            return obj is FreeYachtDto dto &&
                   periodFrom == dto.periodFrom;
        }

        public override int GetHashCode()
        {
            return -492202196 + EqualityComparer<string>.Default.GetHashCode(periodFrom);
        }
    }
}