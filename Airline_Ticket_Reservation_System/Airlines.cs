using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Airline_Ticket_Reservation_System
{
    class Airlines
    {
        private string airline_id;
        private string airline_name;

        public string Airline_ID
        {
            set { airline_id = value; }
            get { return airline_id; }
        }
        public string Airline_Name
        {
            set { airline_name = value; }
            get { return airline_name; }
        }

        public void LoadAirlineIDs(ComboBox cmb)
        {
            string query = "select * from Airlines";
            cmb.Items.Clear();
            Var.dataconn.executeReader(query);
            while (Var.dataconn.reader.Read())
            {
                cmb.Items.Add(Var.dataconn.reader.GetString("Airline_ID"));
            }
        }
        public void LoadAirlines(DataGridView dtv)
        {
            try
            {
                dtv.Rows.Clear();
                string query = "select * from Airlines";
                Var.dataconn.executeReader(query);

                while (Var.dataconn.reader.Read())
                {
                    dtv.Rows.Add
                    (
                        new object[]
                        {
                            Var.dataconn.reader["Airline_ID"].ToString(),
                            Var.dataconn.reader["Airline_Name"].ToString()
                        }
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Var.dataconn.closeConnection();
        }
        public void addNewAirline()
        {
            try
            {
                string query = "INSERT INTO airlines (Airline_ID, Airline_Name) VALUES ('" +
                    this.Airline_ID + "', '" + this.Airline_Name + "')";
                Var.dataconn.execute(query);
                MessageBox.Show("New Airline Successfully Added");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Var.dataconn.closeConnection();
        }
        public void updateAirline()
        {
            try
            {
                string query = "UPDATE airlines SET Airline_ID = '" + this.Airline_ID + "', Airline_Name = '" + this.Airline_Name + "' WHERE Airline_ID = '" + this.Airline_ID + "'";
                Var.dataconn.execute(query);
                MessageBox.Show("Changes to " + this.Airline_Name + " has been made successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Var.dataconn.closeConnection();
        }
        public void deleteAirline()
        {
            try
            {
                //string Name = this.Airline_Name;
                string query = "DELETE FROM airlines where Airline_ID = '" + this.Airline_ID + "'";
                Var.dataconn.execute(query);
                MessageBox.Show(" Records are Successfully deleted");
            }
            catch (Exception ex)
            {
                MessageBox.Show("This Airline is currently reserved on a flight, make sure you first delete all reservstions on it otherwise the system " + ex.Message);
            }
            Var.dataconn.closeConnection();
        }
    }
    
}
