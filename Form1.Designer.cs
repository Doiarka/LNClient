namespace LNClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listView1 = new System.Windows.Forms.ListView();
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.ThreadCountLabel = new System.Windows.Forms.Label();
            this.CountListviewLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ScanIpLabel = new System.Windows.Forms.Label();
            this.MainNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.listView1.Location = new System.Drawing.Point(0, 94);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(704, 275);
            this.listView1.TabIndex = 3;
            this.listView1.TileSize = new System.Drawing.Size(1, 20);
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // Timer1
            // 
            this.Timer1.Enabled = true;
            this.Timer1.Interval = 1000;
            this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Время";
            // 
            // ThreadCountLabel
            // 
            this.ThreadCountLabel.AutoSize = true;
            this.ThreadCountLabel.Location = new System.Drawing.Point(12, 53);
            this.ThreadCountLabel.Name = "ThreadCountLabel";
            this.ThreadCountLabel.Size = new System.Drawing.Size(44, 13);
            this.ThreadCountLabel.TabIndex = 7;
            this.ThreadCountLabel.Text = "Потоки";
            // 
            // CountListviewLabel
            // 
            this.CountListviewLabel.AutoSize = true;
            this.CountListviewLabel.Location = new System.Drawing.Point(12, 40);
            this.CountListviewLabel.Name = "CountListviewLabel";
            this.CountListviewLabel.Size = new System.Drawing.Size(57, 13);
            this.CountListviewLabel.TabIndex = 8;
            this.CountListviewLabel.Text = "Объектов";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ScanIpLabel);
            this.groupBox1.Controls.Add(this.CountListviewLabel);
            this.groupBox1.Controls.Add(this.ThreadCountLabel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(844, 94);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Информация";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "label2";
            // 
            // ScanIpLabel
            // 
            this.ScanIpLabel.AutoSize = true;
            this.ScanIpLabel.Location = new System.Drawing.Point(12, 27);
            this.ScanIpLabel.Name = "ScanIpLabel";
            this.ScanIpLabel.Size = new System.Drawing.Size(17, 13);
            this.ScanIpLabel.TabIndex = 9;
            this.ScanIpLabel.Text = "IP";
            // 
            // MainNotifyIcon
            // 
            this.MainNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("MainNotifyIcon.Icon")));
            this.MainNotifyIcon.Text = "MainNotifyIcon";
            this.MainNotifyIcon.Visible = true;
            this.MainNotifyIcon.Click += new System.EventHandler(this.MainNotifyIcon_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 369);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ELC";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Timer Timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ThreadCountLabel;
        private System.Windows.Forms.Label CountListviewLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label ScanIpLabel;
        private System.Windows.Forms.NotifyIcon MainNotifyIcon;
        public System.Windows.Forms.Label label2;
    }
}

