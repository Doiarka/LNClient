namespace LNClient
{
    partial class MainForm
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
            this.UsersListView = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // UsersListView
            // 
            this.UsersListView.FullRowSelect = true;
            this.UsersListView.Location = new System.Drawing.Point(12, 61);
            this.UsersListView.Name = "UsersListView";
            this.UsersListView.Size = new System.Drawing.Size(160, 430);
            this.UsersListView.TabIndex = 14;
            this.UsersListView.UseCompatibleStateImageBehavior = false;
            this.UsersListView.View = System.Windows.Forms.View.List;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 561);
            this.Controls.Add(this.UsersListView);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView UsersListView;
    }
}