using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Drawing.Printing;
using System.Drawing;

namespace Airline_Ticket_Reservation_System
{
    class Reservations
    {
        private string reservation_ref;
        private string flight_id;
        private string passenger_id;
        private string passenger_name;
        private string email_address;
        private string _class;
        private string issued_date;
        private string cost;
        private string seat_no;
        private string id;


        public string Seat_No{set { seat_no = value; }get { return seat_no; }}
        public string Email_Address{set { email_address = value; }get { return email_address; }}
        public string Reservation_Ref{set { reservation_ref = value ; }get { return reservation_ref; }}
        public string Flight_ID{set { flight_id = value; }get { return flight_id; }}
        public string Passenger_ID{set { passenger_id = value; }get { return passenger_id; }}
        public string Passenger_Name{set { passenger_name = value; }get { return passenger_name; }}
        public string _Class{set { _class = value; }get { return _class; }}
        public string Issued_Date{set { issued_date = value; }get { return issued_date; }}
        public string Cost{set { cost = value; }get { return cost; }}
        public string ID { set { id = value; } get { return id; } }

//####################### METHODS/OPERATIONS #####################################
        public bool ReserveFlight()
            {
                bool Book = false;
                try
                {
                    string query = "SELECT * FROM flightsschedules WHERE Flight_ID='" + this.Flight_ID + "' AND Status='Not Active'";
                    Var.dataconn.executeReader(query);
                    int count = 0;
                    while (Var.dataconn.reader.Read()) { count +=1; }
                    if (count == 1)
                        MessageBox.Show("The Flight you have selected is Not Acitve, please try another flight", "FLIGHT RESERVATION", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    else
                    {
                        query = "SELECT * FROM flightsschedules WHERE Flight_ID='" + this.Flight_ID + "' AND Status='Check-in'";
                        Var.dataconn.executeReader(query);
                        count = 0;
                        while (Var.dataconn.reader.Read()) { count += 1; }
                    if (count == 1)
                            MessageBox.Show("sorry reservation is closed on this flight. Flight on check-in", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        query = "SELECT * FROM flightsschedules WHERE Flight_ID='" + this.Flight_ID + "' AND Status='Departed'";
                        Var.dataconn.executeReader(query);
                        count = 0;
                        while (Var.dataconn.reader.Read()) { count += 1; }
                        if (count == 1)
                            MessageBox.Show("Sorry the flight you've selected has been departed, please try again another flight", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            query = "SELECT * FROM flightsschedules WHERE Flight_ID='" + this.Flight_ID + "' AND Status='Arrived'";
                            Var.dataconn.executeReader(query);
                            count = 0;
                            while (Var.dataconn.reader.Read()) { count += 1; }
                            if (count == 1)
                                MessageBox.Show("Sorry the flight has Arrived, please try again another flight", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else
                            {
                                query = "select * from flightsschedules f, aircraft a WHERE Flight_ID='" + this.Flight_ID + "' AND f.aircraft_ID = a.aircraft_ID";
                                Var.dataconn.executeReader(query);
                                if (Var.dataconn.reader.HasRows)
                                {
                                    Var.dataconn.reader.Read();
                                    int Capacity = Convert.ToInt32(Var.dataconn.reader["Capacity"].ToString());
                                    query = "select * FROM Reservations Where Flight_ID ='" + this.Flight_ID + "' ";
                                    Var.dataconn.executeReader(query);
                                    count = 0;
                                    while (Var.dataconn.reader.Read()) { count += 1; }
                                    if (count == Capacity)
                                        MessageBox.Show("The Flight you have selected is Full, please try another flight", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    else
                                    {

                                        query = "SELECT * FROM Reservations WHERE Flight_ID ='" + this.Flight_ID + "' AND  Seat_No = '" + this.Seat_No + "'";
                                        Var.dataconn.executeReader(query);
                                        count = 0;
                                        while (Var.dataconn.reader.Read())
                                        {
                                            count = count + 1;
                                        }
                                        if (count == 1)
                                            MessageBox.Show("The Seat you have selected is already reserved please try another.");
                                        else
                                        {
                                            query = "SELECT * FROM passengers WHERE Passenger_Name='" + this.Passenger_Name + "'";
                                            Var.dataconn.executeReader(query);
                                            count = 0;
                                            while (Var.dataconn.reader.Read())
                                            {
                                                count = count + 1;

                                            }
                                            if (count == 1)
                                            {
                                                Var.dataconn.reader.Read();
                                                this.Passenger_ID = Var.dataconn.reader["Passenger_ID"].ToString();
                                                this.Email_Address = Var.dataconn.reader["Email"].ToString();
                                                DateTime date = DateTime.Now;
                                                Issued_Date = date.ToString("yyyy-MM-dd H:mm:ss");
                                                query = "INSERT INTO reservations (Reservation_Ref, Passenger_ID, Issued_Date, Cost) VALUES ('" +
                                                       this.Reservation_Ref + "', '" + this.Passenger_ID + "', '" +
                                                       this.Issued_Date + "', '" + this.Cost + "')";
                                                Var.dataconn.executeReader(query);
                                                Book = true;
                                            }
                                            else if (count == 0)
                                            {
                                                Book = false;
                                                MessageBox.Show("register the Traveler first");
                                            }
                                        }
                                    }
                                }
                            }
                            
                        }     
                    }
                }
                        
                }
                catch(Exception e)
                {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Var.dataconn.closeConnection();
            }
                return Book;
            }
        public bool Reserve_flight()
        {
            bool reserve = false;
            string query;
            try
            {
                int count = 0;
                query = "SELECT * FROM reservations WHERE reservation_ref ='"+this.Reservation_Ref+"'";
                Var.dataconn.executeReader(query);
                while (Var.dataconn.reader.Read())
                {
                    count += 1;
                }
                if(count > 0)
                {
                    MessageBox.Show("Reservation Reference already exist, try another!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    query = "SELECT * FROM Passengers WHERE Passenger_Name='" + this.Passenger_Name + "'";
                    Var.dataconn.executeReader(query);
                    int _count = 0;
                    while (Var.dataconn.reader.Read())
                    {
                        _count += 1;
                    }
                    if(_count == 1)
                    {
                        this.Passenger_ID = Var.dataconn.reader["Passenger_ID"].ToString();
                        this.Email_Address = Var.dataconn.reader["Email"].ToString();
                        DateTime date = DateTime.Now;
                        Issued_Date = date.ToString("yyyy-MM-dd H:mm:ss");
                        query = "INSERT INTO reservations (Reservation_Ref, Passenger_ID, Issued_Date, Cost) VALUES ('" +
                                                       this.Reservation_Ref + "', '" + this.Passenger_ID + "', '" +
                                                       this.Issued_Date + "', '" + this.Cost + "')";
                        Var.dataconn.executeReader(query);   
                        reserve = true;
                    }
                    else if (_count == 0)
                    {
                       
                        reserve = false;

                    }
                }
                if (reserve == true)
                    MessageBox.Show("Reservation successfully done!", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (reserve == false)
                    MessageBox.Show("register the Traveler first", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            catch(Exception e)
            {
                reserve = false;
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Var.dataconn.closeConnection();
            }
            return reserve;
        }
        public bool FlightReservation()
        {
            bool fr = false;
            try
            {

                string query = "INSERT INTO flightreservation(Reservation_Ref, Flight_ID, Class, Cost, Seat_No) VALUES ('" +
                    this.Reservation_Ref+"', '"+this.Flight_ID+"', '"+this._Class+"', '"+this.Cost+ "', '" + this.Seat_No+ "')";
                Var.dataconn.execute(query);
                fr = true;

            }
            catch (Exception e)
            {
                fr = false;
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Var.dataconn.closeConnection();
            }
            return fr;
        }
        public void AsignSeat(DataGridView dgv, TextBox OnewaySeat_No, TextBox RetSeat_No)
        {
            try
            {
                DataGridViewCell cell = null;
                foreach (DataGridViewCell selectedCell in dgv.SelectedCells)
                {
                    cell = selectedCell;
                    break;
                }
                if (cell != null)
                {
                    if (OnewaySeat_No.Text == "")
                    {
                        DataGridViewRow row = cell.OwningRow;
                        OnewaySeat_No.Text = row.Cells[0].Value.ToString();
                    }
                    else
                    {
                        DataGridViewRow row = cell.OwningRow;
                        RetSeat_No.Text = row.Cells[0].Value.ToString();
                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        public bool Check_Flight()
        {
            bool check = false;
            try
            {
                string query = "SELECT * FROM flightsschedules WHERE Flight_ID='" + this.Flight_ID + "' AND Status='Not Active'";
                Var.dataconn.executeReader(query);
                int count = 0;
                while (Var.dataconn.reader.Read()) { count += 1; }
                if (count == 1)
                    MessageBox.Show("The Flight you have selected is Not Acitve, please try another flight", "FLIGHT RESERVATION", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                else
                {
                    query = "SELECT * FROM flightsschedules WHERE Flight_ID='" + this.Flight_ID + "' AND Status='Check-in'";
                    Var.dataconn.executeReader(query);
                    count = 0;
                    while (Var.dataconn.reader.Read()) { count += 1; }
                    if (count == 1)
                        MessageBox.Show("sorry reservation is closed on this flight. Flight on check-in", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        query = "SELECT * FROM flightsschedules WHERE Flight_ID='" + this.Flight_ID + "' AND Status='Departed'";
                        Var.dataconn.executeReader(query);
                        count = 0;
                        while (Var.dataconn.reader.Read()) { count += 1; }
                        if (count == 1)
                            MessageBox.Show("Sorry the flight you've selected has been departed, please try again another flight", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            query = "SELECT * FROM flightsschedules WHERE Flight_ID='" + this.Flight_ID + "' AND Status='Arrived'";
                            Var.dataconn.executeReader(query);
                            count = 0;
                            while (Var.dataconn.reader.Read()) { count += 1; }
                            if (count == 1)
                                MessageBox.Show("Sorry the flight has Arrived, please try again another flight", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else
                            {
                                string T_name = "Flight_" + this.Flight_ID + "_Seats";
                                query = "SELECT * FROM "+T_name+ " WHERE Seat_Status='Available'";
                                Var.dataconn.executeReader(query);
                                if (Var.dataconn.reader.HasRows)
                                {
                                    check = true;
                                }

                                else
                                {
                                    MessageBox.Show("This Flight is full", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                } 
                            }
                        }

                     }
                }

            }
            catch (Exception e)
            {
                check = false;
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Var.dataconn.closeConnection();
            }
            return check;
        }
        public void LoadReservations(DataGridView dtv)
        {
            try
            {
                dtv.Rows.Clear();
                string query = "select r.Reservation_Ref, r.Issued_Date, r.cost, p.Passenger_Name, p.Phone_No, p.Email FROM reservations r, passengers p where r.passenger_ID = p.passenger_ID order by Issued_Date";
                Var.dataconn.executeReader(query);

                while (Var.dataconn.reader.Read())
                {
                    dtv.Rows.Add
                    (
                        new object[]
                        {
                            Var.dataconn.reader["Reservation_Ref"].ToString(),
                            Var.dataconn.reader["Passenger_Name"].ToString(),
                            Var.dataconn.reader["Phone_No"].ToString(),
                            Var.dataconn.reader["Email"].ToString(),
                            //Var.dataconn.reader["Cost"].ToString(),
                            string.Format("{0} {1}", "MWK", Var.reserve.MoneyFormat( Var.dataconn.reader["Cost"].ToString())),
                            Var.dataconn.reader["Issued_Date"].ToString().Split(' ')[0]
                        }
                    );
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
        public void searchReservations(string searchValue, DataGridView dtv)
        {
            try
            {
                dtv.Rows.Clear();
                string query = "select r.Reservation_Ref, r.Issued_Date, r.cost, p.Passenger_Name, p.Phone_No, p.Email FROM reservations r, passengers p where r.passenger_ID = p.passenger_ID AND CONCAT(Reservation_Ref,  Passenger_Name, Phone_No, Email, Cost, Issued_Date) like'%" + searchValue + "%'";
                Var.dataconn.executeReader(query);

                while (Var.dataconn.reader.Read())
                {
                    dtv.Rows.Add
                    (
                        new object[]
                        {
                            Var.dataconn.reader["Reservation_Ref"].ToString(),
                            Var.dataconn.reader["Passenger_Name"].ToString(),
                            Var.dataconn.reader["Phone_No"].ToString(),
                            Var.dataconn.reader["Email"].ToString(),
                            Var.dataconn.reader["Cost"].ToString(),
                            Var.dataconn.reader["Issued_Date"].ToString().Split(' ')[0]
                        }
                    );
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
        public void View_Reservation(DataGridView dtv, Label lbl)
        {
            try
            {
                Get_ReservationDetails();
                dtv.Rows.Clear();
                while (Var.dataconn.reader.Read())
                {
                    Passenger_Name = Var.dataconn.reader["Passenger_Name"].ToString();
                    Issued_Date = Var.dataconn.reader["Issued_Date"].ToString().Split(' ')[0];
                    Reservation_Ref = Var.dataconn.reader["Reservation_ref"].ToString();
                    //Cost = Var.dataconn.reader["Cost"].ToString();
                    int cost = 0;
                    cost = Convert.ToInt32(Var.dataconn.reader["Cost"].ToString());
                    lbl.Text = string.Format("{0} {1}", "MWK", Var.reserve.MoneyFormat(cost.ToString()));

                    dtv.Rows.Add
                    (
                        new object[]
                        {
                            Var.dataconn.reader["Flight_ID"].ToString(),
                            Var.dataconn.reader["Origin"].ToString(),
                            Var.dataconn.reader["Destination"].ToString(),
                            Var.dataconn.reader["Airline"].ToString(),
                            Var.dataconn.reader["Depart_Time"].ToString(),
                            Var.dataconn.reader["Arrive_Time"].ToString(),
                            Var.dataconn.reader["Date"].ToString().Split(' ')[0]
                        }
                    );
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("" + e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Var.dataconn.closeConnection();
            }
        }

        private void Get_ReservationDetails()
        {
            string query = "SELECT r.reservation_ref, p.Passenger_Name, a.Airline, r.Issued_Date, r.Cost, f.Class, f.Seat_No, f.Cost, s.Flight_ID, s.Aircraft_ID, " +
                                "s.Origin, s.Destination, s.Depart_Time, s.Arrive_Time, s.Date FROM reservations r," +
                                " flightreservation f, flightsSchedules s, Passengers p, Aircraft a WHERE r.reservation_ref='" + this.Reservation_Ref + "' " +
                                "AND r.reservation_ref=f.reservation_ref AND f.flight_ID=s.flight_ID AND p.passenger_ID = r.passenger_ID AND a.Aircraft_ID = s.Aircraft_ID;";
            Var.dataconn.executeReader(query);
        }

        public void cancelReservation()
        {
            try
            {
                List<string> pk = new List<string>();
                string query = "SELECT Count(*) FROM Flightreservation WHERE Reservation_Ref='"+this.Reservation_Ref+"'";
                int count = 0;
                count = Var.dataconn.executeScalar(query);
                query = "SELECT * FROM Flightreservation WHERE Reservation_Ref='" + this.Reservation_Ref + "'";
                Var.dataconn.executeReader(query);
                while (Var.dataconn.reader.Read())
                    pk.Add(Var.dataconn.reader["ID"].ToString());

                
                for (int i = 0; i < count; i++)
                {
                    query = "SELECT * FROM Flightreservation WHERE ID=" + pk[i] + "";
                    Var.dataconn.executeReader(query);

                    while (Var.dataconn.reader.Read())
                    {
                        
                        Flight_ID = Var.dataconn.reader["Flight_ID"].ToString();
                        ID = Var.dataconn.reader["ID"].ToString();
                        Seat_No = Var.dataconn.reader["Seat_No"].ToString();
                        Reservation_Ref = Var.dataconn.reader["Reservation_ref"].ToString();
                        //MessageBox.Show("" + reservation_ref);
                        query = "select * FROM Flightsschedules WHERE Flight_ID='"+ Flight_ID + "' AND Status='Active'";
                        int read = 0;
                        while (Var.dataconn.reader.Read())
                            read += 1;
                        if (read == 1)
                        {
                            string T_name = "Flight_" + Flight_ID + "_Seats";
                            query = "UPDATE " + T_name + " set Seat_Status='Available' WHERE Seat_No='" + Seat_No + "'";
                            Var.dataconn.execute(query);

                            query = "DELETE FROM Flightreservation WHERE ID='" + this.ID + "'";
                            Var.dataconn.execute(query);
                        }
                        else
                        {
                            MessageBox.Show("Something went wrong! please make sure the flight you are trying to cancel is Active",
                               "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                           
                        
                    }
                }
                query = "DELETE FROM Reservations where reservation_ref='" + this.Reservation_Ref + "'";
                Var.dataconn.execute(query);
                MessageBox.Show("Reservation Cancelled", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
        public void LoadReport(DataGridView dtv, DateTimePicker RangeFrom, DateTimePicker RangeTo)
        {
            try
            {
                dtv.Rows.Clear();
              
                string query = "select r.Reservation_Ref, r.Issued_Date, r.cost, p.Passenger_Name, p.Phone_No, p.Email FROM reservations r, passengers p where r.passenger_ID = p.passenger_ID AND r.Issued_Date BETWEEN '" + RangeFrom.Text+"' AND '"+RangeTo.Text+"' order by Issued_Date";

                Var.dataconn.executeReader(query);

                while (Var.dataconn.reader.Read())
                {
                    dtv.Rows.Add
                    (
                        new object[]
                        {
                             Var.dataconn.reader["Reservation_Ref"].ToString(),
                            Var.dataconn.reader["Passenger_Name"].ToString(),
                            Var.dataconn.reader["Phone_No"].ToString(),
                            Var.dataconn.reader["Email"].ToString(),
                            string.Format("{0} {1}", "MWK", Var.reserve.MoneyFormat( Var.dataconn.reader["Cost"].ToString())),
                            Var.dataconn.reader["Issued_Date"].ToString().Split(' ')[0]
                        }
                    );
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

        //REPORT CODE
        public void CalculateCost(DataGridView dtv, Label lbl, DateTimePicker RangeFrom, DateTimePicker RangeTo)
        {
            try
            {
                int totalCost = 0;
                string query = "SELECT SUM(Cost) FROM Reservations WHERE Issued_Date BETWEEN '" + RangeFrom.Text + "' AND '" + RangeTo.Text + "'";
                Var.dataconn.executeReader(query);
                if (Var.dataconn.reader.Read())
                {
                    if (dtv.Rows.Count >= 1)
                        totalCost = Convert.ToInt32(Var.dataconn.reader["SUM(Cost)"].ToString());
                    else
                        MessageBox.Show("No reservations have been made during the specified period", "NOTIFICATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

               // int totalCost = 0;
                //for (int count = 0; count < dtv.Rows.Count; count++)
                //{
                //    totalCost += Convert.ToInt32(dtv.Rows[count].Cells[4].Value);
                //}


                lbl.Text = string.Format("{0} {1}", "Total Amount: MWK", Var.reserve.MoneyFormat(totalCost.ToString()));
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Var.dataconn.closeConnection();
                Var.dataconn.ClearAllPools();
            }
            
        }
        public string MoneyFormat(string m)
        {
            double x = Convert.ToDouble(m);
            x = Math.Round(x, 2);
            return string.Format("{0:n}", x);
            
        }
    }
}
