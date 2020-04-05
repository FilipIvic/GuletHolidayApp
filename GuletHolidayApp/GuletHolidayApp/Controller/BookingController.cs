using GuletHolidayApp.DAO;
using GuletHolidayApp.Models;
using GuletHolidayApp.Utility;
using System;
using System.Collections.Generic;

namespace GuletHolidayApp.Controller
{
    class BookingController
    {
        public OptionResponseDto CreateOption(int yachtId, string periodFrom, string periodTo)
        {
            OptionResponseDto response = null;
            try
            {
                NauSysApi nauSysApi = new NauSysApi();
                InfoResponseDto infoResponse = nauSysApi.CreateInfo(yachtId,periodFrom,periodTo);
                if (ShipConstants.OK.Equals(infoResponse.status))
                {
                    response = nauSysApi.CreateOption(infoResponse.id, infoResponse.uuid);
                }
                else
                {
                    response = new OptionResponseDto();
                    response.status = ShipConstants.ERROR + infoResponse.status;
                }
            }
            catch (Exception e)
            {
                response = new  OptionResponseDto();
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
            }
            catch (Exception e)
            {
                response = new OptionResponseDto();
                response.status = ShipConstants.ERROR + e.Message;
            }
            return response;
        }


        public BookingResponseDto CreateBooking(int id, string periodFrom, string periodTo, string reservationType, int yachtId)
        {
            BookingResponseDto response = null;
            try
            {
                NauSysApi nauSysApi = new NauSysApi();
                if(ShipConstants.ReservationTypeOption.Equals(reservationType))
                {
                    OptionsListResponseDto listResponse = nauSysApi.AllOptions(periodFrom, periodTo);
                    string uuid = GetUuid(listResponse.status, id, listResponse.reservations);
                    response = nauSysApi.CreateBooking(id, uuid);
                }
                else
                {
                    InfoResponseDto infoResponse = nauSysApi.CreateInfo(yachtId, periodFrom, periodTo);
                    if (ShipConstants.OK.Equals(infoResponse.status))
                    {
                        OptionResponseDto optionResponse = nauSysApi.CreateOption(infoResponse.id, infoResponse.uuid);
                        if (ShipConstants.OK.Equals(optionResponse.status))
                        {
                            response = nauSysApi.CreateBooking(infoResponse.id, infoResponse.uuid);
                        }
                        else
                        {
                            response = new BookingResponseDto();
                            response.status = ShipConstants.ERROR + optionResponse.status;
                        }
                    }
                    else
                    {
                        response = new BookingResponseDto();
                        response.status = ShipConstants.ERROR + infoResponse.status;
                    }
                }
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
                throw new Exception(ShipConstants.ERROR + status);
            }
            return uuid;
        }
    }
}
