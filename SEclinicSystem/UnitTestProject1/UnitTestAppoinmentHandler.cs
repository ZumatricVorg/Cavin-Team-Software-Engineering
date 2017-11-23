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

      
    }
}
