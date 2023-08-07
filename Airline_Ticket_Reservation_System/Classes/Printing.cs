using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Airline_Ticket_Reservation_System
{
    class Printing
    {

        public void Get_ReservationDetails()
        {
                string query = "SELECT r.reservation_ref, p.Passenger_Name, a.Airline, r.Issued_Date, r.Cost, f.Class, f.Seat_No, f.Cost, s.Flight_ID, s.Aircraft_ID, " +
                              "s.Origin, s.Destination, s.Depart_Time, s.Arrive_Time, s.Date FROM reservations r," +
                              " flightreservation f, flightsSchedules s, Passengers p, Aircraft a WHERE r.reservation_ref='" + Var.reserve.Reservation_Ref + "' " +
                              "AND r.reservation_ref=f.reservation_ref AND f.flight_ID=s.flight_ID AND p.passenger_ID = r.passenger_ID AND a.Aircraft_ID = s.Aircraft_ID;";
                Var.dataconn.executeReader(query);
           
          
        }
        public void Reprint_PrintPage(PrintPageEventArgs e)
        {
            try
            {
                Get_ReservationDetails();
                string Line = "****************************************************************************************************************************";
                Bitmap bmp = Properties.Resources.Blueberry_Header;
                Image newHeader = bmp;
                e.Graphics.DrawImage(newHeader, 25, 25, newHeader.Width, newHeader.Height);

                //################################ LINE #################################################################
                e.Graphics.DrawString(Line, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(5, 300));

                e.Graphics.DrawString("ITINERARY", new Font("Century Gothic", 22, FontStyle.Bold), Brushes.DarkOrange, new Point(5, 310));
                e.Graphics.DrawString("INFORMATION", new Font("Century Gothic", 15, FontStyle.Bold), Brushes.DarkOrange, new Point(5, 345));
                e.Graphics.DrawString("Reservation Ref: BB - " + Var.reserve.Reservation_Ref, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(500, 320));
                e.Graphics.DrawString("Doc Issue Date:   " + Var.reserve.Issued_Date, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(500, 345));

                //################################ LINE #################################################################
                e.Graphics.DrawString(Line, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(5, 380));

                e.Graphics.DrawString("Traveler  :   " + Var.reserve.Passenger_Name, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(20, 410));
                e.Graphics.DrawString("Agency        : Blueberry Travel Limited", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(500, 410));
                e.Graphics.DrawString("Agent Name: " + Var.use.Firstname + " " + Var.use.Lastname, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(500, 435));

                int count = 490;

                while (Var.dataconn.reader.Read())
                {
                    //################################ LINE #################################################################
                    e.Graphics.DrawString(Line, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(5, count));

                    e.Graphics.DrawString("FLIGHT: " + Var.dataconn.reader.GetString("Origin") + " to " + Var.dataconn.reader["Destination"].ToString(), new Font("Century Gothic", 12, FontStyle.Bold), Brushes.DarkOrange, new Point(20, count + 10));
                    e.Graphics.DrawString("DATE: " + Var.dataconn.reader.GetString("Date").Split(' ')[0], new Font("Century Gothic", 12, FontStyle.Bold), Brushes.DarkOrange, new Point(660, count + 10));
                    //################################ LINE #################################################################
                    e.Graphics.DrawString(Line, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(5, count + 30));

                    e.Graphics.DrawString("Airline:           " + Var.dataconn.reader.GetString("Airline"), new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(20, count + 55));
                    e.Graphics.DrawString("Flight:   " + Var.dataconn.reader.GetString("Flight_ID"), new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(500, count + 55));
                    e.Graphics.DrawString("Departure:     " + Var.dataconn.reader.GetString("Depart_Time"), new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(20, count + 80));
                    e.Graphics.DrawString("From :   " + Var.dataconn.reader.GetString("Origin"), new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(500, count + 80));
                    e.Graphics.DrawString("Arrival:           " + Var.dataconn.reader.GetString("Arrive_Time"), new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(20, count + 105));
                    e.Graphics.DrawString("To :       " + Var.dataconn.reader.GetString("Destination"), new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(500, count + 105));
                    e.Graphics.DrawString("Class:             " + Var.dataconn.reader.GetString("Class"), new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(20, count + 130));
                    e.Graphics.DrawString("Status : Confirmed", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(500, count + 130));

                    count = count + 170;
                }





                e.Graphics.DrawString("Page 1 of 1", new Font("Century Gothic", 10, FontStyle.Regular), Brushes.Black, new Point(350, 1115));
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
        public void Oneway_printDocument_PrintPage(PrintPageEventArgs e, TextBox Reservation_ref,
            ComboBox cmb_traveler, TextBox From, TextBox To, string Schedule_Date, TextBox Airline, TextBox Flight_ID, DateTimePicker DepDTP, 
            DateTimePicker ArrDTP, ComboBox Class, string Firstname, string Lastname)
        {

            string Line = "****************************************************************************************************************************";
            Bitmap bmp = Properties.Resources.Blueberry_Header;
            Image newHeader = bmp;
            e.Graphics.DrawImage(newHeader, 25, 25, newHeader.Width, newHeader.Height);

            //################################ LINE #################################################################
            e.Graphics.DrawString(Line, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(5, 300));

            e.Graphics.DrawString("ITINERARY", new Font("Century Gothic", 22, FontStyle.Bold), Brushes.DarkOrange, new Point(5, 310));
            e.Graphics.DrawString("INFORMATION", new Font("Century Gothic", 15, FontStyle.Bold), Brushes.DarkOrange, new Point(5, 345));
            e.Graphics.DrawString("Reservation Ref: BB - " + Reservation_ref.Text.ToUpper(), new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(500, 320));
            e.Graphics.DrawString("Doc Issue Date:   " + DateTime.Now.ToLongDateString(), new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(500, 345));

            //################################ LINE #################################################################
            e.Graphics.DrawString(Line, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(5, 380));

            e.Graphics.DrawString("Traveler  :   " + cmb_traveler.Text.ToUpper(), new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(20, 410));
            e.Graphics.DrawString("Agency        : Blueberry Travel Limited", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(500, 410));
            e.Graphics.DrawString("Agent Name: " + Firstname + " " + Lastname, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(500, 435));

            //################################ LINE #################################################################
            e.Graphics.DrawString(Line, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(5, 490));

            e.Graphics.DrawString("FLIGHT: " + From.Text + " to " + To.Text, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.DarkOrange, new Point(20, 500));
            e.Graphics.DrawString("DATE: " + Schedule_Date, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.DarkOrange, new Point(660, 500));
            //################################ LINE #################################################################
            e.Graphics.DrawString(Line, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(5, 520));

            e.Graphics.DrawString("Airline:           " + Airline.Text, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(20, 545));
            e.Graphics.DrawString("Flight:   " + Flight_ID.Text, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(500, 545));
            e.Graphics.DrawString("Departure:     " + DepDTP.Text, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(20, 565));
            e.Graphics.DrawString("From :   " + From.Text, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(500, 565));
            e.Graphics.DrawString("Arrival:           " + ArrDTP.Text, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(20, 585));
            e.Graphics.DrawString("To :       " + To.Text, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(500, 585));
            e.Graphics.DrawString("Class:             " + Class.Text, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(20, 605));
            e.Graphics.DrawString("Status : Confirmed", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(500, 605));

            e.Graphics.DrawString("Page 1 of 1", new Font("Century Gothic", 10, FontStyle.Regular), Brushes.Black, new Point(350, 1115));
        }
        public void Return_printDocument_PrintPage(PrintPageEventArgs e, TextBox Reservation_ref,
            ComboBox cmb_traveler, TextBox From, TextBox To, string Schedule_Date, TextBox Airline, TextBox Flight_ID, DateTimePicker DepDTP,
            DateTimePicker ArrDTP, ComboBox Class, TextBox From2, TextBox To2, string Schedule_Date2, TextBox Airline2, TextBox Flight_ID2, DateTimePicker DepDTP2,
            DateTimePicker ArrDTP2, ComboBox Class2, string Firstname, string Lastname)
        {
            string ret1 = Reservation_ref.Text.ToUpper();
        
            string Line = "****************************************************************************************************************************";
            Bitmap bmp = Properties.Resources.Blueberry_Header;
            Image newHeader = bmp;
            e.Graphics.DrawImage(newHeader, 25, 25, newHeader.Width, newHeader.Height);

            //################################ LINE #################################################################
            e.Graphics.DrawString(Line, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(5, 300));

            e.Graphics.DrawString("ITINERARY", new Font("Century Gothic", 22, FontStyle.Bold), Brushes.DarkOrange, new Point(5, 310));
            e.Graphics.DrawString("INFORMATION", new Font("Century Gothic", 15, FontStyle.Bold), Brushes.DarkOrange, new Point(5, 345));
            e.Graphics.DrawString("Reservation Ref: BB - " + ret1, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(500, 320));
            e.Graphics.DrawString("Doc Issue Date:   " + DateTime.Now.ToLongDateString(), new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(500, 345));

            //################################ LINE #################################################################
            e.Graphics.DrawString(Line, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(5, 380));

            e.Graphics.DrawString("Traveler  :   " + cmb_traveler.Text.ToUpper(), new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(20, 410));
            e.Graphics.DrawString("Agency        : Blueberry Travel Limited", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(500, 410));
            e.Graphics.DrawString("Agent Name: " + Firstname + " " + Lastname, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(500, 435));

            //################################ LINE #################################################################
            e.Graphics.DrawString(Line, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(5, 490));

            e.Graphics.DrawString("FLIGHT: " + From.Text + " to " + To.Text, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.DarkOrange, new Point(20, 500));
            e.Graphics.DrawString("DATE: " + Schedule_Date, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.DarkOrange, new Point(660, 500));
            //################################ LINE #################################################################
            e.Graphics.DrawString(Line, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(5, 520));

            e.Graphics.DrawString("Airline:           " + Airline.Text, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(20, 545));
            e.Graphics.DrawString("Flight:   " + Flight_ID.Text, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(500, 545));
            e.Graphics.DrawString("Departure:     " + DepDTP.Text, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(20, 565));
            e.Graphics.DrawString("From :   " + From.Text, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(500, 565));
            e.Graphics.DrawString("Arrival:           " + ArrDTP.Text, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(20, 585));
            e.Graphics.DrawString("To :       " + To.Text, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(500, 585));
            e.Graphics.DrawString("Class:             " + Class.Text, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(20, 605));
            e.Graphics.DrawString("Status : Confirmed", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(500, 605));

            //################################ LINE #################################################################
            e.Graphics.DrawString(Line, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(5, 690));

            e.Graphics.DrawString("FLIGHT: " + From2.Text + " to " + To2.Text, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.DarkOrange, new Point(20, 700));
            e.Graphics.DrawString("DATE: " + Schedule_Date2, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.DarkOrange, new Point(660, 700));
            //################################ LINE #################################################################
            e.Graphics.DrawString(Line, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(5, 720));

            e.Graphics.DrawString("Airline:           " + Airline2.Text, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(20, 745));
            e.Graphics.DrawString("Flight:   " + Flight_ID2.Text, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(500, 745));
            e.Graphics.DrawString("Departure:     " + DepDTP2.Text, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(20, 770));
            e.Graphics.DrawString("From :   " + From2.Text, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(500, 770));
            e.Graphics.DrawString("Arrival:           " + ArrDTP2.Text, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(20, 795));
            e.Graphics.DrawString("To :       " + To2.Text, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(500, 795));
            e.Graphics.DrawString("Class:             " + Class2.Text, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(20, 820));
            e.Graphics.DrawString("Status : Confirmed", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(500, 820));


            e.Graphics.DrawString("Page 1 of 1", new Font("Century Gothic", 10, FontStyle.Regular), Brushes.Black, new Point(350, 1115));
        }
    }
}
