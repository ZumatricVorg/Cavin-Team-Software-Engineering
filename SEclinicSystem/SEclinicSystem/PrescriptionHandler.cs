using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SEclinicSystem
{
    public class PrescriptionHandler
    {
        OverSurgerySystem run = new OverSurgerySystem();

        public DataTable retrivePrescription(Prescription prescription)
        {        

            DataTable result = run.getLocalSQLData("select medicineID FROM PrescriptMedicine a with (nolock) where prescriptionID = '" + prescription.PrescriptionID + "' order by prescriptMedicineID asc");
            DataTable dt = new DataTable();
            dt.Columns.Add("MedicineID", typeof(string));
            dt.Columns.Add("MedicineName", typeof(string));
            dt.Columns.Add("Dosage", typeof(string));
            dt.Columns.Add("Consumption", typeof(string));
            dt.Columns.Add("Description", typeof(string));

            if (result.Rows.Count > 0)
            {
              for(int i = 0; i < result.Rows.Count; i++)
                    {
                        DataTable mn = run.getLocalSQLData(@"SELECT TOP 1 [medicineID], [medicineName], [dosage], [consumption], [description] FROM Medicine a with(nolock)  where medicineID  ='" + result.Rows[i]["medicineID"].ToString() + "' order by [medicineID] asc");
                        if(mn != null)
                        {
                        
                           dt.Rows.Add(mn.Rows[0]["medicineID"].ToString(), mn.Rows[0]["medicineName"].ToString(), mn.Rows[0]["dosage"].ToString(), mn.Rows[0]["consumption"].ToString(), mn.Rows[0]["description"].ToString());
                        }                       
                    }
                    //dt = result;
                    return dt;          
            }
            else
            {
                return dt;
            }
        }

        public DataTable retriveExtendPrescription(Prescription prescription)
        {

            DataTable result = run.getLocalSQLData("select a.[medicineID], b.[endDate] FROM PrescriptMedicine as a join Prescription as b on a.prescriptionID = b.prescriptionID where a.prescriptionID = '"+prescription.PrescriptionID+"' order by prescriptMedicineID asc");
            DataTable dt = new DataTable();
            dt.Columns.Add("MedicineID", typeof(string));
            dt.Columns.Add("MedicineName", typeof(string));
            dt.Columns.Add("Dosage", typeof(string));
            dt.Columns.Add("Consumption", typeof(string));
            dt.Columns.Add("Description", typeof(string));

            if (result.Rows.Count > 0)
            {
                for (int i = 0; i < result.Rows.Count; i++)
                {
                    DataTable mn = run.getLocalSQLData(@"SELECT TOP 1 [medicineID], [medicineName], [dosage], [unlimitedPrescription], [consumption], [description] FROM Medicine a with(nolock)  where medicineID  ='" + result.Rows[i]["medicineID"].ToString() + "' order by [medicineID] asc");
                    if (mn != null)
                    {
                        prescription.Medicine.UnlimitedPrescription = (bool)mn.Rows[0]["unlimitedPrescription"];

                        if (prescription.Medicine.UnlimitedPrescription == false)
                        {
                            TimeSpan ts = DateTime.Now.Date - DateTime.Parse(result.Rows[0]["endDate"].ToString());

                            if (ts.Days >= 30)
                            {
                                dt.Rows.Add(mn.Rows[0]["medicineID"].ToString(), mn.Rows[0]["medicineName"].ToString(), mn.Rows[0]["dosage"].ToString(), mn.Rows[0]["consumption"].ToString(), mn.Rows[0]["description"].ToString());
                            }
                            
                        }
                        else
                        {
                            dt.Rows.Add(mn.Rows[0]["medicineID"].ToString(), mn.Rows[0]["medicineName"].ToString(), mn.Rows[0]["dosage"].ToString(), mn.Rows[0]["consumption"].ToString(), mn.Rows[0]["description"].ToString());
                        }
                        
                    }
                }
                //dt = result;
                return dt;
            }
            else
            {
                return dt;
            }
        }
        // add prescription method
        public int addPrescription(Prescription prescription)
        {
            string rrsql = "INSERT INTO [Prescription] ([appointmentID],[staffID],[patientID],[endDate]) VALUES ('" + prescription.Appointment.AppointmentID + "','" + prescription.Staff.StaffID + "','" + prescription.Patient.PatientID + "','" + prescription.EndDate.Date.ToString("yyyy-MM-dd") + "')";
            return run.WriteData(rrsql);
        }

        //add prescription Medicine
        public int addPrescriptionMedicine(Prescription prescription)
        {
            DataTable result = run.getLocalSQLData("SELECT TOP 1 [prescriptionID]  FROM [Prescription] order by [prescriptionID] desc");
            prescription.PrescriptionID = result.Rows[0]["prescriptionID"].ToString();
            string sql = "INSERT INTO [PrescriptMedicine] ([prescriptionID], [medicineID]) VALUES ('" + prescription.PrescriptionID + "','" +prescription.Medicine.MedicineID + "')";
            return run.WriteData(sql);
        }

    }
}
