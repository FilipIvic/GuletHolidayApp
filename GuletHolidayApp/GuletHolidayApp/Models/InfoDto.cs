namespace GuletHolidayApp.Models
{
    public class InfoDto
    {
        private int id;
        private string uuid;
        private string reservationStatus;

        private int GetId() { return id; }
        private void SetId(int value) { id = value; }

        public string GetUuid() { return uuid; }
        public void SetUuid(string value) { uuid = value; }

        public string GetReservationStatus() { return reservationStatus; }
        public void SetReservationStatus(string value) { reservationStatus = value; }

    }
}
