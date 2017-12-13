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
    public partial class PrescriptionDetails : Form
    {
        PrescriptionHandler ph = new PrescriptionHandler();
        Prescription prescription = new Prescription();

        public PrescriptionDetails(Prescription prescription)
        {
            this.prescription = prescription;
            InitializeComponent();
            Clear();
            setPrescription();
            btnExtend.Visible = false;
            btnBack.Visible = false;
            button2.Visible = true;
            dtpEndDate.Visible = false;
        }

        //set datatabe and prescription details
        private void setPrescription()
        {
            DataTable dt = ph.retrivePrescription(prescription);

            lblPrescriptionID.Text  = prescription.PrescriptionID;
            label3.Text = prescription.Appointment.AppointmentID;
            lblGPName.Text = prescription.Staff.FullName;
            lblDate.Text = prescription.Appointment.Date.ToString();

            dataGridView1.DataSource = dt;

            DataGridViewCheckBoxColumn chkMedicine = new DataGridViewCheckBoxColumn();
            chkMedicine.Name = "Select";
            chkMedicine.HeaderText = "Select";
            chkMedicine.Width = 50;
            chkMedicine.ReadOnly = false;
            chkMedicine.FillWeight = 10;
            chkMedicine.FalseValue = "0";
            chkMedicine.TrueValue = "1";
            dataGridView1.Columns.Add(chkMedicine);
            dataGridView1.Columns["Select"].Visible = false;

        }

        //extend prescription button
        private void button1_Click(object sender, EventArgs e)
        {         
            dataGridView1.Columns["Select"].Visible = true;
            btnExtend.Visible = true;
            btnBack.Visible = true;
            button2.Visible = false;
            lblEndDate.Visible = true;
            dtpEndDate.Visible = true;
            button1.Visible = false;

            DataTable dt = ph.retriveExtendPrescription(prescription);

            dataGridView1.DataSource = dt;
        }

        //cancel extend prescription
        private void btnBack_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns["Select"].Visible = false;
            btnExtend.Visible = false;
            btnBack.Visible = false;
            button2.Visible = true;
            dtpEndDate.Visible = false;
            lblEndDate.Visible = false;
            button1.Visible = true;

            DataTable dt = ph.retrivePrescription(prescription);
            dataGridView1.DataSource = dt;
        }

        private void Clear()
        {
            dataGridView1.DataSource = "";
            btnExtend.Visible = false;
            btnBack.Visible = false;

            button1.Visible = true;
            dtpEndDate.Visible = false;
        }
        //extend button
        private void btnExtend_Click(object sender, EventArgs e)
        {
            DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
            int rowkena = 0;
            int rowK = 0;

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
                           prescription.Medicine.MedicineID = row.Cells[0].Value.ToString();
                           rowK = ph.addPrescriptionMedicine(prescription);
                }

            }

            if (rowkena > 0 && rowK > 0)
            {
                MessageBox.Show("Extend prescription successfull!");
                Clear();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Extend prescription failed!");
            }

        }

        //back to search prescription
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var ps = new PrescriptionSearch(prescription.Patient);
            ps.Show();
        }

        ////check unlimited prescription when checked the check box
        //private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        //{
        //    DataGridView dgv = (DataGridView)sender;

        //    if (dgv.CurrentCell.GetType() != typeof(DataGridViewCheckBoxCell))
        //    {
        //        DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
        //        ch1 = (DataGridViewCheckBoxCell)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5];

        //        if (ch1.Value == ch1.TrueValue)
        //        {
        //            prescription.Medicine.MedicineID = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].ToString();
        //            prescription.Medicine.MedicineName = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].ToString();
        //            bool result = ph.checkPrescriptionLimit(prescription);

        //            if (result == false)
        //            {
        //                MessageBox.Show(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].ToString() + " medicine cannot be extended!");
        //                ch1.Value = ch1.FalseValue;
        //            }

        //        }

        //    }
        //}
    }
}
