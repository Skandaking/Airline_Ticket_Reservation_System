namespace Airline_Ticket_Reservation_System
{
    partial class frm_Seats
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Seats));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Nav_Panel = new System.Windows.Forms.Panel();
            this.cmd_Edit = new Bunifu.Framework.UI.BunifuImageButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_CloseApp = new Bunifu.Framework.UI.BunifuImageButton();
            this.SeatsDGV = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SeatCMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Nav_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmd_Edit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_CloseApp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SeatsDGV)).BeginInit();
            this.SeatCMS.SuspendLayout();
            this.SuspendLayout();
            // 
            // Nav_Panel
            // 
            this.Nav_Panel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Nav_Panel.Controls.Add(this.cmd_Edit);
            this.Nav_Panel.Controls.Add(this.pictureBox1);
            this.Nav_Panel.Controls.Add(this.label1);
            this.Nav_Panel.Controls.Add(this.btn_CloseApp);
            this.Nav_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Nav_Panel.Location = new System.Drawing.Point(0, 0);
            this.Nav_Panel.Name = "Nav_Panel";
            this.Nav_Panel.Size = new System.Drawing.Size(545, 45);
            this.Nav_Panel.TabIndex = 27;
            // 
            // cmd_Edit
            // 
            this.cmd_Edit.AccessibleName = "";
            this.cmd_Edit.BackColor = System.Drawing.Color.Transparent;
            this.cmd_Edit.Image = ((System.Drawing.Image)(resources.GetObject("cmd_Edit.Image")));
            this.cmd_Edit.ImageActive = null;
            this.cmd_Edit.Location = new System.Drawing.Point(0, 0);
            this.cmd_Edit.Name = "cmd_Edit";
            this.cmd_Edit.Size = new System.Drawing.Size(26, 36);
            this.cmd_Edit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.cmd_Edit.TabIndex = 26;
            this.cmd_Edit.TabStop = false;
            this.cmd_Edit.Zoom = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(169, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(47, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(214, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 32);
            this.label1.TabIndex = 25;
            this.label1.Text = "ASIGN SEAT";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btn_CloseApp
            // 
            this.btn_CloseApp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_CloseApp.BackColor = System.Drawing.Color.Transparent;
            this.btn_CloseApp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_CloseApp.Image = ((System.Drawing.Image)(resources.GetObject("btn_CloseApp.Image")));
            this.btn_CloseApp.ImageActive = null;
            this.btn_CloseApp.Location = new System.Drawing.Point(506, 2);
            this.btn_CloseApp.Name = "btn_CloseApp";
            this.btn_CloseApp.Size = new System.Drawing.Size(37, 34);
            this.btn_CloseApp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_CloseApp.TabIndex = 24;
            this.btn_CloseApp.TabStop = false;
            this.btn_CloseApp.Zoom = 10;
            this.btn_CloseApp.Click += new System.EventHandler(this.btn_CloseApp_Click);
            // 
            // SeatsDGV
            // 
            this.SeatsDGV.AllowUserToAddRows = false;
            this.SeatsDGV.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.SeatsDGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.SeatsDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SeatsDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SeatsDGV.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.SeatsDGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SeatsDGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(197)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.MenuBar;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SeatsDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.SeatsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SeatsDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8,
            this.Column9});
            this.SeatsDGV.DoubleBuffered = true;
            this.SeatsDGV.EnableHeadersVisualStyles = false;
            this.SeatsDGV.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(197)))), ((int)(((byte)(240)))));
            this.SeatsDGV.HeaderForeColor = System.Drawing.SystemColors.MenuBar;
            this.SeatsDGV.Location = new System.Drawing.Point(0, 51);
            this.SeatsDGV.Name = "SeatsDGV";
            this.SeatsDGV.ReadOnly = true;
            this.SeatsDGV.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.SeatsDGV.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.SeatsDGV.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.SeatsDGV.Size = new System.Drawing.Size(545, 433);
            this.SeatsDGV.TabIndex = 28;
            // 
            // Column8
            // 
            this.Column8.FillWeight = 101.5228F;
            this.Column8.HeaderText = "SEAT No";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.FillWeight = 98.47716F;
            this.Column9.HeaderText = "STATUS";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // SeatCMS
            // 
            this.SeatCMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem});
            this.SeatCMS.Name = "SeatCMS";
            this.SeatCMS.Size = new System.Drawing.Size(95, 26);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editToolStripMenuItem.Image")));
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // frm_Seats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(545, 487);
            this.Controls.Add(this.SeatsDGV);
            this.Controls.Add(this.Nav_Panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_Seats";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frm_Seats_Load_1);
            this.Nav_Panel.ResumeLayout(false);
            this.Nav_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmd_Edit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_CloseApp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SeatsDGV)).EndInit();
            this.SeatCMS.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Nav_Panel;
        private Bunifu.Framework.UI.BunifuImageButton btn_CloseApp;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuCustomDataGrid SeatsDGV;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuImageButton cmd_Edit;
        private System.Windows.Forms.ContextMenuStrip SeatCMS;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
    }
}