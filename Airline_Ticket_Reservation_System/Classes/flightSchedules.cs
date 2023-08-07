using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using DGVPrinterHelper;

namespace Airline_Ticket_Reservation_System
{
    class flightSchedules
    {
        private string flight_id;
        private string aircraft_id;
        private string origin;
        private string destination;
        private string depart_time;
        private string arrive_time;
        private string date;
        private string status;
        //private Timer CheckDepature;
        //private static bool update = false;

        public string Flight_ID{set { flight_id = value; }get { return flight_id; }}
        public string Aircraft_ID{set { aircraft_id = value; }get { return aircraft_id; }}
        public string Origin{set { origin = value; }get { return origin; }}
        public string Destination{set { destination = value; }get { return destination; }}
        public string Depart_Time{set { depart_time = value; }get { return depart_time; }}
        public string Arrive_Time{set { arrive_time = value; }get { return arrive_time; }}
        public string Date{set { date = value; } get { return date; }}
        public string Status{set { status = value; }get { return status; }}
        //public bool Update{get { return update; }set { update = value; }}




        //####################### METHODS/OPERATIONS #####################################
        //public flightSchedules()
        //{
        //    CheckDepature = new Timer();
        //    CheckDepature.Interval = 300000;
        //    CheckDepature.Start();
        //    CheckDepature.Tick += CheckDepature_Tick;
        //}

        //private void CheckDepature_Tick(object sender, EventArgs e)
        //{
        //    check_Status();
        //    update = true;
        //    Var.dataconn.closeConnection();
            
        //}


