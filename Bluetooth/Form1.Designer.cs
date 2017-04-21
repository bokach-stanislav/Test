namespace Bluetooth
{
    partial class Form1
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
            this.labelStatus = new System.Windows.Forms.Label();
            this.cbDevices = new System.Windows.Forms.ComboBox();
            this.labelDevices = new System.Windows.Forms.Label();
            this.bRefresh = new System.Windows.Forms.Button();
            this.devicesLoader = new System.ComponentModel.BackgroundWorker();
            this.inRangeTester = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labelLogin = new System.Windows.Forms.Label();
            this.tbEncrypted = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(12, 9);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(75, 13);
            this.labelStatus.TabIndex = 0;
            this.labelStatus.Text = "Device status:";
            // 
            // cbDevices
            // 
            this.cbDevices.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDevices.FormattingEnabled = true;
            this.cbDevices.Location = new System.Drawing.Point(15, 71);
            this.cbDevices.Name = "cbDevices";
            this.cbDevices.Size = new System.Drawing.Size(273, 21);
            this.cbDevices.TabIndex = 1;
            this.cbDevices.SelectedIndexChanged += new System.EventHandler(this.cbDevices_SelectedIndexChanged);
            // 
            // labelDevices
            // 
            this.labelDevices.AutoSize = true;
            this.labelDevices.Location = new System.Drawing.Point(12, 55);
            this.labelDevices.Name = "labelDevices";
            this.labelDevices.Size = new System.Drawing.Size(49, 13);
            this.labelDevices.TabIndex = 2;
            this.labelDevices.Text = "Devices:";
            // 
            // bRefresh
            // 
            this.bRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bRefresh.Location = new System.Drawing.Point(294, 71);
            this.bRefresh.Name = "bRefresh";
            this.bRefresh.Size = new System.Drawing.Size(75, 23);
            this.bRefresh.TabIndex = 3;
            this.bRefresh.Text = "Refresh";
            this.bRefresh.UseVisualStyleBackColor = true;
            this.bRefresh.Click += new System.EventHandler(this.bRefresh_Click);
            // 
            // devicesLoader
            // 
            this.devicesLoader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.devicesLoader_DoWork);
            this.devicesLoader.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.devicesLoader_RunWorkerCompleted);
            // 
            // inRangeTester
            // 
            this.inRangeTester.DoWork += new System.ComponentModel.DoWorkEventHandler(this.inRangeTester_DoWork);
            this.inRangeTester.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.inRangeTester_RunWorkerCompleted);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Location = new System.Drawing.Point(12, 119);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(80, 13);
            this.labelLogin.TabIndex = 4;
            this.labelLogin.Text = "Logged in as ...";
            // 
            // tbEncrypted
            // 
            this.tbEncrypted.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbEncrypted.Location = new System.Drawing.Point(15, 135);
            this.tbEncrypted.Multiline = true;
            this.tbEncrypted.Name = "tbEncrypted";
            this.tbEncrypted.ReadOnly = true;
            this.tbEncrypted.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbEncrypted.Size = new System.Drawing.Size(354, 76);
            this.tbEncrypted.TabIndex = 5;
            this.tbEncrypted.Text = "as\r\ndf";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 223);
            this.Controls.Add(this.tbEncrypted);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.bRefresh);
            this.Controls.Add(this.labelDevices);
            this.Controls.Add(this.cbDevices);
            this.Controls.Add(this.labelStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Test for www.serious-soft.com";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.ComboBox cbDevices;
        private System.Windows.Forms.Label labelDevices;
        private System.Windows.Forms.Button bRefresh;
        private System.ComponentModel.BackgroundWorker devicesLoader;
        private System.ComponentModel.BackgroundWorker inRangeTester;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.TextBox tbEncrypted;
    }
}

