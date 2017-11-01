using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEclinicSystem
{
    class Receptionist : Staff
    {

        public string loginID;
        private string password;

        public void SetloginID(string id)
        {
          
            this.loginID = id;
        }

        public string GetloginID()
        {
            return this.loginID;
        }

        public void SetPassword(string pw)
        {
            this.password = pw;
        }

        public string GetPassword()
        {
            return this.password;
        }


        private bool registerPatient(string name, string dob, string address)
        {
            return true;
        }

        private string checkDuty(DateTime searchDate, string staffID)
        {
            return "";
        }

    }
}
