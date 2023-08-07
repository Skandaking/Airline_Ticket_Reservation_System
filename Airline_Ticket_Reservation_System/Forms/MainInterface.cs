using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Drawing.Printing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using S22.Imap;
using System.IO;
using DGVPrinterHelper;

namespace Airline_Ticket_Reservation_System
{
    public partial class MainInterface : Form
    {
        flightSchedules fs = new flightSchedules();
        Passengers pass = new Passengers();
        Timer t = new Timer();
        public MainInterface()
        {
            InitializeComponent();
            //m = this;

        }

        private void MainInterface_Load(object sender, EventArgs e)
        {
            //load Comboboxes on startup
            Var.air.LoadAirlineIDs(cmbScheduleAirlineID);
            Var.air.LoadAirlineIDs(cmbAirlineID);
            Var.pass.LoadPassengerNames(cmbRetTraveler1);
            Var.pass.LoadPassengerNames(cmbRetTraveler2);
            Var.pass.LoadPassengerNames(cmbOnewayTraveler);

            //loading Datagrid views
            Var.air.LoadAirlines(AirlineDataGridView);
            Var.mail.LoadEmailAdress(EmailslistBox);
            Var.reserve.LoadReservations(flightdReservationsDataGV);
            Var.fs.LoadSchedules(SchedulesDataGridView);
            Var.fs.LoadSchedules(ReservationFlightSchedulesDGV);
            Var.pass.loadPassengers(PassengerDataGridView);
            Var.pass.loadPassengersEmails(PassengerEmailsDGV);
            Var.ac.LoadAircraft(AircraftDataGridView);
            Var.ac.LoadAirlineAircraft(AircraftAirlineDataGridView);
            Var.use.LoadUsers(User_DataGridView);




            SchedulesDataGridView.Height = 600;
            SchedulesDataGridView.Location = new System.Drawing.Point(6, 55);
            PannelAddNewSchdules.Height = 5;
            //possitioning the passengers datagrid view
            PassengerDataGridView.Location = new System.Drawing.Point(6, 100);
            PassengerDataGridView.Height = 550;

            //defalt booking Total cost 
            txtRetTotalCost.Text = "0";

            //menu pannel default logo visibility
            pnlBigLogo.Visible = false;
            pnlSmallLogo.Visible = true;


            lblUsername.Text = " " + Var.use.Username;
            lblUsername.Visible = false;
            leftMenuPanel.Width = 53;

            // timer in intervals 
            t.Interval = 1000; //in milliseconds
            t.Tick += new EventHandler(this.t_tick);

            //start timer on foarm load
            t.Start(); //uses t_tick
        }

        //#####################  TIMER EVENT CODES STARTS HERE #########################
        private void t_tick(object sender, EventArgs e)
        {
            int hh = DateTime.Now.Hour;
            int mm = DateTime.Now.Minute;
            int ss = DateTime.Now.Second;


            string time = "";
            if (hh < 10)
            {
                time += "0" + hh;
            }
            else
            {
                time += hh;
            }
            time += ":";
            if (mm < 10)
            {
                time += "0" + mm;
            }
            else
            {
                time += mm;
            }
            time += ":";
            if (ss < 10)
            {
                time += "0" + ss;
            }
            else
            {
                time += ss;
            }
            //updatte label
            txtclock.Text = time;
            if (hh < 12 && mm < 59)
                lblgreetings.Text = "good morning" + lblUsername.Text;
            if (hh >= 12)
                lblgreetings.Text = "good afternoon" + lblUsername.Text;
            if (hh > 15)
                lblgreetings.Text = "good evening" + lblUsername.Text;


        }

        //#####################  MENU CODES STARTS HERE ##########################
        private void MinimisePanel()
        {
            if (leftMenuPanel.Width == 192)
            {
                //Expand the panel
                pnlBigLogo.Visible = true;
                pnlSmallLogo.Visible = false;
                metroToolTip1.Active = false;
                leftMenuPanel.Visible = false;
                leftMenuPanel.Width = 53;
                panel8Animator.ShowSync(leftMenuPanel);
            }
            else
                leftMenuPanel.Width.Equals(53);
        }
        private void Menu_btn_Click(object sender, EventArgs e)
        {
            if (leftMenuPanel.Width == 53)
            {
                //Expand the panel
                pnlBigLogo.Visible = true;
                pnlSmallLogo.Visible = false;
                metroToolTip1.Active = false;
                leftMenuPanel.Visible = false;
                leftMenuPanel.Width = 192;
                panel8Animator.ShowSync(leftMenuPanel);

            }
            else
            {
                // Minimize panel
                // using bunifu transition
                // side the panel
                pnlBigLogo.Visible = false;
                pnlSmallLogo.Visible = true;
                metroToolTip1.Active = true;
                leftMenuPanel.Visible = false;
                leftMenuPanel.Width = 53;
                panel8Animator.ShowSync(leftMenuPanel);
            }
        }
        private void cmdSchedules_Click(object sender, EventArgs e)
        {
            Slidepanel.Height = cmdSchedules.Height;
            Slidepanel.Top = cmdSchedules.Top;
            MailnTabControl.SelectedTab = tabSchedules;
            MinimisePanel();

        }

        private void cmdPassengers_Click(object sender, EventArgs e)
        {
            Slidepanel.Height = cmdPassengers.Height;
            Slidepanel.Top = cmdPassengers.Top;
            MailnTabControl.SelectedTab = tabPassengers;
            MinimisePanel();
        }

        private void cmdAirlines_Click(object sender, EventArgs e)
        {
            Slidepanel.Height = cmdAirlines.Height;
            Slidepanel.Top = cmdAirlines.Top;
            MailnTabControl.SelectedTab = tabAirlines;
            MinimisePanel();
        }
        private void cmdReports_Click(object sender, EventArgs e)
        {
            Slidepanel.Height = cmdReports.Height;
            Slidepanel.Top = cmdReports.Top;
            MailnTabControl.SelectedTab = tabReports;
            MinimisePanel();

        }
        private void cmdSettings_Click(object sender, EventArgs e)
        {
            Slidepanel.Height = cmdSettings.Height;
            Slidepanel.Top = cmdSettings.Top;
            MailnTabControl.SelectedTab = tabSettings;
            MinimisePanel();
        }
        private void cmdHelp_Click(object sender, EventArgs e)
        {
            Slidepanel.Height = cmdHelp.Height;
            Slidepanel.Top = cmdHelp.Top;
            MailnTabControl.SelectedTab = tabHelp;
            MinimisePanel();
        }
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Close Application?", "Close Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Close();
        }

        private void cmdInfo_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void tabHelp_Click(object sender, EventArgs e)
        {

        }

        private void cmdReservation_Click(object sender, EventArgs e)
        {
            Slidepanel.Height = cmdReservation.Height;
            Slidepanel.Top = cmdReservation.Top;
            MailnTabControl.SelectedTab = tabBookings;
            MinimisePanel();
        }

