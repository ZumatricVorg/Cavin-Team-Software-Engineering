using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEclinicSystem
{
    class OverSurgerySystem
    {
       
        Staff staff = new Staff();
        DataTable dtResult = new DataTable();
        Int32 result;

        // Create the connectionString
        // Trusted_Connection is used to denote the connection uses Windows Authentication

        //"Integrated Security=SSPI;Persist Security Info=False;Data Source=.\\SQLEXPRESS;Initial Catalog=OverSurgery;";
        static string c = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\LENOVO\Documents\OverSurgery.mdf; Integrated Security = True; Connect Timeout = 30";
        SqlConnection cnn = new SqlConnection(c);
        Log log = new Log();

        //retrive data
        public DataTable getLocalSQLData(string query)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(c))
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.CommandTimeout = 0;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    //  Log("WEB", "getLocalSQLData", "query: " + query);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                log.writeLog("WEB", "getLocalSQLData", "query: " + query + " ; Err :" + ex.ToString());
                //  MessageBox.Show(ex.ToString());
                return null;
            }
            finally
            { }
        }

        //retrieve count data
        public Int32 getLocalSQLDataCount(string query)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(c))
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.CommandTimeout = 0;

                    Int32 count = (Int32)cmd.ExecuteScalar();
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    //  Log("WEB", "getLocalSQLData", "query: " + query);
                    return count;
                }
            }
            catch (Exception ex)

            {
                log.writeLog("WEB", "getLocalSQLData", "query: " + query + " ; Err :" + ex.ToString());
                //  MessageBox.Show(ex.ToString());

                return 0;
            }
            finally
            { }
        }


        //write data
        public int WriteData(string query)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(c))
                {
                    int x = 0;

                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;

                    cmd.CommandTimeout = 0;

                    x = cmd.ExecuteNonQuery(); //returns row affected

                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }

                    conn.Dispose();

                    return x;
                }
            }
            catch (Exception ex)
            {
                log.writeLog("WEB", "WriteDBLog", "Err :" + ex.ToString());
                return 0;
            }
            finally
            {
            }

        }

        public bool login(string loginID, string password)
        {
            result = getLocalSQLDataCount("SELECT* FROM login where username = '"+ loginID + "' AND password = '"+ password + "'");
            
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public Staff credential(string id)
        {

             dtResult = getLocalSQLData("SELECT * FROM login INNER JOIN Staff on login.staffID = Staff.staffID WHERE login.username = '" + id+"'");
             staff.staffID = dtResult.Rows[0]["staffID"].ToString();
             staff.fullName = dtResult.Rows[0]["name"].ToString();
             return staff;

        }

        private bool schedualeAppointment()
        {
            return true;
        }
        private string searchPatient(string patientID = "", string name = "", DateTime dateOfBirth = new DateTime(), string address = "")
        {
            if (patientID != "")
            {
                //filter with patientID
            }
            else if (name != "" && dateOfBirth != new DateTime())
            {
                //filter with name and dateOfBirth
            }
            else if (name != "" && address != "")
            {
                //filter with name and address
            }
            else
            {
                //no result
            }
            return "";

        }
      
        private void checkAndPrintResult()
        {

        }

        private void extendPrinscription()
        {

        }
    }


}

