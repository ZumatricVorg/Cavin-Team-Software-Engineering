using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEclinicSystem
{
    public partial class LoginForm : Form
    {
        
        OverSurgerySystem overSystem = new OverSurgerySystem();
        Receptionist receptionist = new Receptionist();
        bool access;
            
        const string message = "Please enter your ID or password";
        const string message2 = "Wrong ID or password";
        const string caption = "Alert";

        public LoginForm()
        {
            InitializeComponent();
            Application.Run(new AppointmentMain());
        }

        private void login_Click(object sender, EventArgs e)
        {
           
           
            if(idBox.Text == "" || pwBox.Text == "" )
            {
                MessageBox.Show(message, caption);
            }else
            {
                //String id = idBox.Text;
                //String pw = pwBox.Text;
           
                receptionist.SetloginID(idBox.Text);
                receptionist.SetPassword(pwBox.Text);


               access = overSystem.login(receptionist.GetloginID(),receptionist.GetPassword()); 

                if(access == true)
                {
                    this.Hide();
                    Main main = new Main(receptionist.GetloginID());
                    main.ShowDialog();

                }else
                {
                    MessageBox.Show(message2, caption);
                }

            }

        }
  
    }
}
