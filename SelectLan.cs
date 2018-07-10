using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LNClient
{
    public partial class SelectLan : Form
    {
        public List<string> lanlist = new List<string>();

        public SelectLan()
        {
            //this.ShowInTaskbar = true;
            InitializeComponent();
        }

        private void SelectLan_Load(object sender, EventArgs e)
        {
            lanlist = Form1.MyIPs;
            foreach (var item in lanlist)
            {
                LanListView.Items.Add(item.ToString());
            }
        }

        private void AcceptLanButton_Click(object sender, EventArgs e)
        {
            if (LanListView.SelectedItems.Count != 0)
            {
                Form1.selectedmyip = LanListView.SelectedItems[0].Text;
                if (SecondLevelCheckBox.Checked == true)
                {
                    Form1.secondLevel = true;
                }
                Form1.BeginScan();
                this.Close();
            }
        }
    }
}
