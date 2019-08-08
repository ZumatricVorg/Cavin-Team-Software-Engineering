using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SEclinicSystem;
using System.Data;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTestPrescriptionHandler
    {
        [TestMethod]
        public void TestaddPrescription()
        {
            Prescription prescription = new Prescription();
            PrescriptionHandler pHlr = new PrescriptionHandler();
             
            prescription.Appointment.AppointmentID = "1";
            prescription.Medicine.MedicineID = "1";
            prescription.Staff.StaffID = "2";
            prescription.Patient.PatientID = "1";
            prescription.EndDate = Convert.ToDateTime("12/12/12");

           int resp = pHlr.addPrescription(prescription);
            Assert.IsNotNull(resp);
        }

        [TestMethod]
        public void TestextendPrescription()
        {
            Prescription prescription = new Prescription();
            PrescriptionHandler pHlr = new PrescriptionHandler();

            prescription.Appointment.AppointmentID = "1";
            prescription.Medicine.MedicineID = "1";
            prescription.Staff.StaffID = "2";
            prescription.Patient.PatientID = "1";
            prescription.EndDate = Convert.ToDateTime("12/12/12");

            int resp = pHlr.addPrescription(prescription);
            Assert.IsNotNull(resp);
        }

        [TestMethod]
        public void TestcheckPrescriptionLimit()
        {
            Prescription prescription = new Prescription();
            PrescriptionHandler pHlr = new PrescriptionHandler();

            prescription.Medicine.MedicineID = "1";
            bool resp = pHlr.checkPrescriptionLimit(prescription);
            Assert.AreEqual(true, resp);
        }

        [TestMethod]
        public void TestretrivePrescription()
        {
            Prescription prescription = new Prescription();
            PrescriptionHandler pHlr = new PrescriptionHandler();

            prescription.PrescriptionID = "1";
            DataTable resp = pHlr.retrivePrescription(prescription);
            Assert.IsNotNull(resp);
        }
        

    }
}
