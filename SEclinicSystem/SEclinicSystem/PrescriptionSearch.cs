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
    public partial class PrescriptionSearch : Form
    {
        OverSurgerySystem run = new OverSurgerySystem();
        Prescription prescription = new Prescription();
        Patient p = new Patient();

        public PrescriptionSearch(Patient patient)
        {
            p = patient;
            InitializeComponent();
            setDataGridTable();
            lblText.Visible = false;
            dataGridView1.Visible = true;            
        }


        //set datatable
        public void setDataGridTable()
        {
            dataGridView1.Columns.Add("prescriptionID", "Prescription ID");
            dataGridView1.Columns.Add("date", "Appointment Date");
            dataGridView1.Columns.Add("patientName", "Patient Name");
            dataGridView1.Columns.Add("fullName", "General Practitioner");

        }        

        //back to Patient Main
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable result = run.getLocalSQLData(@"select DISTINCT a.[prescriptionID], a.[appointmentID], CONCAT(b.startDate,' ',b.startTime) as startDate,"
                           + " a.[staffID] FROM [Prescription] as a left join [Appointment] as b on a.[appointmentID] = b.[id] where a.[patientID] = '" + p.PatientID+"' AND prescriptionID LIKE '%"+textBox1.Text+"%' order by prescriptionID asc");

            if (result != null)
            {
                if (result.Rows.Count > 0)
                {
                    lblText.Visible = false;
                    dataGridView1.Visible = true;

                    int x = 0;
                    while (x <= result.Rows.Count - 1)
                    {
                        DataTable pn = run.getLocalSQLData("select [name] FROM [Patient] where patientID = '" + p.PatientID + "' order by patientID asc");
                        DataTable gpn = run.getLocalSQLData("select [name] FROM [Staff] where staffID = '" + result.Rows[x]["staffID"].ToString() + "' order by staffID asc");

                        dataGridView1.Rows.Add(result.Rows[x]["prescriptionID"].ToString(), result.Rows[x]["startDate"].ToString(), pn.Rows[0]["name"].ToString(), gpn.Rows[0]["name"].ToString());
                        x++;
                    }

                    foreach (DataGridViewRow r in dataGridView1.Rows)
                    {
                        DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                        linkCell.LinkBehavior = LinkBehavior.SystemDefault;
                        linkCell.LinkColor = Color.Blue;
                        linkCell.Value = r.Cells[0].Value;
                        dataGridView1[0, r.Index] = linkCell;
                    }

                }
                else
                {
                    lblText.Visible = true;
                    dataGridView1.Visible = false;
                }

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewLinkCell)
            {
                prescription.PrescriptionID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                prescription.Appointment.Date = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()); //DateTime.Now;
                prescription.Staff.FullName = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

                DataTable result = run.getLocalSQLData(@"select distinct [prescriptionID], [appointmentID], [staffID], [endDate] FROM [Prescription] a with(nolock) where patientId = '" + p.PatientID + "' AND prescriptionID = '" + prescription.PrescriptionID + "' order by prescriptionID asc");
                prescription.Staff.StaffID = result.Rows[0]["staffID"].ToString();
                prescription.Appointment.AppointmentID = result.Rows[0]["appointmentID"].ToString();
                prescription.Patient.PatientID = p.PatientID;
                prescription.EndDate = (DateTime)result.Rows[0]["endDate"];

                this.Hide();
                var pd = new PrescriptionDetails(prescription);
                pd.Show();
            }

        }
    }
}
