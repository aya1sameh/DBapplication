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
    public partial class UserHome : Form
    {
        string UserID;
        Form MyParent;
        public UserHome(Form p,string id)
        {
            InitializeComponent();
            MyParent = p;
            UserID = id;
            MyParent.Hide();
        }

        private void UserHome_Load(object sender, EventArgs e)
        {

        }

        private void UserHome_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            MyParent.Show();
        }
    }
}