        private void leftMenuPanel_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btnMinimise_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;

        }
        //------------------------------------------------------------------------

        //#####################  RESERVATION CODES STARTS HERE ##########################   


        private void tabPageReturn_Click(object sender, EventArgs e)
        {

        }

        private void tabPageOneWay_Click(object sender, EventArgs e)
        {

        }

        private void tabPageMulticity_Click(object sender, EventArgs e)
        {

        }
        private void txtRetBoardTime1_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            txtRetFrom1.Clear();
            txtRetFrom2.Clear();
            txtRetTo1.Clear();
            txtRetTo2.Clear();
            combRetClass1.SelectedIndex = 0;
            combRetClass2.SelectedIndex = 0;
            txtRetCost1.Clear();
            txtRetCost2.Clear();
            txtRetTotalCost.Clear();
            txtRetReservationRef2.Clear();
        }
        private void UpdateTotalCost()
        {
            try
            {
                decimal totalCost;

                if (txtRetCost1.Text != "" && txtRetCost2.Text != "")
                {
                    totalCost = Convert.ToInt32(txtRetCost2.Text) + Convert.ToInt32(txtRetCost1.Text);
                    txtRetTotalCost.Text = totalCost.ToString();
                }
                else if (txtRetCost1.Text != "" && txtRetCost2.Text == "")
                {
                    totalCost = Convert.ToInt32(txtRetCost1.Text);
                    txtRetTotalCost.Text = totalCost.ToString();
                }
                else if (txtRetCost2.Text != "" && txtRetCost1.Text == "")
                {
                    totalCost = Convert.ToInt32(txtRetCost2.Text);
                    txtRetTotalCost.Text = totalCost.ToString();
                }
                else
                    txtRetTotalCost.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void txtRetCost2_TextChanged(object sender, EventArgs e)
        {
            UpdateTotalCost();
        }

        private void txtRetCost1_TextChanged(object sender, EventArgs e)
        {
            UpdateTotalCost();
        }

        private void cmdPrintPreview_Click(object sender, EventArgs e)
        {
            //try
            //{ 
            //IDisposable id = new System.Drawing.Printing.PrintDocument();
            MYprintPreviewDialog.Document = MYprintDocument;
            MYprintPreviewDialog.ShowDialog();
            //id.Dispose();


            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void MYprintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {

            string ret1 = txtRetReservationRef1.Text.ToUpper();
            string ret2 = txtRetReservationRef2.Text.ToUpper();
            string Line = "****************************************************************************************************************************";
            Bitmap bmp = Properties.Resources.Blueberry_Header;
            Image newHeader = bmp;
            e.Graphics.DrawImage(newHeader, 25, 25, newHeader.Width, newHeader.Height);

            //################################ LINE #################################################################
            e.Graphics.DrawString(Line, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(5, 300));

            e.Graphics.DrawString("ITINERARY", new Font("Century Gothic", 22, FontStyle.Bold), Brushes.DarkOrange, new Point(5, 310));
            e.Graphics.DrawString("INFORMATION", new Font("Century Gothic", 15, FontStyle.Bold), Brushes.DarkOrange, new Point(5, 345));
            e.Graphics.DrawString("Reservation Ref: BB - " + ret1 + "-" + ret2, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(500, 320));
            e.Graphics.DrawString("Doc Issue Date:   " + DateTime.Now.ToLongDateString(), new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(500, 345));

            //################################ LINE #################################################################
            e.Graphics.DrawString(Line, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(5, 380));

            e.Graphics.DrawString("Traveler  :   " + cmbRetTraveler1.Text.ToUpper(), new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(20, 410));
            e.Graphics.DrawString("Agency        : Blueberry Travel Limited", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(500, 410));
            e.Graphics.DrawString("Agent Name: " + Var.use.Firstname + " " + Var.use.Lastname, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(500, 435));

            //################################ LINE #################################################################
            e.Graphics.DrawString(Line, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(5, 490));

            e.Graphics.DrawString("FLIGHT: " + txtRetFrom1.Text + " to " + txtRetTo1.Text, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.DarkOrange, new Point(20, 500));
            e.Graphics.DrawString("DATE: " + ScheduleDate, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.DarkOrange, new Point(660, 500));
            //################################ LINE #################################################################
            e.Graphics.DrawString(Line, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(5, 520));

            e.Graphics.DrawString("Airline:           " + combRetAirline1.Text, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(20, 545));
            e.Graphics.DrawString("Flight:   " + txtRetFlightID1.Text, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(500, 545));
            e.Graphics.DrawString("Departure:     " + RetDepdateTimePicker1.Text, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(20, 565));
            e.Graphics.DrawString("From :   " + txtRetFrom1.Text, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(500, 565));
            e.Graphics.DrawString("Arrival:           " + RetArrdateTimePicker1.Text, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(20, 585));
            e.Graphics.DrawString("To :       " + txtRetTo1.Text, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(500, 585));
            e.Graphics.DrawString("Class:             " + combRetClass1.Text, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(20, 605));
            e.Graphics.DrawString("Status : Confirmed", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(500, 605));

            //################################ LINE #################################################################
            e.Graphics.DrawString(Line, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(5, 690));

            e.Graphics.DrawString("FLIGHT: " + txtRetFrom2.Text + " to " + txtRetTo2.Text, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.DarkOrange, new Point(20, 700));
            e.Graphics.DrawString("DATE: " + ScheduleDate2, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.DarkOrange, new Point(660, 700));
            //################################ LINE #################################################################
            e.Graphics.DrawString(Line, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(5, 720));

            e.Graphics.DrawString("Airline:           " + combRetAirline2.Text, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(20, 745));
            e.Graphics.DrawString("Flight:   " + txtRetFlightID2.Text, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(500, 745));
            e.Graphics.DrawString("Departure:     " + RetDepdateTimePicker2.Text, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(20, 770));
            e.Graphics.DrawString("From :   " + txtRetFrom2.Text, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(500, 770));
            e.Graphics.DrawString("Arrival:           " + RetArrdateTimePicker2.Text, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(20, 795));
            e.Graphics.DrawString("To :       " + txtRetTo2.Text, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(500, 795));
            e.Graphics.DrawString("Class:             " + combRetClass2.Text, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(20, 820));
            e.Graphics.DrawString("Status : Confirmed", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(500, 820));


            e.Graphics.DrawString("Page 1 of 1", new Font("Century Gothic", 10, FontStyle.Regular), Brushes.Black, new Point(350, 1115));
        }
        private void printReturnItinerary()
        {
            PrintDialog print_dialog = new PrintDialog();
            PrintDocument print_document = new PrintDocument();
            print_dialog.Document = print_document;
            print_document.PrintPage += new PrintPageEventHandler(MYprintDocument_PrintPage);
            DialogResult result = print_dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                print_document.Print();
            }
        }
        private void printOnewayItinerary()
        {
            PrintDialog print_dialog = new PrintDialog();
            PrintDocument print_document = new PrintDocument();
            print_dialog.Document = print_document;
            print_document.PrintPage += new PrintPageEventHandler(MYprintDocument1_PrintPage);
            DialogResult result = print_dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                print_document.Print();
            }
        }
        string ScheduleDate;
        string ScheduleDate2;
        string OnewayScheduleDate;
        private void MultiwayfirstTextsLoad()
        {
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in ReservationFlightSchedulesDGV.SelectedCells)
            {
                cell = selectedCell;
                break;
            }
            if (cell != null)
            {
                DataGridViewRow row = cell.OwningRow;
                txtRetFlightID1.Text = row.Cells[0].Value.ToString();
                txtRetFrom1.Text = row.Cells[1].Value.ToString();
                txtRetTo1.Text = row.Cells[2].Value.ToString();
                combRetAirline1.Text = row.Cells[3].Value.ToString();
                RetDepdateTimePicker1.Text = row.Cells[4].Value.ToString();
                RetArrdateTimePicker1.Text = row.Cells[5].Value.ToString();
                ScheduleDate = row.Cells[6].Value.ToString();
                //txtScheduleStatus.Text = row.Cells[7].Value.ToString();
            }
        }
        private void MultiwaySecondTextsLoad()
        {
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in ReservationFlightSchedulesDGV.SelectedCells)
            {
                cell = selectedCell;
                break;
            }
            if (cell != null)
            {
                DataGridViewRow row = cell.OwningRow;
                txtRetFlightID2.Text = row.Cells[0].Value.ToString();
                txtRetFrom2.Text = row.Cells[1].Value.ToString();
                txtRetTo2.Text = row.Cells[2].Value.ToString();
                combRetAirline2.Text = row.Cells[3].Value.ToString();
                RetDepdateTimePicker2.Text = row.Cells[4].Value.ToString();
                RetArrdateTimePicker2.Text = row.Cells[5].Value.ToString();
                ScheduleDate2 = row.Cells[6].Value.ToString();
                //txtScheduleStatus.Text = row.Cells[7].Value.ToString();
            }
        }
        private void OnewayTextsLoad()
        {
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in ReservationFlightSchedulesDGV.SelectedCells)
            {
                cell = selectedCell;
                break;
            }
            if (cell != null)
            {
                DataGridViewRow row = cell.OwningRow;
                txtOnewayFlightID.Text = row.Cells[0].Value.ToString();
                txtOnewayFrom.Text = row.Cells[1].Value.ToString();
                txtOnewayTo.Text = row.Cells[2].Value.ToString();
                combOnewayAirline.Text = row.Cells[3].Value.ToString();
                OnewayDepdateTimePicker.Text = row.Cells[4].Value.ToString();
                OnewayArrdateTimePicker.Text = row.Cells[5].Value.ToString();
                OnewayScheduleDate = row.Cells[6].Value.ToString();
                //txtScheduleStatus.Text = row.Cells[7].Value.ToString();
            }
        }
        private void onewayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnewayTextsLoad();
        }
        private void firstToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MultiwayfirstTextsLoad();
        }
        private void secondToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MultiwaySecondTextsLoad();
        }
        //private void SendReservationEmail()
        //{
        //    string EmailText;
        //    //try
        //    //{
        //    //    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
        //    //    smtp.EnableSsl = true;
        //    //    smtp.UseDefaultCredentials = false;

        //    //    //(uernamame, Password)
        //    //    smtp.Credentials = new NetworkCredential("cyrilmvula@gmail.com", "23rdMay1995");

        //    //    //(from, to, subject, body)
        //     MailMessage mail = new MailMessage("cyrilmvula@gmail.com", EmailText, textBoxSubject.Text, txtMessage.Text);
        //    //    mail.Priority = MailPriority.High;
        //    //    smtp.Send(mail);

        //    //    MessageBox.Show("Mail Sent");
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    MessageBox.Show(ex.Message);
        //    //}
        //}
        private void cmdReturnBookFlight_Click(object sender, EventArgs e)
        {
            if (txtRetReservationRef1.Text.Equals("") || txtRetFlightID1.Text.Equals("") || cmbRetTraveler1.Text.Equals("") || combRetClass1.Text.Equals("") || txtRetCost1.Text.Equals("") || txtRetReservationRef2.Text.Equals("") || txtRetFlightID2.Text.Equals("") || cmbRetTraveler2.Text.Equals("") || combRetClass2.Text.Equals("") || txtRetCost2.Text.Equals(""))
            {
                MessageBox.Show("please fill in all text boxes");
            }
            else
            {


                Var.reserve.Reservation_Ref = txtRetReservationRef1.Text.ToUpper();
                Var.reserve.Flight_ID = txtRetFlightID1.Text.ToUpper();
                Var.reserve.Passenger_Name = cmbRetTraveler1.Text;
                Var.reserve._Class = combRetClass1.Text;
               // Var.reserve.Issued_Date =  /*DateTime.Now.ToShortDateString();*/                            //ToShortDateString();
                Var.reserve.Cost = txtRetCost1.Text;


                //label74.Text = Var.reserve.Email_Address;

                //Var.reserve.ReserveFlight();
                if (Var.reserve.ReserveFlight().Equals(true))
                {
                    Var.reserve.Reservation_Ref = txtRetReservationRef2.Text.ToUpper();
                    Var.reserve.Flight_ID = txtRetFlightID2.Text.ToUpper();
                    Var.reserve.Passenger_Name = cmbRetTraveler2.Text;
                    Var.reserve._Class = combRetClass2.Text;
                    //Var.reserve.Issued_Date = bookingDTP;
                    Var.reserve.Cost = txtRetCost2.Text;

                    if (Var.reserve.ReserveFlight().Equals(true))
                    {
                        printReturnItinerary();
                        //MessageBox.Show("Reservation Has Been Made Successfully");

                        if (MessageBox.Show("Reservation Has Been Made Successfully, Do you want to send Reservation Details to email?", "RESERVATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Var.mail.Recipient = Var.reserve.Email_Address;
                            Var.mail.ReservationDetails = txtRetReservationRef1.Text.ToUpper() + " and " + txtRetReservationRef2.Text.ToUpper();
                            Var.mail.SendItineraryDetails();
                            //try
                            //{
                            //    string emailAddress = Var.reserve.Email_Address;
                            //    string Message = "Reservation has been made successfully, your Reservation Reference(s): " + txtRetReservationRef1.Text.ToUpper() + " and " + txtRetReservationRef2.Text.ToUpper() + ". Thank you for dealing with us. BLUEBERRY TRAVELS.";
                            //    string Subject = "Ticket Reservation Confirmation";

                            //    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                            //    smtp.EnableSsl = true;
                            //    smtp.UseDefaultCredentials = false;

                            //    //(uernamame, Password)
                            //    smtp.Credentials = new NetworkCredential("cyrilmvula@gmail.com", "23rdMay1995");

                            //    //(from, to, subject, body)
                            //    MailMessage mail = new MailMessage("cyrilmvula@gmail.com", emailAddress, Subject, Message);
                            //    mail.Priority = MailPriority.High;
                            //    smtp.Send(mail);
                            //    MessageBox.Show(" Reservation Details sent to email successfully");
                            //}
                            //catch (Exception ex)
                            //{
                            //    MessageBox.Show("failed to send email of Reservation details " + ex.Message);
                            //}
                        }
                        Var.reserve.LoadReservations(flightdReservationsDataGV);
                        txtRetFrom1.Clear();
                        txtRetFrom2.Clear();
                        txtRetTo1.Clear();
                        txtRetTo2.Clear();
                        txtRetCost1.Clear();
                        txtRetCost2.Clear();
                        txtRetReservationRef1.Clear();
                        txtRetReservationRef2.Clear();
                        txtRetFlightID1.Clear();
                        txtRetFlightID2.Clear();
                        txtRetTotalCost.Clear();
                    }

                }
                //Var.reserve.ReserveFlight();


                //MYprintDocument.Print();

            }

        }

        private void cmdOnewayBookFlight_Click(object sender, EventArgs e)
        {
            if (txtOnewayReservationRef.Text.Equals("") || txtOnewayFlightID.Text.Equals("") || cmbOnewayTraveler.Text.Equals("") || combOnewayClass.Text.Equals("") || txtOnewayCost.Text.Equals(""))
                MessageBox.Show("please fill in all text boxes");
            else
            {

                Var.reserve.Reservation_Ref = txtOnewayReservationRef.Text.ToUpper();
                Var.reserve.Flight_ID = txtOnewayFlightID.Text.ToUpper();
                Var.reserve.Passenger_Name = cmbOnewayTraveler.Text;
                Var.reserve._Class = combOnewayClass.Text;
                //Var.reserve.Issued_Date = DateTime.Now.ToShortDateString();
                Var.reserve.Cost = txtOnewayCost.Text;
                if (Var.reserve.ReserveFlight().Equals(true))
                {
                    printOnewayItinerary();
                    if (MessageBox.Show("Reservation Has Been Made Successfully, Do you want to send Reservation Details to email?", "RESERVATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Var.mail.Recipient = Var.reserve.Email_Address;
                        Var.mail.ReservationDetails = txtOnewayReservationRef.Text.ToUpper();
                        Var.mail.SendItineraryDetails();
                    }
                    Var.reserve.LoadReservations(flightdReservationsDataGV);

                    txtOnewayReservationRef.Clear();
                    txtOnewayFlightID.Clear();
                    txtOnewayFrom.Clear();
                    txtOnewayTo.Clear();
                    txtOnewayReservationRef.Clear();
                    txtOnewayCost.Clear();
                    txtOnewayTotalCost.Clear();

                }
            }
        }

        private void txtOnewayCost_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal totalCost;

                if (txtOnewayCost.Text != "")
                {
                    totalCost = Convert.ToInt32(txtOnewayCost.Text);
                    txtOnewayTotalCost.Text = totalCost.ToString();
                }
                else
                    txtRetTotalCost.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmdClearOneway_Click(object sender, EventArgs e)
        {
            txtOnewayFrom.Clear();
            txtOnewayTo.Clear();
            combOnewayClass.SelectedIndex = 0;
            txtOnewayCost.Clear();
            txtOnewayTotalCost.Clear();
            txtOnewayReservationRef.Clear();
        }

        private void cmdPreviewOneway_Click(object sender, EventArgs e)
        {
            ////IDisposable id = new System.Drawing.Printing.PrintDocument();
            MYprintPreviewDialog1.Document = MYprintDocument1;
            MYprintPreviewDialog1.ShowDialog();
            //MYprintPreviewDialog1.Dispose();
            ////id.Dispose();
        }
        private void txtSearchFligts2_TextChanged(object sender, EventArgs e)
        {
            Var.fs.searchSchedules(txtSearchFligts2.Text, ReservationFlightSchedulesDGV);
        }

        private void MYprintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            string Line = "****************************************************************************************************************************";
            Bitmap bmp = Properties.Resources.Blueberry_Header;
            Image newHeader = bmp;
            e.Graphics.DrawImage(newHeader, 25, 25, newHeader.Width, newHeader.Height);

            //################################ LINE #################################################################
            e.Graphics.DrawString(Line, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(5, 300));

            e.Graphics.DrawString("ITINERARY", new Font("Century Gothic", 22, FontStyle.Bold), Brushes.DarkOrange, new Point(5, 310));
            e.Graphics.DrawString("INFORMATION", new Font("Century Gothic", 15, FontStyle.Bold), Brushes.DarkOrange, new Point(5, 345));
            e.Graphics.DrawString("Reservation Ref: BB - " + txtOnewayReservationRef.Text.ToUpper(), new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(500, 320));
            e.Graphics.DrawString("Doc Issue Date:   " + DateTime.Now.ToLongDateString(), new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(500, 345));

            //################################ LINE #################################################################
            e.Graphics.DrawString(Line, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(5, 380));

            e.Graphics.DrawString("Traveler  :   " + cmbOnewayTraveler.Text.ToUpper(), new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(20, 410));
            e.Graphics.DrawString("Agency        : Blueberry Travel Limited", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(500, 410));
            e.Graphics.DrawString("Agent Name: " + Var.use.Firstname + " " + Var.use.Lastname, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(500, 435));

            //################################ LINE #################################################################
            e.Graphics.DrawString(Line, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(5, 490));

            e.Graphics.DrawString("FLIGHT: " + txtOnewayFrom.Text + " to " + txtOnewayTo.Text, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.DarkOrange, new Point(20, 500));
            e.Graphics.DrawString("DATE: " + OnewayScheduleDate, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.DarkOrange, new Point(660, 500));
            //################################ LINE #################################################################
            e.Graphics.DrawString(Line, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(5, 520));

            e.Graphics.DrawString("Airline:           " + combOnewayAirline.Text, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(20, 545));
            e.Graphics.DrawString("Flight:   " + txtOnewayFlightID.Text, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(500, 545));
            e.Graphics.DrawString("Departure:     " + OnewayDepdateTimePicker.Text, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(20, 565));
            e.Graphics.DrawString("From :   " + txtOnewayFrom.Text, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(500, 565));
            e.Graphics.DrawString("Arrival:           " + OnewayArrdateTimePicker.Text, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(20, 585));
            e.Graphics.DrawString("To :       " + txtOnewayTo.Text, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(500, 585));
            e.Graphics.DrawString("Class:             " + combOnewayClass.Text, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(20, 605));
            e.Graphics.DrawString("Status : Confirmed", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(500, 605));

            e.Graphics.DrawString("Page 1 of 1", new Font("Century Gothic", 10, FontStyle.Regular), Brushes.Black, new Point(350, 1115));
        }
        //--------------------------------- RESERVATION ENDS HERE----------------------------------------------------------------------

        private void tabPassengers_Click(object sender, EventArgs e)
        {

        }

        private void tabAirlines_Click(object sender, EventArgs e)
        {

        }

        private void cmdPassengersList_Click(object sender, EventArgs e)
        {
            IndicatorPannel.Width = cmdPassengersList.Width;
            IndicatorPannel.Left = cmdPassengersList.Left;
            panelAddNewPassenger.Visible = false;
            //panel8Animator.ShowSync(IndicatorPannel);
            PassengerDataGridView.Location = new System.Drawing.Point(6, 100);
            PassengerDataGridView.Height = 550;

        }

        private void cmdAddNewPassenger_Click(object sender, EventArgs e)
        {
            IndicatorPannel.Width = cmdAddNewPassengerTab.Width;
            IndicatorPannel.Left = cmdAddNewPassengerTab.Left;
            panelAddNewPassenger.Visible = true;
            //panel8Animator.ShowSync(IndicatorPannel);
            PassengerDataGridView.Location = new System.Drawing.Point(6, 232);
        }

        private void Slidepanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelAddNewPassenger_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmdMore_Click(object sender, EventArgs e)
        {
            ManipulateSchedules();

        }

        private void ManipulateSchedules()
        {
            if (PannelAddNewSchdules.Height == 5)
            {
                PannelAddNewSchdules.Height = 127;
                SchedulesDataGridView.Height = 444;
                cmdMore.BackgroundImage = Properties.Resources.Colapse;
                SchedulesDataGridView.Location = new System.Drawing.Point(7, 185);
            }
            else
            {
                PannelAddNewSchdules.Height = 5;
                cmdMore.BackgroundImage = Properties.Resources.expand;
                SchedulesDataGridView.Height = 600;
                SchedulesDataGridView.Location = new System.Drawing.Point(6, 55);
            }
        }

        private void SchedulesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        

        private void cmdPrintSchedules_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;
            printSchedules_DGV();
        }    
        private void printSchedules_DGV()
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "SCHEDULES";
            printer.SubTitle = "flights schedules available as on " + DateTime.Today.ToLongDateString();
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Blueberry Travels Malawi";
            printer.FooterSpacing = 15;

            printer.PrintDataGridView(SchedulesDataGridView);
            //printer.PrintPreviewDataGridView(SchedulesDataGridView);
        }

        private void cmdEmails_Click(object sender, EventArgs e)
        {
            Slidepanel.Height = cmdEmails.Height;
            Slidepanel.Top = cmdEmails.Top;
            MailnTabControl.SelectedTab = tabEmails;
            MinimisePanel();
        }

        private void tabPageInbox_Click(object sender, EventArgs e)
        {

        }

        private void cmdReceive_Click(object sender, EventArgs e)
        {
            //CheckEmails();
        }

        private void groupBox10_Enter(object sender, EventArgs e)
        {

        }




        private void cmdListAirlines_Click(object sender, EventArgs e)
        {
            NavPanel.Height = cmdListAirlines.Height;
            NavPanel.Left = cmdListAirlines.Left;
            AirlinesTabControl.SelectedTab = ListAirlineTabPage;
        }

        private void cmdEditAirlines_Click(object sender, EventArgs e)
        {
            NavPanel.Height = cmdEditAirlines.Height;
            NavPanel.Left = cmdEditAirlines.Left;
            AirlinesTabControl.SelectedTab = EditAirlineTabPage;
        }
        //############################### SHEDULES CODES STARTS HERE ######################################################
        private void editScheduleTsm_Click(object sender, EventArgs e)
        {
            //ManipulateSchedules();
            PannelAddNewSchdules.Height = 127;
            SchedulesDataGridView.Height = 444;
            cmdMore.BackgroundImage = Properties.Resources.Colapse;
            SchedulesDataGridView.Location = new System.Drawing.Point(7, 185);

            SchedulesTextsLoad();

        }
        private void cmdUpdateFlight_Click(object sender, EventArgs e)
        {
            EquateScheduleTextsWithVariables();

            if (cmbScheduleAirlineID.Text.Equals("") || txtScheduleFlightID.Text.Equals("") || txtScheduleOrigin.Text.Equals("") || txtScheduleDestination.Text.Equals("") || dtpScheduleDepart.Text.Equals("") || dtpScheduleArrive.Text.Equals("") || dtpScheduleDate.Text.Equals("") || txtScheduleStatus.Text.Equals(""))
            {
                MessageBox.Show("please fill in all text boxes");
            }
            else
            {
                if (Var.fs.UpdateFlight().Equals(true))
                {
                    MessageBox.Show("Flight Number " + txtScheduleFlightID.Text + " has been Updated");
                    Var.fs.LoadSchedules(SchedulesDataGridView);
                    Var.fs.LoadSchedules(ReservationFlightSchedulesDGV);
                    ScheduleTextsClear();
                }

            }
        }

        private void SchedulesTextsLoad()
        {
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in SchedulesDataGridView.SelectedCells)
            {
                cell = selectedCell;
                break;
            }
            if (cell != null)
            {
                DataGridViewRow row = cell.OwningRow;
                txtScheduleFlightID.Text = row.Cells[0].Value.ToString();
                txtScheduleOrigin.Text = row.Cells[1].Value.ToString();
                txtScheduleDestination.Text = row.Cells[2].Value.ToString();
                //cmbScheduleAirlineID.Text = row.Cells[3].Value.ToString();
                dtpScheduleDepart.Text = row.Cells[4].Value.ToString();
                dtpScheduleArrive.Text = row.Cells[5].Value.ToString();
                dtpScheduleDate.Text = row.Cells[6].Value.ToString();
                txtScheduleStatus.Text = row.Cells[7].Value.ToString();
            }
        }

        private void SchedulesCMS_Opening(object sender, CancelEventArgs e)
        {

        }

        private void cmdAddSchedule_Click(object sender, EventArgs e)
        {
            EquateScheduleTextsWithVariables();

            if (cmbScheduleAirlineID.Text.Equals("") || txtScheduleFlightID.Text.Equals("") || txtScheduleOrigin.Text.Equals("") || txtScheduleDestination.Text.Equals("") || dtpScheduleDepart.Text.Equals("") || dtpScheduleArrive.Text.Equals("") || dtpScheduleDate.Text.Equals("") || txtScheduleStatus.Text.Equals(""))
            {
                MessageBox.Show("please fill in all text boxes");
            }
            else
            {
                if (Var.fs.AddNewSchedule().Equals(true))
                {
                    MessageBox.Show("New Schedule Successfully Added");
                    Var.fs.LoadSchedules(SchedulesDataGridView);
                    Var.fs.LoadSchedules(ReservationFlightSchedulesDGV);
                    ScheduleTextsClear();
                }

                

            }
        }

        private void EquateScheduleTextsWithVariables()
        {
            //Var.fs.Airline_ID = cmbScheduleAirlineID.Text;
            Var.fs.Flight_ID = txtScheduleFlightID.Text;
            Var.fs.Origin = txtScheduleOrigin.Text;
            Var.fs.Destination = txtScheduleDestination.Text;
            Var.fs.Depart_Time = dtpScheduleDepart.Text;
            Var.fs.Arrive_Time = dtpScheduleArrive.Text;
            Var.fs.Date = dtpScheduleDate.Text;
            Var.fs.Status = txtScheduleStatus.Text;
        }

        public void ScheduleTextsClear()
        {
            txtScheduleFlightID.Clear();
            txtScheduleOrigin.Clear();
            txtScheduleDestination.Clear();
            txtScheduleStatus.Clear();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Delete this Flight Schedule?", "Delete Schedule", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SchedulesTextsLoad();
                Var.fs.Flight_ID = txtScheduleFlightID.Text;
                Var.fs.deleteSchedule();
                ScheduleTextsClear();
                Var.fs.LoadSchedules(SchedulesDataGridView);
            }


        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Cancel this Flight Schedule?", "Cancel Schedule", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SchedulesTextsLoad();
                Var.fs.Flight_ID = txtScheduleFlightID.Text;
                Var.fs.cancelFlight();
                ScheduleTextsClear();
                Var.fs.LoadSchedules(SchedulesDataGridView);
            }
        }

        private void cmdClearShceduleText_Click(object sender, EventArgs e)
        {
            ScheduleTextsClear();
        }


        private void cmdRechedule_Click(object sender, EventArgs e)
        {
            EquateScheduleTextsWithVariables();

            if (cmbScheduleAirlineID.Text.Equals("") || txtScheduleFlightID.Text.Equals("") || txtScheduleOrigin.Text.Equals("") || txtScheduleDestination.Text.Equals("") || dtpScheduleDepart.Text.Equals("") || dtpScheduleArrive.Text.Equals("") || dtpScheduleDate.Text.Equals("") || txtScheduleStatus.Text.Equals(""))
            {
                MessageBox.Show("please fill in all text boxes");
            }
            else
            {
                if (MessageBox.Show("this flight is going to be rescheduled, proceed?", "Reschedule Flight", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Var.fs.rescheduleFlight();
                    Var.fs.LoadSchedules(SchedulesDataGridView);
                    Var.fs.LoadSchedules(ReservationFlightSchedulesDGV);
                    ScheduleTextsClear();
                }

            }
        }

        private void txtSearchSchedules_TextChanged(object sender, EventArgs e)
        {

            //string searchValue = txtSearchSchedules.Text.ToString();
            //Var.fs.searchSchedules(txtSearchSchedules.Text, SchedulesDataGridView);
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            Var.fs.searchSchedules(textBoxSearch.Text, SchedulesDataGridView);
        }

        private void txtSearchSchedules_OnTextChange(object sender, EventArgs e)
        {

        }

        private void txtRetTotalCost_TextChanged(object sender, EventArgs e)
        {

        }
        //--------------------------------- SCHEDULES CODES ENDS HERE ------------------------------------------------------

        //################################# PASSENGERS CODE STARTS HERE ###############################################################
        private void cmdAddPassenger_Click(object sender, EventArgs e)
        {
            EquatePassengerTextWithVariables();
            if (txtPassengerID.Text.Equals("") || txtPassengerName.Text.Equals("") || cmbPassengerGender.Text.Equals("") || cmbPassengerAgeRange.Text.Equals("") || txtPassengerPhone_No.Text.Equals("") || txtPassengerAddress.Text.Equals("") || txtPassengerEmail.Text.Equals(""))
            {
                MessageBox.Show("please fill in all text boxes");
            }
            else
            {
                Var.pass.addNewPassenger();
                Var.pass.loadPassengers(PassengerDataGridView);
                Var.pass.loadPassengersEmails(PassengerEmailsDGV);
                Var.pass.LoadPassengerNames(cmbRetTraveler1);
                Var.pass.LoadPassengerNames(cmbRetTraveler2);
                Var.pass.LoadPassengerNames(cmbOnewayTraveler);
                ClearPassengerTexts();

            }


        }

        private void ClearPassengerTexts()
        {
            txtPassengerID.Clear();
            txtPassengerName.Clear();
            cmbPassengerGender.SelectedIndex = 0;
            cmbPassengerAgeRange.SelectedIndex = 0;
            txtPassengerPhone_No.Clear();
            txtPassengerAddress.Clear();
            txtPassengerEmail.Clear();
        }
        private void PassengersTextsLoad()
        {
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in PassengerDataGridView.SelectedCells)
            {
                cell = selectedCell;
                break;
            }
            if (cell != null)
            {
                DataGridViewRow row = cell.OwningRow;
                txtPassengerID.Text = row.Cells[0].Value.ToString();
                txtPassengerName.Text = row.Cells[1].Value.ToString();
                cmbPassengerGender.Text = row.Cells[2].Value.ToString();
                cmbPassengerAgeRange.Text = row.Cells[3].Value.ToString();
                txtPassengerPhone_No.Text = row.Cells[4].Value.ToString();
                txtPassengerAddress.Text = row.Cells[5].Value.ToString();
                txtPassengerEmail.Text = row.Cells[6].Value.ToString();
            }
        }

        private void EquatePassengerTextWithVariables()
        {
            Var.pass.Passenger_ID = txtPassengerID.Text;
            Var.pass.Passenger_Name = txtPassengerName.Text;
            Var.pass.Gender = cmbPassengerGender.Text;
            Var.pass.Age_Range = cmbPassengerAgeRange.Text;
            Var.pass.Phone_No = txtPassengerPhone_No.Text;
            Var.pass.Address = txtPassengerAddress.Text;
            Var.pass.Email = txtPassengerEmail.Text;
        }

        private void cmdClearPass_Click(object sender, EventArgs e)
        {
            ClearPassengerTexts();
        }

        private void cmdUpdatePassenger_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Click Yes to save changes or No to Cancel", "Upadate Passenger Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                EquatePassengerTextWithVariables();
                Var.pass.updatePassengerDetails();
                Var.pass.loadPassengers(PassengerDataGridView);
                ClearPassengerTexts();
            }

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IndicatorPannel.Width = cmdAddNewPassengerTab.Width;
            IndicatorPannel.Left = cmdAddNewPassengerTab.Left;
            panelAddNewPassenger.Visible = true;
            //panel8Animator.ShowSync(IndicatorPannel);
            PassengerDataGridView.Location = new System.Drawing.Point(6, 232);
            PassengersTextsLoad();
        }
        private void txtSearchPassengers_TextChanged(object sender, EventArgs e)
        {
            Var.pass.searchPassengers(txtSearchPassengers.Text, PassengerDataGridView);
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this Passenger?", "Delete Passenger", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                PassengersTextsLoad();
                Var.pass.Passenger_ID = txtPassengerID.Text;
                Var.pass.deletePassenger();
                ClearPassengerTexts();
                Var.pass.loadPassengers(PassengerDataGridView);
            }
        }
        //----------------------------------- PASSENGER CODES ENDS HERE -------------------------------------------------

        //###################################### AIRLINE AND AIRCRAFT CODES STARTS HERE ######################################
        private void cmdAddAirline_Click(object sender, EventArgs e)
        {
            if (txtAirlineID.Text.Equals("") || txtAirlineName.Text.Equals(""))
            {
                MessageBox.Show("please fill in all text boxes");
            }
            else
            {
                Var.air.Airline_ID = txtAirlineID.Text;
                Var.air.Airline_Name = txtAirlineName.Text;
                Var.air.addNewAirline();
                Var.air.LoadAirlines(AirlineDataGridView);
                Var.air.LoadAirlineIDs(cmbScheduleAirlineID);
                Var.air.LoadAirlineIDs(cmbAirlineID);
                txtAirlineName.Clear();
                txtAirlineID.Clear();
            }
        }

        private void cmdClearAirlineTexts_Click(object sender, EventArgs e)
        {
            txtAirlineName.Clear();
            txtAirlineID.Clear();
        }

        public void AirlineTextLoad()
        {
            try
            {
                DataGridViewCell cell = null;
                foreach (DataGridViewCell selectedCell in AirlineDataGridView.SelectedCells)
                {
                    cell = selectedCell;
                    break;
                }
                if (cell != null)
                {
                    DataGridViewRow row = cell.OwningRow;
                    txtAirlineID.Text = row.Cells[0].Value.ToString();
                    txtAirlineName.Text = row.Cells[1].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cmdUpdateAirline_Click(object sender, EventArgs e)
        {
            if (txtAirlineID.Text.Equals("") || txtAirlineName.Text.Equals(""))
            {
                MessageBox.Show("please fill in all text boxes");
            }
            else
            {
                Var.air.Airline_ID = txtAirlineID.Text;
                Var.air.Airline_Name = txtAirlineName.Text;
                Var.air.updateAirline();
                Var.air.LoadAirlines(AirlineDataGridView);
                txtAirlineName.Clear();
                txtAirlineID.Clear();
            }
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AirlineTextLoad();
        }

        private void deleteToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this Airline?", "Delete Airline", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                AirlineTextLoad();
                Var.air.Airline_ID = txtAirlineID.Text;
                Var.air.deleteAirline();
                txtAirlineName.Clear();
                txtAirlineID.Clear();
                Var.air.LoadAirlines(AirlineDataGridView);

            }
        }

        private void cmdAddAircraft_Click(object sender, EventArgs e)
        {
            if (cmbAirlineID.Text.Equals("") || txtAircraftName.Text.Equals("") || txtAircraftID.Text.Equals(""))
            {
                MessageBox.Show("please fill in all text boxes");
            }
            else
            {
                //Var.ac.Airline_ID = cmbAirlineID.Text;
                Var.ac.Aircraft_Name = txtAircraftName.Text;
                Var.ac.Aircraft_ID = txtAircraftID.Text;
                Var.ac.addNewAicraft();
                Var.ac.LoadAircraft(AircraftDataGridView);
                txtAircraftName.Clear();
                txtAircraftID.Clear();

            }
        }
        private void cmdUpdateAircraft_Click(object sender, EventArgs e)
        {
            if (cmbAirlineID.Text.Equals("") || txtAircraftName.Text.Equals("") || txtAircraftID.Text.Equals(""))
            {
                MessageBox.Show("please fill in all text boxes");
            }
            else
            {
               // Var.ac.Airline_ID = cmbAirlineID.Text;
                Var.ac.Aircraft_Name = txtAircraftName.Text;
                Var.ac.Aircraft_ID = txtAircraftID.Text;
                Var.ac.updateAircraft();
                Var.ac.LoadAircraft(AircraftDataGridView);
                txtAircraftName.Clear();
                txtAircraftID.Clear();
            }
        }

        private void cmdClearAircraftTexts_Click(object sender, EventArgs e)
        {
            txtAircraftName.Clear();
            txtAircraftID.Clear();
        }

        private void editToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AircraftTextLoad();
        }
        public void AircraftTextLoad()
        {
            try
            {
                DataGridViewCell cell = null;
                foreach (DataGridViewCell selectedCell in AircraftDataGridView.SelectedCells)
                {
                    cell = selectedCell;
                    break;
                }
                if (cell != null)
                {
                    DataGridViewRow row = cell.OwningRow;
                    txtAircraftID.Text = row.Cells[0].Value.ToString();
                    cmbAirlineID.Text = row.Cells[1].Value.ToString();
                    txtAircraftName.Text = row.Cells[2].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void deleteToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this Aircraft?", "Delete Aircraft", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                AircraftTextLoad();
                Var.ac.Aircraft_ID = txtAircraftID.Text;
                Var.ac.deleteAircraft();
                txtAircraftName.Clear();
                txtAircraftID.Clear();
                Var.ac.LoadAircraft(AircraftDataGridView);

            }
        }
        private void txtSearchAirlineAircraft_TextChanged(object sender, EventArgs e)
        {
            Var.ac.searchAirlineAircraft(txtSearchAirlineAircraft.Text, AircraftAirlineDataGridView);
        }
        //--------------------------------- AIRLINE AND AIRCRAFT CODES ENDS HERE ------------------------------------------------

        private void cmdAdd_New_User_Click(object sender, EventArgs e)
        {
            if (txtUserID.Text.Equals("") || txtUserFirstname.Text.Equals("") || txtUserLastname.Text.Equals("") || txtUserType.Text.Equals("") || txtUserPosition.Text.Equals("") || dateTimeUser_DOB.Text.Equals("") || txtUserAddress.Equals("") || txtUsername.Text.Equals("") || txtUserPassword.Text.Equals(""))
            {
                MessageBox.Show("please fill in all text boxes");
            }
            else
            {
                Var.use.UserID = txtUserID.Text;
                Var.use.Address = txtUserAddress.Text;
                Var.use.Firstname = txtUserFirstname.Text;
                Var.use.Lastname = txtUserLastname.Text;
                Var.use.Usertype = txtUserType.Text;
                Var.use.Position = txtUserPosition.Text;
                Var.use.DOB = dateTimeUser_DOB.Text;
                Var.use.Username = txtUsername.Text;
                Var.use.Password = txtUserPassword.Text;
                if (Var.use.addNewUser().Equals(true))
                {
                    Var.use.LoadUsers(User_DataGridView);
                    MessageBox.Show("New User Successfully Added");
                    txtUserID.Clear();
                    txtUserFirstname.Clear();
                    txtUserLastname.Clear();
                    txtUserPosition.Clear();
                    txtUsername.Clear();
                    txtUserPassword.Clear();

                }
            }

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txtSearchReservation_TextChanged(object sender, EventArgs e)
        {
            //Var.reserve.searchReservations(txtSearchReservation.Text, ReservationFlightSchedulesDGV);
        }
        public void ReservationsTextLoad()
        {
            try
            {
                DataGridViewCell cell = null;
                foreach (DataGridViewCell selectedCell in flightdReservationsDataGV.SelectedCells)
                {
                    cell = selectedCell;
                    break;
                }
                if (cell != null)
                {
                    DataGridViewRow row = cell.OwningRow;
                    textRefID.Text = row.Cells[0].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cancelReservationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("are you sure you want to cancel this reservation?", "Cancel Resevation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ReservationsTextLoad();
                Var.reserve.Reservation_Ref = textRefID.Text;
                Var.reserve.cancelReservation();
                Var.reserve.LoadReservations(flightdReservationsDataGV);
                textRefID.Clear();
            }
        }

        private void tabPageManageBookings_Click(object sender, EventArgs e)
        {

        }

        private void cmdSendToOne_Click(object sender, EventArgs e)
        {
            if (txtEmailRecipient.Text.Equals("") || txtEmailSubject.Text.Equals("") || txtEmailBody.Text.Equals(""))
            {
                MessageBox.Show("fill in all text Boxes");
            }
            else
            {
                EmailLoadingPnl.Location = new Point(335, 52);  //"335,52";
                EmailLoadingPnl.Height = 221;
                cmdSendToOne.Enabled = false;
                //Var.le.Show();
                Var.mail.Subject = txtEmailSubject.Text;
                Var.mail.Body = txtEmailBody.Text;
                Var.mail.Recipient = txtEmailRecipient.Text;
                Var.mail.Attachment = txtAttachment.Text;
                if (Var.mail.SendEmail().Equals(true))
                {
                    EmailLoadingPnl.Location = new Point(334, 6);  //"335,52";
                    EmailLoadingPnl.Height = 0;
                    cmdSendToOne.Enabled = true;
                    //Var.le.Hide();
                    txtEmailBody.Clear();
                    txtEmailSubject.Clear();
                    txtEmailRecipient.Clear();
                    txtAttachment.Clear();
                }
                EmailLoadingPnl.Location = new Point(334, 6);  //"335,52";
                EmailLoadingPnl.Height = 0;
                cmdSendToOne.Enabled = true;
                //try
                //{
                //    string from, pass;

                //    MailMessage email = new MailMessage();
                //    SmtpClient smtp = new SmtpClient("smtp.gmail.com");     // email provider, in this case its gmail
                //    email.From = new MailAddress("cyrilmvula@gmail.com");   // sender's address
                //    email.Subject = txtEmailSubject.Text;
                //    email.Body = txtEmailBody.Text;
                //    //email.CC.Add(new MailAddress("BLUEBERRY TRAVELS")); //display name
                //    from = "cyrilmvula@gmail.com"; // sender address
                //    pass = "23rdMay1995";   // sender password


                //    foreach (var item in txtEmailRecipient.Text.Split(new[] { ": " }, StringSplitOptions.RemoveEmptyEntries)) // we need to spit Textbox 
                //    {
                //        email.To.Add(item);
                //    }

                //    smtp.UseDefaultCredentials = false;

                //    if (txtAttachment.Text != "")
                //    {
                //        //checking if attachment textfield is not empty so that we can be abble to send the email with attachment in this section
                //        email.Attachments.Add(new Attachment(txtAttachment.Text));

                //        smtp.EnableSsl = true;
                //        smtp.Port = 587;
                //        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                //        smtp.Credentials = new NetworkCredential(from, pass); //sign in credentials email, password
                //        smtp.Send(email);
                //        MessageBox.Show("Email sent Successfully", "Success");

                //    }
                //    else
                //    {
                //        //send without attachment  
                //        smtp.EnableSsl = true;
                //        smtp.Port = 587;
                //        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                //        smtp.Credentials = new NetworkCredential(from, pass); //sign in credentials email, password
                //        smtp.Send(email);
                //        MessageBox.Show("Email sent Successfully", "Success");
                //    }
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show("error occured: " + ex.Message);
                //}
            }

        }

        private void cmdEmailAttachment_Click(object sender, EventArgs e)
        {
            if (openFileDialogForAttachment.ShowDialog() == DialogResult.OK)
            {
                txtAttachment.Text = openFileDialogForAttachment.FileName;
            }
            //openFileDialogForAttachment.ShowDialog();
            ////txtAttachment.Text = openFileDialogForAttachment
            //folderBrowserDialogForAttachment.ShowDialog();
            //txtAttachment.Text = folderBrowserDialogForAttachment.SelectedPath;
        }

        private void tabEmails_Click(object sender, EventArgs e)
        {

        }
        public void EmailRecipientTextLoad()
        {
            try
            {
                DataGridViewCell cell = null;
                foreach (DataGridViewCell selectedCell in PassengerEmailsDGV.SelectedCells)
                {
                    cell = selectedCell;
                    break;
                }
                if (cell != null)
                {
                    DataGridViewRow row = cell.OwningRow;
                    txtEmailRecipient.Text = row.Cells[2].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmailRecipientTextLoad();
        }

        private void PassengerEmailsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // EmailRecipientTextLoad();
        }

        private void PassengerEmailsDGV_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EmailRecipientTextLoad();
        }

        private void txtEmailRecipient_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmailSubject_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmdClear_UserTextBoxes_Click(object sender, EventArgs e)
        {
            txtUserID.Clear();
            txtUserFirstname.Clear();
            txtUserLastname.Clear();
            txtUserPosition.Clear();
            txtUsername.Clear();
            txtUserPassword.Clear();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (txtUserID.Text.Equals(""))
            {
                MessageBox.Show("Fill in User ID");
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to delete this user?", "Delete user", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Var.use.UserID = txtUserID.Text;
                    Var.use.deleteUser();
                    Var.use.LoadUsers(User_DataGridView);
                    txtUserID.Clear();
                    txtUserFirstname.Clear();
                    txtUserLastname.Clear();
                    txtUserPosition.Clear();
                    txtUsername.Clear();
                    txtUserPassword.Clear();

                }
                    
            }
            

        }

        private void cmdUpdateUser_Click(object sender, EventArgs e)
        {
            if (txtUserID.Text.Equals("") || txtUserFirstname.Text.Equals("") || txtUserLastname.Text.Equals("") || txtUserType.Text.Equals("") || txtUserPosition.Text.Equals("") || dateTimeUser_DOB.Text.Equals("") || txtUserAddress.Equals("") || txtUsername.Text.Equals("") || txtUserPassword.Text.Equals(""))
            {
                MessageBox.Show("please fill in all text boxes");
            }
            else
            {
                Var.use.UserID = txtUserID.Text;
                Var.use.Address = txtUserAddress.Text;
                Var.use.Firstname = txtUserFirstname.Text;
                Var.use.Lastname = txtUserLastname.Text;
                Var.use.Usertype = txtUserType.Text;
                Var.use.Position = txtUserPosition.Text;
                Var.use.DOB = dateTimeUser_DOB.Text;
                Var.use.Username = txtUsername.Text;
                Var.use.Password = txtUserPassword.Text;
                if (Var.use.updateUserDetails().Equals(true))
                {
                    Var.use.LoadUsers(User_DataGridView);
                    MessageBox.Show("you have successfully updated " + txtUserFirstname.Text + "'s details");
                    txtUserID.Clear();
                    txtUserFirstname.Clear();
                    txtUserLastname.Clear();
                    txtUserPosition.Clear();
                    txtUsername.Clear();
                    txtUserPassword.Clear();
                }
            }
        }

        public void UsersTextLoad()
        {
            try
            {
                DataGridViewCell cell = null;
                foreach (DataGridViewCell selectedCell in User_DataGridView.SelectedCells)
                {
                    cell = selectedCell;
                    break;
                }
                if (cell != null)
                {
                    DataGridViewRow row = cell.OwningRow;
                    txtUserID.Text = row.Cells[0].Value.ToString();
                    txtUserFirstname.Text = row.Cells[1].Value.ToString();
                    txtUserLastname.Text = row.Cells[2].Value.ToString();
                    txtUserType.Text = row.Cells[3].Value.ToString();
                    txtUserPosition.Text = row.Cells[4].Value.ToString();
                    dateTimeUser_DOB.Text = row.Cells[5].Value.ToString();
                    txtUserAddress.Text = row.Cells[6].Value.ToString();
                    txtUsername.Text = row.Cells[7].Value.ToString();
                    txtUserPassword.Text = row.Cells[8].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void editToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            UsersTextLoad();
        }

        private void textRefID_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

//############################## REPORT CODES STARTS HERE #############################
        private void button1_Click(object sender, EventArgs e)
        {

            Var.reserve.LoadReport(ReportsDGV, dtpRangeFrom, dtpRangeTo);
            //Var.reserve.Sum_Cost(ReportsDGV);
            Var.reserve.CalculateCost(ReportsDGV, result);
        }

        private void printREport_DGV()
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "RESERVATIONS REPORT";
            printer.SubTitle = "Report for Reserved flights From: " + dtpRangeFrom.Text + " To: " + dtpRangeTo.Text + ". | " + result.Text;
            //printer.SubTitle = result.Text;
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Blueberry Travels Malawi";
            printer.FooterSpacing = 15;

            printer.PrintDataGridView(ReportsDGV);
            //printer.PrintPreviewDataGridView(ReportsDGV);
        }
        private void cmdPrintReport_Click(object sender, EventArgs e)
        {
            printREport_DGV();
        }

        private void cmbRetTraveler1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
