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
        DBconfig dbcon = new DBconfig();
        Staff staff = new Staff();
        DataTable dtResult = new DataTable();
        Int32 result;

        public bool login(string loginID, string password)
        {
            result = dbcon.getLocalSQLDataCount("SELECT COUNT(*) FROM login where username ='" + loginID + "' AND password = '" + password + "'");
            //SqlDataReader reader = command.ExecuteReader();
           
            if(result > 0)
            {
                return true;
            }

            return false;
        }

        public Staff credential(string id)
        {
            dtResult = dbcon.getLocalSQLData("select * from login inner join Staff ON login.staffID = staff.staffID WHERE login.username ='" + id + "'");
            staff.fullName = dtResult.Rows[0]["name"].ToString();
            staff.staffID = dtResult.Rows[0]["staffID"].ToString();
            return staff;
            
        }

       

        private void checkAndPrintResult()
        {

        }

        private void extendPrinscription()
        {

        }
    }


}

