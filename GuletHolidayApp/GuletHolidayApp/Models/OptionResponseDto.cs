using System;
using System.Collections.Generic;
using System.Text;

namespace GuletHolidayApp.Models
{
    class OptionResponseDto
    {
        public string status { get; set; }
        public int id { get; set; }
        public string uuid { get; set; }
        public string reservationStatus { get; set; }
        public int yachtId { get; set; }
        public string optionTill { get; set; }
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
    }
}
