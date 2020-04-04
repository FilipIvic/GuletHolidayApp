using System;
using System.Collections.Generic;
using System.Text;

namespace GuletHolidayApp.Models
{
    public class InfoRequestDto
    {
        public ClientDto client { get; set; }
        public CredentialsDto credentials { get; set; }
        public string periodFrom { get; set; }
        public string periodTo { get; set; }
        public int yachtID { get; set; }
        public string onlinePayment { get; set; }
        public string numberOfPayments { get; set; }
        public string useDepositPayment { get; set; }
    }
}
