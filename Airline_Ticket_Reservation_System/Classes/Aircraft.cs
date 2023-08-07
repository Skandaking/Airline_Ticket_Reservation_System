using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Airline_Ticket_Reservation_System
{
    class Aircraft
    {
        private string aircraft_id;
        private string airline;
        private string aircraft_name;
        private string capacity;

        public string Aircraft_ID{set { aircraft_id = value; }get { return aircraft_id; }}
        public string Airline{set { airline = value; }get { return airline; }}
        public string Aircraft_Name {set { aircraft_name = value; }get { return aircraft_name; }}
        public string Capacity{set { capacity = value; }get { return capacity; }}

//####################### METHODS/OPERATIONS #####################################
        public void addNewAicraft()
        {
            try
            {
                string query = "INSERT INTO aircraft (Aircraft_ID, Aircraft_Name,  Airline, Capacity) VALUES ('" +
                    this.Aircraft_ID + "', '" + this.Aircraft_Name + "', '" + this.Airline + "', '" + this.Capacity + "')";
                Var.dataconn.execute(query);
                MessageBox.Show("New Aircraft Successfully Added");
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
        public void updateAircraft()
        {
            try
            {
                string query = "UPDATE aircraft SET Aircraft_ID = '" + this.Aircraft_ID + "', Airline = '" + this.Airline + "', Aircraft_Name = '" + this.Aircraft_Name + "', Capacity = '" + this.Capacity + "' WHERE Aircraft_ID = '" + this.Aircraft_ID + "'";
                Var.dataconn.execute(query);
                MessageBox.Show("Changes to " + this.Aircraft_Name + " has been made successfully");
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
        public void deleteAircraft()
        {
            try
            {
                string query = "DELETE FROM aircraft where Aircraft_ID = '" + this.Aircraft_ID + "'";
                Var.dataconn.execute(query);
                MessageBox.Show(" Records are Successfully deleted");
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
        public void searchAirlineAircraft(string searchValue, DataGridView dtv)
        {
            try
            {
                dtv.Rows.Clear();
                string query = "select * from aircraft where  CONCAT(Aircraft_ID, Airline, Aircraft_Name, Capacity) like'%" + searchValue + "%'";
                Var.dataconn.executeReader(query);

                while (Var.dataconn.reader.Read())
                {
                    dtv.Rows.Add
                    (
                        new object[]
                        {
                            Var.dataconn.reader["Aircraft_ID"].ToString(),
                            Var.dataconn.reader["Airline"].ToString(),
                            Var.dataconn.reader["Aircraft_Name"].ToString(),
                             Var.dataconn.reader["Capacity"].ToString()
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
        public void getAirline(string aircraftName, string airlineName)
        {
            try {
                string query = "SELECT * FROM aircraft WHERE Aircraft_Name like'%" + aircraftName + "%'";
                Var.dataconn.executeReader(query);
                int count = 0;
                while (Var.dataconn.reader.Read())
                {
                    count = count + 1;

                }
                if (count == 1)
                {
                    Var.dataconn.reader.Read();
                   string airlineID = Var.dataconn.reader["Airline_ID"].ToString();
                    query = "SELECT * FROM airlines WHERE Airline_ID='" + airlineID + "'";
                    Var.dataconn.executeReader(query);
                    int c = 0;
                    while (Var.dataconn.reader.Read())
                    {
                        c = c + 1;

                    }
                    if (c == 1)
                    {
                        Var.dataconn.reader.Read();
                        airlineName = Var.dataconn.reader["Airline_Name"].ToString();
                    }
                    else
                        airlineName = "";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Var.dataconn.closeConnection();
            }
            
        }
        public void LoadAirlineAircraft(DataGridView dtv)
        {
            try
            {
                dtv.Rows.Clear();
                string query = "select * from aircraft";
                Var.dataconn.executeReader(query);

                while (Var.dataconn.reader.Read())
                {
                    dtv.Rows.Add
                    (
                        new object[]
                        {
                            Var.dataconn.reader["Aircraft_ID"].ToString(),
                            Var.dataconn.reader["Airline"].ToString(),
                            Var.dataconn.reader["Aircraft_Name"].ToString(),
                            Var.dataconn.reader["Capacity"].ToString()
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
        public void LoadAircraftIDs(ComboBox cmb)
        {
            try
            {
                string query = "select * from Aircraft";
                cmb.Items.Clear();
                Var.dataconn.executeReader(query);
                while (Var.dataconn.reader.Read())
                {
                    cmb.Items.Add(Var.dataconn.reader.GetString("Aircraft_ID"));
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
             finally
            {
                Var.dataconn.closeConnection();
            }
        }
        public void LoadAircraft(DataGridView dtv)
        {
            try
            {
                dtv.Rows.Clear();
                string query = "select * from Aircraft";
                Var.dataconn.executeReader(query);

                while (Var.dataconn.reader.Read())
                {
                    dtv.Rows.Add
                    (
                        new object[]
                        {
                            Var.dataconn.reader["Aircraft_ID"].ToString(),
                            Var.dataconn.reader["Airline"].ToString(),
                            Var.dataconn.reader["Aircraft_Name"].ToString(),
                            Var.dataconn.reader["Capacity"].ToString()

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
    }
}
