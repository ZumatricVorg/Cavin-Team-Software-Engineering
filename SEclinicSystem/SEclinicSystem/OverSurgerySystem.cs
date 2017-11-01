using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEclinicSystem
{
    class OverSurgerySystem
    {
        DBconfig dbcon = new DBconfig(); 

        public bool login(string loginID, string password)
        {
            bool access = dbcon.login(loginID, password);
            return access;
        }

        public Staff credential(string id)
        {

            return dbcon.credential(id);
            
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

