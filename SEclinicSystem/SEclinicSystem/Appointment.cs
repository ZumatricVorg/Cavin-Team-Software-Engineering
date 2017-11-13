using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEclinicSystem
{
    class Appointment
    {
        const string Cstate = "complete";
        private string inputTime;
        private DateTime inputDate = new DateTime();
        private string patientName;
        private string gpName;
        OverSurgerySystem dbCon = new OverSurgerySystem();
        int result;

        public void setDate(DateTime d)
        {
            this.inputDate = d;
        }

        public DateTime getDate()
        {
            return this.inputDate;
        }

        public void setTime(string t)
        {
            this.inputTime = t;
        }

        public string getTime()
        {
            return this.inputTime;
        }

        public bool book(string id, string time,DateTime date,string remark)
        {
            result = dbCon.WriteData("INSERT INTO Appointment(staffID, startTime, startDate, Cstatus, remark) VALUES('"+id+"', '" + time + "','" + date + "', 'pending', '" + remark + "')");

            if (result == 1)
            {
                return true;
            }else
            {
                return false;
            }
           
        }

        private bool change()
        {
            return true;
        }

        public void check(string id, DateTime date, string time)
        {
            
            result = dbCon.getLocalSQLDataCount("SELECT COUNT(*) FROM Appointment WHERE staffID = '"+id+"' AND Cstatus != '"+Cstate+"' AND startTime = '"+time+"' AND startDate = '"+date+"'");
            //SELECT staffID, startTime, startDate FROM Appointment WHERE staffID = '1' AND Cstatus != 'completed' AND startTime = '10:20:00' AND startDate = '2017-09-11';
        }

        private void cancel()
        {

        }
    }
}
