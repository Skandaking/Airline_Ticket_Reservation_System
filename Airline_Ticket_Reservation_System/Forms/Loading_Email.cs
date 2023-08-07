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
    public partial class Loading_Email : Form
    {
        Timer SendMail;
        public Loading_Email()
        {
            SendMail = new Timer();
            SendMail.Interval = 10000;
           
            SendMail.Tick += SendMail_Tick;
            InitializeComponent();
        }

        private void SendMail_Tick(object sender, EventArgs e)
        {

            MessageBox.Show("hello world " + Var.mail.Body);
            if (Var.mail.SendEmail().Equals(true))
            {
            Var.mf.EmailBody.Clear();
            Var.mf.EmailSubject.Clear();
            Var.mf.EmailRecipient.Clear();
            Var.mf.Attachment.Clear();
            

            }
            SendMail.Stop();
            this.Close();
            
        }

        private void Loading_Email_Load(object sender, EventArgs e)
        {
            SendMail.Start();
        }

        private void Cancel_Mail_btn_Click(object sender, EventArgs e)
        {
            SendMail.Stop();
            if (MessageBox.Show("this will cancel your mail, Are you sure?", "                               CANCEL EMAIL",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                
                this.Close();
            }
            SendMail.Start();

        }
    }
}
