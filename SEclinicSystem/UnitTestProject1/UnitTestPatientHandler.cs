using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SEclinicSystem;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTestPatientHandler
    {
        [TestMethod]
        public void TestupdatePatientDetails()
        {
            Patient p = new Patient();
            PatientHandler pHldr = new PatientHandler();

            p.PatientID = "1";
            p.Address = "abc";
            p.DOB1 = Convert.ToDateTime("12/12/12");
            p.Email = "a@gmail.com";
            p.NRIC1 = "441221-11-1234";
            p.PhoneNo = "013946574";
            p.Name = "elden";
            p.Gender = "Male";

            string resp = pHldr.updatePatientDetails(p);
            Assert.AreEqual("Y", resp);
            
        }
        [TestMethod]
        public void TestRegisterPatient()
        {
            Patient p = new Patient();
            PatientHandler pHldr = new PatientHandler();

            p.PatientID = "1";
            p.Address = "abc";
            p.DOB1 = Convert.ToDateTime("12/12/12");
            p.Email = "a@gmail.com";
            p.NRIC1 = "441221-11-1234";
            p.PhoneNo = "013946574";
            p.Name = "elden";
            p.Gender = "Male";

            string resp = pHldr.registerPatient(p);
            Assert.IsNotNull(resp);

        }

        [TestMethod]
        public void TestSearchPatient()
        {
            Patient p = new Patient();
            PatientHandler pHldr = new PatientHandler();

            p.PatientID = "1";
            p.Address = "";
            p.DOB1 = new DateTime();
            p.Email = "";
            p.NRIC1 = "";
            p.PhoneNo = "" ;
            p.Name = "";
            p.Gender = "";
            //p.Address = "abc";
            //p.DOB1 = Convert.ToDateTime("12/12/12");
            //p.Email = "a@gmail.com";
            //p.NRIC1 = "441221-11-1234";
            //p.PhoneNo = "013946574";
            //p.Name = "elden";
            //p.Gender = "Male";

            string resp = pHldr.searchPatient(p);
            Assert.AreEqual("Yes", resp);

        }
        
    }
}
