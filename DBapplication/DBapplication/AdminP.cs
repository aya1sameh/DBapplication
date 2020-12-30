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
    public partial class AdminP : Form
    {
        Form MyParent;
        public AdminP(Form p)
        {
            InitializeComponent();
            MyParent = p;
            MyParent.Hide();
        }

        private void AdminP_Load(object sender, EventArgs e)
        {

        }

        private void AdminP_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            MyParent.Show();
        }

        private void button1_Click(object sender, EventArgs e) //Sign up new Admin button
        {
            AdminSignUp a = new AdminSignUp(this);
            a.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)//Player ID
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)//Player first name
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)//Player Last name
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)//Match ID
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)//Player Points
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)//New assists
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)// New goals
        {

        }

        private void button2_Click(object sender, EventArgs e)//Update certain player info given his id
        {
            if (textBox7.Text=="" || textBox6.Text == "" || textBox5.Text == "" || textBox4.Text == "" || textBox3.Text == "" || textBox2.Text == "" || textBox1.Text == "") {
                MessageBox.Show("Please fill all the boxes");
            }
            else {
                //Query should update the player info given the player ID in textBox1
                //refresh data grid to show the new updates
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) // data grid to show All players Info
        {
            //Query should show all the players info in datagrid
            //refresh data grid to show the data
        }
    }
}
