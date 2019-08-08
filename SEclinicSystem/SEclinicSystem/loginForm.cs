using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEclinicSystem
{
    public partial class LoginForm : Form
    {
        
        ReceptionistHandler rHdler = new ReceptionistHandler();
        Receptionist receptionist = new Receptionist();
        bool access;
            
        const string message = "Please enter your ID or password";
        const string message2 = "Wrong ID or password";
        const string caption = "Alert";

        public LoginForm()
        {
            InitializeComponent();
          
        }

        public string Crypt(string password)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = md5.ComputeHash(utf8.GetBytes(password));
                return Convert.ToBase64String(data);
            }
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
                // id:admin
                // pw:1234
                receptionist.LoginID = idBox.Text;
                receptionist.Password = Crypt(pwBox.Text);
              
                access = rHdler.login(receptionist); 

                if(access == true)
                {
                    this.Hide();
                    Main main = new Main(receptionist.LoginID);
                    main.ShowDialog();

                }else
                {
                    MessageBox.Show(message2, caption);
                }

            }

        }
  
    }
}
