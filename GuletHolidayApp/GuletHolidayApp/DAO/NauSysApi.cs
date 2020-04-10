using GuletHolidayApp.Models;
using GuletHolidayApp.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GuletHolidayApp.DAO
{
    class NauSysApi
    {
        public ReservationResponseDto Occupancy(string year)
        {
            CredentialsDto credentials = GetCredentials();
            string json = JsonConvert.SerializeObject(credentials);
            string url = "http://ws.nausys.com/CBMS-external/rest/yachtReservation/v6/occupancy/" + ShipConstants.CompanyId + "/" + year;
            string result = CallNauSysApi(url, json);
            //Console.WriteLine(result);
            ReservationResponseDto response = JsonConvert.DeserializeObject<ReservationResponseDto>(result);
            return response;
        }

        public InfoResponseDto CreateInfo(int yachtId, string periodFrom, string periodTo)
        {
            CredentialsDto credentials = GetCredentials();
            ClientDto client = new ClientDto();
            client.name = "ime";
            client.surname = "prezime";
            client.company = "false";
            client.vatNr = "";
            client.address = "";
            client.zip = "";
            client.city = "";
            client.countryId = "1";
            client.email = "somebody@someone.some";
            client.phone = "";
            client.mobile = "";
            client.skype = "";

            InfoRequestDto request = new InfoRequestDto();
            request.client = client;
            request.credentials = credentials;
            request.periodFrom = periodFrom;
            request.periodTo = periodTo;
            request.yachtID = yachtId;
            request.onlinePayment = "false";
            request.numberOfPayments = "0";
            request.useDepositPayment = "false";

            string json = JsonConvert.SerializeObject(request);
            string url = "http://ws.nausys.com/CBMS-external/rest/booking/v6/createInfo/";
            string result = CallNauSysApi(url, json);
            InfoResponseDto response = JsonConvert.DeserializeObject<InfoResponseDto>(result);
            return response;
        }

        public OptionResponseDto CreateOption(int id, string uuid)
        {
            CredentialsDto credentials = GetCredentials();

            OptionRequestDto request = new OptionRequestDto();
            request.credentials = credentials;
            request.id = id;
            request.uuid = uuid;
            request.createWaitingOption = "false";

            string json = JsonConvert.SerializeObject(request);
            string url = "http://ws.nausys.com/CBMS-external/rest/booking/v6/createOption";
            string result = CallNauSysApi(url, json);
            OptionResponseDto response = JsonConvert.DeserializeObject<OptionResponseDto>(result);
            return response;
        }

        public OptionResponseDto StornoOption(int id, string uuid)
        {
            CredentialsDto credentials = GetCredentials();

            StornoRequestDto request = new StornoRequestDto();
            request.credentials = credentials;
            request.id = id;
            request.uuid = uuid;
     
            string json = JsonConvert.SerializeObject(request);
            //Console.WriteLine(json);
            string url = "http://ws.nausys.com/CBMS-external/rest/booking/v6/stornoOption";
            string result = CallNauSysApi(url, json);
            //Console.WriteLine(result);
            OptionResponseDto response = JsonConvert.DeserializeObject<OptionResponseDto>(result);
            return response;
        }

        public BookingResponseDto CreateBooking(int id, string uuid)
        {
            CredentialsDto credentials = GetCredentials();

            BookingRequestDto request = new BookingRequestDto();
            request.credentials = credentials;
            request.id = id;
            request.uuid = uuid;

            string json = JsonConvert.SerializeObject(request);
            string url = "http://ws.nausys.com/CBMS-external/rest/booking/v6/createBooking";
            string result = CallNauSysApi(url, json);
            BookingResponseDto response = JsonConvert.DeserializeObject<BookingResponseDto>(result);
            return response;
        }

        public BookingResponseDto StornoBooking(int id, string uuid)
        {
            CredentialsDto credentials = GetCredentials();

            BookingRequestDto request = new BookingRequestDto();
            request.credentials = credentials;
            request.id = id;
            request.uuid = uuid;

            string json = JsonConvert.SerializeObject(request);
            //Console.WriteLine(json);
            string url = "http://ws.nausys.com/CBMS-external/rest/booking/v6/stornoBooking";
            string result = CallNauSysApi(url, json);
            //Console.WriteLine(result);
            BookingResponseDto response = JsonConvert.DeserializeObject<BookingResponseDto>(result);
            return response;
        }

        public OptionsListResponseDto AllOptions(string periodFrom, string periodTo)
        {
            CredentialsDto credentials = GetCredentials();
            OptionsListRequestDto request = new OptionsListRequestDto();
            request.credentials = credentials;
            request.periodFrom = periodFrom;
            request.periodTo = periodTo;

            string json = JsonConvert.SerializeObject(request);
            //Console.WriteLine(json);
            string url = "http://ws.nausys.com/CBMS-external/rest/yachtReservation/v6/options";
            string result = CallNauSysApi(url, json);
            //Console.WriteLine(result);
            OptionsListResponseDto response = JsonConvert.DeserializeObject<OptionsListResponseDto>(result);
            return response;
        }

        public OptionsListResponseDto AllBookings(string periodFrom, string periodTo)
        {
            CredentialsDto credentials = GetCredentials();
            OptionsListRequestDto request = new OptionsListRequestDto();
            request.credentials = credentials;
            request.periodFrom = periodFrom;
            request.periodTo = periodTo;

            string json = JsonConvert.SerializeObject(request);
            //Console.WriteLine(json);
            string url = "http://ws.nausys.com/CBMS-external/rest/yachtReservation/v6/reservations";
            string result = CallNauSysApi(url, json);
            //Console.WriteLine(result);
            OptionsListResponseDto response = JsonConvert.DeserializeObject<OptionsListResponseDto>(result);
            return response;
        }


        public FreeYachtResponseDto FreeYacht(int yachtId, string periodFrom, string periodTo)
        {
            List<int> yachts = new List<int>();
            yachts.Add(yachtId);

            CredentialsDto credentials = GetCredentials();

            FreeYachtRequestDto request = new FreeYachtRequestDto();
            request.credentials = credentials;
            request.periodFrom = periodFrom;
            request.periodTo = periodTo;
            request.yachts = yachts;

            string json = JsonConvert.SerializeObject(request);
            string url = "http://ws.nausys.com/CBMS-external/rest/yachtReservation/v6/freeYachts";
            string result = CallNauSysApi(url, json);
            //Console.WriteLine(result);
            FreeYachtResponseDto response = JsonConvert.DeserializeObject<FreeYachtResponseDto>(result);
            return response;
        }


        public LocationsResponseDto Locations()
        {
            CredentialsDto credentials = GetCredentials();
            string json = JsonConvert.SerializeObject(credentials);
            string url = "http://ws.nausys.com/CBMS-external/rest/catalogue/v6/locations";
            string result = CallNauSysApi(url, json);
            LocationsResponseDto response = JsonConvert.DeserializeObject<LocationsResponseDto>(result);
            return response;
        }

        private string CallNauSysApi(string url, string json)
        {
            StringContent data = new StringContent(json, Encoding.UTF8, "application/json");

            string result = null;
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage httpsResponse = client.PostAsync(url, data).Result;
                result = httpsResponse.Content.ReadAsStringAsync().Result;
            }
            return result;
        }

        private CredentialsDto GetCredentials()
        {
            CredentialsDto credentials = new CredentialsDto();
            credentials.username = ShipConstants.Username;
            credentials.password = ShipConstants.Password;
            return credentials;
        }
    }
}
