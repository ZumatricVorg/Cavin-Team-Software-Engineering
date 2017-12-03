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
    public partial class Main : Form
    {
        ReceptionistHandler rHdler = new ReceptionistHandler();
        Staff staff = new Staff();
        AppointmentHandler aptHler = new AppointmentHandler();
        StaffHandler sHler = new StaffHandler();
        DataTable dtResult = new DataTable();
        AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();

        public Main(string username)
        {

            InitializeComponent();
            staff = rHdler.credential(username);
            staffID.Text = staff.StaffID;
            staffName.Text = staff.FullName;
            //pictureBox1.Image = Image.FromFile("C:\\Users\\LENOVO\\Desktop\\ARU\\Software Engineer\\Cavin-Team-Software-Engineering\\user.png");
            dtResult = sHler.selectAllDP();

            if (dtResult == null)
            {
                return;
            }else
            {
                foreach (DataRow row in dtResult.Rows)
                {
                    MyCollection.Add(row["name"].ToString());
                }

                gpName.AutoCompleteCustomSource = MyCollection;
                dataGridView1.DataSource = aptHler.selectAllApt();

            }

        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm form = new LoginForm();
            form.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
        }

        private void SearchPatient_Click(object sender, EventArgs e)
        {
            PatientSearch fPatientSearch = new PatientSearch();
            fPatientSearch.Show();
        }

        private void searchAptBtn_Click(object sender, EventArgs e)
        {
            Staff staff2 = new Staff();
            staff2.FullName = gpName.Text.ToString();
            if(staff2.FullName.Equals(""))
            {
                MessageBox.Show("Please enter a GP name");
                return;
            }
            dataGridView1.DataSource = aptHler.selectGpAppointment(staff2);
        }
    }
}

