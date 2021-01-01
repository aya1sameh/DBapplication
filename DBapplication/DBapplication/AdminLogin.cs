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
    public partial class AdminLogin : Form
    {
        Form MyParent;
        public AdminLogin(Form p)
        {
            InitializeComponent();
            MyParent = p;
            MyParent.Hide();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter a valid ID");
            }
            else {
                /// String Role=query check if id exists and return his Role
                String Role = "C";///temp for testing
                if (Role == "P")
                {
                    AdminP a = new AdminP(this);
                    a.Show();
                }
                else if (Role == "F")
                {
                    AdminF a = new AdminF(this);
                    a.Show();
                }
                else if (Role == "C")
                {
                    AdminC a = new AdminC(this);
                    a.Show();
                }
                else
                {
                    MessageBox.Show("The entered ID Doesn't have a Role");
                }
            }
           
           
        }

        private void AdminLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            MyParent.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) ///Admin ID
        {

        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
