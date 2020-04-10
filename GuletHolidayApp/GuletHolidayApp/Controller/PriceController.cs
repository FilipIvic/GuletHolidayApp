using GuletHolidayApp.DAO;
using GuletHolidayApp.Models;
using GuletHolidayApp.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuletHolidayApp.Controller
{
    public class PriceController
    {
        public PeriodPriceDto GetPrice(int yachtId, string periodFrom, string periodTo, string reservationType)
        {

            //step1 check for price
            PeriodPriceDto price = ShipVariables.PeriodPrice.Find(
            delegate(PeriodPriceDto pp)
            {
                return pp.periodFrom.Equals(periodFrom);
            }
            );

            //step2 call api if price does not exist
            if (price == null)
            {
                Console.WriteLine("periodFrom:" + periodFrom);

                price = new PeriodPriceDto();
                price.periodFrom = periodFrom;

                if (ShipConstants.ReservationTypeFree.Equals(reservationType))
                {
                    try
                    {
                        NauSysApi nauSysApi = new NauSysApi();
                        FreeYachtResponseDto responseDto = nauSysApi.FreeYacht(yachtId, periodFrom, periodTo);
                        List<FreeYachtDto> freeYachts = responseDto.freeYachts;
                        FreeYachtDto yachtdto = freeYachts[0];

                        price.priceListPrice = yachtdto.price.priceListPrice;
                        price.clientPrice = yachtdto.price.clientPrice;
                    }
                    catch (Exception e)
                    {
                        //for just case for OPTION and RESERVATION
                        price.clientPrice = "0.00";
                        price.priceListPrice = "0.00";
                    }
                }
                else
                {
                    //for just case for OPTION and RESERVATION
                    price.clientPrice = "0.00";
                    price.priceListPrice = "0.00";
                }
                ShipVariables.PeriodPrice.Add(price);
            }
            return price;
        }
    }
}
