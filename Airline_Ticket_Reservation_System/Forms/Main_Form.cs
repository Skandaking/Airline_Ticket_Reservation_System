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
    public partial class Main_Form : Form
    {
        Timer t = new Timer();
        Timer CheckDepature;
        flightSchedules flight = new flightSchedules();
       // bool update = false;
        public Main_Form()
        { 
            InitializeComponent();
            CheckDepature = new Timer();
            CheckDepature.Interval = 1800000; //30 minutes
            CheckDepature.Start();
            CheckDepature.Tick += CheckDepature_Tick;
        }

        private void CheckDepature_Tick(object sender, EventArgs e)
        {
                Var.fs.check_Status();
                Var.fs.LoadSchedules(SchedulesDGV);
                CheckDepature.Stop();
                CheckDepature.Start();
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {
            Check_User();
            Var.fs.check_Status();
            txt_TotalCost.Text = "K0.00";

            // timer in intervals 
            t.Interval = 1000; //in milliseconds
            t.Tick += new EventHandler(this.t_tick);

            //start timer on foarm load
            t.Start(); //uses t_tick

            //load Comboboxes on startup
            Var.ac.LoadAircraftIDs(cmb_ScheduleAircraftID);
            Var.pass.LoadPassengerNames(cmb_Traveler);
           // Var.pass.LoadPassengerNames(cmb_RetTraveler);


            //load datagridviews on startup
            Var.fs.LoadSchedules(SchedulesDGV);
            Var.pass.loadPassengers(PassengerDGV);
            Var.ac.LoadAirlineAircraft(AircraftAirlineDGV);
            Var.ac.LoadAircraft(AircraftDGV);
            Var.reserve.LoadReservations(flightdReservationsDGV);
            Var.pass.loadPassengersEmails(PassengerEmailsDGV);
            Var.use.LoadUsers(User_DataGridView);


            Passengers_Settings.Height = 0;
            //comb_OnewayClass.Text = "Economy";
            //comb_RetClass.Text = "Economy";
            Schedules_Settings.Height = 0;
            Airlines_Settings.Height = 0;
            user_settings.Height = 0;


            //BUTTON TOOL TIPS
            Var.btnToolTip.SetToolTip(this.btn_Max, "Maximise");
            Var.btnToolTip.SetToolTip(this.btn_CloseApp, "Close");
            Var.btnToolTip.SetToolTip(this.btn_Min, "Minimise");

            Load_HelpList();
        }
        private void Load_HelpList()
        {
            Var.help.Load_Help_List(Help_FlowPanel);
        }
        private void Check_User()
        {
            try
            {
                lblUsertype.Text =""+ Var.use.Usertype;
                lblUsername.Text = " " + Var.use.Username;

                if (Var.use.Usertype == "Admin")
                {

                    cancelToolStripMenuItem.Enabled = false;
                    reserveToolStripMenuItem.Enabled = false;

                }
                if (Var.use.Usertype == "Staff")
                {
                    btn_User_Settings.Enabled = false;
                    editToolStripMenuItem.Enabled = false;
                    cancelToolStripMenuItem.Enabled = false;
                    btn_Airlines.Enabled = false;
                    deleteToolStripMenuItem.Enabled = false;
                    btn_Edit.Enabled = false;
                    btn_Reports.Enabled = false;
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
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
            //if (hh < 12 && mm < 59)
            //    lblgreetings.Text = "good morning " + lblUsername.Text;
            //if (hh >= 12)
            //    lblgreetings.Text = "good afternoon " + lblUsername.Text;
            //if (hh > 15)
            //    lblgreetings.Text = "good evening " + lblUsername.Text;

        }

        //##################### MENU CODES HERE ###########################
        private void btn_CloseApp_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Close Application?", "Close Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }

        private void btn_Max_Click(object sender, EventArgs e)
        {
            
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                Var.btnToolTip.SetToolTip(this.btn_Max, "Restore Down");
            }

            else if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                Var.btnToolTip.SetToolTip(this.btn_Max, "Maximise");
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                Var.btnToolTip.SetToolTip(this.btn_Max, "Maximise");
            }
            

        }

        private void btn_Min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void cmd_Menu_Click(object sender, EventArgs e)
        {
            if (MenuPanel.Width == 52)
            {
                //Expand the panel
                MenuPanel.Visible = false;
                MenuPanel.Width = 192;
                Menu_Animator.ShowSync(MenuPanel);

            }
            else
            {
                // Minimize panel
                // using bunifu transition
                // side the panel
                MenuPanel.Visible = false;
                MenuPanel.Width = 52;
                Menu_Animator.ShowSync(MenuPanel);
            }

        }
        private void Minimize_Menu()
        {
            if (MenuPanel.Width == 192)
            {
                MenuPanel.Visible = false;
                MenuPanel.Width = 52;
                Menu_Animator.ShowSync(MenuPanel);
            }
            else
                MenuPanel.Width = 52;
                
        }

        private void btn_Schedules_Click(object sender, EventArgs e)
        {
            Tab_Indicator.Height = btn_Schedules.Height;
            Tab_Indicator.Top = btn_Schedules.Top;
            Main_Tab.SelectedTab = Schedules_Tab;
            Minimize_Menu();
        }

        private void btn_Passengers_Click(object sender, EventArgs e)
        {
            Tab_Indicator.Height = btn_Passengers.Height;
            Tab_Indicator.Top = btn_Passengers.Top;
            Main_Tab.SelectedTab = Passengers_Tab;
            Minimize_Menu();
        }

        private void btn_Airlines_Click(object sender, EventArgs e)
        {
            Tab_Indicator.Height = btn_Airlines.Height;
            Tab_Indicator.Top = btn_Airlines.Top;
            Main_Tab.SelectedTab = Airlines_Tab;
            Minimize_Menu();
        }

        private void btn_Reservation_Click(object sender, EventArgs e)
        {
            Tab_Indicator.Height = btn_Reservation.Height;
            Tab_Indicator.Top = btn_Reservation.Top;
            Main_Tab.SelectedTab = Reservations_Tab;
            Minimize_Menu();
        }

        private void btn_Reports_Click(object sender, EventArgs e)
        {
            Tab_Indicator.Height = btn_Reports.Height;
            Tab_Indicator.Top = btn_Reports.Top;
            Main_Tab.SelectedTab = Reports_Tab;
            Minimize_Menu();
        }
        private void btn_Emails_Click(object sender, EventArgs e)
        {
            Tab_Indicator.Height = btn_Emails.Height;
            Tab_Indicator.Top = btn_Emails.Top;
            Main_Tab.SelectedTab = Emails_tab;
            Minimize_Menu();
        }
        private void btn_User_Settings_Click(object sender, EventArgs e)
        {
            Tab_Indicator.Height = btn_User_Settings.Height;
            Tab_Indicator.Top = btn_User_Settings.Top;
            Main_Tab.SelectedTab = UserSettings_Tab;
            Minimize_Menu();
        }

        private void Schedules_Tab_Click(object sender, EventArgs e)
        {

        }

        //####################### SCHEDULES CODES ##################################
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            
            if (Schedules_Settings.Height == 0)
            {
                //Expand the panel
                Schedules_Settings.Visible = false;
                Schedules_Settings.Height = 533;
                Edit_Animator.ShowSync(Schedules_Settings);

            }
            else
            {
                // Minimize panel
                Schedules_Settings.Visible = false;
                Schedules_Settings.Height = 0;
                Edit_Animator.ShowSync(Schedules_Settings);
            }
        }

        private void Cancel_Schedules_btn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Cancel? All unsaved changes will be lost, make sure you save before closing. Click Yes to Cancel or No to abort", "Close Schedules Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Schedules_Settings.Height = 0;
                clear_Schedules_Text();
            }
        }
        private void Btn_ClearShcedule_Click(object sender, EventArgs e) => clear_Schedules_Text();
        private void btn_Clear_Shcedule_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_PrintSchedules_Click(object sender, EventArgs e)
        {
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

            //printer.PrintDataGridView(SchedulesDGV);
            printer.PrintPreviewDataGridView(SchedulesDGV);
        }

        private void txt_Search_TextChanged(object sender, EventArgs e)
        {
            Var.fs.searchSchedules(txt_Search.Text, SchedulesDGV);
        }
        private void clear_Schedules_Text()
        {
            txt_ScheduleFlightID.Clear();
            txt_ScheduleOrigin.Clear();
            txt_ScheduleDestination.Clear();
            cmb_ScheduleAircraftID.Text = "";
            dtp_ScheduleDepart.Text = "00:00:00";
            dtp_ScheduleArrive.Text = "00:00:00";
            dtp_ScheduleDate.Text = DateTime.Now.ToShortDateString();
            txt_ScheduleStatus.Clear();
        }

        private void Load_Schedules_Text()
        {
            try
            {
                DataGridViewCell cell = null;
                foreach (DataGridViewCell selectedCell in SchedulesDGV.SelectedCells)
                {
                    cell = selectedCell;
                    break;
                }
                if (cell != null)
                {
                    DataGridViewRow row = cell.OwningRow;
                    txt_ScheduleFlightID.Text = row.Cells[0].Value.ToString();
                    txt_ScheduleOrigin.Text = row.Cells[1].Value.ToString();
                    txt_ScheduleDestination.Text = row.Cells[2].Value.ToString();
                    //cmb_ScheduleAircraftID.Text = row.Cells[3].Value.ToString();
                    dtp_ScheduleDepart.Text = row.Cells[5].Value.ToString();
                    dtp_ScheduleArrive.Text = row.Cells[6].Value.ToString();
                    dtp_ScheduleDate.Text = row.Cells[7].Value.ToString();
                    txt_ScheduleStatus.Text = row.Cells[8].Value.ToString();
                }
            }
            catch
            { 
            
            }
            
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Load_Schedules_Text();
            Schedules_Settings.Height = 533;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Delete this Flight Schedule?", "Delete Schedule", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Load_Schedules_Text();
                Var.fs.Flight_ID = txt_ScheduleFlightID.Text;
               if(Var.fs.deleteSchedule().Equals(true))
                {
                    clear_Schedules_Text();
                    Var.fs.LoadSchedules(SchedulesDGV);
                    MessageBox.Show("Flight deleted");
                }
                
            }
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Cancel this Flight Schedule?", "Cancel Schedule", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Load_Schedules_Text();
                Var.fs.Flight_ID = txt_ScheduleFlightID.Text;
                Var.fs.cancelFlight();
                clear_Schedules_Text();
                Var.fs.LoadSchedules(SchedulesDGV);
            }
        }
        private void EquateScheduleTextsWithVariables()
        {
            Var.fs.Aircraft_ID = cmb_ScheduleAircraftID.Text;
            Var.fs.Flight_ID = txt_ScheduleFlightID.Text;
            Var.fs.Origin = txt_ScheduleOrigin.Text;
            Var.fs.Destination = txt_ScheduleDestination.Text;
            Var.fs.Depart_Time = dtp_ScheduleDepart.Text;
            Var.fs.Arrive_Time = dtp_ScheduleArrive.Text;
            Var.fs.Date = dtp_ScheduleDate.Text;
            Var.fs.Status = txt_ScheduleStatus.Text;
        }

        private void btn_AddSchedule_Click(object sender, EventArgs e)
        {

            EquateScheduleTextsWithVariables();
            if (cmb_ScheduleAircraftID.Text.Equals("") || txt_ScheduleFlightID.Text.Equals("") || txt_ScheduleOrigin.Text.Equals("") || txt_ScheduleDestination.Text.Equals("") || dtp_ScheduleDepart.Text.Equals("") || dtp_ScheduleArrive.Text.Equals("") || dtp_ScheduleDate.Text.Equals("") || txt_ScheduleStatus.Text.Equals(""))
            {
                MessageBox.Show("please fill in all text boxes");
            }
            else
            {
                if (Var.fs.AddNewSchedule().Equals(true))
                {
                    Var.fs.get_capacity();
                    Var.fs.LoadSchedules(SchedulesDGV);
                    clear_Schedules_Text();
                }



            }
        }

        private void btn_Rechedule_Click(object sender, EventArgs e)
        {
            EquateScheduleTextsWithVariables();
            if (cmb_ScheduleAircraftID.Text.Equals("") || txt_ScheduleFlightID.Text.Equals("") || txt_ScheduleOrigin.Text.Equals("") || txt_ScheduleDestination.Text.Equals("") || dtp_ScheduleDepart.Text.Equals("") || dtp_ScheduleArrive.Text.Equals("") || dtp_ScheduleDate.Text.Equals("") || txt_ScheduleStatus.Text.Equals(""))
            {
                MessageBox.Show("please fill in all text boxes");
            }
            else
            {
                if (MessageBox.Show("this flight is going to be rescheduled, proceed?", "Reschedule Flight", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Var.fs.rescheduleFlight();
                    Var.fs.LoadSchedules(SchedulesDGV);
                    clear_Schedules_Text();
                }
            }
        }
        private void UpdateSchedules_btn_Click(object sender, EventArgs e)
        {
            EquateScheduleTextsWithVariables();
            if (cmb_ScheduleAircraftID.Text.Equals("") || txt_ScheduleFlightID.Text.Equals("") || txt_ScheduleOrigin.Text.Equals("") || txt_ScheduleDestination.Text.Equals("") || dtp_ScheduleDepart.Text.Equals("") || dtp_ScheduleArrive.Text.Equals("") || dtp_ScheduleDate.Text.Equals("") || txt_ScheduleStatus.Text.Equals(""))
            {
                MessageBox.Show("please fill in all text boxes", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (Var.fs.UpdateFlight().Equals(true))
                {
                    //MessageBox.Show("Flight Number " + txt_ScheduleFlightID.Text + " has been Updated");
                    Var.fs.LoadSchedules(SchedulesDGV);

                    //Var.fs.LoadSchedules(ReservationFlightSchedulesDGV);
                    clear_Schedules_Text();
                }
            }
        }
        private void btn_UpdateSchedule_Click(object sender, EventArgs e)
        {
            
        }
        //----------------------------------------------------------------------------------------------

        //####################### PASSENGERS CODES ##################################
        private void Passengers_Tab_Click(object sender, EventArgs e)
        {

        }

        private void btn_Edit_Passengers_Click(object sender, EventArgs e)
        {
            //Passengers_Settings.Height = 571;
            if (Passengers_Settings.Height == 0)
            {
                //Expand the panel
                Passengers_Settings.Visible = false;
                Passengers_Settings.Height = 571;
                Edit_Animator.ShowSync(Passengers_Settings);

            }
            else
            {
                // Minimize panel
                Passengers_Settings.Visible = false;
                Passengers_Settings.Height = 0;
                Edit_Animator.ShowSync(Passengers_Settings);
            }
        }
        private void Clear_Passenger_Text()
        {
            txt_PassengerID.Clear();
            txt_PassengerName.Clear();
            cmb_PassengerGender.Text = "";
            cmb_PassengerAgeRange.Text = "";
            txt_PassengerPhoneNo.Clear();
            txt_PassengerAddress.Clear();
            txt_PassengerEmail.Clear();
            txt_PassengerPassword.Clear();
            txt_PassengerUsername.Clear();
            dtp_PassengerDOB.Text = DateTime.Now.ToShortDateString();
        }

        private void btn_ClosePassengerSettings_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Cancel? All unsaved changes will be lost, make sure you save before closing. Click Yes to Cancel or No to abort", "Close Schedules Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Passengers_Settings.Height = 0;
                Clear_Passenger_Text();

            }
        }

        private void ClearPassText_btn_Click(object sender, EventArgs e) => Clear_Passenger_Text();
        private void btn_ClearPassText_Click(object sender, EventArgs e)
        {
            
        }

        private void PassengersTextsLoad()
        {
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in PassengerDGV.SelectedCells)
            {
                cell = selectedCell;
                break;
            }
            if (cell != null)
            {
                DataGridViewRow row = cell.OwningRow;
                txt_PassengerID.Text = row.Cells[0].Value.ToString();
                txt_PassengerName.Text = row.Cells[1].Value.ToString();
                cmb_PassengerGender.Text = row.Cells[2].Value.ToString();
                cmb_PassengerAgeRange.Text = row.Cells[3].Value.ToString();
                txt_PassengerPhoneNo.Text = row.Cells[4].Value.ToString();
                txt_PassengerAddress.Text = row.Cells[5].Value.ToString();
                txt_PassengerEmail.Text = row.Cells[6].Value.ToString();
                dtp_PassengerDOB.Text = row.Cells[7].Value.ToString();
            }
        }
        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Passengers_Settings.Height = 571;
            PassengersTextsLoad();
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this Passenger?", "Delete Passenger", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                PassengersTextsLoad();
                Var.pass.Passenger_ID = txt_PassengerID.Text;
                if (Var.pass.deletePassenger().Equals(true))
                {
                    Clear_Passenger_Text();
                    Var.pass.loadPassengers(PassengerDGV);
                    //MessageBox.Show("Records Deleted");
                }
                
            }
        }
        private void EquatePassengerTextWithVariables()
        {
            Var.pass.Passenger_ID = txt_PassengerID.Text;
            Var.pass.Passenger_Name = txt_PassengerName.Text;
            Var.pass.Gender = cmb_PassengerGender.Text;
            Var.pass.Age_Range = cmb_PassengerAgeRange.Text;
            Var.pass.Phone_No = txt_PassengerPhoneNo.Text;
            Var.pass.Address = txt_PassengerAddress.Text;
            Var.pass.Email = txt_PassengerEmail.Text;
            Var.pass.DOB = dtp_PassengerDOB.Text;
            Var.pass.Username = txt_PassengerUsername.Text;
            Var.pass.Password = txt_PassengerPassword.Text;
        }
        private void AddPassenger_btn_Click(object sender, EventArgs e)
        {

            EquatePassengerTextWithVariables();
            if (txt_PassengerName.Text.Equals("") || cmb_PassengerGender.Text.Equals("") || cmb_PassengerAgeRange.Text.Equals("") || txt_PassengerPhoneNo.Text.Equals("") || txt_PassengerAddress.Text.Equals("") || txt_PassengerEmail.Text.Equals(""))
            {
                MessageBox.Show("Oops! please fill in all text boxes", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                if (Var.pass.addNewPassenger().Equals(true))
                {
                    Var.pass.loadPassengers(PassengerDGV);
                    Var.pass.LoadPassengerNames(cmb_Traveler);
                    //Var.pass.LoadPassengerNames(cmb_RetTraveler);
                    Var.pass.loadPassengersEmails(PassengerEmailsDGV);
                    Clear_Passenger_Text();
                }
            }
        }
        private void btn_AddPassenger_Click(object sender, EventArgs e)
        {
        }
        private void UpdatePassenger_btn_Click(object sender, EventArgs e)
        {

            EquatePassengerTextWithVariables();
            if (txt_PassengerID.Text.Equals("") || txt_PassengerName.Text.Equals("") || cmb_PassengerGender.Text.Equals("") || cmb_PassengerAgeRange.Text.Equals("") || txt_PassengerPhoneNo.Text.Equals("") || txt_PassengerAddress.Text.Equals("") || txt_PassengerEmail.Text.Equals(""))
            {
                MessageBox.Show("please fill in all text boxes");
            }
            else
            {
                if (MessageBox.Show("Click Yes to save changes or No to Cancel", "Upadate Passenger Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    EquatePassengerTextWithVariables();
                    Var.pass.updatePassengerDetails();
                    Var.pass.loadPassengers(PassengerDGV);
                    Clear_Passenger_Text();
                }
            }
        }
        private void btn_UpdatePassenger_Click(object sender, EventArgs e)
        {
        }

        private void txt_Search_Passenger_TextChanged(object sender, EventArgs e)
        {
            Var.pass.searchPassengers(txt_Search_Passenger.Text, PassengerDGV);
        }
        //----------------------------------------------------------------------------------------------

        //#####################  AIRLINES CODES STARTS HERE ########################

        private void btn_EditAirlines_Click(object sender, EventArgs e)
        {
            //Airlines_Settings.Height = 533;
            if (Airlines_Settings.Height == 0)
            {
                //Expand the panel
                Airlines_Settings.Visible = false;
                Airlines_Settings.Height = 533;
                Edit_Animator.ShowSync(Airlines_Settings);

            }
            else
            {
                // Minimize panel
                Airlines_Settings.Visible = false;
                Airlines_Settings.Height = 0;
                Edit_Animator.ShowSync(Airlines_Settings);
            }

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Cancel? All unsaved changes will be lost, make sure you save before closing. Click Yes to Cancel or No to abort", "Close Schedules Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Airlines_Settings.Height = 0;
                //this.Aircraft_Panel.Height = 0;
                CLear_Aircraft_Text();
                Clear_Airline_Text();
            }
        }

        private void btn_Nav_Airlines_Click(object sender, EventArgs e)
        {
            this.Aircraft_Panel.Height = 0;
        }

        private void btn_Nav_Aircraft_Click(object sender, EventArgs e)
        {
            this.Aircraft_Panel.Height = 431;
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Aircraft_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_SearchAirlines_TextChanged(object sender, EventArgs e)
        {
            Var.ac.searchAirlineAircraft(txt_SearchAirlines.Text, AircraftAirlineDGV);
        }
        private void AddAircraft_btn_Click(object sender, EventArgs e)
        {
            if (txt_Airline.Text.Equals("") || txt_AircraftName.Text.Equals("") || txt_AircraftID.Text.Equals("") || txt_capacity.Text.Equals(""))
            {
                MessageBox.Show("please fill in all text boxes");
            }
            else
            {
                Var.ac.Capacity = txt_capacity.Text;
                Var.ac.Airline = txt_Airline.Text;
                Var.ac.Aircraft_Name = txt_AircraftName.Text;
                Var.ac.Aircraft_ID = txt_AircraftID.Text;
                Var.ac.addNewAicraft();
                Var.ac.LoadAircraft(AircraftDGV);
                Var.ac.LoadAirlineAircraft(AircraftAirlineDGV);
                Var.ac.LoadAircraftIDs(cmb_ScheduleAircraftID);
                CLear_Aircraft_Text();

            }
        }
        private void btn_AddAircraft_Click(object sender, EventArgs e)
        {
           
        }

        private void UpdateAirlcraft_btn_Click(object sender, EventArgs e)
        {
            if (/*cmb_AirlineID.Text.Equals("") || */txt_AircraftName.Text.Equals("") || txt_AircraftID.Text.Equals(""))
            {
                MessageBox.Show("please fill in all text boxes");
            }
            else
            {
                Var.ac.Capacity = txt_capacity.Text;
                Var.ac.Airline = txt_Airline.Text;
                Var.ac.Aircraft_Name = txt_AircraftName.Text;
                Var.ac.Aircraft_ID = txt_AircraftID.Text;
                Var.ac.updateAircraft();
                Var.ac.LoadAircraft(AircraftDGV);
                Var.ac.LoadAirlineAircraft(AircraftAirlineDGV);
                CLear_Aircraft_Text();
            }
        }
        private void btn_UpdateAirlcraft_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnClear_AirText_Click(object sender, EventArgs e) => CLear_Aircraft_Text();
        private void btn_Clear_Aircraft_Text_Click(object sender, EventArgs e)
        {
            
        }

        private void CLear_Aircraft_Text()
        {
            txt_AircraftName.Clear();
            txt_AircraftID.Clear();
            txt_Airline.Text = "";
            txt_capacity.Text = "";
        }

        public void AircraftTextLoad()
        {
            try
            {
                DataGridViewCell cell = null;
                foreach (DataGridViewCell selectedCell in AircraftDGV.SelectedCells)
                {
                    cell = selectedCell;
                    break;
                }
                if (cell != null)
                {
                    DataGridViewRow row = cell.OwningRow;
                    txt_AircraftID.Text = row.Cells[0].Value.ToString();
                    txt_Airline.Text = row.Cells[1].Value.ToString();
                    txt_AircraftName.Text = row.Cells[2].Value.ToString();
                    txt_capacity.Text = row.Cells[3].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteAircraft_btn_Click(object sender, EventArgs e)
        {
            if (txt_Airline.Text.Equals("") || txt_AircraftName.Text.Equals("") || txt_AircraftID.Text.Equals(""))
            {
                MessageBox.Show("please fill in all text boxes");
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to delete this Aircraft?", "Delete Aircraft", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //AircraftTextLoad();
                    Var.ac.Capacity = txt_capacity.Text;
                    Var.ac.Aircraft_ID = txt_AircraftID.Text;
                    Var.ac.deleteAircraft();
                    Var.ac.LoadAircraft(AircraftDGV);
                    Var.ac.LoadAirlineAircraft(AircraftAirlineDGV);
                    CLear_Aircraft_Text();


                }
            }
        }
        private void btn_DeleteAircraft_Click(object sender, EventArgs e)
        {
           
        }
        private void editToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Airlines_Settings.Height = 533;
            AircraftTextLoad();
        }

       

        private void Clear_Airline_Text()
        {
           
        }
       

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_ClearAirline_Text_Click(object sender, EventArgs e)
        {
            Clear_Airline_Text();
        }
        //-----------------------------------------------------------------------------------------------------

        //############################# RESERVATIONS CODES STARTS HERE #########################################
        private double CalDoubleCost()
        {
            double oneWay = Convert.ToDouble(txt_OnewayCost.Text);
            double Ret = Convert.ToDouble(txt_RetCost.Text);
            double total = (oneWay + Ret) + (RateCalculate(oneWay, "One Way") + RateCalculate(Ret, "Return"));
            return total;
        }

        private double RateCalculate(double value, string signature)
        {
            double rate = 0;
            switch (signature)
            {
                case "One Way":
                    if (comb_OnewayClass.SelectedIndex == 2) rate = (value) * 15 / 100;
                    else if (comb_OnewayClass.SelectedIndex == 1) rate = (value) * 10 / 100;
                    else if (comb_OnewayClass.SelectedIndex == 0) rate = 0;
                        break;
                case "Return":
                    if (comb_RetClass.SelectedIndex == 2) rate = (value) * 15 / 100;
                    else if (comb_RetClass.SelectedIndex == 1) rate = (value) * 10 / 100;
                    else if (comb_RetClass.SelectedIndex == 0) rate = 0;
                    break;
                default:
                    break;
            }
            return rate;
        }

        private void CalculateCostOnClass()
        {
            try
            {
                decimal totalCost;
                decimal retCost;
                decimal onewayCost;

                if (txt_OnewayCost.Text != "" && txt_RetCost.Text != "")
                {
                    //txt_TotalCost.Text = "K" + CalDoubleCost().ToString() + ".00";
                    txt_TotalCost.Text = CalDoubleCost().ToString();
                }
                else if (txt_OnewayCost.Text != "" && txt_RetCost.Text == "")
                {
                    if (comb_OnewayClass.Text =="First Class")
                    {
                        onewayCost = Convert.ToInt32(txt_OnewayCost.Text) * 15 / 100;
                        totalCost = onewayCost + Convert.ToInt32(txt_OnewayCost.Text);
                        //txt_TotalCost.Text = "K" + totalCost.ToString() + ".00";
                        txt_TotalCost.Text = totalCost.ToString();
                    }
                    else if (comb_OnewayClass.Text == "Business")
                    {
                        onewayCost = Convert.ToInt32(txt_OnewayCost.Text) * 10 / 100;
                        totalCost = onewayCost + Convert.ToInt32(txt_OnewayCost.Text);
                        //txt_TotalCost.Text = "K" + totalCost.ToString() + ".00";
                        txt_TotalCost.Text = totalCost.ToString();
                    }
                    else if (comb_OnewayClass.Text == "Economy")
                    {
                        totalCost = Convert.ToInt32(txt_OnewayCost.Text);
                        //txt_TotalCost.Text = "K" + totalCost.ToString() + ".00";
                        txt_TotalCost.Text = totalCost.ToString();
                    }
                    else
                    {
                        totalCost = Convert.ToInt32(txt_OnewayCost.Text);
                        //txt_TotalCost.Text = "K" + totalCost.ToString() + ".00";
                        txt_TotalCost.Text = totalCost.ToString();
                    }


                }
                else if (txt_RetCost.Text != "" && txt_OnewayCost.Text == "")
                {
                    if (comb_RetClass.Text == "First Class")
                    {
                        retCost = Convert.ToInt32(txt_RetCost.Text) * 15 / 100;
                        totalCost = retCost + Convert.ToInt32(txt_RetCost.Text);
                        //txt_TotalCost.Text = "K" + totalCost.ToString() + ".00";
                        txt_TotalCost.Text = totalCost.ToString();
                    }
                    else if (comb_RetClass.Text == "Business")
                    {
                        retCost = Convert.ToInt32(txt_RetCost.Text) * 10 / 100;
                        totalCost = retCost + Convert.ToInt32(txt_RetCost.Text);
                        // txt_TotalCost.Text = "K" + totalCost.ToString() + ".00";
                        txt_TotalCost.Text = totalCost.ToString();
                    }
                    else if (comb_RetClass.Text == "Economy")
                    {
                        totalCost = Convert.ToInt32(txt_RetCost.Text);
                        //txt_TotalCost.Text = "K" + totalCost.ToString() + ".00";
                        txt_TotalCost.Text = totalCost.ToString();
                    }
                    else
                    {
                        totalCost = Convert.ToInt32(txt_RetCost.Text);
                        //txt_TotalCost.Text = "K" + totalCost.ToString() + ".00";
                        txt_TotalCost.Text = totalCost.ToString();
                    }
                }
                else
                    //txt_TotalCost.Text = "K0.00";
                    txt_TotalCost.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ReserveFlight_btn_Click(object sender, EventArgs e)
        {

            /* ##########################################################################
                this condition if for the oneway ititnerary
             ############################################################################*/
            if (txt_ReservationRef.Text != "" && txt_TotalCost.Text != "" && cmb_Traveler.Text != ""
                && txt_OnewayFlightID.Text != "" && txt_OnewayCost.Text != "" && txt_OnewaySeat_No.Text != ""
                && txt_OnewayAircraft.Text != "" && txt_OnewayAirline.Text != "" && txt_OnewayFrom.Text != ""
                && txt_OnewayTo.Text != "" && OnewayDepDTP.Text != "" && OnewayArrDTP.Text != "" && comb_OnewayClass.Text != ""
                && txt_RetFlightID.Text == "" && txt_RetCost.Text == "" && txt_RetSeat_No.Text == "" && txt_RetAircraft.Text == ""
                && txt_RetAirline.Text == "" && txt_RetFrom.Text == "" && txt_RetTo.Text == ""
                && comb_RetClass.Text == "")
            {
                Var.reserve.Reservation_Ref = txt_ReservationRef.Text;
                Var.reserve.Cost = txt_TotalCost.Text;
                Var.reserve.Passenger_Name = cmb_Traveler.Text;
                if (Var.reserve.Reserve_flight().Equals(true))
                {
                    Var.reserve.Flight_ID = txt_OnewayFlightID.Text;
                    Var.reserve._Class = comb_OnewayClass.Text;
                    Var.reserve.Cost = txt_OnewayCost.Text;
                    Var.reserve.Seat_No = txt_OnewaySeat_No.Text;
                    if (Var.reserve.FlightReservation().Equals(true))
                    {
                        string T_name = "Flight_" + txt_OnewayFlightID.Text + "_Seats";
                        Var.fs.Asign_Seat(T_name, txt_OnewaySeat_No.Text);
                        printItinerary(Oneway_printDocument_PrintPage);
                        if (MessageBox.Show("Reservation Has Been Made Successfully, Do you want to send Reservation Details to email?", "RESERVATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            ReserveFlight_btn.Enabled = false;
                            Var.mail.Recipient = Var.reserve.Email_Address;
                            Var.mail.ReservationDetails = txt_ReservationRef.Text.ToUpper();
                            Var.mail.SendItineraryDetails();
                        }
                        ReserveFlight_btn.Enabled = true;
                        Var.reserve.LoadReservations(flightdReservationsDGV);
                        Clear_Reservation_Text();
                        //MessageBox.Show("Reservarion made successfully", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }


                }
            }
            /* ##########################################################################
                this condition if for the return ititnerary
             ############################################################################*/
            else if (txt_ReservationRef.Text != "" && txt_TotalCost.Text != "" && cmb_Traveler.Text != ""
                && txt_OnewayFlightID.Text != "" && txt_OnewayCost.Text != "" && txt_OnewaySeat_No.Text != ""
                && txt_OnewayAircraft.Text != "" && txt_OnewayAirline.Text != "" && txt_OnewayFrom.Text != ""
                && txt_OnewayTo.Text != "" && OnewayDepDTP.Text != "" && OnewayArrDTP.Text != "" && comb_OnewayClass.Text != ""
                && txt_RetFlightID.Text != "" && txt_RetCost.Text != "" && txt_RetSeat_No.Text != "" && txt_RetAircraft.Text != ""
                && txt_RetAirline.Text != "" && txt_RetFrom.Text != "" && txt_RetTo.Text != "" && RetDepDTP.Text != "" && RetArrDTP.Text != ""
                && comb_RetClass.Text != "")
            {

                Var.reserve.Reservation_Ref = txt_ReservationRef.Text;
                Var.reserve.Cost = txt_TotalCost.Text;
                Var.reserve.Passenger_Name = cmb_Traveler.Text;
                if (Var.reserve.Reserve_flight().Equals(true))
                {
                    Var.reserve.Flight_ID = txt_OnewayFlightID.Text;
                    Var.reserve._Class = comb_OnewayClass.Text;
                    Var.reserve.Cost = txt_OnewayCost.Text;
                    Var.reserve.Seat_No = txt_OnewaySeat_No.Text;
                    if (Var.reserve.FlightReservation().Equals(true))
                    {
                        string T_name = "Flight_" + txt_OnewayFlightID.Text + "_Seats";
                        Var.fs.Asign_Seat(T_name, txt_OnewaySeat_No.Text);

                        Var.reserve.Flight_ID = txt_RetFlightID.Text;
                        Var.reserve._Class = comb_RetClass.Text;
                        Var.reserve.Cost = txt_OnewayCost.Text;
                        Var.reserve.Seat_No = txt_RetSeat_No.Text;

                        if (Var.reserve.FlightReservation().Equals(true))
                        {
                            T_name = "Flight_" + txt_RetFlightID.Text + "_Seats";
                            Var.fs.Asign_Seat(T_name, txt_RetSeat_No.Text);
                            printItinerary(Return_printDocument_PrintPage);

                            if (MessageBox.Show("Reservation Has Been Made Successfully, Do you want to send Reservation Details to email?", "RESERVATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                ReserveFlight_btn.Enabled = false;
                                Var.mail.Recipient = Var.reserve.Email_Address;
                                Var.mail.ReservationDetails = txt_ReservationRef.Text + ", your fligts references are: " + txt_OnewayFlightID.Text.ToUpper() + " and " + txt_RetFlightID.Text.ToUpper();
                                //Var.mail.SendItineraryDetails();
                            }

                            ReserveFlight_btn.Enabled = true;
                            Var.reserve.LoadReservations(flightdReservationsDGV);
                            Clear_Reservation_Text();
                            MessageBox.Show("Reservarion made successfully", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }


                    }

                }
            }
        }
        private void Btn_ReserveFlight_Click(object sender, EventArgs e)
        {

        }
        private void txt_SearchReservation_TextChanged(object sender, EventArgs e)
        {
            Var.reserve.searchReservations(txt_SearchReservation.Text, flightdReservationsDGV);
        }
        private void Assign_StripMenuItem_Click(object sender, EventArgs e)
        {
            Var.reserve.AsignSeat(SeatsDGV, txt_OnewaySeat_No, txt_RetSeat_No);
            seatSelection_pnl.Height = 0;
        }

        private void txt_RetSeat_No_TextChanged(object sender, EventArgs e)
        {

        }

        private void seats_close_Click(object sender, EventArgs e)
        {
            seatSelection_pnl.Height = 0;
        }
        private void Clear_Reservation_Text()
        {
            txt_RetFrom.Clear();
            txt_OnewayFrom.Clear();
            txt_RetTo.Clear();
            txt_OnewayTo.Clear();
            txt_RetCost.Clear();
            txt_OnewayCost.Clear();
            //txt_RetReservationRef.Clear();
            txt_ReservationRef.Clear();
            txt_RetFlightID.Clear();
            txt_OnewayFlightID.Clear();
            txt_TotalCost.Clear();
            txt_OnewayAirline.Text = "";
            txt_RetAirline.Text = "";
            cmb_Traveler.Text = "";
            //cmb_RetTraveler.Text = "";
            comb_OnewayClass.Text = "";
            comb_RetClass.Text = "";
            txt_OnewaySeat_No.Text = "";
            txt_RetSeat_No.Text = "";
        }
        private void comb_RetClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateCostOnClass();
        }
        private void comb_OnewayClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateCostOnClass();
        }
        private void txt_OnewayCost_TextChanged(object sender, EventArgs e)
        {
             //UpdateTotalCost();
            CalculateCostOnClass();
        }

        private void txt_RetCost_TextChanged(object sender, EventArgs e)
        {
            CalculateCostOnClass();
            //UpdateTotalCost();
        }
        //schedule date variables to display on the ititnerary
        string Oneway_ScheduleDate;
        string Ret_ScheduleDate;
        private void Return_printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            String Firstname = Var.use.Firstname;
            String Lastname = Var.use.Lastname;

            Var.print.Return_printDocument_PrintPage(e, txt_ReservationRef, cmb_Traveler, txt_OnewayFrom, txt_OnewayTo,
                Oneway_ScheduleDate, txt_OnewayAirline, txt_OnewayFlightID, OnewayDepDTP, OnewayArrDTP, comb_OnewayClass, txt_RetFrom, txt_RetTo,
                Ret_ScheduleDate, txt_RetAirline, txt_RetFlightID, RetDepDTP, RetArrDTP, comb_RetClass, Firstname, Lastname);

        }
        private void Oneway_printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            String Firstname = Var.use.Firstname;
            String Lastname = Var.use.Lastname;
            Var.print.Oneway_printDocument_PrintPage(e, txt_ReservationRef, cmb_Traveler, txt_OnewayFrom, txt_OnewayTo,
                Oneway_ScheduleDate, txt_OnewayAirline, txt_OnewayFlightID, OnewayDepDTP, OnewayArrDTP, comb_OnewayClass, Firstname, Lastname);

        }
        private void form_Fade(Form frm)
        {
            Bitmap bmp = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
                g.CopyFromScreen(this.PointToScreen(new Point(0, 0)), new Point(0, 0), this.ClientRectangle.Size);
                double percent = 0.60;
                Color darken = Color.FromArgb((int)(255 * percent), Color.Black);
                using (Brush brush = new SolidBrush(darken))
                    g.FillRectangle(brush, this.ClientRectangle);
            }

            using (Panel pan = new Panel())
            {
                pan.Location = new Point(0, 0);
                pan.Size = this.ClientRectangle.Size;
                pan.BackgroundImage = bmp;
                this.Controls.Add(pan);
                pan.BringToFront();

                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
                
            }
        }
        private void _Reservation_View_Tooltip_Click(object sender, EventArgs e)
        {
            ReservationsTextLoad();
            Var.reserve.Reservation_Ref = text_RefID.Text;
            Reservation_View rv = new Reservation_View();
            form_Fade(rv);
            //Var.rv.ShowDialog();
            //Var.reserve.View_Reservation();
        }

        private void btn_PreviewItinerary_Click(object sender, EventArgs e)
        {
            if (txt_ReservationRef.Text != "" && txt_TotalCost.Text != "" && cmb_Traveler.Text != ""
                && txt_OnewayFlightID.Text != "" && txt_OnewayCost.Text != "" && txt_OnewaySeat_No.Text != ""
                && txt_OnewayAircraft.Text != "" && txt_OnewayAirline.Text != "" && txt_OnewayFrom.Text != ""
                && txt_OnewayTo.Text != "" && OnewayDepDTP.Text != "" && OnewayArrDTP.Text != "" && comb_OnewayClass.Text != ""
                && txt_RetFlightID.Text != "" && txt_RetCost.Text != "" && txt_RetSeat_No.Text != "" && txt_RetAircraft.Text != ""
                && txt_RetAirline.Text != "" && txt_RetFrom.Text != "" && txt_RetTo.Text != "" && RetDepDTP.Text != "" && RetArrDTP.Text != ""
                && comb_RetClass.Text != "")
            {
                MYprintPreviewDialog.Document = Return_printDocument;
                MYprintPreviewDialog.ShowDialog();
            }
            else if (txt_ReservationRef.Text != "" && txt_TotalCost.Text != "" && cmb_Traveler.Text != ""
                && txt_OnewayFlightID.Text != "" && txt_OnewayCost.Text != "" && txt_OnewaySeat_No.Text != ""
                && txt_OnewayAircraft.Text != "" && txt_OnewayAirline.Text != "" && txt_OnewayFrom.Text != ""
                && txt_OnewayTo.Text != "" && OnewayDepDTP.Text != "" && OnewayArrDTP.Text != "" && comb_OnewayClass.Text != ""
                && txt_RetFlightID.Text == "" && txt_RetCost.Text == "" && txt_RetSeat_No.Text == "" && txt_RetAircraft.Text == ""
                && txt_RetAirline.Text == "" && txt_RetFrom.Text == "" && txt_RetTo.Text == ""
                && comb_RetClass.Text == "")
            {
                MYprintPreviewDialog.Document = Oneway_printDocument;
                MYprintPreviewDialog.ShowDialog();
            }
            else
            {
                MessageBox.Show("make sure all required fields are filled");
            }
        }
        private void printItinerary(PrintPageEventHandler pd)
        {
            PrintDialog print_dialog = new PrintDialog();
            PrintDocument print_document = new PrintDocument();
            print_dialog.Document = print_document;
            print_document.PrintPage += new PrintPageEventHandler(pd);
            DialogResult result = print_dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                print_document.Print();
            }
        }
        private void Clear_Reserve_Text_btn_Click(object sender, EventArgs e) => Clear_Reservation_Text();
        private void btn_Clear_Reserve_Text_Click(object sender, EventArgs e)
        {
            
        }
        private void ManageReservations_btn_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                if (Reservation_Management.Height == 0)
                {
                    //Expand the panel
                    Reservation_Management.Visible = false;
                    Reservation_Management.Height = 573;
                    Edit_Animator.ShowSync(Reservation_Management);
                    ManageReservations_btn.Text = "Back to Reservations";

                }
                else
                {
                    // Minimize panel
                    Reservation_Management.Visible = false;
                    Reservation_Management.Height = 0;
                    Edit_Animator.ShowSync(Reservation_Management);
                    ManageReservations_btn.Text = "Manage Reservations";
                }
            }
            else if (this.WindowState == FormWindowState.Maximized)
            {
                if (Reservation_Management.Height == 0)
                {
                    //Expand the panel
                    Reservation_Management.Visible = false;
                    Reservation_Management.Height = 603;
                    Edit_Animator.ShowSync(Reservation_Management);
                    ManageReservations_btn.Text = "Back to Reservations";
                }
                else
                {
                    // Minimize panel
                    Reservation_Management.Height = 0;
                    Reservation_Management.Visible = false;
                    Edit_Animator.ShowSync(Reservation_Management);
                    ManageReservations_btn.Text = "Manage Reservations";
                }
            }
        }
        private void btn_Manage_Reservations_Click(object sender, EventArgs e)
        {
          
        }
        //this is used to load the reservation ID to use it for deleting the records
        public void ReservationsTextLoad()
        {
            try
            {
                DataGridViewCell cell = null;
                foreach (DataGridViewCell selectedCell in flightdReservationsDGV.SelectedCells)
                {
                    cell = selectedCell;
                    break;
                }
                if (cell != null)
                {
                    DataGridViewRow row = cell.OwningRow;
                    text_RefID.Text = row.Cells[0].Value.ToString();
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
                Var.reserve.Reservation_Ref = text_RefID.Text;
                
                Var.reserve.cancelReservation();
                Var.reserve.LoadReservations(flightdReservationsDGV);
                text_RefID.Clear();
            }
        }
        private void OnewayTextsLoad()
        {
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in SchedulesDGV.SelectedCells)
            {
                cell = selectedCell;
                break;
            }
            if (cell != null)
            {
                DataGridViewRow row = cell.OwningRow;
                txt_OnewayFlightID.Text = row.Cells[0].Value.ToString();
                txt_OnewayFrom.Text = row.Cells[1].Value.ToString();
                txt_OnewayTo.Text = row.Cells[2].Value.ToString();
                txt_OnewayAircraft.Text = row.Cells[3].Value.ToString();
                txt_OnewayAirline.Text = row.Cells[4].Value.ToString();
                OnewayDepDTP.Text = row.Cells[5].Value.ToString();
                OnewayArrDTP.Text = row.Cells[6].Value.ToString();
                Oneway_ScheduleDate = row.Cells[7].Value.ToString();
                //txtScheduleStatus.Text = row.Cells[7].Value.ToString();
            }
        }
        private void MultiwayTextsLoad()
        {
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in SchedulesDGV.SelectedCells)
            {
                cell = selectedCell;
                break;
            }
            if (cell != null)
            {
                DataGridViewRow row = cell.OwningRow;
                txt_RetFlightID.Text = row.Cells[0].Value.ToString();
                txt_RetFrom.Text = row.Cells[1].Value.ToString();
                txt_RetTo.Text = row.Cells[2].Value.ToString();
                txt_RetAircraft.Text = row.Cells[3].Value.ToString();
                txt_RetAirline.Text = row.Cells[4].Value.ToString();
                RetDepDTP.Text = row.Cells[5].Value.ToString();
                RetArrDTP.Text = row.Cells[6].Value.ToString();
                Ret_ScheduleDate = row.Cells[7].Value.ToString();
                //txtScheduleStatus.Text = row.Cells[7].Value.ToString();
            }
        }
        
        private void Load_FlightID()
        {
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in SchedulesDGV.SelectedCells)
            {
                cell = selectedCell;
                break;
            }
            if (cell != null)
            {
                DataGridViewRow row = cell.OwningRow;
                Var.reserve.Flight_ID = row.Cells[0].Value.ToString();
            }
        }
        private void oneWayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Load_FlightID();
            if (Var.reserve.Check_Flight().Equals(true))
            {
                OnewayTextsLoad();
                Tab_Indicator.Height = btn_Reservation.Height;
                Tab_Indicator.Top = btn_Reservation.Top;
                Main_Tab.SelectedTab = Reservations_Tab;
                Minimize_Menu();
                Var.reserve.Flight_ID = "";
            }
            
        }

        private void Schedules_CMS_Opening(object sender, CancelEventArgs e)
        {

        }

        private void secondRouteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Load_FlightID();
            if (Var.reserve.Check_Flight().Equals(true))
            {
                MultiwayTextsLoad();
                Tab_Indicator.Height = btn_Reservation.Height;
                Tab_Indicator.Top = btn_Reservation.Top;
                Main_Tab.SelectedTab = Reservations_Tab;
                Minimize_Menu();
                Var.reserve.Flight_ID = "";
            }
            
        }
        //------------------------------------------------------------------------------------------------------

        //########################## EMAIL CODES HERE #######################################################
        private void btn_EmailAttachment_Click(object sender, EventArgs e)
        {
            if (openFileDialogForAttachment.ShowDialog() == DialogResult.OK)
            {
                txt_Attachment.Text = openFileDialogForAttachment.FileName;
            }
        }
        public TextBox EmailBody{set { txt_EmailBody = value; } get { return txt_EmailBody; }}
        public TextBox EmailSubject { set { txt_EmailSubject = value; } get { return txt_EmailSubject; } }
        public TextBox EmailRecipient { set { txt_EmailRecipient = value; } get { return txt_EmailRecipient; } }
        public TextBox Attachment { set { txt_Attachment = value; } get { return txt_Attachment; } }
        private void btn_SendToOne_Click(object sender, EventArgs e)
        {
            if (txt_EmailRecipient.Text.Equals("") || txt_EmailSubject.Text.Equals("") || txt_EmailBody.Text.Equals(""))
            {
                MessageBox.Show("fill in all required filelds");
            }
            else
            {
                //Var.Email.ShowDialog();
                btn_SendToOne.Enabled = false;
                Var.mail.Subject = txt_EmailSubject.Text;
                Var.mail.Body = txt_EmailBody.Text;
                Var.mail.Recipient = txt_EmailRecipient.Text;
                Var.mail.Attachment = txt_Attachment.Text;
                if (Var.mail.SendEmail().Equals(true))
                {
                    btn_SendToOne.Enabled = true;
                    Email_TextClear();
                }
                btn_SendToOne.Enabled = true;

            }
        }

        private void Btn_EmailTextClear_Click(object sender, EventArgs e) => Email_TextClear();
        private void Email_TextClear()
        {
            txt_EmailBody.Clear();
            txt_EmailSubject.Clear();
            txt_EmailRecipient.Clear();
            txt_Attachment.Clear();
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
                    txt_EmailRecipient.Text = row.Cells[2].Value.ToString();

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

        private void PassengerEmailsDGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EmailRecipientTextLoad();
        }
        //------------------------------------------------------------------------------------------------------

        //########################## REPORT CODES HERE #######################################################
        private void Btn_Generate_Report_Click(object sender, EventArgs e)
        {
            string From = dtpRangeFrom.Text;
            string To = dtpRangeTo.Text;
           if( MessageBox.Show("Are you sure you have entered the corect range? " + "From: " + From + " To: " + To, "GENERATE REPORT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                result.Visible = true;
                Var.reserve.LoadReport(ReportDGV, dtpRangeFrom, dtpRangeTo);
                //Var.reserve.Sum_Cost(ReportsDGV);
                Var.reserve.CalculateCost(ReportDGV, result, dtpRangeFrom, dtpRangeTo);

            }
         
            
        }
        private void cmdLoad_Click(object sender, EventArgs e)
        {
                   
        }
        private void printReport_DGV()
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "RESERVATIONS REPORT";
            printer.SubTitle = "Report for Reserved flights From: " + dtpRangeFrom.Text + " To: " + dtpRangeTo.Text + ". | " + result.Text;

            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Blueberry Travels Malawi";
            printer.FooterSpacing = 15;

           // printer.PrintDataGridView(ReportDGV);
            printer.PrintPreviewDataGridView(ReportDGV);
        }
        private void cmdPrintReport_Click(object sender, EventArgs e)
        {
            if (ReportDGV.Rows.Count >= 1) printReport_DGV();
            else MessageBox.Show("There is nothing to Print, make sure you Generate the Report first", "NOTIFICATION", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        public void ReportTextLoad()
        {
            try
            {
                DataGridViewCell cell = null;
                foreach (DataGridViewCell selectedCell in ReportDGV.SelectedCells)
                {
                    cell = selectedCell;
                    break;
                }
                if (cell != null)
                {
                    DataGridViewRow row = cell.OwningRow;
                    text_RefID.Text = row.Cells[0].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportTextLoad();
            Var.reserve.Reservation_Ref = text_RefID.Text;
            Reservation_View rv = new Reservation_View();
            form_Fade(rv);
            //Var.rv.ShowDialog();
        }


        //------------------------------------------------------------------------------------------------------
        //########################## USER CODES HERE #######################################################
        private void btn_edit_users_Click(object sender, EventArgs e)
        {
            //user_settings.Height = 533;
            if (user_settings.Height == 0)
            {
                //Expand the panel
                user_settings.Visible = false;
                user_settings.Height = 533;
                Edit_Animator.ShowSync(user_settings);

            }
            else
            {
                // Minimize panel
                user_settings.Visible = false;
                user_settings.Height = 0;
                Edit_Animator.ShowSync(user_settings);
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Cancel? All unsaved changes will be lost, make sure you save before closing. Click Yes to Cancel or No to abort", "Close Schedules Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                user_settings.Height = 0;
                Clear_User_Text();

            }
            
        }
        private void Clear_User_Text()
        {
            txt_user_id.Clear();
            txt_firstname.Clear();
            txt_lastname.Clear();
            cmb_userType.Text = "";
            txt_position.Clear();
            txt_address.Clear();
            dtp_dob.Text = "";
            txt_username.Clear();
            txt_password.Clear();
        }
        private void ClearText_btn_Click(object sender, EventArgs e) => Clear_User_Text();
        private void btn_clearText_Click(object sender, EventArgs e)
        {
            
        }
        private void AddUser_btn_Click(object sender, EventArgs e)
        {
            if (txt_user_id.Text.Equals("") || txt_firstname.Text.Equals("") || txt_lastname.Text.Equals("") || cmb_userType.Text.Equals("") || txt_position.Text.Equals("") || dtp_dob.Text.Equals("") || txt_address.Equals("") || txt_username.Text.Equals("") || txt_password.Text.Equals(""))
            {
                MessageBox.Show("please fill in all text boxes");
            }
            else
            {
                Var.use.UserID = txt_user_id.Text;
                Var.use.Address = txt_address.Text;
                Var.use.Firstname = txt_firstname.Text;
                Var.use.Lastname = txt_lastname.Text;
                Var.use.Usertype = cmb_userType.Text;
                Var.use.Position = txt_position.Text;
                Var.use.DOB = dtp_dob.Text;
                Var.use.Username = txt_username.Text;
                Var.use.Password = txt_password.Text;
                if (Var.use.addNewUser().Equals(true))
                {
                    Var.use.LoadUsers(User_DataGridView);
                    MessageBox.Show("New User Successfully Added");
                    Clear_User_Text();

                }
            }
        }
        private void btn_addUser_Click(object sender, EventArgs e)
        {
           
        }

        private void UpdateUser_btn_Click(object sender, EventArgs e)
        {

            if (txt_user_id.Text.Equals("") || txt_firstname.Text.Equals("") || txt_lastname.Text.Equals("") || cmb_userType.Text.Equals("") || txt_position.Text.Equals("") || dtp_dob.Text.Equals("") || txt_address.Equals("") || txt_username.Text.Equals("") || txt_password.Text.Equals(""))
            {
                MessageBox.Show("please fill in all text boxes");
            }
            else
            {
                Var.use.UserID = txt_user_id.Text;
                Var.use.Address = txt_address.Text;
                Var.use.Firstname = txt_firstname.Text;
                Var.use.Lastname = txt_lastname.Text;
                Var.use.Usertype = cmb_userType.Text;
                Var.use.Position = txt_position.Text;
                Var.use.DOB = dtp_dob.Text;
                Var.use.Username = txt_username.Text;
                Var.use.Password = txt_password.Text;
                if (Var.use.updateUserDetails().Equals(true))
                {
                    Var.use.LoadUsers(User_DataGridView);
                    MessageBox.Show("you have successfully updated " + txt_firstname.Text + "'s details");
                    Clear_User_Text();

                }
            }
        }
        private void btn_updateUser_Click(object sender, EventArgs e)
        {
        }
        private void UserTextsLoad()
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
                    txt_user_id.Text = row.Cells[0].Value.ToString();
                    txt_firstname.Text = row.Cells[1].Value.ToString();
                    txt_lastname.Text = row.Cells[2].Value.ToString();
                    cmb_userType.Text = row.Cells[3].Value.ToString();
                    txt_position.Text = row.Cells[4].Value.ToString();
                    dtp_dob.Text = row.Cells[5].Value.ToString();
                    txt_address.Text = row.Cells[6].Value.ToString();
                    txt_username.Text = row.Cells[7].Value.ToString();
                    txt_password.Text = row.Cells[8].Value.ToString();
                }
                user_settings.Height = 533;
            }
            catch(Exception e)
            {
                MessageBox.Show("Error: " + e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void editToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            UserTextsLoad();
        }
        private void UserDelTextsLoad()
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
                txt_user_id.Text = row.Cells[0].Value.ToString();
            }
        }
        private void DeleteToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this User? Click Yes to Cancel or No to abort", "Delete User", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                UserDelTextsLoad();
                Var.use.UserID = txt_user_id.Text;
                Var.use.deleteUser();
                Var.use.LoadUsers(User_DataGridView);
            }
        }
        private void User_DataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            UserTextsLoad();
            
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void cmb_ScheduleAircraftID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txt_OnewayAircraft_TextChanged(object sender, EventArgs e)
        {
        }

        private void Edit_Airlines_Body_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_TotalCost_TextChanged(object sender, EventArgs e)
        {

        }

        private void comb_OnewayClass_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void btn_OneWaySeat_Click(object sender, EventArgs e)
        {
            txt_OnewaySeat_No.Clear();
            string T_name = "Flight_" + txt_OnewayFlightID.Text + "_Seats";
            Var.fs.LoadSeats(T_name, SeatsDGV);
            if (seatSelection_pnl.Height == 0)
            {
                //Expand the panel
                seatSelection_pnl.Visible = false;
                seatSelection_pnl.Height = 508;
                Edit_Animator.ShowSync(seatSelection_pnl);

            }
            else
            {
                // Minimize panel
                seatSelection_pnl.Visible = false;
                seatSelection_pnl.Height = 0;
                Edit_Animator.ShowSync(seatSelection_pnl);
            }
            //Tab_Indicator.Height = cmd_Seats.Height;
            //Tab_Indicator.Top = cmd_Seats.Top;
            //Main_Tab.SelectedTab = seats_Tab;
            //Minimize_Menu();
        }

        private void btn_RetSeat_Click(object sender, EventArgs e)
        {
            txt_RetSeat_No.Clear();
            string T_name = "Flight_" + txt_RetFlightID.Text + "_Seats";
            Var.fs.LoadSeats(T_name, SeatsDGV);
            if (seatSelection_pnl.Height == 0)
            {
                //Expand the panel
                seatSelection_pnl.Visible = false;
                seatSelection_pnl.Height = 508;
                Edit_Animator.ShowSync(seatSelection_pnl);

            }
            else
            {
                // Minimize panel
                seatSelection_pnl.Visible = false;
                seatSelection_pnl.Height = 0;
                Edit_Animator.ShowSync(seatSelection_pnl);
            }
            //Tab_Indicator.Height = cmd_Seats.Height;
            //Tab_Indicator.Top = cmd_Seats.Top;
            //Main_Tab.SelectedTab = seats_Tab;
            //Minimize_Menu();
    }

        private void txt_OnewayAircraft_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }
   
        //################################### SEAT CODES STARTS HERE #####################################

        

        private void SeatsDGV_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void UserSettings_Tab_Click(object sender, EventArgs e)
        {

        }

        private void Nav_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Btn_logout_Click(object sender, EventArgs e)
        {
           
            this.Hide();
            Var.log.Show();

        }

        private void MYprintPreviewDialog_Load(object sender, EventArgs e)
        {

        }

        private void Cmb_Traveler_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ITalk_Button_11_Click(object sender, EventArgs e) => printItinerary(Return_printDocument_PrintPage);

        private void ReservationsContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {

        }

        private void GroupBox15_Enter(object sender, EventArgs e)
        {
            
        }

    
        private void ITalk_ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void Btn_Help_Click(object sender, EventArgs e)
        {
            Tab_Indicator.Height = btn_Help.Height;
            Tab_Indicator.Top = btn_Help.Top;
            Main_Tab.SelectedTab = Info_Tab;
            Minimize_Menu();
            Load_HelpList();
        }

        private void SearchHelp_TextChanged(object sender, EventArgs e)
        {
            Var.help.Search_Help_List(txtSearchHelp.Text, Help_FlowPanel);
        }

        private void Reservations_Tab_Click(object sender, EventArgs e)
        {

        }
    }
}
