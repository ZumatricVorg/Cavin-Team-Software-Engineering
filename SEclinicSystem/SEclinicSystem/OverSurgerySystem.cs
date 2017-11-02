using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            result = dbcon.getLocalSQLDataCount("SELECT* FROM login where username = '"+ loginID + "' AND password = '"+ password + "'");
            
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public Staff credential(string id)
        {

             dtResult = dbcon.getLocalSQLData("SELECT * FROM login INNER JOIN Staff on login.staffID = Staff.staffID WHERE login.username = '" + id+"'");
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