        public void check_Status()
        {
            try
            {
                //if (Var.dataconn.openConnection() == true)
                //{
                    List<string> pk = new List<string>();
                    string Query = "SELECT Count(*) FROM FlightsSchedules";
                    int count = 0;
                    count = Var.dataconn.executeScalar(Query);

                    Var.dataconn.closeConnection();
                    Query = "SELECT * FROM FlightsSchedules";
                    Var.dataconn.executeReader(Query);
                    while (Var.dataconn.reader.Read())
                        pk.Add(Var.dataconn.reader["flight_id"].ToString());
                     Var.dataconn.closeConnection();
                    for (int i = 0; i < count; i++)
                    {
                        Query = "SELECT * FROM FlightsSchedules WHERE flight_id = " + pk[i] + "";
                        Var.dataconn.executeReader(Query);
                        while (Var.dataconn.reader.Read())
                        {
                            Status = Var.dataconn.reader["Status"].ToString();
                            DateTime today = DateTime.Now;
                            DateTime Departure_Date = DateTime.Parse(Var.dataconn.reader["Date"].ToString());
                            TimeSpan ts = Departure_Date - today;
                            int days = ts.Days;
                            if (today.Date == Departure_Date)
                            {

                                DateTime time = DateTime.Now;
                                DateTime dept_time = DateTime.Parse(Var.dataconn.reader["Depart_Time"].ToString());
                                ts = dept_time - time;

                                int hours = ts.Hours;
                                if (hours > 0)
                                {
                                    if (hours == 1)
                                    {
                                        Query = "Update FlightsSchedules set Status = 'Check-in' where Flight_ID= '" + pk[i] + "'";
                                        Var.dataconn.execute(Query);
                                        Var.dataconn.closeConnection();
                                    }
                                    else
                                    {
                                        Query = "Update FlightsSchedules set Status = 'depart in " + hours + " hours' where Flight_ID= '" + pk[i] + "'";
                                        Var.dataconn.execute(Query);
                                        Var.dataconn.closeConnection();
                                    }

                                }

                                else if (hours < 0)
                                {
                                    DateTime arr_time = DateTime.Parse(Var.dataconn.reader["Arrive_Time"].ToString());
                                    if (time < arr_time)
                                    {
                                        Query = "Update FlightsSchedules set Status = 'departed' where Flight_ID= '" + pk[i] + "'";
                                        Var.dataconn.execute(Query);
                                        Var.dataconn.closeConnection();
                                    }
                                    else
                                    {
                                        Query = "Update FlightsSchedules set Status = 'Arrived' where Flight_ID= '" + pk[i] + "'";
                                        Var.dataconn.execute(Query);
                                        Var.dataconn.closeConnection();
                                    }
                                }
                            }
                            else if (today.Date > Departure_Date)
                            {

                                string T_name = "Flight_" + pk[i] + "_Seats";
                                //Query = "UPDATE FlightsSchedules SET Status = 'Arrived' WHERE Flight_ID= '" + pk[i] + "'";
                                //Var.dataconn.execute(Query);
                                Query = "SELECT * FROM FlightsSchedules WHERE Flight_ID= '" + pk[i] + "' AND Status = 'Arrived'";
                                Var.dataconn.executeReader(Query);
                                int _count = 0;
                                while (Var.dataconn.reader.Read())
                                {
                                    _count = _count + 1;
                                }
                                if (_count == 1)
                                {
                                    Query = "Update FlightsSchedules set Status = 'Not Active' where Flight_ID= '" + pk[i] + "'";
                                    Var.dataconn.execute(Query);
                                    Var.dataconn.closeConnection();

                                    Query = "DROP TABLE " + T_name + "";
                                    Var.dataconn.execute(Query);
                                    Var.dataconn.closeConnection();
                            }
                                else
                                {

                                }
                            }
                            else { }
                        }
                    }
                Var.dataconn.closeConnection();
                //}
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
             finally
            {
                Var.dataconn.closeConnection();
                Var.dataconn.ClearAllPools();
            }

        }

        public void LoadSchedules(DataGridView dtv)
        {
            try
            {
                dtv.Rows.Clear();
                string query = "select * from flightsschedules f, aircraft a where f.aircraft_ID = a.aircraft_ID order by Flight_ID DESC";
                Var.dataconn.executeReader(query);

                while (Var.dataconn.reader.Read())
                {
                    dtv.Rows.Add
                    (
                        new object[]
                        {
                            Var.dataconn.reader["Flight_ID"].ToString(),
                            Var.dataconn.reader["Origin"].ToString(),
                            Var.dataconn.reader["Destination"].ToString(),
                            Var.dataconn.reader["Aircraft_Name"].ToString(),
                            Var.dataconn.reader["Airline"].ToString(),
                            Var.dataconn.reader["Depart_Time"].ToString(),
                            Var.dataconn.reader["Arrive_Time"].ToString(),
                            Var.dataconn.reader["Date"].ToString(),
                            Var.dataconn.reader["Status"].ToString()
                        }
                    );
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Var.dataconn.closeConnection();
            }
        }
        public void searchSchedules(string searchValue, DataGridView dtv)
        {
            try
            {
                dtv.Rows.Clear();
                string query = "select * from flightsschedules f, aircraft a where f.aircraft_ID = a.aircraft_ID AND CONCAT(flight_ID, Aircraft_Name, Airline, Origin, Destination, Depart_Time, Arrive_Time, Date, Status) like'%" + searchValue + "%' order by Date DESC";
                Var.dataconn.executeReader(query);

                while (Var.dataconn.reader.Read())
                {
                    dtv.Rows.Add
                    (
                        new object[]
                        {
                            Var.dataconn.reader["Flight_ID"].ToString(),
                            Var.dataconn.reader["Origin"].ToString(),
                            Var.dataconn.reader["Destination"].ToString(),
                            Var.dataconn.reader["Aircraft_Name"].ToString(),
                             Var.dataconn.reader["Airline"].ToString(),
                            Var.dataconn.reader["Depart_Time"].ToString(),
                            Var.dataconn.reader["Arrive_Time"].ToString(),
                            Var.dataconn.reader["Date"].ToString(),
                            Var.dataconn.reader["Status"].ToString()
                        }
                    );
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Var.dataconn.closeConnection();
            }
        }
        public bool AddNewSchedule()
        {
            bool Add = false;
            try
            {
                string query = "Select * FROM Flightsschedules WHERE Flight_ID ='" + this.Flight_ID + "'";
                Var.dataconn.executeReader(query);
                int count = 0;
                while (Var.dataconn.reader.Read())
                {
                    count = count + 1;

                }
                if(count == 0)
                {
                    query = "INSERT INTO flightsschedules (Flight_ID, Aircraft_ID, Origin, Destination, Depart_Time, Arrive_Time, Date, Status) VALUES ('" +
                                        this.Flight_ID + "', '" + this.Aircraft_ID + "', '" + this.Origin + "', '" + this.Destination + "', '" +
                                        this.Depart_Time + "', '" + this.Arrive_Time + "', '" + this.Date + "', '" + this.Status + "')";
                    Var.dataconn.execute(query);
                    Add = true;
                }
                else if(count > 0)
                {
                    Add = false;
                }
                if (Add == true)
                    MessageBox.Show("New Flight has been Scheduled", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (Add == false && count > 0)
                    MessageBox.Show("Oops! error occured, Flight ID already exist", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }

            catch (Exception ex)
            {
                Add = false;
                MessageBox.Show("Oops! " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                Var.dataconn.closeConnection();
            }
            return Add;
        }

        public bool deleteSchedule()
        {
            bool del = false;
            try
            {
                string query = "DELETE FROM flightsschedules where Flight_ID = '" + this.Flight_ID + "'";
                Var.dataconn.execute(query);
                del = true;
                if (del == true)
                {
                    MessageBox.Show(" Schedule removed", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("This flight is currently reserved, make sure you first delete all reservstions on it otherwise the system " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                del = false;
            }
          
            finally
            {
                Var.dataconn.closeConnection();
            }
            return del;
        }
        public void cancelFlight()
        {
            try
            {
                string query = "UPDATE flightsSchedules SET Status = 'Cancelled' WHERE Flight_ID = '" + this.Flight_ID + "'";
                Var.dataconn.execute(query);
                MessageBox.Show("you have Cancelled Flight Number " + this.Flight_ID);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Var.dataconn.closeConnection();
            }
        }
        public void rescheduleFlight()
        {
            try
            {
                string query = "UPDATE flightsSchedules SET Aircraft_ID = '" + this.Aircraft_ID + "', Origin = '" + this.Origin + "', Destination = '" + this.Destination + "', Depart_Time = '" + this.Depart_Time + "', Arrive_Time = '" + this.Arrive_Time + "', Date = '" + this.Date + "', Status = 'Rescheduled' WHERE Flight_ID = '" + this.Flight_ID + "'";
                Var.dataconn.execute(query);
                MessageBox.Show("Flight Number " + this.Flight_ID + " has been Rescheduled");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Var.dataconn.closeConnection();
            }
        }
        public bool UpdateFlight()
        {
            bool update = false;
            try
            {
                string query = "UPDATE flightsSchedules SET Aircraft_ID = '" + this.Aircraft_ID + "', Origin = '" + this.Origin + "', Destination = '" + this.Destination + "', Depart_Time = '" + this.Depart_Time + "', Arrive_Time = '" + this.Arrive_Time + "', Date = '" + this.Date + "', Status = '" + this.Status + "' WHERE Flight_ID = '" + this.Flight_ID + "'";
                Var.dataconn.execute(query);
                update = true;
                if (update == true)
                    MessageBox.Show("Flight Number " + this.Flight_ID + " has been Updated ", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                update = false;
                MessageBox.Show("Oops! " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
             finally
            {
                Var.dataconn.closeConnection();
            }
            return update;
        }
        public void get_capacity()
        {
            int count = 0;
            int capacity = 0;
            try
            {
                string query = "SELECT Capacity FROM Aircraft WHERE Aircraft_ID='" + this.Aircraft_ID + "'";
                Var.dataconn.executeReader(query);
                while (Var.dataconn.reader.Read())
                    capacity = int.Parse(Var.dataconn.reader["Capacity"].ToString());

                string T_name = "Flight_" + this.Flight_ID + "_Seats";
                query = "CREATE TABLE " + T_name + "(Seat_No int(11) NOT NULL AUTO_INCREMENT PRIMARY KEY, Flight_ID varchar(255), Seat_Status varchar(30), FOREIGN KEY (Flight_ID) REFERENCES flightsschedules(Flight_ID))";
                Var.dataconn.execute(query);

                for (count = 1; count <= capacity; count++)
                {
                    query = "INSERT INTO " + T_name + "(Flight_ID, Seat_Status) VALUES('" + this.Flight_ID + "', 'Available')";
                    Var.dataconn.execute(query);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Var.dataconn.closeConnection();
            }
        }
        public void Asign_Seat(string T_name, string Seat_No)
        {
            try
            {
                string query = "UPDATE "+T_name+" SET Seat_Status='Occupied' WHERE Seat_No='"+Seat_No+"'";
                Var.dataconn.execute(query);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Var.dataconn.closeConnection();
            }

        }
        public void Cancel_Seat(string T_name, string Seat_No)
        {
            try
            {
                string query = "UPDATE " + T_name + " SET Seat_Status='Available' WHERE Seat_No='" + Seat_No + "'";
                Var.dataconn.execute(query);
            }
            catch (Exception e)
            {
                MessageBox.Show("The seat occupied by this user is now available","ERROR MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(e.Message, "ERROR MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Var.dataconn.closeConnection();
            }

        }
        public void LoadSeats(string T_name, DataGridView dtv)
        {
            try
            {
                dtv.Rows.Clear();
                string query = "select * from " + T_name + " WHERE Seat_Status='Available'";
                Var.dataconn.executeReader(query);

                while (Var.dataconn.reader.Read())
                {
                    dtv.Rows.Add
                    (
                        new object[]
                        {
                            Var.dataconn.reader["Seat_No"].ToString(),
                            Var.dataconn.reader["Seat_Status"].ToString()
                        }
                    );
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Var.dataconn.closeConnection();
            }
        }
       
    }
}
