using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace SEclinicSystem
{
    public partial class PrescriptionAddNew : Form
    {
        OverSurgerySystem run = new OverSurgerySystem();
        Prescription prescription = new Prescription();
        PrescriptionHandler ph = new PrescriptionHandler();
        DataTable dtResult = new DataTable();
        StaffHandler sHlder = new StaffHandler();
        DataGridViewCheckBoxColumn checkMedicine = new DataGridViewCheckBoxColumn();
        AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
        AppointmentHandler aHlder = new AppointmentHandler();


        public PrescriptionAddNew(Patient patient)
        {
            prescription.Patient.PatientID = patient.PatientID;
            InitializeComponent();
            clearList();
            setPatientName();
            setMedicineList();
            dtResult = sHlder.selectAllDP();

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

        private void PrescriptionAddNew_Load(object sender, EventArgs e)
        {                        
          
         }

        public void allApt()
        {
            dtResult = aHlder.checkAllApt(prescription.Patient.PatientID);

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
    
        //set the medicine datagridview
        private void setMedicineList()
        {         
            DataTable medicineDT = run.getLocalSQLData("SELECT [medicineID], [medicineName], [dosage], [consumption], [description] FROM [Medicine] ORDER BY [medicineID] ASC ");

            if (medicineDT.Rows.Count > 0)
            {               
                dataGridView1.DataSource = medicineDT;
            }

           
            checkMedicine.Name = "select";
            checkMedicine.HeaderText = "Select";
            checkMedicine.Width = 50;
            checkMedicine.ReadOnly = false;
            checkMedicine.FillWeight = 10;
            checkMedicine.FalseValue = "0";
            checkMedicine.TrueValue = "1";
            dataGridView1.Columns.Add(checkMedicine);
        }

        private void btnCreatePrescription_Click(object sender, EventArgs e)
        {
            int rowkena = 0;
            int rowK = 0;

            if (!checkValidation())
            {
                return;
            }
            
            prescription.Appointment.AppointmentID = txtAppointmentID.Text.ToString();

            DataTable gp = run.getLocalSQLData("SELECT [staffID] FROM [Staff] WHERE [name] = '" + txtGPName.Text.ToString() + "' ORDER BY [staffID] ASC");
            prescription.Staff.StaffID = gp.Rows[0]["staffID"].ToString();

            prescription.EndDate = dtpEndDate.Value.Date;

            rowkena = ph.addPrescription(prescription);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                //Get the appropriate cell using index, name or whatever and cast to DataGridViewCheckBoxCell
                DataGridViewCheckBoxCell cell = row.Cells["select"] as DataGridViewCheckBoxCell;

                //Compare to the true value because Value isn't boolean
                if (cell.Value == cell.TrueValue)
                {
                    //The value is true
                    prescription.Medicine.MedicineID = row.Cells["medicineID"].Value.ToString();
                    rowK = ph.addPrescriptionMedicine(prescription);
                }            
         
            }
                                                          
                //}            
                
            //}

            if (rowK > 0 && rowkena > 0)
            {
                MessageBox.Show("New prescription is successfully created!");
                clearList();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Insert failed!");
            }            
            
        }

        //check validation for each input
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

            // End date validation
            if(dtpEndDate.Value.Date <= DateTime.Now.Date)
            {
                MessageBox.Show("Invalid date!");
                dtpEndDate.Focus();
                return false;
            }
            //must have one checkbox checked
            else
            {
                int checkedBox = 0;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    //Get the appropriate cell using index, name or whatever and cast to DataGridViewCheckBoxCell
                    DataGridViewCheckBoxCell cell = row.Cells["select"] as DataGridViewCheckBoxCell;

                    //Compare to the true value because Value isn't boolean
                    if (cell.Value == cell.TrueValue)
                    {
                        //The value is true
                        checkedBox = checkedBox + 1;
                    }

                }

                if (checkedBox == 0)
                {
                    MessageBox.Show("Please select atleast one medicine!");
                    return false;
                }
                else if (checkedBox > 0)
                {
                    return validation;
                }            

            }

            return validation;
        }

        //reset list
        private void clearList()
        {
            txtGPName.Text = "";
            txtAppointmentID.Text = "";
            dtpEndDate.Value = DateTime.Now;
            
            if(dataGridView1 != null)
            {
               
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    //Get the appropriate cell using index, name or whatever and cast to DataGridViewCheckBoxCell
                    DataGridViewCheckBoxCell cell = row.Cells["select"] as DataGridViewCheckBoxCell;

                    //Compare to the true value because Value isn't boolean
                    if (cell.Value == cell.TrueValue)
                    {
                        //The value is true
                        cell.Value = cell.FalseValue;
                    }

                }
            }
        }
        
        //set txtPatientName textbox value (patient's name)
        private void setPatientName()
        {
            DataTable dt = run.getLocalSQLData("SELECT [name] FROM [Patient] WHERE patientId = '"+prescription.Patient.PatientID+"' ORDER BY [patientID] ASC");

            if (dt.Rows.Count > 0)
            {
                prescription.Patient.Name = dt.Rows[0]["name"].ToString();
                txtPatientName.Text = prescription.Patient.Name;
            }
            
        }

        //back button
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txtGPName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

