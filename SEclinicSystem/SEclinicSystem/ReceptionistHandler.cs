using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEclinicSystem
{
    class ReceptionistHandler
    {
        Int32 result;
        Staff staff = new Staff();
        OverSurgerySystem run = new OverSurgerySystem();
        DataTable dtResult = new DataTable();

        public bool login(Receptionist receptionist)
        {
            result = run.getLocalSQLDataCount("SELECT* FROM login where username = '" + receptionist.LoginID + "' AND password = '" + receptionist.Password + "'");

            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public Staff credential(string id)
        {

            dtResult = run.getLocalSQLData("SELECT * FROM login INNER JOIN Staff on login.staffID = Staff.staffID WHERE login.username = '" + id + "'");
            staff.StaffID = dtResult.Rows[0]["staffID"].ToString();
            staff.FullName = dtResult.Rows[0]["name"].ToString();
            return staff;

        }
    }
}
