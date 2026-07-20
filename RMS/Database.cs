using System;
using System.Data.SqlClient;

namespace RMS
{
    public static class Database
    {
        // Change C:\RMS to wherever you copy the RMS.mdf file on your C drive.
        public static string connectionString =
            @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\RMS\RMS.mdf;Integrated Security=True;Connect Timeout=30";

        public static SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection(connectionString);
            return con;
        }
    }
}
