using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Airline_Ticket_Reservation_System
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            RecoveryPanel.Height = 0;

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Close Application?", "Close Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void Btn_Exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Exit Application?", "Close Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void cmdExit_Click(object sender, EventArgs e)
        {
            
        }

        //timer to fade out the form when login
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0.0)
            {
                this.Opacity -= 0.025;
            }
            else
            {
                timer1.Stop();
                Main_Form mf = new Main_Form();

                mf.Show();
                this.Hide();
                txtUsername.Clear();
                txtPassword.Clear();

            }
        }
        private void Btn_Login_Click(object sender, EventArgs e)
        {
            Var.use.Username = txtUsername.Text;
            Var.use.Password = txtPassword.Text;

            if (Var.use.Login().Equals(true))
            {
                timer1.Enabled.Equals(true);
                timer1.Start();
            }
        }
        private void cmdLogin_Click(object sender, EventArgs e)
        {
           
            
        }

        private void Login_Load(object sender, EventArgs e)
        {
            lsv1.Visible = false;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This service has been suspended, contact admin!","INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //lsv1.Items.Clear();
            //lsv1.Visible = false;
            //string value;
            //value = "Recovery";
            //label1.Text = value;
            //bunifuSeparator1.LineColor = Color.LightGray;
            //bunifuSeparator2.LineColor = Color.Blue;
            //RecoveryPanel.Visible = false;
            //RecoveryPanel.Height = 218;
            //loginPanel.Visible = false;
            //panel8Animator.ShowSync(RecoveryPanel);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string value;
            value = "Login";
            label1.Text = value;
            bunifuSeparator1.LineColor = Color.Blue;
            bunifuSeparator2.LineColor = Color.LightGray;
            loginPanel.Visible = false;
            RecoveryPanel.Height = 0;
            loginPanel.Height = 218;
            //loginPanel.Visible = true;
            panel8Animator.ShowSync(loginPanel);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Do you want to Exit Application?", "Close Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void cmdRecover_Click(object sender, EventArgs e)
        {
            Var.use.Username = txtRecUsername.Text;
            
            if (MessageBox.Show("If this won't be helpfull please contact Admin", "Notification", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                
                txtRecUsername.Clear();
                lsv1.Visible = true;
                Var.use.RecoverAccount(lsv1);
            }
        }


      
        //password viewer
        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            
            if (txtPassword.UseSystemPasswordChar == true)
            {
                bunifuImageButton2.BackgroundImage = Properties.Resources.eyeClose;
                txtPassword.UseSystemPasswordChar = false;
            }

            else
            {
                bunifuImageButton2.BackgroundImage = Properties.Resources.eyeOpen;
                txtPassword.UseSystemPasswordChar = true;
            }
                
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar.Equals(true))
                txtPassword.UseSystemPasswordChar.Equals(false);
            else
                txtPassword.UseSystemPasswordChar.Equals(true);
        }

        
    }
}
