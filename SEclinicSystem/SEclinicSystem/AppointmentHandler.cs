using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEclinicSystem
{
    public class AppointmentHandler
    {
       
        OverSurgerySystem dbCon = new OverSurgerySystem();
        int result;

        public string book(string pID,string id,Appointment app)
        {
            // result = dbCon.WriteData("INSERT INTO Appointment(staffID, startTime, startDate, Cstatus, remark) VALUES('1', '" + app.Time + "','" + app.Date.Date + "', 'pending', '" + app.Remark + "')");
            result = dbCon.WriteData("INSERT INTO Appointment(staffID, startTime, startDate, Cstatus, remark, patientID) VALUES('" + id + "', '" + app.Time.ToString("hh:mm tt") + "','" + app.Date.ToString("yyyy-MM-dd") + "', 'pending', '" + app.Remark + "',"+pID+")");

            if (result == 1)
            {
                return "Appointment Success registered";
            }else
            {
                return "Failed to register appoinment";
            }


        }

        public bool change()
        {
            return true;
        }

        public int check(string id, Appointment app)
        {          
           result = dbCon.getLocalSQLDataCount("SELECT COUNT(*) FROM Appointment"
                                               +" WHERE staffID = '"+id+"' AND Cstatus != 'completed'"
                                               +" AND startDate = '" + app.Date.ToString("yyyy-MM-dd") + "'" 
                                               +" AND startTime = '"+ app.Time.ToString("hh:mm tt") + "'");
            return result;
        }

        private void cancel()
        {

        }

        public DataTable selectGpAppointment(Staff staff)
        {
            DataTable dt = new DataTable();
            dt = dbCon.getLocalSQLData("SELECT s.name as Name,a.startTime as Time,a.startDate as Date,a.Cstatus as Status,a.remark as Remark" 
                                       +" FROM Appointment as a INNER JOIN Staff as s ON a.staffID = s.staffID"
                                       +" WHERE s.name = '"+staff.FullName+"'");

            return dt;
        }

        public DataTable selectAllApt()
        {
            DataTable dt = new DataTable();
            dt = dbCon.getLocalSQLData("SELECT s.name as Name,a.startTime as Time,a.startDate as Date,a.Cstatus as Status,a.remark as Remark"
                                       +" FROM Appointment as a INNER JOIN Staff as s ON a.staffID = s.staffID");

            return dt;
        }

        public void updateAllApt()
        {
           dbCon.getLocalSQLData("UPDATE Appointment SET status = 'completed' WHERE status = 'pending'"
                                 +" AND startTime +20 minutes < now()");

        }
    }
}
