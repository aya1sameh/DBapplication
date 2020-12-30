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
    public partial class AdminC : Form
    { Form MyParent;
        public AdminC(Form p)
        {
            InitializeComponent();
            MyParent = p;
            MyParent.Hide();
        }

        private void AdminC_Load(object sender, EventArgs e)
        {

        }

        private void AdminC_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            MyParent.Show();
        }

        private void button1_Click(object sender, EventArgs e)//sign up new admin
        {
            AdminSignUp a = new AdminSignUp(this);
            a.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)//club id
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)//club name
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)// new points
        {

        }

        private void button2_Click(object sender, EventArgs e)// update club info by id
        {
            if (textBox4.Text=="" || textBox3.Text == "" || textBox2.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Please fill all the boxes");
            }
            else
            {
                //Query should update the Club info given the club ID in textBox1
                //refresh data grid to show the new updates
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) //datagrid shows club info
        {
            //Query should show all the Clubs info in datagrid
            //refresh data grid to show the data
        }

        private void textBox4_TextChanged(object sender, EventArgs e)// Position
        {

        }

        private void button3_Click(object sender, EventArgs e)//insert new club button
        {
            if (textBox4.Text == "" || textBox3.Text == "" || textBox2.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Please fill all the boxes");
            }
            else
            {
                //Query should insert a new Club 
                //refresh data grid to show the new updates
            }
        }

        private void button4_Click(object sender, EventArgs e)//delete a club button
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter Club ID");
            }
            else
            {
                //Query should delete the Club given the club ID in textBox1
                //refresh data grid to show the new updates
            }
        }
    }
}
