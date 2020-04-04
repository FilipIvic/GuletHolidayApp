using GuletHolidayApp.Models;
using GuletHolidayApp.Utility;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GuletHolidayApp.DAO
{
    class NauSysApi
    {
        public ReservationResponseDto Occupancy(string year)
        {
            string url = "http://ws.nausys.com/CBMS-external/rest/yachtReservation/v6/occupancy/" + ShipConstants.CompanyId + "/" + year;
            string result = CallNauSysApi(url);
            ReservationResponseDto response = JsonConvert.DeserializeObject<ReservationResponseDto>(result);
            return response;
        }

        public LocationsResponseDto Locations()
        {
            string url = "http://ws.nausys.com/CBMS-external/rest/catalogue/v6/locations";
            string result = CallNauSysApi(url);
            LocationsResponseDto response = JsonConvert.DeserializeObject<LocationsResponseDto>(result);
            return response;
        }

        private string CallNauSysApi(string url)
        {
            CredentialsDto credentials = new CredentialsDto();
            credentials.username = ShipConstants.Username;
            credentials.password = ShipConstants.Password;

            string json = JsonConvert.SerializeObject(credentials);
            StringContent data = new StringContent(json, Encoding.UTF8, "application/json");

            string result = null;
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage httpsResponse = client.PostAsync(url, data).Result;
                result = httpsResponse.Content.ReadAsStringAsync().Result;
            }
            return result;
        }
    }
}
