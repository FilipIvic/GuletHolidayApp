using GuletHolidayApp.DAO;
using GuletHolidayApp.Models;
using GuletHolidayApp.Utility;
using System;
using System.Data.SqlClient;

namespace GuletHolidayApp.Controller
{
    class UserController
    {
        public UserResponseDto GetUser(string username, string password)
        {
            UserResponseDto response = new UserResponseDto();

            SqlConnection conn = null;
            try
            {
                conn = MySQLConn.GetConnection();
                conn.Open();
                ShipSQL sql = new ShipSQL(conn);
                response = sql.GetUser(username, password);
            }
            catch (Exception e)
            {
                response.status = ShipConstants.NOK;
                response.message = ShipConstants.SYSTEM_ERROR;
            }
            finally
            {
                MySQLConn.Close(conn);
            }
            return response;
        }
    }
}
