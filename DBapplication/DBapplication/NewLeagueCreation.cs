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

    public partial class NewLeagueCreation : Form
    {
        private int UserID;
        private Form MyParent;
        Controller controllerObj;
        public NewLeagueCreation(Form p,int id)
        {
            InitializeComponent();
            controllerObj = new Controller();
            UserID = id;
            MyParent = p;
            MyParent.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)//League id
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)//League name
        {

        }

        private void button1_Click(object sender, EventArgs e)//join an existing League
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter League ID");
            }
            else {
                int result = controllerObj.InsertUserInLeague(UserID, Int32.Parse(textBox1.Text));             //query insert UserID in the League which League id is in textBox1
                if (result == 0)
                {
                  MessageBox.Show("you can't enter this League");
                }
                else {
                  MessageBox.Show("you entered the League successfully");
                }

            }

        }

        private void button2_Click(object sender, EventArgs e)// create League
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Please fill all boxes");
            }
            else
            {
                int result = controllerObj.InsertNewLeague(UserID, Int32.Parse(textBox1.Text), textBox2.Text);                 //query create new League with ID in textBox1, name in textBox2 and Owner in UserID
                if (result == 0)
                {
                  MessageBox.Show("League can't be created");
                }
                else {
                  MessageBox.Show(" League is created successfully");
                }

            }
        }

        private void NewLeagueCreation_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            MyParent.Show();
        }
    }
}
