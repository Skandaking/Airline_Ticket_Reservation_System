using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace Airline_Ticket_Reservation_System
{
    public partial class Reservation_View : Form
    {
        public Reservation_View()
        {
            InitializeComponent();
        }

        private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Var.print.Reprint_PrintPage(e);
        }
        private void Reprint_Itinerary()
        {
            PrintDialog printDialog = new PrintDialog();
            PrintDocument pd = new PrintDocument();
            printDialog.Document = pd;

            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
            //pd.PrintPage += new PrintPageEventHandler(PrintDocument1_PrintPage);
            //DialogResult result = printDialog.ShowDialog();
            //if(result == DialogResult.OK)
            //{
            //    pd.Print();
            //}
        }
        private void Btb_reprint_Click(object sender, EventArgs e)
        {
            Reprint_Itinerary();
            //LoadItineraryDetails();
        }

        private void PrintPreviewDialog1_Load(object sender, EventArgs e)
        {
           
        }

        private void SchedulesDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        private void Reservation_View_Load(object sender, EventArgs e)
        {
            
            Load_Itinerary();
        }

        private void Load_Itinerary()
        {
            
            Var.reserve.View_Reservation(ItineraryDGV, lbl_Cost);
            lbl_ref.Text = Var.reserve.Reservation_Ref;
            lbl_traveler.Text = Var.reserve.Passenger_Name;
            lbl_issue_Date.Text = Var.reserve.Issued_Date;
            //lbl_Cost.Text = Var.reserve.Cost;

        }
        private void Btn_CloseApp_Click(object sender, EventArgs e)=> this.Hide();

        private void Btb_reprint_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
