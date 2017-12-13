using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SEclinicSystem;
using System.Data;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTestStaff
    {
        [TestMethod]
        public void TestMethodLogin()
        {
            Receptionist r = new Receptionist();
            ReceptionistHandler rHdler = new ReceptionistHandler();
            LoginForm form = new LoginForm();

            r.LoginID = "admin";
            r.Password = form.Crypt("1234");
          
           bool res = rHdler.login(r);
            Assert.AreEqual(true, res);

        }
        [TestMethod]
        public void TestMethodCredential()
        {
            Receptionist r = new Receptionist();
            ReceptionistHandler rHdler = new ReceptionistHandler();
     
            Staff s = rHdler.credential("admin");
            Assert.IsNotNull(s);
            
        }

        [TestMethod]
        public void TestSelectAllDP()
        {
            StaffHandler sHdler = new StaffHandler();

           DataTable res = sHdler.selectAllDP();
            Assert.IsNotNull(res);
           
        }
    }
}
