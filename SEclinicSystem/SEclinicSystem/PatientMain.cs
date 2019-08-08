using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEclinicSystem
{
    public partial class PatientMain : Form
    {
        OverSurgerySystem run = new OverSurgerySystem();

        Patient p = new Patient();

        public PatientMain(Patient patient)
        {
            p = patient;
            InitializeComponent();
            setValue();
        }


        //set patient's details
        private void setValue()
        {
            string tempQuery = "select [name], [NRIC], [dateOfBirth], [phoneNo], [email], [address], [gender] FROM [Patient] where patientId = '" + p.PatientID + "'";

            DataTable result = run.getLocalSQLData(tempQuery);

            if(result.Rows.Count > 0)
            {

                lblPatientID.Text = p.PatientID;
                lblPatientName.Text = result.Rows[0]["name"].ToString();
                lblNRIC.Text = result.Rows[0]["NRIC"].ToString();
                lblGender.Text = result.Rows[0]["gender"].ToString();
                lblDOB.Text = result.Rows[0]["dateOfBirth"].ToString();
                lblPhoneNo.Text = result.Rows[0]["phoneNo"].ToString();
                lblEmail.Text = result.Rows[0]["email"].ToString();
                lblAddress.Text = result.Rows[0]["address"].ToString().Replace("\\n", Environment.NewLine);

                createApt.Enabled = true;

                this.p.PatientID = p.PatientID;
                this.p.Name = result.Rows[0]["name"].ToString();
                this.p.NRIC1 = result.Rows[0]["NRIC"].ToString();
                this.p.Gender = result.Rows[0]["gender"].ToString();
                this.p.DOB1 = Convert.ToDateTime(result.Rows[0]["dateOfBirth"]);
                this.p.PhoneNo = result.Rows[0]["phoneNo"].ToString();
                this.p.Email = result.Rows[0]["email"].ToString();
                this.p.Address = result.Rows[0]["address"].ToString().Replace("\r\n", Environment.NewLine);
            }
        }

        //back to patient search
        private void btnGoBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            var PatientSearch = new PatientSearch();
            PatientSearch.Show();
        }

        private void btnUpdateDetails_Click(object sender, EventArgs e)
        {
            var UP = new UpdatePatient(p);
            UP.Show();
        }

        private void createApt_Click(object sender, EventArgs e)
        {          
            AppointmentMain aptmain = new AppointmentMain(p.PatientID,"");
            aptmain.ShowDialog();
        }

        //add prescription
        private void button2_Click(object sender, EventArgs e)
        {           
            var anp = new PrescriptionAddNew(p);
            anp.Show();
        }

        //search prescription
        private void button1_Click(object sender, EventArgs e)
        {
            var sp = new PrescriptionSearch(p);
            sp.Show();
        }

        //create new report
        private void btnNewReport_Click(object sender, EventArgs e)
        {
            var ra = new ReportAdd(p);
            ra.Show();
        }

        //search report
        private void btnSearchReport_Click(object sender, EventArgs e)
        {
            var rs = new ReportSearch(p);
            rs.Show();
        }

        private void btnUpdateDetails_Click_1(object sender, EventArgs e)
        {
            var UP = new UpdatePatient(p);
            UP.Show();

        }
    }
}
