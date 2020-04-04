namespace GuletHolidayApp.Models
{
    public class InfoResponseDto
    {
        public string status { get; set; }
        public int id { get; set; }
        public string uuid { get; set; }
        public string reservationStatus { get; set; }
        public int yachtId { get; set; }
        public string periodFrom { get; set; }
        public string periodTo { get; set; }
        //public string agency { get; set; }
        //public ClientDto client { get; set; }
        //public List<Discount> discounts { get; set; }
        //public List<AdditionalEquipment> additionalEquipment { get; set; }
        //public List<Service> services { get; set; }
        //public string priceListPrice { get; set; }
        //public string agencyPrice { get; set; }
        //public string clientPrice { get; set; }
        //public string paymentCurrency { get; set; }
        //public bool approved { get; set; }
        //public string numberOfPayments { get; set; }
        //public string useDepositPayment { get; set; }

        public override string ToString()
        {
            return "status=" + status
                + ", id=" + id
                + ", yachtId=" + yachtId
                + ", uuid=" + uuid
                + ", reservationStatus=" + reservationStatus
                + ", periodFrom=" + periodFrom
                + ", periodTo=" + periodTo;
        }
    }
}
