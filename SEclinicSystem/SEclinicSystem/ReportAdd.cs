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
using System.Data.SqlClient;

namespace SEclinicSystem
{
    public partial class ReportAdd : Form
    {
        OverSurgerySystem run = new OverSurgerySystem();
        Report report = new Report();
        ReportHandler rh = new ReportHandler();
        DataTable dtResult = new DataTable();
        StaffHandler sHler = new StaffHandler();
        AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
        AppointmentHandler aHlder = new AppointmentHandler();

        public ReportAdd(Patient patient)
        {
            report.Patient.PatientID = patient.PatientID;
            InitializeComponent();
            clearList();
            setPatientName();
            dtResult = sHler.selectAllDP();

            if (dtResult == null)
            {
                return;
            }
            else
            {
                foreach (DataRow row in dtResult.Rows)
                {
                    MyCollection.Add(row["name"].ToString());
                }

                txtGPName.AutoCompleteCustomSource = MyCollection;
            }
            allApt();
        }

        public void allApt()
        {
            dtResult = aHlder.checkAllApt(report.Patient.PatientID);

            if (dtResult == null)
            {
                return;
            }
            else
            {
                foreach (DataRow row in dtResult.Rows)
                {
                    MyCollection.Add(row["Id"].ToString());
                }

                txtAppointmentID.AutoCompleteCustomSource = MyCollection;
            }

        }

        //Textbox change for GP Name
        private void ReportAdd_Load(object sender, EventArgs e)
        {
          
        }   

        //reset list
        private void clearList()
        {
            txtGPName.Text = "";
            txtAppointmentID.Text = "";
            txtDescription.Text = "";
            txtRemarks.Text = "";
        }

        //set txtPatientName textbox value (patient's name)
        private void setPatientName()
        {
            DataTable dt = run.getLocalSQLData("SELECT [name] FROM [Patient] WHERE patientID = '" + report.Patient.PatientID + "' ORDER BY [patientID] ASC");

            if (dt.Rows.Count > 0)
            {
                report.Patient.Name = dt.Rows[0]["name"].ToString();
                txtPatientName.Text = report.Patient.Name;
            }

        }

        //back to patient main
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        //add new report
        private void btnAddReport_Click(object sender, EventArgs e)
        {
            int rowkena;

            if (!checkValidation())
            {
                return;
            }

            DataTable gp = run.getLocalSQLData("SELECT [staffID] FROM [Staff] WHERE [name] = '" + txtGPName.Text.ToString() + "' ORDER BY [staffID] ASC");
            report.Staff.StaffID = gp.Rows[0]["staffID"].ToString();

            report.Appointment.AppointmentID = txtAppointmentID.Text;
            report.Description = txtDescription.Text.Replace(Environment.NewLine, "/n");
            report.Remarks = txtRemarks.Text.Replace(Environment.NewLine, "/n");

            rowkena = rh.addReport(report);

            if (rowkena > 0)
            {
                MessageBox.Show("New report is successfully created!");
                clearList();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Insert failed!");
            }
        }

        //Check for validation for the inputs
        private bool checkValidation()
        {
            bool validation = true;
                        
            //GP Name validation
            if (txtGPName.Text.Trim() == "")
            {
                MessageBox.Show("Please fill up GP's name.");
                txtGPName.Focus();
                return false;
            }
            else if (txtGPName.Text.Trim() != "")
            {
                Regex emp1 = new Regex("^[\\sa-z-A-Z]+$");

                if (!emp1.IsMatch(txtGPName.Text))
                {
                    MessageBox.Show("Only ALPHABETIC letters");
                    txtGPName.Focus();
                    return false;
                }
            }
            // Appointment ID validation
             if (txtAppointmentID.Text.Trim() == "")
            {
                MessageBox.Show("Please fill up apponintment ID.");
                txtAppointmentID.Focus();
                return false;
            }
            // Description validation
             if (txtDescription.Text.Trim() == "")
            {
                MessageBox.Show("Please fill up the description!");
                txtDescription.Focus();
                return false;
            }            

            return validation;
        }
       
    }
}
