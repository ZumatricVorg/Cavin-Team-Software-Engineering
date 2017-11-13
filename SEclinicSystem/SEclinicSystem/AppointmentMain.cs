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
        Appointment appointment = new Appointment();

        public AppointmentMain()
        {
            InitializeComponent();
            gpNames();
            fillTime();
            fillRemark();
        }

        public void gpNames()
        {
            gpName.Items.Add("doctor1");
            gpName.SelectedIndex = 0;
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
            remark.Items.Add("none");
            remark.Items.Add("immediate");
            remark.Items.Add("others");
            remark.SelectedIndex = 0;
        }

        private void createApt_Click(object sender, EventArgs e)
        {
            string remarkText = remark.Text;
            appointment.setDate(date.Value);
            appointment.setTime(timeList.SelectedItem.ToString());

            if (remarkText == "immediate")
            {
                // timeList.SelectedItem + "','" + date.Value.ToShortDateString() + "', 'pending', '" + remark.SelectedItem
               
                appointment.book("1",appointment.getTime(), appointment.getDate().Date, remarkText);
                
            }
            else
            {
                TimeSpan toTime = TimeSpan.Parse(appointment.getTime());
                DateTime aptTime = appointment.getDate() + toTime;
                //aptTime = aptTime + appointment.getDate().Date;
                int checkTime = DateTime.Compare(aptTime,DateTime.Now);
                //int checkDate = DateTime.Compare(appointment.getDate().Date,now.Date);         
                //if aptTime > now = 1
                //if aptTime < now = -1
                //if aptTime == now = 0 

                if(checkTime >= 0)
                {
                    appointment.check("1", appointment.getDate().Date, appointment.getTime());

                }else
                {
                    MessageBox.Show("Pass time is not valid");
                }

            }
        }
    }
}
