using System;
using System.Collections.Generic;
using System.Data;
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
        static String cnString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\LENOVO\Documents\OverSurgery.mdf; Integrated Security = True; Connect Timeout = 30";
        SqlConnection cnn = new SqlConnection(cnString);
        DataTable dt = new DataTable();
        SqlDataAdapter da;
        SqlDataReader reader;

        public bool login(string id, string password)
        {
            
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM login where username ='"+id+"' AND password = '"+password+"'", cnn);
            cnn.Open();
            //SqlDataReader reader = command.ExecuteReader();
            Int32 count = (Int32)command.ExecuteScalar();
            cnn.Close();

            if (count == 1)
            {
                return true;
            }else
            {
                return false;
            }     
           
        }

        public Staff credential(string id)
        {
            Staff staff = new Staff();
            SqlCommand command = new SqlCommand("select * from login inner join Staff ON login.staffID = staff.staffID WHERE login.username ='" + id + "'", cnn);

            
            cnn.Open();
            reader = command.ExecuteReader();
            //da = new SqlDataAdapter(command);
            //da.Fill(dt);
            while (reader.Read())
            {
                staff.fullName = reader[5].ToString();
                staff.staffID = reader[1].ToString();
            }

            cnn.Close();
            return staff;
        }
       
    }
}
