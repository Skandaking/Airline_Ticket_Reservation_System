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
    public partial class LoadingPage : Form
    {
        public LoadingPage()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string value;
            bunifuCircleProgressbar1.Value = bunifuCircleProgressbar1.Value + 1;
            if (bunifuCircleProgressbar1.Value >= 10)
            {
                value = "       Loading Pages...    ";
                label4.Text = value;
            }
            if (bunifuCircleProgressbar1.Value >= 20)
            {
                value = "     retrieving data...    ";
                label4.Text = value;
            }
            if (bunifuCircleProgressbar1.Value >= 30)
            {
                value = "       unpacking data...   ";
                label4.Text = value;
            }
            if (bunifuCircleProgressbar1.Value >= 40)
            {
                value = "connecting to database...";
                label4.Text = value;
            }
            if (bunifuCircleProgressbar1.Value >= 50)
            {
                value = "  Preparing interface...  ";
                label4.Text = value;
            }
            if (bunifuCircleProgressbar1.Value >= 60)
            {
                value = "     Loading Schedules...  ";
                label4.Text = value;
            }
            if (bunifuCircleProgressbar1.Value >= 70)
            {
                value = "Retrieving Customer Data...";
                label4.Text = value;
            }
            if (bunifuCircleProgressbar1.Value >= 80)
            {
                value = "        Please wait...    ";
                label4.Text = value;
                //timer2.Enabled.Equals(true);
                //timer2.Start();
            }
            if (bunifuCircleProgressbar1.Value >= 90)
            {
                value = "        Almost there...    ";
                label4.Text = value;
               
            }
            if (bunifuCircleProgressbar1.Value >= 99)
            {
                this.Hide();
                Login lg = new Login();
                lg.Show();

                timer1.Enabled = false;
                bunifuCircleProgressbar1.Value = bunifuCircleProgressbar1.Value - 1;

            }
        }

        private void LoadingPage_Load(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if(this.Opacity > 0.0)
            {
                this.Opacity -= 0.025;
            }
            else
            {
                timer2.Stop();
                
            }
        }
    }
}
