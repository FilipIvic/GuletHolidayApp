using GuletHolidayApp.DAO;
using GuletHolidayApp.Models;
using GuletHolidayApp.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace GuletHolidayApp.Controller
{
    class UserController
    {
        public UserResponseDto GetUser(int idUser)
        {
            UserResponseDto response = new UserResponseDto();
            
            SqlConnection conn = null;
            try
            {
                conn = MySQLConn.GetConnection();
                conn.Open();
                ShipSQL sql = new ShipSQL(conn);
                response = sql.GetUser(idUser);
            }
            catch (Exception e)
            {
                response.status = ShipConstants.NOK;
                response.message = e.Message;
            }
            finally
            {
                if (conn != null)
                    conn.Close();      
            }
            return response;
        }

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
                response.message = "Data base connection error!";
            }
            finally
            {
                MySQLConn.close(conn);
            }
            return response;
        }
    }
}
