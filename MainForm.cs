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
    public partial class MainForm : Form
    {
        public static int testcount;

        public MainForm()
        {
            Location = new Point(100, 100);
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < testcount; i++)
            {
                UsersListView.Items.Add(i.ToString());
            }
        }
    }
}
