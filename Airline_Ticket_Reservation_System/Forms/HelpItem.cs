using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Airline_Ticket_Reservation_System.Forms
{
    public partial class HelpItem : UserControl
    {
        public HelpItem()
        {
            InitializeComponent();
        }

        #region Properties
        private int id;
        private string tittle;
        private string _text;
        private Color back_Color;

        [Category("Custom Props")]
        public Color Back_Color
        {
            get { return back_Color; }
            set { back_Color = value; this.BackColor = Color.Transparent; }
        }

        [Category ("Props")]
        public int ID
        {
            set { id = value; lbl_ID.Text = value.ToString() + "."; }
            get { return id; }
        }

        [Category("Props")]
        public string Tittle
        {
            set { tittle = value; lbl_Header.Text = value; }
            get { return tittle; }
        }

        [Category("Props")]
        public string _Text
        {
            set { _text = value; }
            get { return _text; }
        }
        #endregion

        private void RestoreBackColor()
        {
            this.BackColor = Color.Transparent;
        }
        private void ChangeBackColor()
        {
            this.BackColor = Color.AliceBlue;
        }

        private void Lbl_Header_MouseEnter(object sender, EventArgs e)
        {
            ChangeBackColor();
        }

        private void Lbl_Header_MouseLeave(object sender, EventArgs e)
        {
            RestoreBackColor();
        }

        private void HelpItem_MouseClick(object sender, MouseEventArgs e)
        {
            Var.help.Tittle = this.Tittle;
            //form_Fade(Var.hf);
            Var.hf.ShowDialog();

        }
        private void form_Fade(Form frm)
        {
            Bitmap bmp = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
                g.CopyFromScreen(this.PointToScreen(new Point(0, 0)), new Point(0, 0), this.ClientRectangle.Size);
                double percent = 0.60;
                Color darken = Color.FromArgb((int)(255 * percent), Color.Black);
                using (Brush brush = new SolidBrush(darken))
                    g.FillRectangle(brush, this.ClientRectangle);
            }

            using (Panel pan = new Panel())
            {
                pan.Location = new Point(0, 0);
                pan.Size = this.ClientRectangle.Size;
                pan.BackgroundImage = bmp;
                this.Controls.Add(pan);
                pan.BringToFront();

                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();

            }
        }
    }
}
