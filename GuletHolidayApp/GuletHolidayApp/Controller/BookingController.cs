using GuletHolidayApp.DAO;
using GuletHolidayApp.Models;
using GuletHolidayApp.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuletHolidayApp.Controller
{
    class BookingController
    {
        public InfoResponseDto CreateOption(int yachtId, string periodFrom, string periodTo)
        {
            //pišemo API zahtjev te dohvaćamo info za rezervaciju
            InfoResponseDto response = null;
            try
            {
                NauSysApi nauSysApi = new NauSysApi();
                response = nauSysApi.CreateInfo(yachtId,periodFrom,periodTo);
                if (ShipConstants.OK.Equals(response.status))
                {
                    //za sda ne treba nista od Option responsa (oism statusa)
                    OptionResponseDto optResponse = nauSysApi.CreateOption(response.id, response.uuid);
                    response.status = optResponse.status;
                    Console.WriteLine(response.ToString());
                }
            }
            catch (Exception e)
            {
                response = new  InfoResponseDto();
                response.status = ShipConstants.ERROR + e.Message;
            }
            return response;
        }

        public OptionResponseDto StornoOption(int id, string periodFrom, string periodTo)
        {

            OptionResponseDto response = null;
            try
            {
                NauSysApi nauSysApi = new NauSysApi();
                OptionsListResponseDto listResponse = nauSysApi.AllOptions(periodFrom, periodTo);
                string uuid = GetUuid(listResponse.status, id, listResponse.reservations);

                response = nauSysApi.StornoOption(id, uuid);
                Console.WriteLine(response.ToString());

            }
            catch (Exception e)
            {
                response = new OptionResponseDto();
                response.status = ShipConstants.ERROR + e.Message;
            }
            return response;
        }

        public BookingResponseDto CreateBooking(int id, string periodFrom, string periodTo, string reservationType)
        {

            BookingResponseDto response = null;
            try
            {
                NauSysApi nauSysApi = new NauSysApi();
                OptionsListResponseDto listResponse = nauSysApi.AllOptions(periodFrom, periodTo);
                string uuid = GetUuid(listResponse.status, id, listResponse.reservations);

                response = nauSysApi.CreateBooking(id, uuid);
                Console.WriteLine(response.ToString());
            }
            catch (Exception e)
            {
                response = new BookingResponseDto();
                response.status = ShipConstants.ERROR + e.Message;
            }
            return response;
        }

        public BookingResponseDto StornoBooking(int id, string periodFrom, string periodTo)
        {

            BookingResponseDto response = null;
            try
            {
                NauSysApi nauSysApi = new NauSysApi();
                OptionsListResponseDto listResponse = nauSysApi.AllBookings(periodFrom, periodTo);
                string uuid = GetUuid(listResponse.status, id, listResponse.reservations);

                response = nauSysApi.StornoBooking(id, uuid);
                Console.WriteLine(response.ToString());

            }
            catch (Exception e)
            {
                response = new BookingResponseDto();
                response.status = ShipConstants.ERROR + e.Message;
            }
            return response;
        }

        private string GetUuid(string status, int id, List<UuidDto> reservations)
        {
            string uuid = null;
            if (ShipConstants.OK.Equals(status))
            {
                foreach (UuidDto dto in reservations)
                {
                    if (id == dto.id)
                    {
                        uuid = dto.uuid;
                        break;
                    }
                }
                if (uuid == null)
                {
                    throw new Exception(ShipConstants.ERROR + "UUID not found in ALL OPTIONS");
                }
            }
            else
            {
                throw new Exception(status);
            }
            return uuid;
        }

    }
}
