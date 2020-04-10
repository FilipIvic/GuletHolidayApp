using System.Data.SqlClient;

namespace GuletHolidayApp.DAO
{
    class MySQLConn
    {
        private static SqlConnection conn = null;

        public static SqlConnection GetConnection()
        {
            string connectionString = @"Data Source = lukastroliga.database.windows.net; Initial Catalog = Kviz; User ID = Luka; Password = Split021";
            conn = new SqlConnection(connectionString);
            return conn;
        }

        public static void Close(SqlConnection  conn)
        {
            if (conn != null)
                conn.Close();
        }

        public static void Close(SqlDataReader dataReader)
        {
            if (dataReader != null)
                dataReader.Close();
        }

        public static void Dispose(SqlCommand command)
        {
            if (command != null)
                command.Dispose();
        }
    }
}
