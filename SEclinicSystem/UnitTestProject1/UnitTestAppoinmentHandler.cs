using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SEclinicSystem;
using System.Data;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTestAppoinmentHandler
    {
        [TestMethod]
        public void TestSelectGPApt()
        {
            AppointmentHandler aptHlder = new AppointmentHandler();
            Staff staff = new Staff();

            staff.FullName = "Ali";
            staff.StaffID = "1";

            DataTable resp = aptHlder.selectGpAppointment(staff);
            Assert.IsNotNull(resp);
        }

        [TestMethod]
        public void TestselectAllApt()
        {
            AppointmentHandler aptHlder = new AppointmentHandler();

            DataTable resp = aptHlder.selectAllApt();
            Assert.IsNotNull(resp);
        }

        [TestMethod]
        public void TestBook()
        {
            AppointmentHandler aptHlder = new AppointmentHandler();
            Appointment apt = new Appointment();


            apt.Time = Convert.ToDateTime("12:00:00"); ;
            apt.Date = Convert.ToDateTime("12/12/12");
            apt.Remark = "Immediate";

            string resp = aptHlder.book("1","2", apt);
            Assert.AreEqual("Appointment Success registered",resp);
        }

        [TestMethod]
        public void TestCheck()
        {
            AppointmentHandler aptHlder = new AppointmentHandler();
            Appointment apt = new Appointment();


            apt.Time = Convert.ToDateTime("12:00:00"); ;
            apt.Date = Convert.ToDateTime("12/12/12");

            int resp = aptHlder.check("2", apt);

            Assert.IsNotNull(resp);
        }




    }
}
