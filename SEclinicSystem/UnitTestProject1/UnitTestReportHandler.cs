using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SEclinicSystem;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTestReportHandler
    {
        [TestMethod]
        public void TestaddReport()
        {
            Report report = new Report();
            ReportHandler rHlr = new ReportHandler();

            report.Appointment.AppointmentID = "1";
            report.Staff.StaffID = "2";
            report.Patient.PatientID = "1";
            report.Description = "Hello Test";
            report.Remarks = "Testing";

            int resp = rHlr.addReport(report);

            Assert.IsNotNull(resp);

        }
    }
}
