using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEclinicSystem
{
    public partial class UpdatePatient : Form
    {
        Patient patient = new Patient();
        OverSurgerySystem run = new OverSurgerySystem();

        public UpdatePatient()
        {
            InitializeComponent();

            setValue();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!checkValidation())
            {
                return;
            }

            string result = patient.updatePatientDetails(PatientSearch.patientID, txtPatientName.Text, txtNRIC.Text, dtpDOB.Value.Date.ToString(), txtPhoneNo.Text, txtEmail.Text, txtAddress.Text.Replace(Environment.NewLine, "\\n"), ddlGender.SelectedValue.ToString()); 

            if(result == "Y")
            {
                MessageBox.Show("Update patient's details successful!");
                this.Close();                
            }
            else if (result == "N")
            {
                MessageBox.Show("Update patient's details failed!");
                Clear();
            }
        }

        public void setValue()
        {
            string tempQuery = "select [name], [NRIC], [dateOfBirth], [phoneNo], [email], [address], [gender] FROM [Patient] where patientId = '" + PatientSearch.patientID + "'";

            DataTable result = run.getLocalSQLData(tempQuery);

            if (result.Rows.Count > 0)
            {
                txtPatientName.Text = result.Rows[0]["name"].ToString();
                txtNRIC.Text = result.Rows[0]["NRIC"].ToString();
                ddlGender.SelectedIndex = ddlGender.Items.IndexOf(result.Rows[0]["gender"].ToString());
                dtpDOB.Value = (DateTime)result.Rows[0]["dateOfBirth"];
                txtPhoneNo.Text = result.Rows[0]["phoneNo"].ToString();
                txtEmail.Text = result.Rows[0]["email"].ToString();
                txtAddress.Text = result.Rows[0]["address"].ToString().Replace("\r\n", Environment.NewLine);
            }
        }

        public bool checkValidation()
        {
            bool validation = true;

            if (txtPatientName.Text.Trim() == "")
            {
                MessageBox.Show("Please fill up patient's name.");
                txtPatientName.Focus();
                return false;
            }
            else if (txtNRIC.Text.Trim() == "")
            {
                MessageBox.Show("Please fill up patient's NRIC.");
                txtNRIC.Focus();
                return false;
            }
            else if (dtpDOB.Value.Date == DateTime.Now.Date)
            {
                MessageBox.Show("Please fill up patient's birth date.");
                dtpDOB.Focus();
                return false;
            }
            else if (ddlGender.SelectedIndex == 0)
            {
                MessageBox.Show("Please fill up patient's gender.");
                ddlGender.Focus();
                return false;
            }
            else if (txtPhoneNo.Text.Trim() == "")
            {
                MessageBox.Show("Please fill up patient's contact number.");
                txtPhoneNo.Focus();
                return false;
            }
            else if (txtEmail.Text.Trim() == "")
            {
                MessageBox.Show("Please fill up patient's email address.");
                txtEmail.Focus();
                return false;
            }
            else if (txtAddress.Text.Trim() == "")
            {
                MessageBox.Show("Please fill up patient's address.");
                txtAddress.Focus();
                return false;
            }

            return validation;
        }

        public void Clear()
        {
            txtPatientName.Text = "";
            txtNRIC.Text = "";
            dtpDOB.Value = DateTime.Now.Date;
            ddlGender.SelectedIndex = 0;
            txtPhoneNo.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
        }
    }
}
