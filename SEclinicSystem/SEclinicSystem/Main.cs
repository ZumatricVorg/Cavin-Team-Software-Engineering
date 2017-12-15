using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEclinicSystem
{
    public partial class Main : Form
    {
        ReceptionistHandler rHdler = new ReceptionistHandler();
        Staff staff = new Staff();
        AppointmentHandler aptHler = new AppointmentHandler();
        StaffHandler sHler = new StaffHandler();
        DataTable dtResult = new DataTable();
        AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
        DataGridViewCheckBoxColumn checkApt = new DataGridViewCheckBoxColumn();
        Appointment appoinment = new Appointment();

        public Main(string username)
        {

            InitializeComponent();
            staff = rHdler.credential(username);
            staffID.Text = staff.StaffID;
            staffName.Text = staff.FullName;
            if (staff.Image != "")
            {
                pictureBox1.ImageLocation = staff.Image;
            }

            if (staff.Position == "DP")
            {
                delApt.Visible = false;
                upDateApt.Visible = false;
                dtResult = sHler.selectAllDP();

                if (dtResult == null)
                {
                    return;
                }
                else
                {
                    aptMethod(dtResult);
                }
            }

            if (staff.Position == "Receptionist")
            {
                dtResult = sHler.selectAllDP();

                if (dtResult == null)
                {
                    return;
                }
                else
                {
                    aptMethod(dtResult);
                }
            }

            if (staff.Position == "Nurse")
            {
                dateTimePicker1.Visible = false;
                delApt.Visible = false;
                upDateApt.Visible = false;
                searchAptBtn.Visible = false;
                gpName.Visible = false;
                label1.Visible = false;
                SearchPatient.Visible = false;
                dataGridView1.DataSource = aptHler.selectAllNurseApt(staff);
            }

        }

        private void aptMethod(DataTable dtResult)
        {
            foreach (DataRow row in dtResult.Rows)
            {
                MyCollection.Add(row["name"].ToString());
            }

            gpName.AutoCompleteCustomSource = MyCollection;
            dataGridView1.DataSource = aptHler.selectAllApt();

            checkApt.Name = "select";
            checkApt.HeaderText = "Select";
            checkApt.Width = 50;
            checkApt.ReadOnly = false;
            checkApt.FillWeight = 10;
            checkApt.FalseValue = "0";
            checkApt.TrueValue = "1";
            dataGridView1.Columns.Add(checkApt);

        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm form = new LoginForm();
            form.Show();
        }

        private void SearchPatient_Click(object sender, EventArgs e)
        {
            PatientSearch fPatientSearch = new PatientSearch();
            fPatientSearch.Show();
        }

        private void searchAptBtn_Click(object sender, EventArgs e)
        {
            Staff staff2 = new Staff();            
            Appointment appt = new Appointment();

            staff2.FullName = gpName.Text.ToString();
            if (staff2.FullName.Equals(""))
            {
                MessageBox.Show("Please enter a GP name");
                return;
            }
            dataGridView1.DataSource = aptHler.selectGpAppointment(staff2, appt);
        }

        private void delApt_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                //Get the appropriate cell using index, name or whatever and cast to DataGridViewCheckBoxCell
                DataGridViewCheckBoxCell cell = row.Cells["select"] as DataGridViewCheckBoxCell;

                //Compare to the true value because Value isn't boolean
                if (cell.Value == cell.TrueValue)
                {
                    //The value is true
                    appoinment.AppointmentID = row.Cells["Id"].Value.ToString();
                    aptHler.cancel(appoinment);
                }

            }
            dataGridView1.DataSource = aptHler.selectAllApt();
        }

        private void upDateApt_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                //Get the appropriate cell using index, name or whatever and cast to DataGridViewCheckBoxCell
                DataGridViewCheckBoxCell cell = row.Cells["select"] as DataGridViewCheckBoxCell;

                //Compare to the true value because Value isn't boolean
                if (cell.Value == cell.TrueValue)
                {
                    //The value is true
                    appoinment.AppointmentID = row.Cells["Id"].Value.ToString();
                    //aptHler.cancel(appoinment);
                    i++;
                }

            }
            if (i <= 0)
            {
                MessageBox.Show("Please select at least one appointment");
            }
            else if (i > 1)
            {
                MessageBox.Show("Only one appoinment is allow to update each time");
            }
            else
            {
                AppointmentMain aptmain = new AppointmentMain("", appoinment.AppointmentID);
                aptmain.ShowDialog();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (staff.Position == "Nurse")
            {
            }
            else
            {
                aptHler.updateAllApt();
                dataGridView1.DataSource = aptHler.selectAllApt();
            }

        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.Show();
        }
    }
}

