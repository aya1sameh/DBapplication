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
    public partial class UserLogin : Form
    {
        Form MyParent;
        public UserLogin(Form p)
        {
            InitializeComponent();
            MyParent = p;
            MyParent.Hide();
        }

        private void UserLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            MyParent.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)//user ID
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)//First name
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)//Last Name
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)//Password
        {

        }

        private void button1_Click(object sender, EventArgs e)//Login button
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Please fill all the boxes");
            }
            else
            {
                //bool Exists= //query that check if this user exists given its data in textBox1, textBox2, textBox3, textBox4 AND RETURNS BOOL TRUE IF USER EXISTS
                bool Exists = true;//temp.....to be removed
                if (Exists == true)
                {
                    UserHome a = new UserHome(this,textBox1.Text);
                    a.Show();
                }
                else {
                    MessageBox.Show("No such a user please make sure of your inputs or sign up");
                }
            }
        }
    }
}
