using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
//using EASendMail;
using MySql.Data.MySqlClient;

namespace Airline_Ticket_Reservation_System
{
    class Email
    {
        private string subject;
        private string recipient;
        private string attachment;
        public string ReservationDetails;
        //{
        //    set { reservationDetails = value; }
        //    get { return reservationDetails; }
        //}
        public string Subject
        {
            set { subject = value; }
            get { return subject; }
        }
        public string Body;
        //{
        //    set { body = value; }
        //    get { return subject; }
        //}
        public string Recipient
        {
            set { recipient = value; }
            get { return recipient; }
        }
        public string Attachment
        {
            set { attachment = value; }
            get { return attachment; }
        }
        //GMAIL CODES
        public bool SendEmail()
        {
            bool send_email = false;
            try
            {
                string from, pass;
                MailMessage email = new MailMessage();
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");     // email provider, in this case its gmail
                email.From = new MailAddress("a.skanda265@gmail.com");   // sender's address
                email.Subject = Subject;
                email.Body = Body;
                email.CC.Add(new MailAddress("walco256@gmail.com", "King Kaunda")); //display name
                from = "a.skanda265@gmail.com"; // sender address
                pass = "systemadmin";   // sender password

                foreach (var item in Recipient.Split(new[] { ": " }, StringSplitOptions.RemoveEmptyEntries)) // we need to spit Textbox 
                {
                    email.To.Add(item);
                }

                smtp.UseDefaultCredentials = false;
                if (Attachment != "")
                {
                    //checking if attachment textfield is not empty so that we can be abble to send the email with attachment in this section
                    email.Attachments.Add(new Attachment(Attachment));

                    smtp.EnableSsl = true;
                    smtp.Port = 587;
                    //smtp.Port = 465; 
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential(from, pass); //sign in credentials email, password
                    smtp.Send(email);
                    send_email = true;
                    MessageBox.Show("Email sent Successfully", "Success");

                }
                else
                {
                    //send without attachment  
                    smtp.EnableSsl = true;
                    smtp.Port = 587;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential(from, pass); //sign in credentials email, password
                    smtp.Send(email);
                    send_email = true;
                    MessageBox.Show("Email sent Successfully", "Success");
                }
            }
            catch (Exception ex)
            {
                send_email = false;
                MessageBox.Show("Error Ocurred: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //Var.le.Hide();
            }
            finally
            {
                Var.dataconn.closeConnection();
            }
            return send_email;
        }
        public void SendItineraryDetails()
        {
            try
            {

                Body = "Reservation has been made successfully, your Reservation Reference is: " + ReservationDetails + ". Thank you for dealing with us. BLUEBERRY TRAVELS.";
                Subject = "Ticket Reservation Confirmation";

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;

                //(uernamame, Password)
                smtp.Credentials = new NetworkCredential("a.skanda265@gmail.com", "systemadmin");

                //(from, to, subject, body)
                MailMessage mail = new MailMessage("walco265gmail.com", Recipient, Subject, Body);
                mail.Priority = MailPriority.High;
                smtp.Send(mail);
                MessageBox.Show(" Reservation Details sent to email successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("failed to send email of Reservation details: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Var.dataconn.closeConnection();
            }
        }

        //YAHOO CODES

        public void LoadEmailAdress(ListBox lst)
        {
            try
            {

                string query = "SELECT Email FROM passengers";
                Var.dataconn.executeReader(query);
                while (Var.dataconn.reader.Read())
                {
                    lst.Items.Add(Var.dataconn.reader["Email"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Var.dataconn.closeConnection();
            }

        }


        //public bool SendEmail()
        //{
        //    bool mail = false;
        //    try
        //    {
        //        SmtpMail oMail = new SmtpMail("TryIt");

        //        //yahoo email address
        //        oMail.From = "a.skanda265@gmail.com";
        //        oMail.To = Recipient;
        //        //subject
        //        oMail.Subject = Subject;
        //        //body
        //        oMail.TextBody = Body;

        //        //Yahoo SMTP server address
        //        SmtpServer oServer = new SmtpServer("smtp.mail.yahoo.com");

        //        oServer.User = "a.skanda265@gmail.com";
        //        oServer.Password = "systemadmin";

        //        // Because yahoo deploys SMTP server on 465 port with implicit SSL connection.
        //        // So we should change the port to 465.
        //        oServer.Port = 465;
        //        // detect SSL type automatically
        //        oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

        //        SmtpClient oSmtp = new SmtpClient();
        //        oSmtp.SendMail(oServer, oMail);
        //        mail = true;
        //    }

        //    catch (Exception e)
        //    {
        //        mail = false;
        //        MessageBox.Show("Failed to Send Email", "ERROR MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        MessageBox.Show(e.Message, "ERROR MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //    }
        //    return mail;
        //}


    }
}
