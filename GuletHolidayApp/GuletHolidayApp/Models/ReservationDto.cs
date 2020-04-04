namespace GuletHolidayApp.Models
{
    public class ReservationDto
    {
        public int id { get; set; }
        public int yachtId { get; set; }
        public int locationFromId { get; set; }
        public int locationToId { get; set; }
        public string reservationType { get; set; }
        public string periodFrom { get; set; }
        public string checkInTime { get; set; }
        public string periodTo { get; set; }
        public string checkOutTime { get; set; }
        public string optionValidTill { get; set; }
        //public string periodFromTo { get; set; }
        //public string color { get; set; }

        public override string ToString()
        {
            return "id=" + id
                + ", yachtId=" + yachtId
                + ", locationFromId=" + locationFromId
                + ", locationToId=" + locationToId
                + ", reservationType=" + reservationType
                + ", periodFrom=" + periodFrom
                + ", checkInTime=" + checkInTime
                + ", periodTo=" + periodTo
                + ", checkOutTime=" + checkOutTime
                + ", optionValidTill=" + optionValidTill;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) && (!this.GetType().Equals(obj.GetType())))
                return false;
            ReservationDto dto = (ReservationDto)obj;
            if (dto.periodFrom == null)
                return false;
            if (periodFrom.Equals(dto.periodFrom))
                return true;
            return false;
        }
    }
}
