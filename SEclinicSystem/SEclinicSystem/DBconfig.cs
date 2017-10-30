using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEclinicSystem
{
    class DBconfig
    {
        // Create the connectionString
        // Trusted_Connection is used to denote the connection uses Windows Authentication
        SqlConnection cnn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\LENOVO\Documents\OverSurgery.mdf; Integrated Security = True; Connect Timeout = 30");

        public void selectAll()
        {
            
            SqlCommand command = new SqlCommand("SELECT * FROM Position", cnn);

            cnn.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string a = reader["positionName"].ToString();
            }

            cnn.Close();
        }
       
    }
}
