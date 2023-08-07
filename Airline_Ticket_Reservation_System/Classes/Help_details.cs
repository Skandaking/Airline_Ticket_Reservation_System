using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using Airline_Ticket_Reservation_System.Forms;

namespace Airline_Ticket_Reservation_System
{
    class Help_details
    {
        #region Properties

        private int id;
        private string tittle;
        private string _text;



        public int ID
        {
            set { id = value; }
            get { return id; }
        }

        public string Tittle
        {
            set { tittle = value; }
            get { return tittle; }
        }

        public string _Text
        {
            set { _text = value; }
            get { return _text; }
        }
        #endregion

        public void Load_Help_List(FlowLayoutPanel flp)
        {
            try
            {
                List<string> id = new List<string>();
                string query = "Select COUNT(*) FROM Help";
                int count = 0;
                count = Var.dataconn.executeScalar(query);

                query = "Select * FROM Help";
                Var.dataconn.executeReader(query);
                while (Var.dataconn.reader.Read())
                    id.Add(Var.dataconn.reader["ID"].ToString());

              HelpItem[] helpItem = new HelpItem[count];
                for (int i = 0; i < helpItem.Length; i++)
                {
                    query = "SELECT * FROM Help WHERE ID = '" + id[i] + "'";
                    Var.dataconn.executeReader(query);
                    while (Var.dataconn.reader.Read())
                    {
                        helpItem[i] = new HelpItem();
                        helpItem[i].ID = Convert.ToInt32(Var.dataconn.reader["ID"].ToString()) ;
                        helpItem[i].Tittle = Var.dataconn.reader["Tittle"].ToString();
                        helpItem[i]._Text = Var.dataconn.reader["Text"].ToString();

                        if (flp.Controls.Count < 0)
                            flp.Controls.Clear();
                        else
                            flp.Controls.Add(helpItem[i]);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error occurred: " + e.Message, "ERROR MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Var.dataconn.closeConnection();
            }
        }
        public void Search_Help_List(string searchValue, FlowLayoutPanel flp)
        {
            flp.Controls.Clear();
            try
            {
                String query = "SELECT * FROM Help WHERE CONCAT(ID, Tittle) like'%" + searchValue + "%'";
                Var.dataconn.executeReader(query);
                while (Var.dataconn.reader.Read())
                {
                    HelpItem hp = new HelpItem();
                    hp.ID = Convert.ToInt32(Var.dataconn.reader["ID"].ToString());
                    hp.Tittle = Var.dataconn.reader["Tittle"].ToString();
                    hp._Text = Var.dataconn.reader["Text"].ToString();

                    flp.Controls.Add(hp);
                }   
            }
            catch (Exception e)
            {
                MessageBox.Show("Error occurred: " + e.Message, "ERROR MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Var.dataconn.closeConnection();
            }
        }
        public void Load_Help_Text()
        {
            try
            {
                string query = "Select * from Help WHERE Tittle = '" + this.Tittle + "'";
                Var.dataconn.executeReader(query);
                while (Var.dataconn.reader.Read())
                {
                    Tittle = Var.dataconn.reader["Tittle"].ToString();
                    _Text = Var.dataconn.reader["Text"].ToString();
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Error occurred: " + e.Message, "ERROR MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Var.dataconn.closeConnection();
            }
        }
    }
}
