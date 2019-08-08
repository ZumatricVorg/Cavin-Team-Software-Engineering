using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEclinicSystem
{    
    public class ReportHandler
    {
        OverSurgerySystem run = new OverSurgerySystem();

        //add new report
        public int addReport(Report report)
        {
            string rrsql = @"INSERT INTO [Report] ([appointmentID],[staffID],[patientID],[description],[remarks]) VALUES ('" + report.Appointment.AppointmentID + "','" + report.Staff.StaffID + "','" + report.Patient.PatientID + "','" + report.Description.Replace("/", "//") + "','" + report.Remarks.Replace("/", "//") + "')";
            return run.WriteData(rrsql);
        }

    }
}
