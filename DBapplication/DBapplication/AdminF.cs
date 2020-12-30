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
    public partial class AdminF : Form
    {
        Form MyParent;
        public AdminF(Form p)
        {
            InitializeComponent();
            MyParent = p;
            MyParent.Hide();
        }

        private void AdminF_Load(object sender, EventArgs e)
        {

        }

        private void AdminF_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            MyParent.Show();
        }

        private void button1_Click(object sender, EventArgs e)// sign up new admin
        {
            AdminSignUp a = new AdminSignUp(this);
            a.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) //match ID
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)//Time
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)//Date
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)//Home club ID
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)//Away club ID
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)//Home club score
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)//Away club score
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)//Fixtures Info
        {
            //Query should show all the Fixtures info in datagrid
            //refresh data grid to show the data
        }

        private void button2_Click(object sender, EventArgs e)//update fixture info by id button
        {
            if (textBox7.Text == "" || textBox6.Text == "" || textBox5.Text == "" || textBox4.Text == "" || textBox3.Text == "" || textBox2.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Please fill all the boxes");
            }
            else
            {
                //Query should update the Fixture info given the match ID in textBox1
                //refresh data grid to show the new updates
            }
        }
    }
}
