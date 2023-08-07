using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Airline_Ticket_Reservation_System
{
    public partial class Help_Form : Form
    {
        public Help_Form()
        {
            InitializeComponent();
        }

        private void Btn_CloseApp_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void Load_Help()
        {
            Var.help.Load_Help_Text();
            txt_HelpText.Text = Var.help._Text;
            lbl_Header_Tittle.Text = Var.help.Tittle;
        }

        private void Help_Form_Load(object sender, EventArgs e)
        {
            Load_Help();
        }
    }
}
