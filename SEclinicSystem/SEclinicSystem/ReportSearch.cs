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
    public partial class ReportSearch : Form
    {
        OverSurgerySystem run = new OverSurgerySystem();
        Report report = new Report();
        Patient p = new Patient();

        public ReportSearch(Patient patient)
        {
            p = patient;
            InitializeComponent();
            setDataGridTable();
            lblText.Visible = false;
            dataGridView1.Visible = true;
        }

        public void setDataGridTable()
        {
            dataGridView1.Columns.Add("reportID", "Report ID");
            dataGridView1.Columns.Add("date", "Appointment Date");
            dataGridView1.Columns.Add("patientName", "Patient Name");
            dataGridView1.Columns.Add("staffName", "General Practitioner");

        }

        //back to Patient Main
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        //click search
        private void button1_Click(object sender, EventArgs e)
        {
            DataTable result = run.getLocalSQLData(@"select r.[reportID], r.[appointmentID], CONCAT(b.startDate,' ',b.startTime) as startDate, r.[staffID] FROM [Report] as r with (nolock) left join [Appointment] as b with (nolock) on r.appointmentID = b.Id  where r.patientID ='" + p.PatientID + "' AND reportID LIKE '%" + txtReportID.Text + "%' order by reportID asc");

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


                        dataGridView1.Rows.Add(result.Rows[x]["reportID"].ToString(), result.Rows[x]["startDate"].ToString(), pn.Rows[0]["name"].ToString(), gpn.Rows[0]["name"].ToString());
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

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewLinkCell)
            {
                report.ReportID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
               report.Appointment.Date = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                report.Staff.FullName = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

                DataTable result = run.getLocalSQLData(@"select [reportID], [appointmentID], [staffID], [description], [remarks] FROM [Report] a with(nolock) where patientId = '" + p.PatientID + "' AND reportID = '" + report.ReportID + "' order by reportID asc");
                report.Staff.StaffID = result.Rows[0]["staffID"].ToString();
                report.Appointment.AppointmentID = result.Rows[0]["appointmentID"].ToString();
                report.Description = result.Rows[0]["description"].ToString();
                report.Remarks = result.Rows[0]["remarks"].ToString();
                report.Patient.PatientID = p.PatientID;


                this.Hide();
                var rvp = new ReportViewPrint(report);
                rvp.Show();

            }
        }
    }
}