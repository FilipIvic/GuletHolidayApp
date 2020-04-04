using GuletHolidayApp.DAO;
using GuletHolidayApp.Models;
using GuletHolidayApp.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuletHolidayApp.Controller
{
    class CreateController
    {
        public InfoResponseDto GetInfo(int yachtId, string periodFrom, string periodTo)
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
    }
}
