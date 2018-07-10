namespace LNClient
{
    partial class SelectLan
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
            this.label1 = new System.Windows.Forms.Label();
            this.LanListView = new System.Windows.Forms.ListView();
            this.AcceptLanButton = new System.Windows.Forms.Button();
            this.SecondLevelCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 33);
            this.label1.TabIndex = 12;
            this.label1.Text = "Обноружено несколько сетей. Какую использовать?";
            // 
            // LanListView
            // 
            this.LanListView.FullRowSelect = true;
            this.LanListView.Location = new System.Drawing.Point(15, 45);
            this.LanListView.Name = "LanListView";
            this.LanListView.Size = new System.Drawing.Size(132, 101);
            this.LanListView.TabIndex = 13;
            this.LanListView.UseCompatibleStateImageBehavior = false;
            this.LanListView.View = System.Windows.Forms.View.List;
            // 
            // AcceptLanButton
            // 
            this.AcceptLanButton.Location = new System.Drawing.Point(153, 68);
            this.AcceptLanButton.Name = "AcceptLanButton";
            this.AcceptLanButton.Size = new System.Drawing.Size(123, 23);
            this.AcceptLanButton.TabIndex = 14;
            this.AcceptLanButton.Text = "Подтвердить выбор";
            this.AcceptLanButton.UseVisualStyleBackColor = true;
            this.AcceptLanButton.Click += new System.EventHandler(this.AcceptLanButton_Click);
            // 
            // SecondLevelCheckBox
            // 
            this.SecondLevelCheckBox.AutoSize = true;
            this.SecondLevelCheckBox.Location = new System.Drawing.Point(153, 45);
            this.SecondLevelCheckBox.Name = "SecondLevelCheckBox";
            this.SecondLevelCheckBox.Size = new System.Drawing.Size(106, 17);
            this.SecondLevelCheckBox.TabIndex = 15;
            this.SecondLevelCheckBox.Text = "Второй уровень";
            this.SecondLevelCheckBox.UseVisualStyleBackColor = true;
            // 
            // SelectLan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 160);
            this.Controls.Add(this.SecondLevelCheckBox);
            this.Controls.Add(this.AcceptLanButton);
            this.Controls.Add(this.LanListView);
            this.Controls.Add(this.label1);
            this.Name = "SelectLan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выбор сети";
            this.Load += new System.EventHandler(this.SelectLan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView LanListView;
        private System.Windows.Forms.Button AcceptLanButton;
        public System.Windows.Forms.CheckBox SecondLevelCheckBox;
    }
}