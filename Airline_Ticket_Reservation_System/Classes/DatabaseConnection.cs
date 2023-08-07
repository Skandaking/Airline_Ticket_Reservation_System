using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using WindowsFormsControlLibrary1;

namespace Airline_Ticket_Reservation_System
{
    class DatabaseConnection
    {
        private MySqlConnection connection;
        public MySqlDataReader reader;
        private string server;
        private string database;
        private string username;
        private string password;
        private string connectionString;

        public DatabaseConnection()
        {
            server = "localhost";
            database = "atrs";
            username = "root";
            password = "";

            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "USERNAME=" + username + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);

        }
        
        public MySqlConnection Connect
        {
            get { return connection; }
            set { connection = value; }
        }

        public bool openConnection()
        {
            try
            {
                connection.Open();
                
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("error, failed to connect to database" + ex.Message);
                return false;
            }
        }
        public bool ClearAllPools()
        {
            try
            {
                connection.ClearAllPoolsAsync();
                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }
        public bool closeConnection()
        {
            try
            {
                connection.Close();
                
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        

        public void execute(string query)
        {
            DatabaseConnection dbc = new DatabaseConnection();
            try
            {
                
                if (dbc.openConnection() == true)
                {
                    MySqlCommand msc = new MySqlCommand(query, dbc.Connect);
                    msc.ExecuteNonQuery();
                }
                dbc.closeConnection();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public int executeScalar(string query)
        {
            int count = 0;
            try
            {
                
                DatabaseConnection dbc = new DatabaseConnection();
                if (dbc.openConnection() == true)
                {
                    MySqlCommand msc = new MySqlCommand(query, dbc.Connect);
                    count = Int32.Parse(msc.ExecuteScalar().ToString());
                }
                dbc.closeConnection();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return count;
        }

        public void executeReader(string query)
        {
            try
            {
                DatabaseConnection dbc = new DatabaseConnection();
                if (dbc.openConnection() == true)
                {
                    MySqlCommand msc = new MySqlCommand(query, dbc.Connect);
                    this.reader = msc.ExecuteReader();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
