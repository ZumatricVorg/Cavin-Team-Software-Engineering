using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace SEclinicSystem
{
    public partial class UpdatePatient : Form
    {
        Patient p = new Patient();
        PatientHandler ph = new PatientHandler();
        OverSurgerySystem run = new OverSurgerySystem();

        public UpdatePatient(Patient patient)
        {
            InitializeComponent();
            p = patient;
                 
            ddlGender.Items.Insert(0, "- Select a gender -");
            ddlGender.Items.Insert(1, "Male");
            ddlGender.Items.Insert(2, "Female");
            Clear();
            setValue();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!checkValidation())
            {
                return;
            }

            p.Name = txtPatientName.Text;
            p.NRIC1 = txtNRIC1.Text + "-" + txtNRIC2.Text + "-" + txtNRIC3.Text;
            p.DOB1 = dtpDOB.Value.Date;
            p.PhoneNo = txtPhoneNo.Text;
            p.Email = txtEmail.Text;
            p.Address = txtAddress.Text.Replace(Environment.NewLine, "\\n");
            p.Gender = ddlGender.SelectedItem.ToString();

            string result = ph.updatePatientDetails(p); 

            if(result == "Y")
            {
                MessageBox.Show("Update patient's details successful!");
                this.Close();                
            }
            else if (result == "N")
            {
                MessageBox.Show("Update patient's details failed!");                
            }
        }

        public void setValue()
        {           
            //setting NRIC
            string[] nricArray = p.NRIC1.Split('-');
            txtNRIC1.Text = nricArray[0];
            txtNRIC2.Text = nricArray[1];
            txtNRIC3.Text = nricArray[2];               
                
            ddlGender.SelectedIndex = ddlGender.Items.IndexOf(p.Gender);
            dtpDOB.Value = Convert.ToDateTime(p.DOB1);
            txtPhoneNo.Text = p.PhoneNo;
            txtEmail.Text = p.Email;
            txtAddress.Text = p.Address;            
        }

        public bool checkValidation()
        {
            bool validation = true;

            //patient name validation
            if (txtPatientName.Text.Trim() == "")
            {
                MessageBox.Show("Please fill up patient's name.");
                txtPatientName.Focus();
                return false;
            }
            else if (txtPatientName.Text.Trim() != "")
            {
                Regex emp1 = new Regex("^[\\sa-z-A-Z]+$");

                if (!emp1.IsMatch(txtPatientName.Text))
                {
                    MessageBox.Show("Only ALPHABETIC letters");
                    txtPatientName.Focus();
                    return false;
                }
            }
            //NRIC validation
             if (txtNRIC1.Text.Trim() == "")
            {
                MessageBox.Show("Please fill up patient's NRIC column 1.");
                txtNRIC1.Focus();
                return false;
            }
            else if (txtNRIC2.Text.Trim() == "")
            {
                MessageBox.Show("Please fill up patient's NRIC column 2.");
                txtNRIC1.Focus();
                return false;
            }
            else if (txtNRIC3.Text.Trim() == "")
            {
                MessageBox.Show("Please fill up patient's NRIC column 3.");
                txtNRIC1.Focus();
                return false;
            }
            else if (txtNRIC1.Text.Trim() != "")
            {
                Regex emp1 = new Regex("^[0-9]");

                if (txtNRIC1.Text.Length < 6)
                {
                    MessageBox.Show("Need 6 digits");
                    txtNRIC1.Focus();
                    return false;
                }
                else if (!emp1.IsMatch(txtNRIC1.Text))
                {
                    MessageBox.Show("Only numeric number");
                    txtNRIC1.Focus();
                    return false;
                }
            }
            else if (txtNRIC2.Text.Trim() != "")
            {
                Regex emp1 = new Regex("^[0-9]");

                if (txtNRIC2.Text.Length < 2)
                {
                    MessageBox.Show("Need 2 digits");
                    txtNRIC2.Focus();
                    return false;
                }
                else if (!emp1.IsMatch(txtNRIC2.Text))
                {
                    MessageBox.Show("Only numeric number");
                    txtNRIC2.Focus();
                    return false;
                }
            }
            else if (txtNRIC3.Text.Trim() != "")
            {
                Regex emp1 = new Regex("^[0-9]");

                if (txtNRIC3.Text.Length < 6)
                {
                    MessageBox.Show("Need 6 digits");
                    txtNRIC3.Focus();
                    return false;
                }
                else if (!emp1.IsMatch(txtNRIC3.Text))
                {
                    MessageBox.Show("Only numeric number");
                    txtNRIC3.Focus();
                    return false;
                }
            }
            // Date of birth validation
             if (dtpDOB.Value.Date > DateTime.Now.Date)
            {
                MessageBox.Show("Invalid date.");
                dtpDOB.Focus();
                return false;
            }
            // Gender validation
             if (ddlGender.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a patient's gender.");
                ddlGender.Focus();
                return false;
            }
            //Phone number validation
            else if (txtPhoneNo.Text.Trim() == "")
            {
                MessageBox.Show("Please fill up patient's contact number.");
                txtPhoneNo.Focus();
                return false;
            }
            else if (txtPhoneNo.Text.Trim() != "")
            {
                Regex emp1 = new Regex("^[0-9]");

                if (txtPhoneNo.Text.Length < 10)
                {
                    MessageBox.Show("Minimum 10 digits");
                    txtPhoneNo.Focus();
                    return false;
                }
                else if (!emp1.IsMatch(txtPhoneNo.Text))
                {
                    MessageBox.Show("Only numeric letters");
                    txtPhoneNo.Focus();
                    return false;
                }
            }
            // Email validation
             if (txtEmail.Text.Trim() == "")
            {
                MessageBox.Show("Please fill up patient's email address.");
                txtEmail.Focus();
                return false;
            }
            else if (txtEmail.Text.Trim() != "")
            {
                Regex emp1 = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");

                if (!emp1.IsMatch(txtEmail.Text))
                {
                    MessageBox.Show("Invalid email aadress");
                    txtEmail.Focus();
                    return false;
                }

            }
            // Address validation
             if (txtAddress.Text.Trim() == "")
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
            txtNRIC1.Text = "";
            txtNRIC2.Text = "";
            txtNRIC3.Text = "";
            dtpDOB.Value = DateTime.Now.Date;
            ddlGender.SelectedIndex = 0;
            txtPhoneNo.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
