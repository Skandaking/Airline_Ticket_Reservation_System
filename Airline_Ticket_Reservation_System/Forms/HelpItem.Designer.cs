namespace Airline_Ticket_Reservation_System.Forms
{
    partial class HelpItem
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpItem));
            this.footer = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl_ID = new Ambiance.Ambiance_HeaderLabel();
            this.lbl_Header = new Ambiance.Ambiance_HeaderLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // footer
            // 
            this.footer.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footer.Location = new System.Drawing.Point(0, 51);
            this.footer.Name = "footer";
            this.footer.Size = new System.Drawing.Size(728, 3);
            this.footer.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(54, 51);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.HelpItem_MouseClick);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.Lbl_Header_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.Lbl_Header_MouseLeave);
            // 
            // lbl_ID
            // 
            this.lbl_ID.AutoSize = true;
            this.lbl_ID.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ID.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.lbl_ID.Location = new System.Drawing.Point(68, 9);
            this.lbl_ID.Name = "lbl_ID";
            this.lbl_ID.Size = new System.Drawing.Size(31, 30);
            this.lbl_ID.TabIndex = 3;
            this.lbl_ID.Text = "1.";
            this.lbl_ID.MouseClick += new System.Windows.Forms.MouseEventHandler(this.HelpItem_MouseClick);
            this.lbl_ID.MouseEnter += new System.EventHandler(this.Lbl_Header_MouseEnter);
            this.lbl_ID.MouseLeave += new System.EventHandler(this.Lbl_Header_MouseLeave);
            // 
            // lbl_Header
            // 
            this.lbl_Header.AutoSize = true;
            this.lbl_Header.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Header.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Header.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.lbl_Header.Location = new System.Drawing.Point(105, 9);
            this.lbl_Header.Name = "lbl_Header";
            this.lbl_Header.Size = new System.Drawing.Size(262, 30);
            this.lbl_Header.TabIndex = 2;
            this.lbl_Header.Text = "How to Reserve a Flight ?";
            this.lbl_Header.MouseClick += new System.Windows.Forms.MouseEventHandler(this.HelpItem_MouseClick);
            this.lbl_Header.MouseEnter += new System.EventHandler(this.Lbl_Header_MouseEnter);
            this.lbl_Header.MouseLeave += new System.EventHandler(this.Lbl_Header_MouseLeave);
            // 
            // HelpItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lbl_ID);
            this.Controls.Add(this.lbl_Header);
            this.Controls.Add(this.footer);
            this.Controls.Add(this.pictureBox1);
            this.Name = "HelpItem";
            this.Size = new System.Drawing.Size(728, 54);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.HelpItem_MouseClick);
            this.MouseEnter += new System.EventHandler(this.Lbl_Header_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.Lbl_Header_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel footer;
        private Ambiance.Ambiance_HeaderLabel lbl_Header;
        private Ambiance.Ambiance_HeaderLabel lbl_ID;
    }
}
