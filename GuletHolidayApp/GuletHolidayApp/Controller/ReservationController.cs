using GuletHolidayApp.DAO;
using GuletHolidayApp.Models;
using GuletHolidayApp.Utility;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuletHolidayApp.Controller
{
    class ReservationController
    {
        public ReservationResponseDto GetReservations(int yachtId, string year)
        {
            ReservationResponseDto response = null;
            try
            {
                NauSysApi nauSysApi = new NauSysApi();
                response = nauSysApi.Occupancy(year);

                if(ShipConstants.OK.Equals(response.status))
                {
                    List<ReservationDto> reservations = response.reservations;

                    //dohvati sve subote u godini
                    WeeksOfYear weeks = new WeeksOfYear();
                    List<ReservationDto> reservationsWeeks = weeks.GetWeeksOfYear(yachtId, year);

                    foreach (ReservationDto dto in reservations)
                    {
                        if (dto.yachtId == yachtId)
                        {
                            int index = reservationsWeeks.IndexOf(dto);
                            if (index > -1) //ako je -1, odbaci
                            {
                                ReservationDto x = reservationsWeeks[index];
                                x.id = dto.id;    //= je overrideano
                                x.locationFromId = dto.locationFromId;
                                x.locationToId = dto.locationToId;
                                x.reservationType = dto.reservationType;
                                x.checkInTime = dto.checkInTime;
                                x.checkOutTime = dto.checkOutTime;
                                x.optionValidTill = dto.optionValidTill;
                            }
                        }
                    }

                    //price
                    PriceController controller = new PriceController();
                    foreach (ReservationDto dto in reservationsWeeks)
                    {
                        PeriodPriceDto price = controller.GetPrice(yachtId, dto.periodFrom, dto.periodTo, dto.reservationType);
                        dto.priceListPrice = price.priceListPrice;
                        dto.clientPrice = price.clientPrice;                        
                    }
                    response.reservations = reservationsWeeks;
                }        
            }
            catch(Exception e)
            {
                response = new ReservationResponseDto();
                response.status = ShipConstants.ERROR + e.Message;
            }
            return response;
        }
    }
}
