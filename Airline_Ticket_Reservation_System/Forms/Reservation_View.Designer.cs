namespace Airline_Ticket_Reservation_System
{
    partial class Reservation_View
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reservation_View));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Nav_Panel = new System.Windows.Forms.Panel();
            this.btn_CloseApp = new Bunifu.Framework.UI.BunifuImageButton();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ItineraryDGV = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.IG_link = new System.Windows.Forms.PictureBox();
            this.Twitter_Link = new System.Windows.Forms.PictureBox();
            this.FaceBook_Link = new System.Windows.Forms.PictureBox();
            this.Footer_panel = new System.Windows.Forms.Panel();
            this.lbl_Cost = new Ambiance.Ambiance_Label();
            this.ambiance_Label10 = new Ambiance.Ambiance_Label();
            this.ambiance_Label1 = new Ambiance.Ambiance_Label();
            this.btb_reprint = new Ambiance.Ambiance_Button_2();
            this.ambiance_Label8 = new Ambiance.Ambiance_Label();
            this.ambiance_Label9 = new Ambiance.Ambiance_Label();
            this.lbl_traveler = new Ambiance.Ambiance_Label();
            this.ambiance_Label6 = new Ambiance.Ambiance_Label();
            this.lbl_issue_Date = new Ambiance.Ambiance_Label();
            this.ambiance_Label5 = new Ambiance.Ambiance_Label();
            this.ambiance_Label4 = new Ambiance.Ambiance_Label();
            this.lbl_ref = new Ambiance.Ambiance_Label();
            this.ambiance_Label3 = new Ambiance.Ambiance_Label();
            this.ambiance_Label2 = new Ambiance.Ambiance_Label();
            this.lbl_devider = new Ambiance.Ambiance_Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.Nav_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_CloseApp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItineraryDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IG_link)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Twitter_Link)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FaceBook_Link)).BeginInit();
            this.Footer_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Nav_Panel
            // 
            this.Nav_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(197)))), ((int)(((byte)(240)))));
            this.Nav_Panel.Controls.Add(this.btn_CloseApp);
            this.Nav_Panel.Controls.Add(this.label2);
            this.Nav_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Nav_Panel.Location = new System.Drawing.Point(0, 0);
            this.Nav_Panel.Name = "Nav_Panel";
            this.Nav_Panel.Size = new System.Drawing.Size(923, 39);
            this.Nav_Panel.TabIndex = 27;
            // 
            // btn_CloseApp
            // 
            this.btn_CloseApp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_CloseApp.BackColor = System.Drawing.Color.Transparent;
            this.btn_CloseApp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_CloseApp.Image = ((System.Drawing.Image)(resources.GetObject("btn_CloseApp.Image")));
            this.btn_CloseApp.ImageActive = null;
            this.btn_CloseApp.Location = new System.Drawing.Point(890, 1);
            this.btn_CloseApp.Name = "btn_CloseApp";
            this.btn_CloseApp.Size = new System.Drawing.Size(31, 35);
            this.btn_CloseApp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_CloseApp.TabIndex = 24;
            this.btn_CloseApp.TabStop = false;
            this.btn_CloseApp.Zoom = 10;
            this.btn_CloseApp.Click += new System.EventHandler(this.Btn_CloseApp_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Info;
            this.label2.Location = new System.Drawing.Point(367, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 34);
            this.label2.TabIndex = 19;
            this.label2.Text = "RESERVATION";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Airline_Ticket_Reservation_System.Properties.Resources.Blueberry_Header;
            this.pictureBox1.Location = new System.Drawing.Point(0, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(923, 197);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // ItineraryDGV
            // 
            this.ItineraryDGV.AllowUserToAddRows = false;
            this.ItineraryDGV.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ItineraryDGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ItineraryDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ItineraryDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ItineraryDGV.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.ItineraryDGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ItineraryDGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(197)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.MenuBar;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ItineraryDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.ItineraryDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ItineraryDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8,
            this.Column9,
            this.Column13,
            this.Column14,
            this.Column15,
            this.Column16,
            this.Column17});
            this.ItineraryDGV.DoubleBuffered = true;
            this.ItineraryDGV.EnableHeadersVisualStyles = false;
            this.ItineraryDGV.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(197)))), ((int)(((byte)(240)))));
            this.ItineraryDGV.HeaderForeColor = System.Drawing.SystemColors.MenuBar;
            this.ItineraryDGV.Location = new System.Drawing.Point(0, 414);
            this.ItineraryDGV.Name = "ItineraryDGV";
            this.ItineraryDGV.ReadOnly = true;
            this.ItineraryDGV.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.ItineraryDGV.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.ItineraryDGV.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.ItineraryDGV.Size = new System.Drawing.Size(923, 112);
            this.ItineraryDGV.TabIndex = 37;
            this.ItineraryDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SchedulesDGV_CellContentClick);
            // 
            // Column8
            // 
            this.Column8.HeaderText = "FLIGHT";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "ORIGIN";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "DESTINATION";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            // 
            // Column14
            // 
            this.Column14.HeaderText = "AIRLINE";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            // 
            // Column15
            // 
            this.Column15.HeaderText = "DEPART";
            this.Column15.Name = "Column15";
            this.Column15.ReadOnly = true;
            // 
            // Column16
            // 
            this.Column16.HeaderText = "ARRIVE";
            this.Column16.Name = "Column16";
            this.Column16.ReadOnly = true;
            // 
            // Column17
            // 
            this.Column17.HeaderText = "DATE";
            this.Column17.Name = "Column17";
            this.Column17.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Version: 6.3.5";
            // 
            // IG_link
            // 
            this.IG_link.Dock = System.Windows.Forms.DockStyle.Right;
            this.IG_link.Image = ((System.Drawing.Image)(resources.GetObject("IG_link.Image")));
            this.IG_link.Location = new System.Drawing.Point(890, 0);
            this.IG_link.Name = "IG_link";
            this.IG_link.Size = new System.Drawing.Size(33, 29);
            this.IG_link.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.IG_link.TabIndex = 19;
            this.IG_link.TabStop = false;
            // 
            // Twitter_Link
            // 
            this.Twitter_Link.Dock = System.Windows.Forms.DockStyle.Right;
            this.Twitter_Link.Image = ((System.Drawing.Image)(resources.GetObject("Twitter_Link.Image")));
            this.Twitter_Link.Location = new System.Drawing.Point(857, 0);
            this.Twitter_Link.Name = "Twitter_Link";
            this.Twitter_Link.Size = new System.Drawing.Size(33, 29);
            this.Twitter_Link.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Twitter_Link.TabIndex = 20;
            this.Twitter_Link.TabStop = false;
            // 
            // FaceBook_Link
            // 
            this.FaceBook_Link.Dock = System.Windows.Forms.DockStyle.Right;
            this.FaceBook_Link.Image = ((System.Drawing.Image)(resources.GetObject("FaceBook_Link.Image")));
            this.FaceBook_Link.Location = new System.Drawing.Point(824, 0);
            this.FaceBook_Link.Name = "FaceBook_Link";
            this.FaceBook_Link.Size = new System.Drawing.Size(33, 29);
            this.FaceBook_Link.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.FaceBook_Link.TabIndex = 21;
            this.FaceBook_Link.TabStop = false;
            // 
            // Footer_panel
            // 
            this.Footer_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.Footer_panel.Controls.Add(this.FaceBook_Link);
            this.Footer_panel.Controls.Add(this.Twitter_Link);
            this.Footer_panel.Controls.Add(this.IG_link);
            this.Footer_panel.Controls.Add(this.label1);
            this.Footer_panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Footer_panel.Location = new System.Drawing.Point(0, 523);
            this.Footer_panel.Name = "Footer_panel";
            this.Footer_panel.Size = new System.Drawing.Size(923, 29);
            this.Footer_panel.TabIndex = 38;
            // 
            // lbl_Cost
            // 
            this.lbl_Cost.AutoSize = true;
            this.lbl_Cost.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Cost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Cost.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Cost.ForeColor = System.Drawing.Color.Green;
            this.lbl_Cost.Location = new System.Drawing.Point(7, 371);
            this.lbl_Cost.Name = "lbl_Cost";
            this.lbl_Cost.Size = new System.Drawing.Size(167, 38);
            this.lbl_Cost.TabIndex = 49;
            this.lbl_Cost.Text = "Total Cost";
            // 
            // ambiance_Label10
            // 
            this.ambiance_Label10.AutoSize = true;
            this.ambiance_Label10.BackColor = System.Drawing.Color.Transparent;
            this.ambiance_Label10.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.ambiance_Label10.ForeColor = System.Drawing.Color.Black;
            this.ambiance_Label10.Location = new System.Drawing.Point(2, 355);
            this.ambiance_Label10.Name = "ambiance_Label10";
            this.ambiance_Label10.Size = new System.Drawing.Size(921, 20);
            this.ambiance_Label10.TabIndex = 48;
            this.ambiance_Label10.Text = "*********************************************************************************" +
    "***********************************************************************";
            // 
            // ambiance_Label1
            // 
            this.ambiance_Label1.AutoSize = true;
            this.ambiance_Label1.BackColor = System.Drawing.Color.Transparent;
            this.ambiance_Label1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.ambiance_Label1.ForeColor = System.Drawing.Color.Black;
            this.ambiance_Label1.Location = new System.Drawing.Point(2, 303);
            this.ambiance_Label1.Name = "ambiance_Label1";
            this.ambiance_Label1.Size = new System.Drawing.Size(921, 20);
            this.ambiance_Label1.TabIndex = 47;
            this.ambiance_Label1.Text = "*********************************************************************************" +
    "***********************************************************************";
            // 
            // btb_reprint
            // 
            this.btb_reprint.BackColor = System.Drawing.Color.Transparent;
            this.btb_reprint.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btb_reprint.Image = ((System.Drawing.Image)(resources.GetObject("btb_reprint.Image")));
            this.btb_reprint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btb_reprint.Location = new System.Drawing.Point(766, 375);
            this.btb_reprint.Name = "btb_reprint";
            this.btb_reprint.Size = new System.Drawing.Size(155, 30);
            this.btb_reprint.TabIndex = 46;
            this.btb_reprint.Text = "Reprint";
            this.btb_reprint.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btb_reprint.Click += new System.EventHandler(this.Btb_reprint_Click);
            this.btb_reprint.MouseHover += new System.EventHandler(this.Btb_reprint_MouseHover);
            // 
            // ambiance_Label8
            // 
            this.ambiance_Label8.AutoSize = true;
            this.ambiance_Label8.BackColor = System.Drawing.Color.Transparent;
            this.ambiance_Label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ambiance_Label8.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ambiance_Label8.ForeColor = System.Drawing.Color.Black;
            this.ambiance_Label8.Location = new System.Drawing.Point(757, 323);
            this.ambiance_Label8.Name = "ambiance_Label8";
            this.ambiance_Label8.Size = new System.Drawing.Size(161, 19);
            this.ambiance_Label8.TabIndex = 42;
            this.ambiance_Label8.Text = "Blueberry Travel LTD";
            // 
            // ambiance_Label9
            // 
            this.ambiance_Label9.AutoSize = true;
            this.ambiance_Label9.BackColor = System.Drawing.Color.Transparent;
            this.ambiance_Label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ambiance_Label9.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ambiance_Label9.ForeColor = System.Drawing.Color.Black;
            this.ambiance_Label9.Location = new System.Drawing.Point(687, 323);
            this.ambiance_Label9.Name = "ambiance_Label9";
            this.ambiance_Label9.Size = new System.Drawing.Size(75, 19);
            this.ambiance_Label9.TabIndex = 41;
            this.ambiance_Label9.Text = "Agency:";
            // 
            // lbl_traveler
            // 
            this.lbl_traveler.AutoSize = true;
            this.lbl_traveler.BackColor = System.Drawing.Color.Transparent;
            this.lbl_traveler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_traveler.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_traveler.ForeColor = System.Drawing.Color.Black;
            this.lbl_traveler.Location = new System.Drawing.Point(76, 323);
            this.lbl_traveler.Name = "lbl_traveler";
            this.lbl_traveler.Size = new System.Drawing.Size(93, 19);
            this.lbl_traveler.TabIndex = 40;
            this.lbl_traveler.Text = "------------";
            // 
            // ambiance_Label6
            // 
            this.ambiance_Label6.AutoSize = true;
            this.ambiance_Label6.BackColor = System.Drawing.Color.Transparent;
            this.ambiance_Label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ambiance_Label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ambiance_Label6.ForeColor = System.Drawing.Color.Black;
            this.ambiance_Label6.Location = new System.Drawing.Point(6, 323);
            this.ambiance_Label6.Name = "ambiance_Label6";
            this.ambiance_Label6.Size = new System.Drawing.Size(74, 19);
            this.ambiance_Label6.TabIndex = 39;
            this.ambiance_Label6.Text = "Traveler:";
            // 
            // lbl_issue_Date
            // 
            this.lbl_issue_Date.AutoSize = true;
            this.lbl_issue_Date.BackColor = System.Drawing.Color.Transparent;
            this.lbl_issue_Date.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_issue_Date.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_issue_Date.ForeColor = System.Drawing.Color.Black;
            this.lbl_issue_Date.Location = new System.Drawing.Point(812, 277);
            this.lbl_issue_Date.Name = "lbl_issue_Date";
            this.lbl_issue_Date.Size = new System.Drawing.Size(93, 19);
            this.lbl_issue_Date.TabIndex = 36;
            this.lbl_issue_Date.Text = "------------";
            // 
            // ambiance_Label5
            // 
            this.ambiance_Label5.AutoSize = true;
            this.ambiance_Label5.BackColor = System.Drawing.Color.Transparent;
            this.ambiance_Label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ambiance_Label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ambiance_Label5.ForeColor = System.Drawing.Color.Black;
            this.ambiance_Label5.Location = new System.Drawing.Point(687, 277);
            this.ambiance_Label5.Name = "ambiance_Label5";
            this.ambiance_Label5.Size = new System.Drawing.Size(89, 19);
            this.ambiance_Label5.TabIndex = 34;
            this.ambiance_Label5.Text = "Issue Date:";
            // 
            // ambiance_Label4
            // 
            this.ambiance_Label4.AutoSize = true;
            this.ambiance_Label4.BackColor = System.Drawing.Color.Transparent;
            this.ambiance_Label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ambiance_Label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ambiance_Label4.ForeColor = System.Drawing.Color.Black;
            this.ambiance_Label4.Location = new System.Drawing.Point(687, 254);
            this.ambiance_Label4.Name = "ambiance_Label4";
            this.ambiance_Label4.Size = new System.Drawing.Size(128, 19);
            this.ambiance_Label4.TabIndex = 33;
            this.ambiance_Label4.Text = "Reservation Ref:";
            // 
            // lbl_ref
            // 
            this.lbl_ref.AutoSize = true;
            this.lbl_ref.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ref.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_ref.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ref.ForeColor = System.Drawing.Color.Black;
            this.lbl_ref.Location = new System.Drawing.Point(812, 254);
            this.lbl_ref.Name = "lbl_ref";
            this.lbl_ref.Size = new System.Drawing.Size(93, 19);
            this.lbl_ref.TabIndex = 35;
            this.lbl_ref.Text = "------------";
            // 
            // ambiance_Label3
            // 
            this.ambiance_Label3.AutoSize = true;
            this.ambiance_Label3.BackColor = System.Drawing.Color.Transparent;
            this.ambiance_Label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ambiance_Label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ambiance_Label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ambiance_Label3.Location = new System.Drawing.Point(5, 282);
            this.ambiance_Label3.Name = "ambiance_Label3";
            this.ambiance_Label3.Size = new System.Drawing.Size(117, 19);
            this.ambiance_Label3.TabIndex = 32;
            this.ambiance_Label3.Text = "INFORMATION";
            // 
            // ambiance_Label2
            // 
            this.ambiance_Label2.AutoSize = true;
            this.ambiance_Label2.BackColor = System.Drawing.Color.Transparent;
            this.ambiance_Label2.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ambiance_Label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ambiance_Label2.Location = new System.Drawing.Point(2, 254);
            this.ambiance_Label2.Name = "ambiance_Label2";
            this.ambiance_Label2.Size = new System.Drawing.Size(127, 28);
            this.ambiance_Label2.TabIndex = 31;
            this.ambiance_Label2.Text = "ITINERARY";
            // 
            // lbl_devider
            // 
            this.lbl_devider.AutoSize = true;
            this.lbl_devider.BackColor = System.Drawing.Color.Transparent;
            this.lbl_devider.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lbl_devider.ForeColor = System.Drawing.Color.Black;
            this.lbl_devider.Location = new System.Drawing.Point(3, 239);
            this.lbl_devider.Name = "lbl_devider";
            this.lbl_devider.Size = new System.Drawing.Size(921, 20);
            this.lbl_devider.TabIndex = 29;
            this.lbl_devider.Text = "*********************************************************************************" +
    "***********************************************************************";
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // Reservation_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(923, 552);
            this.Controls.Add(this.lbl_Cost);
            this.Controls.Add(this.ambiance_Label10);
            this.Controls.Add(this.ambiance_Label1);
            this.Controls.Add(this.btb_reprint);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ambiance_Label8);
            this.Controls.Add(this.ambiance_Label9);
            this.Controls.Add(this.lbl_traveler);
            this.Controls.Add(this.ambiance_Label6);
            this.Controls.Add(this.Footer_panel);
            this.Controls.Add(this.ItineraryDGV);
            this.Controls.Add(this.lbl_issue_Date);
            this.Controls.Add(this.ambiance_Label5);
            this.Controls.Add(this.ambiance_Label4);
            this.Controls.Add(this.lbl_ref);
            this.Controls.Add(this.ambiance_Label3);
            this.Controls.Add(this.ambiance_Label2);
            this.Controls.Add(this.lbl_devider);
            this.Controls.Add(this.Nav_Panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Reservation_View";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reservation_View";
            this.Load += new System.EventHandler(this.Reservation_View_Load);
            this.Nav_Panel.ResumeLayout(false);
            this.Nav_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_CloseApp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItineraryDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IG_link)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Twitter_Link)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FaceBook_Link)).EndInit();
            this.Footer_panel.ResumeLayout(false);
            this.Footer_panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Nav_Panel;
        private Bunifu.Framework.UI.BunifuImageButton btn_CloseApp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Ambiance.Ambiance_Label lbl_devider;
        private Ambiance.Ambiance_Label ambiance_Label2;
        private Ambiance.Ambiance_Label ambiance_Label3;
        private Ambiance.Ambiance_Label ambiance_Label4;
        private Ambiance.Ambiance_Label ambiance_Label5;
        private Ambiance.Ambiance_Label lbl_ref;
        private Ambiance.Ambiance_Label lbl_issue_Date;
        private Bunifu.Framework.UI.BunifuCustomDataGrid ItineraryDGV;
        private Ambiance.Ambiance_Label ambiance_Label6;
        private Ambiance.Ambiance_Label lbl_traveler;
        private Ambiance.Ambiance_Label ambiance_Label8;
        private Ambiance.Ambiance_Label ambiance_Label9;
        private Ambiance.Ambiance_Button_2 btb_reprint;
        private Ambiance.Ambiance_Label ambiance_Label1;
        private Ambiance.Ambiance_Label ambiance_Label10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private Ambiance.Ambiance_Label lbl_Cost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox IG_link;
        private System.Windows.Forms.PictureBox Twitter_Link;
        private System.Windows.Forms.PictureBox FaceBook_Link;
        private System.Windows.Forms.Panel Footer_panel;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}