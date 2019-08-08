using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEclinicSystem
{
    public class StaffHandler
    {
        OverSurgerySystem run = new OverSurgerySystem();
        DataTable dtResult = new DataTable();

        public DataTable selectAllDP()
        {

            dtResult = run.getLocalSQLData("SELECT Staff.name,Staff.staffID FROM Staff"
                                + " INNER JOIN StaffPosition ON Staff.staffID = StaffPosition.staffID"
                                + " INNER JOIN Position ON StaffPosition.positionID = Position.positionID"
                                + " WHERE positionName = 'DP' ");
            return dtResult;
        }

        public DataTable selectAllNurse()
        {

            dtResult = run.getLocalSQLData("SELECT Staff.name,Staff.staffID FROM Staff"
                                + " INNER JOIN StaffPosition ON Staff.staffID = StaffPosition.staffID"
                                + " INNER JOIN Position ON StaffPosition.positionID = Position.positionID"
                                + " WHERE positionName = 'Nurse' ");
            return dtResult;
        }
    }
}
