using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DBapplication
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }
        private void Welcome_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e) //I need to register button
        {
            
        }

        private void button1_Click(object sender, EventArgs e) // Login as a user button
        {
            
        }

        private void button3_Click(object sender, EventArgs e)//Login as an Admin button
        {
            AdminLogin a = new AdminLogin(this);
            a.Show();
        }
    }
}
