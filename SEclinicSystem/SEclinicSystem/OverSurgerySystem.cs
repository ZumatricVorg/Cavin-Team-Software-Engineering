using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;
using System.Configuration;
using System.IO;


namespace SEclinicSystem
{
    class OverSurgerySystem
    {
        private static OverSurgerySystem instance;
        // Create the connectionString
        // Trusted_Connection is used to denote the connection uses Windows Authentication
        //"Integrated Security=SSPI;Persist Security Info=False;Data Source=.\\SQLEXPRESS;Initial Catalog=OverSurgery;";
        Log log = new Log();

        public static OverSurgerySystem Instance
        {
            get
            {
                if (instance == null) 
                {
                    instance = new OverSurgerySystem();
                }
 
                return instance;
            }
        }
        public SqlConnection connectToDB()
        {
            
            string c = "Integrated Security=SSPI;Persist Security Info=False;Data Source=.\\SQLEXPRESS;Initial Catalog=OverSurgery;";
            SqlConnection conn = new SqlConnection(c);

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            
            return conn;
        }

        //retrive data
        public DataTable getLocalSQLData(string query)
        {
            try
            {
                using (SqlConnection conn = OverSurgerySystem.Instance.connectToDB() )
                {
                   
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.CommandTimeout = 0;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    da.Fill(dt);
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

                using (SqlConnection conn = OverSurgerySystem.Instance.connectToDB())
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.CommandTimeout = 0;

                    Int32 count = (Int32)cmd.ExecuteScalar();
     
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
                using (SqlConnection conn = OverSurgerySystem.Instance.connectToDB())
                {
                    int x = 0;

                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;

                    cmd.CommandTimeout = 0;

                    x = cmd.ExecuteNonQuery(); //returns row affected
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

    }
}

