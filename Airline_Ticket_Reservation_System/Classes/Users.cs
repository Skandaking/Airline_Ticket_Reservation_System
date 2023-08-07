using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Airline_Ticket_Reservation_System
{
    class Users
    {
        private string user_ID;
        private string firstname;
        private string lastname;
        private string usertype;
        private string position;
        private string dob;
        private string address;
        private string username;
        private string password;

        public string UserID{set{user_ID = value; }get { return user_ID; }}
        public string Firstname{set { firstname = value; }get { return firstname; }}
        public string Lastname{set { lastname = value; }get { return lastname; }}
        public string Usertype{set { usertype = value; }get { return usertype; }}
        public string Position{ set { position = value; }get { return position; }}
        public string DOB{set { dob = value; }get { return dob; }}
        public string Address{set { address = value; }get { return address; }}
        public string Username{set { username = value; }get { return username; }}
        public string Password{set { password = value; }get { return password; }}

        public void RecoverAccount(ListView lsv)
        {
            DatabaseConnection dbc = new DatabaseConnection();
            if (dbc.openConnection() == true)
            {
                try
                {
                   string query1 = "SELECT * FROM users WHERE username='" + this.Username + "'";
                    lsv.Items.Clear();
                    dbc.executeReader(query1);

                    while (dbc.reader.Read())
                    {
                        ListViewItem item = new ListViewItem(dbc.reader["Username"].ToString());
                        item.SubItems.Add(dbc.reader["Password"].ToString());
                        lsv.Items.Add(item);
                    }

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
        public bool Login()
        {
            bool login = false;
            try
            {
                if(Var.dataconn.openConnection() == true)
                {
                    string query = "SELECT * FROM Users WHERE username='" + this.Username + "' and Password='" + this.Password + "'";
                    Var.dataconn.executeReader(query);
                    int count = 0;
                    while (Var.dataconn.reader.Read())
                    {
                        count = count + 1;
                    }
                    if (count == 1)
                    {
                        login = true;
                        query = "SELECT * FROM users WHERE username='" + this.Username + "'";
                        Var.dataconn.executeReader(query);
                        if (Var.dataconn.reader.HasRows)
                        {
                            Var.dataconn.reader.Read();
                            this.Usertype = Var.dataconn.reader["Usertype"].ToString();
                            this.Username = Var.dataconn.reader["Username"].ToString();
                            this.Firstname = Var.dataconn.reader["Firstname"].ToString();
                            this.Lastname = Var.dataconn.reader["Lastname"].ToString();
                            
                        }
                    }
                    else if (count > 1)
                    {
                        MessageBox.Show("Error in Login, try again or Contact admin", "LOGIN FAILED", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        login = false;
                    }
                    else if(count < 1)
                    {
                        MessageBox.Show("Account doesn't exist", "LOGIN FAILED", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        login = false;
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
            return login;
        }
        public bool addNewUser()
        {
            bool add_new = false;
            try
            {
                string query1 = "SELECT * FROM Users WHERE Username='" + this.Username + "'";
                Var.dataconn.executeReader(query1);
                int count = 0;
                while (Var.dataconn.reader.Read())
                {
                    count = count + 1;

                }
                if (count == 0)
                {
                    string query = "INSERT INTO Users (User_ID, Firstname, Lastname, Usertype, Position, Dob, Address, Username, Password) VALUES ('" +
                           this.UserID + "', '" + this.Firstname + "', '" + this.Lastname + "', '" + this.Usertype + "', '" +
                           this.Position + "', '" + this.DOB +"', '" + this.Address + "', '" + this.Username + "', '" + this.Password + "')";
                    Var.dataconn.executeReader(query);
                    add_new = true;
                }
                else if (count > 0)
                {
                    add_new = false;
                    MessageBox.Show("the Username is already taken, try another");
                }
                    
            }
            catch (Exception ex)
            {
                add_new = false;
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Var.dataconn.closeConnection();
            }
            return add_new;
        }
        public void LoadUsers(DataGridView dtv)
        {
            try
            {
                dtv.Rows.Clear();
                string query = "SELECT * FROM Users";
                Var.dataconn.executeReader(query);

                while (Var.dataconn.reader.Read())
                {
                    dtv.Rows.Add
                    (
                       new object[]
                       {
                           Var.dataconn.reader["User_ID"].ToString(),
                            Var.dataconn.reader["Firstname"].ToString(),
                            Var.dataconn.reader["Lastname"].ToString(),
                            Var.dataconn.reader["Usertype"].ToString(),
                            Var.dataconn.reader["Position"].ToString(),
                            Var.dataconn.reader["Dob"].ToString(),
                            Var.dataconn.reader["Address"].ToString(),
                            Var.dataconn.reader["Username"].ToString(),
                            Var.dataconn.reader["Password"].ToString()
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
        public void deleteUser()
        {
            try
            {
                string query = "DELETE FROM users where User_ID = '" + this.UserID + "'";
                Var.dataconn.execute(query);
                MessageBox.Show("User Deleted");
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message);
            }
            finally
            {
                Var.dataconn.closeConnection();
            }
        }
        public bool updateUserDetails()
        {
            bool update = false;
            try
            {
                string query = "UPDATE Users SET User_ID = '" + this.UserID + "', Firstname = '" + this.Firstname + "', Lastname = '" + this.Lastname +
                    "', Usertype = '" + this.Usertype + "', Position = '" + this.Position + "', Dob = '" + this.DOB + "', Address = '" + this.Address + "', Username = '" + this.Username + "', Password = '" + this.Password + "' WHERE User_ID = '" + this.UserID + "'";
                Var.dataconn.execute(query);
                update = true;
                
            }
            catch (Exception ex)
            {
                update = false;
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Var.dataconn.closeConnection();
            }
            return update;
        }
    }
            
}
