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

        //search ReportID
        private void txtReportID_TextChanged(object sender, EventArgs e)
        {
            DataTable result = run.getLocalSQLData(@"select a.[reportID], a.[appointmentID], b.[date], a.[staffID] FROM [Report] a with (nolock) left join [Appointment] with (nolock) on a.appointmentID = b.appointmentID   where patientID ='" + p.PatientID + "' AND reportID LIKE '%" + txtReportID.Text + "%' order by reportID asc");

            if (result != null)
            {
                if (result.Rows.Count > 0)
                {
                    lblText.Visible = false;
                    dataGridView1.Visible = true;

                    int x = 0;
                    while (x <= result.Rows.Count - 1)
                    {
                        DataTable pn = run.getLocalSQLData("select [patientName] FROM [Patient] where patientID = '" + p.PatientID + "' order by patientID asc");
                        DataTable gpn = run.getLocalSQLData("select [staffName] FROM [Staff] where staffID = '" + result.Rows[x]["staffID"].ToString() + "' order by staffID asc");

                        DataGridViewLinkColumn linkCell = new DataGridViewLinkColumn();
                        linkCell.UseColumnTextForLinkValue = true;
                        linkCell.LinkBehavior = LinkBehavior.SystemDefault;
                        linkCell.Name = "ReportID";
                        linkCell.LinkColor = Color.Blue;
                        linkCell.Text = result.Rows[x]["reportID"].ToString();
                        linkCell.UseColumnTextForLinkValue = true;

                        dataGridView1.Rows.Add(linkCell, result.Rows[x]["date"].ToString(), pn.Rows[0]["patientName"].ToString(), gpn.Rows[0]["staffName"].ToString());
                        x++;
                    }

                }
                else
                {
                    lblText.Visible = true;
                    dataGridView1.Visible = false;
                }

            }

        }

        //link cell - click the id then will show the report
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                report.ReportID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                report.Appointment.Date = (DateTime)dataGridView1.Rows[e.RowIndex].Cells[1].Value;
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

        //set datatable
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
    }
}
