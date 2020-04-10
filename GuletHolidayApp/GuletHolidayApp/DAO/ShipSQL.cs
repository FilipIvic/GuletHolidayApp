using GuletHolidayApp.Models;
using GuletHolidayApp.Test;
using GuletHolidayApp.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GuletHolidayApp.DAO
{
    class ShipSQL
    {
        private SqlConnection conn = null;

        public ShipSQL(SqlConnection conn)
        {
            this.conn = conn;
        }

        internal UserResponseDto GetUser(string username, string password)
        {
            UserResponseDto response = new UserResponseDto();

            string sqlQuery = "select ID, username, password, ime, prezime, yachtID, yachtName " +
                "from Bloem_Users " +
                "where username = '" + username + "' " +
                "and password = '" + password + "' ";

            //Console.WriteLine(sqlQuery);

            SqlCommand command = null;
            SqlDataReader dataReader = null;
            try
            {
                command = new SqlCommand(sqlQuery, conn);
                dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    UserDto user = new UserDto();
                    user.SetId(dataReader.GetInt32(0));
                    user.SetUsername(dataReader.GetString(1));
                    user.SetPassword(dataReader.GetString(2));
                    user.SetFirstName(dataReader.GetString(3));
                    user.SetLastName(dataReader.GetString(4));
                    user.SetYachtId(dataReader.GetInt32(5));
                    user.SetYachtName(dataReader.GetString(6));
                    //Console.WriteLine(user.ToString());
                    response.status = ShipConstants.OK;
                    response.user = user;
                }
                else
                {
                    response.status = ShipConstants.NOK;
                    response.message = "Wrong username/password!";
                }
            }
            catch (SqlException e)
            {
                response.status = ShipConstants.NOK;
                response.message = e.Message;
            }
            finally
            {
                MySQLConn.Close(dataReader);
                MySQLConn.Dispose(command);
            }
            return response;
        }

        /*Get all users from database
         * 
        public List<UserDto> GetListUsers()
        {
            List<UserDto> listUsers = new List<UserDto>();
            string sqlQuery = "select ID, username, password, ime, prezime, yachtID, yachtName " +
                "from Bloem_Users";
            SqlCommand command = new SqlCommand(sqlQuery, conn);
            SqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                UserDto dto = new UserDto();
                dto.SetId(dataReader.GetInt32(0));
                dto.SetUsername(dataReader.GetString(1));
                dto.SetPassword(dataReader.GetString(2));
                dto.SetFirstName(dataReader.GetString(3));
                dto.SetLastName(dataReader.GetString(4));
                dto.SetYachtId(dataReader.GetInt32(5));
                dto.SetYachtName(dataReader.GetString(6));
                listUsers.Add(dto);

                Console.WriteLine(dto.ToString());
                string output = JsonConvert.SerializeObject(dto);
                Console.WriteLine(output);
            }

            dataReader.Close();
            command.Dispose();

            UserJSON user = new UserJSON();
            string outputx = JsonConvert.SerializeObject(user);
            Console.WriteLine(outputx);

            return listUsers;
        }*/

        

        /* Get USER by ID
         * 
        public UserResponseDto GetUser(int userId)
        {
            UserResponseDto response = new UserResponseDto();
            string sqlQuery = "select ID, username, password, ime, prezime, yachtID, yachtName " +
                "from Bloem_Users " +
                "where ID = " + userId.ToString();

            SqlCommand command = null;
            SqlDataReader dataReader = null;
            try
            {
                command = new SqlCommand(sqlQuery, conn);
                dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    UserDto user = new UserDto();
                    user.SetId(dataReader.GetInt32(0));
                    user.SetUsername(dataReader.GetString(1));
                    user.SetPassword(dataReader.GetString(2));
                    user.SetFirstName(dataReader.GetString(3));
                    user.SetLastName(dataReader.GetString(4));
                    user.SetYachtId(dataReader.GetInt32(5));
                    user.SetYachtName(dataReader.GetString(6));
                    //Console.WriteLine(user.ToString());
                    response.status = ShipConstants.OK;
                    response.user = user;
                }
                else
                {
                    response.status = ShipConstants.NOK;
                    response.message = "Wrong username/password!";
                }
            }
            catch (SqlException e)
            {
                response.status = ShipConstants.NOK;
                response.message = e.Message;
            }
            finally
            {
                MySQLConn.Close(dataReader);
                MySQLConn.Dispose(command);
            }

            return response;
        }
        */

    }
}
