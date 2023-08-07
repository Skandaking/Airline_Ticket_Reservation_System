namespace Airline_Ticket_Reservation_System
{
    partial class Help_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Help_Form));
            this.Nav_Panel = new System.Windows.Forms.Panel();
            this.ambiance_HeaderLabel1 = new Ambiance.Ambiance_HeaderLabel();
            this.btn_CloseApp = new Bunifu.Framework.UI.BunifuImageButton();
            this.lbl_Header_Tittle = new Ambiance.Ambiance_HeaderLabel();
            this.txt_HelpText = new System.Windows.Forms.TextBox();
            this.Nav_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_CloseApp)).BeginInit();
            this.SuspendLayout();
            // 
            // Nav_Panel
            // 
            this.Nav_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(197)))), ((int)(((byte)(240)))));
            this.Nav_Panel.Controls.Add(this.ambiance_HeaderLabel1);
            this.Nav_Panel.Controls.Add(this.btn_CloseApp);
            this.Nav_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Nav_Panel.Location = new System.Drawing.Point(0, 0);
            this.Nav_Panel.Name = "Nav_Panel";
            this.Nav_Panel.Size = new System.Drawing.Size(873, 35);
            this.Nav_Panel.TabIndex = 65;
            // 
            // ambiance_HeaderLabel1
            // 
            this.ambiance_HeaderLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ambiance_HeaderLabel1.AutoSize = true;
            this.ambiance_HeaderLabel1.BackColor = System.Drawing.Color.Transparent;
            this.ambiance_HeaderLabel1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ambiance_HeaderLabel1.ForeColor = System.Drawing.Color.White;
            this.ambiance_HeaderLabel1.Location = new System.Drawing.Point(370, 3);
            this.ambiance_HeaderLabel1.Name = "ambiance_HeaderLabel1";
            this.ambiance_HeaderLabel1.Size = new System.Drawing.Size(130, 30);
            this.ambiance_HeaderLabel1.TabIndex = 63;
            this.ambiance_HeaderLabel1.Text = "Help/About";
            // 
            // btn_CloseApp
            // 
            this.btn_CloseApp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_CloseApp.BackColor = System.Drawing.Color.Transparent;
            this.btn_CloseApp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_CloseApp.Image = ((System.Drawing.Image)(resources.GetObject("btn_CloseApp.Image")));
            this.btn_CloseApp.ImageActive = null;
            this.btn_CloseApp.Location = new System.Drawing.Point(844, 1);
            this.btn_CloseApp.Name = "btn_CloseApp";
            this.btn_CloseApp.Size = new System.Drawing.Size(26, 28);
            this.btn_CloseApp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_CloseApp.TabIndex = 24;
            this.btn_CloseApp.TabStop = false;
            this.btn_CloseApp.Zoom = 10;
            this.btn_CloseApp.Click += new System.EventHandler(this.Btn_CloseApp_Click);
            // 
            // lbl_Header_Tittle
            // 
            this.lbl_Header_Tittle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Header_Tittle.AutoSize = true;
            this.lbl_Header_Tittle.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Header_Tittle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Header_Tittle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.lbl_Header_Tittle.Location = new System.Drawing.Point(3, 43);
            this.lbl_Header_Tittle.Name = "lbl_Header_Tittle";
            this.lbl_Header_Tittle.Size = new System.Drawing.Size(135, 30);
            this.lbl_Header_Tittle.TabIndex = 64;
            this.lbl_Header_Tittle.Text = "Header Here";
            // 
            // txt_HelpText
            // 
            this.txt_HelpText.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txt_HelpText.Enabled = false;
            this.txt_HelpText.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_HelpText.Location = new System.Drawing.Point(0, 87);
            this.txt_HelpText.Multiline = true;
            this.txt_HelpText.Name = "txt_HelpText";
            this.txt_HelpText.ReadOnly = true;
            this.txt_HelpText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_HelpText.Size = new System.Drawing.Size(873, 219);
            this.txt_HelpText.TabIndex = 63;
            // 
            // Help_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 306);
            this.Controls.Add(this.Nav_Panel);
            this.Controls.Add(this.lbl_Header_Tittle);
            this.Controls.Add(this.txt_HelpText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Help_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Help_Form";
            this.Load += new System.EventHandler(this.Help_Form_Load);
            this.Nav_Panel.ResumeLayout(false);
            this.Nav_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_CloseApp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Nav_Panel;
        private Ambiance.Ambiance_HeaderLabel ambiance_HeaderLabel1;
        private Bunifu.Framework.UI.BunifuImageButton btn_CloseApp;
        private Ambiance.Ambiance_HeaderLabel lbl_Header_Tittle;
        private System.Windows.Forms.TextBox txt_HelpText;
    }
}