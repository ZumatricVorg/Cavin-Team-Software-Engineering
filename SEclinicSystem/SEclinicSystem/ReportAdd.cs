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

        public ReportAdd(Patient patient)
        {
            report.Patient.PatientID = patient.PatientID;            
            InitializeComponent();
            clearList();
            setPatientName();
        }

        //Textbox change for GP Name
        private void ReportAdd_Load(object sender, EventArgs e)
        {
            string resp = run.connect();
            AutoCompleteStringCollection gpNameCollection = new AutoCompleteStringCollection();

            if (resp == "Done")
            {
                SqlCommand cmd = new SqlCommand(@"select [fullName] FROM [Staff] order by fullName asc", run.getConn());
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    gpNameCollection.Add(reader.GetString(0));
                }
                txtGPName.AutoCompleteCustomSource = gpNameCollection;

                run.closeConnection();
            }

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
            DataTable dt = run.getLocalSQLData("SELECT [patientName] FROM [Patient] WHERE patientId = '" + report.Patient.PatientID + "' ORDER BY [patientID] ASC");

            if (dt.Rows.Count > 0)
            {
                report.Patient.Name = dt.Rows[0]["patientName"].ToString();
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

            DataTable gp = run.getLocalSQLData("SELECT [staffID] FROM [Staff] WHERE [fullName] = '" + txtGPName.Text.ToString() + "' ORDER BY [staffID] ASC");
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
                Regex emp1 = new Regex("^[a-z-A-Z]+$");

                if (!emp1.IsMatch(txtGPName.Text))
                {
                    MessageBox.Show("Only ALPHABETIC letters");
                    txtGPName.Focus();
                    return false;
                }
            }
            // Appointment ID validation
            else if (txtAppointmentID.Text.Trim() == "")
            {
                MessageBox.Show("Please fill up apponintment ID.");
                txtAppointmentID.Focus();
                return false;
            }
            // Description validation
            else if (txtDescription.Text.Trim() == "")
            {
                MessageBox.Show("Please fill up the description!");
                txtDescription.Focus();
                return false;
            }            

            return validation;
        }
    }
}
