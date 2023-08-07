using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Airline_Ticket_Reservation_System
{
    class Passengers
    {
        private string passenger_id;
        private string passenger_name;
        private string gender;
        private string age_range;
        private string phone_no;
        private string address;
        private string email;
        private string dob;
        private string username;
        private string password;
        
       
        public string Passenger_ID{set { passenger_id = value; }get { return passenger_id; }}
        public string Passenger_Name{set { passenger_name = value; }get { return passenger_name; }}
        public string Gender{set { gender = value; }get { return gender; }}
        public string Age_Range{set { age_range = value; }get { return age_range; }}
        public string Phone_No{set { phone_no = value; }get { return phone_no; }}
        public string Address{set { address = value; }get { return address; }}
        public string Email{set { email = value; }get { return email; }}
        public string DOB{get { return dob; }set { dob = value; }}
        public string Username{set { username = value; }get { return username; }}
        public string Password{set { password = value; }get { return password; }}

        //################### METHODS/OPERATIONS #########################################
        public void searchPassengers(string searchValue, DataGridView dtv)
        {
            try
            {
                dtv.Rows.Clear();
                string query = "SELECT * FROM passengers WHERE CONCAT(Passenger_ID, Passenger_Name, Gender, Age_Range, Phone_No, Address, Email, DOB) like'%" + searchValue + "%'";
                Var.dataconn.executeReader(query);

                while (Var.dataconn.reader.Read())
                {
                    dtv.Rows.Add
                    (
                        new object[]
                        {
                           Var.dataconn.reader["Passenger_ID"].ToString(),
                            Var.dataconn.reader["Passenger_Name"].ToString(),
                            Var.dataconn.reader["Gender"].ToString(),
                            Var.dataconn.reader["Age_Range"].ToString(),
                            Var.dataconn.reader["Phone_No"].ToString(),
                            Var.dataconn.reader["Address"].ToString(),
                            Var.dataconn.reader["Email"].ToString(),
                            Var.dataconn.reader["DOB"].ToString()
                        }
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Var.dataconn.closeConnection();
            }
        }
        public void LoadPassengerNames(ComboBox cmb)
        {
            try
            {
                string query = "select * from Passengers";
                cmb.Items.Clear();
                Var.dataconn.executeReader(query);
                while (Var.dataconn.reader.Read())
                {
                    //cmb.Items.Add(Var.dataconn.reader.GetString(""))
                    cmb.Items.Add(Var.dataconn.reader.GetString("Passenger_Name"));
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
        }
        public void loadPassengers(DataGridView dtv)
        {
            try
            {
                dtv.Rows.Clear();
                string query = "SELECT * FROM passengers";
                Var.dataconn.executeReader(query);

                while (Var.dataconn.reader.Read())
                {
                    dtv.Rows.Add
                    (
                       new object []
                       {
                           Var.dataconn.reader["Passenger_ID"].ToString(),
                            Var.dataconn.reader["Passenger_Name"].ToString(),
                            Var.dataconn.reader["Gender"].ToString(),
                            Var.dataconn.reader["Age_Range"].ToString(),
                            Var.dataconn.reader["Phone_No"].ToString(),
                            Var.dataconn.reader["Address"].ToString(),
                            Var.dataconn.reader["Email"].ToString(),
                            Var.dataconn.reader["DOB"].ToString()
                       } 
                    );
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
        public void loadPassengersEmails(DataGridView dtv)
        {
            try
            {
                dtv.Rows.Clear();
                string query = "SELECT * FROM passengers";
                Var.dataconn.executeReader(query);

                while (Var.dataconn.reader.Read())
                {
                    dtv.Rows.Add
                    (
                       new object[]
                       {
                           Var.dataconn.reader["Passenger_ID"].ToString(),
                            Var.dataconn.reader["Passenger_Name"].ToString(),
                            Var.dataconn.reader["Email"].ToString()
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
        public bool addNewPassenger()
        {
            bool add = false;
            try
            {
                string query1 = "SELECT * FROM Passengers WHERE Passenger_Name='" + this.Passenger_Name + "'";
                Var.dataconn.executeReader(query1);
                int count = 0;
                while (Var.dataconn.reader.Read())
                {
                    count = count + 1;

                }
                if (count == 0)
                {
                    string query = "INSERT INTO passengers (Passenger_Name, Gender, Age_Range, Phone_No, Address, Email, DOB, Username, Password) VALUES ('" + this.Passenger_Name + "', '" + this.Gender + "', '" + this.Age_Range + "', '" +
                           this.Phone_No + "', '" + this.Address + "', '" + this.Email + "', '" + this.DOB + "', '" + this.Username + "', '" + this.Password + "')";
                    Var.dataconn.executeReader(query);
                    add = true;
                }
                else if (count > 0)
                {
                    add = false;
                    
                }
                if (add == true)
                    MessageBox.Show("New Passenger is Successfully added", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if(add == false)
                    MessageBox.Show("Oops! error occured", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (add == false && count > 0)
                    MessageBox.Show("Oops! the name is already taken, try another name", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception e)
            {
                add = false;
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Var.dataconn.closeConnection();
            }
            return add;
        }
        public void updatePassengerDetails()
        {
            try
            {
                string query = "UPDATE passengers SET Passenger_Name = '" + this.Passenger_Name + "', Gender = '" + this.Gender +
                    "', Age_Range = '" + this.Age_Range + "', Phone_No = '" + this.Phone_No + "', Address = '" + this.Address + "', Email = '" + this.Email + "', DOB = '" + this.DOB + "', Username = '" + this.Username + "', Password = '" + this.Password + "' WHERE Passenger_ID = '" + this.Passenger_ID + "'";
                Var.dataconn.execute(query);
                MessageBox.Show("you have successfully updated " + this.Passenger_Name + "'s details");
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
        public void del()
        {
            
        }
        public bool deletePassenger()
        {
            bool deletePassenger = false;
            try
            {
                string query = "DELETE FROM passengers where Passenger_ID = '" + this.Passenger_ID + "'";
                Var.dataconn.execute(query);
                deletePassenger = true;
                    MessageBox.Show("" + this.Passenger_Name + " has been Deleted");
            }
            catch (Exception ex)
            {
                deletePassenger = false;
                MessageBox.Show("This Passenger has recently reserved a flight, make sure you first delete all reservstions he/she has otherwise the system " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            finally
            {
                Var.dataconn.closeConnection();
            }
            return deletePassenger;
        }
    }
}
