using System;
using System.Collections.Generic;
using System.Text;

namespace GuletHolidayApp.Models
{
    public class PaymentDto
    {
        public string amount { get; set; }
        public string request { get; set; }
        public string currency { get; set; }
        public string date { get; set; }// String pattern dd.MM.yyyy
        /*
         * paymentMethod possible values:
         * BANK_TRANSFER Bank transfer
         * CASH Paper money / coins
         * CREDIT_CARD Credit card
         * CHECQUE Checque
        */
        public string paymentMethod { get; set; }
        public string approvalCode { get; set; }

    }
}
