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
            result = dbCon.WriteData("INSERT INTO Appointment(staffID, startTime, startDate, Cstatus, remark, patientID, message) VALUES('" + id + "', '" + app.Time.ToString("hh:mm tt") + "','" + app.Date.ToString("yyyy-MM-dd") + "', 'pending', '" + app.Remark + "','"+pID+"','"+ app.Msg +"')");

            if (result == 1)
            {
                return "Appointment Success registered";
            }else
            {
                return "Failed to register appoinment";
            }

        }

        public DataTable aptGP(string aID)
        {
            DataTable dt = new DataTable();
         
            dt = dbCon.getLocalSQLData("SELECT s.staffID,s.name FROM Appointment as a INNER JOIN [OverSurgery].[dbo].Staff as s ON s.staffID = a.staffID WHERE Id = '" + aID + "'");

            return dt;
        }

        public string change(Appointment app)
        {
            result = dbCon.WriteData("UPDATE Appointment SET startDate ='"+app.Date.ToString("yyyy-MM-dd")+"',startTime ='"+app.Time.ToString("hh:mm tt") + "' WHERE Id = '"+app.AppointmentID+"'");

            if(result == 1)
            {
                return "Update Succesfull";
            }else
            {
                return "Update Failed";
            }
           
        }


        public int check(string id, Appointment app)
        {          
           result = dbCon.getLocalSQLDataCount("SELECT COUNT(*) FROM Appointment"
                                               +" WHERE staffID = '"+id+"' AND Cstatus != 'completed'"
                                               +" AND startDate = '" + app.Date.ToString("yyyy-MM-dd") + "'" 
                                               +" AND startTime = '"+ app.Time.ToString("hh:mm tt") + "'");
            return result;
        }

        public void cancel(Appointment app)
        {
            result = dbCon.getLocalSQLDataCount("DELETE Appointment WHERE Id = '" + app.AppointmentID + "'");

        }

        public DataTable selectGpAppointment(Staff staff,Appointment app)
        {
            DataTable dt = new DataTable();
            dt = dbCon.getLocalSQLData("SELECT s.name as Name,a.startTime as Time,a.startDate as Date,a.Cstatus as Status,a.remark as Remark,a.message as Message"
                                       + " FROM Appointment as a INNER JOIN Staff as s ON a.staffID = s.staffID"
                                       +" WHERE s.name = '"+staff.FullName+"' AND a.startDate ='"+ app.Date.ToString("yyyy-MM-dd") + "' ");

            return dt;
        }

        public DataTable checkAllApt()
        {
            DataTable dt = new DataTable();
            dt = dbCon.getLocalSQLData("SELECT * FROM Appointment");


            return dt;
        }

        public DataTable selectAllApt()
        {
            DataTable dt = new DataTable();
            dt = dbCon.getLocalSQLData("SELECT a.Id,s.name as GP,s2.name as Nurse,a.startTime as Time,a.startDate as Date,a.Cstatus as Status,a.remark as Remark,a.message as Message"
                                       + " FROM Appointment as a INNER JOIN Staff as s ON a.staffID = s.staffID"
                                       +" INNER JOIN OverSurgery.dbo.Staff as s2 ON a.nurseID = s2.staffID"
                                       + " WHERE a.Cstatus = 'pending' AND a.startDate = CAST(GETDATE() as DATE) ORDER BY startDate DESC");

            return dt;
        }

        public DataTable selectAllNurseApt(Staff staff)
        {
            DataTable dt = new DataTable();
            dt = dbCon.getLocalSQLData("SELECT a.Id,s.name as Name,a.startTime as Time,a.startDate as Date,a.Cstatus as Status,a.remark as Remark,a.message as Message"
                                       + " FROM Appointment as a INNER JOIN Staff as s ON a.nurseID = s.staffID WHERE a.Cstatus = 'pending' AND s.staffID = '"+staff.StaffID+ "' AND a.startDate = CAST(GETDATE() as DATE) ORDER BY startDate DESC");

            return dt;
        }

        public void updateAllApt()
        {
           dbCon.WriteData("UPDATE Appointment SET Cstatus = 'completed'"
                           +" WHERE Cstatus = 'pending' AND"
                           +" DATEADD(MINUTE, 30, CONVERT(DATETIME, CONVERT(CHAR(8), startDate, 112)"
                           +"+' ' + CONVERT(CHAR(8), startTime, 108))) < SYSDATETIME()");


        }
    }
}
