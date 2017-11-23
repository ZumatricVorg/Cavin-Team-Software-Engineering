using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEclinicSystem
{
    public partial class AppointmentMain : Form
    {
       
        Appointment app = new Appointment();
        AppointmentHandler aHdler = new AppointmentHandler();
        StaffHandler sHlder = new StaffHandler();
        DataTable dtResult = new DataTable();

        string message = "";
        int count = 0;
        Patient patient = new Patient();

        public AppointmentMain(string pID)
        {
            patient.PatientID = pID;
            InitializeComponent();
            gpNames();
            fillTime();
            fillRemark();

        }

        public void gpNames()
        {
            dtResult = sHlder.selectAllDP();

            foreach (DataRow row in dtResult.Rows)
            {
                gpName.Items.Add(row["name"].ToString());             
            }       

            gpName.SelectedIndex=0;
        }

        public void fillTime()
        {

            var start = DateTime.ParseExact("09:00", "HH:mm",CultureInfo.InvariantCulture);
            var clockQuery = from offset in Enumerable.Range(0,37)
                             select start.AddMinutes(20 * offset);

            foreach (var time in clockQuery)
                timeList.Items.Add(time.ToString("hh:mm tt"));
            timeList.SelectedIndex = 0;
        }

        public void fillRemark()
        {
            remark.Items.Add("None");
            remark.Items.Add("Immediate");
            remark.Items.Add("Others");
            remark.SelectedIndex = 0;
        }

        private void createApt_Click(object sender, EventArgs e)
        {
            Staff staff2 = new Staff();
            app.Date = date.Value.Date;
            app.Time = DateTime.Parse(timeList.SelectedItem.ToString());
            app.Remark = remark.SelectedItem.ToString();
            staff2.StaffID = dtResult.Rows[gpName.SelectedIndex]["staffID"].ToString();
            DateTime aptTime = DateTime.Parse(app.Date.ToString("dd/MM/yyyy") + " " + app.Time.ToString("hh:mm tt"));

            if (aptTime < DateTime.Now)
            {
                MessageBox.Show("Pass Time or Date is not allowed");
                return;
            }

            if (app.Remark == "Immediate")
            {
                OverSurgerySystem dbCon = new OverSurgerySystem();
                message = aHdler.book(patient.PatientID, staff2.StaffID, app);
                MessageBox.Show(message);
            }
            else
            {
                count = aHdler.check(staff2.StaffID, app);
                if(count > 0)
                {
                    MessageBox.Show("Appointment Clash! Please select another Date");
                    return;
                }else
                {
                    message = aHdler.book(patient.PatientID, staff2.StaffID, app);
                    MessageBox.Show(message);
                }
            }
        }

      
    }
}
