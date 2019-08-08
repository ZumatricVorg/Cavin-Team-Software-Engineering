using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEclinicSystem
{
    public partial class ReportViewPrint : Form
    {
        ReportHandler rh = new ReportHandler();
        Report r = new Report();
        OverSurgerySystem run = new OverSurgerySystem();


        public ReportViewPrint(Report report)
        {
            r = report;
            InitializeComponent();
            setReport();
        }

        private void setReport()
        {
            DataTable dt = run.getLocalSQLData("SELECT [name] as patientName FROM [Patient] WHERE patientID = '" + r.Patient.PatientID + "' ORDER BY [patientID] ASC");

            if (dt.Rows.Count > 0)
            {
                r.Patient.Name = dt.Rows[0]["patientName"].ToString();               
            }
            webBrowser1.DocumentText = "<!DOCTYPE html>" +
                                        "<html>" +
                                        "<head><title>Report</title></head>" +
                                        "<body>" +
                                        "<p><b>Report ID: </b>" + r.ReportID + "</p>" +
                                        "<p><b>Appointment ID: </b>" + r.Appointment.AppointmentID + "</p>" +
                                        "<p><b>Date: </b>" + r.Appointment.Date.ToString() + "</p>" +
                                        "<p><b>Patient's Name: </b>" + r.Patient.Name + "</p>" +
                                        "<p><b>GP's Name: </b>" + r.Staff.FullName + "</p>" +
                                        "<p><b>Description: </b>" + r.Description.Replace("/n/r", "<br>") + "</p>" +
                                        "<p><b>Remarks: </b>" + r.Remarks.Replace("/n/r", "<br>") + "</p>" +
                                        "<body>" +
                                        "<html>";
           
        }

        //print report
        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            // Displays the Print dialog box.
            webBrowser1.ShowPrintDialog(); //reference:https://msdn.microsoft.com/en-us/library/3s8ys666(v=vs.100).aspx
        }

        //back button
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            var rs = new ReportSearch(r.Patient);
            rs.Show();
        }
    }
}
