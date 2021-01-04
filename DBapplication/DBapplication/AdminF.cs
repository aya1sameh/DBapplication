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
        Controller controllerObj;
        public AdminF(Form p)
        {
            InitializeComponent();
            controllerObj = new Controller();
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
            DataTable dt = controllerObj.SelectAllFixtures();
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
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
                int r = controllerObj.UpdateFixture(Int32.Parse(textBox1.Text), textBox2.Text, textBox3.Text, Int32.Parse(textBox4.Text), Int32.Parse(textBox5.Text), Int32.Parse(textBox6.Text), Int32.Parse(textBox7.Text));
                if (r != 0)
                {
                    MessageBox.Show("fixture data updated successfully");
                    DataTable dt = controllerObj.SelectAllFixtures();
                    dataGridView1.DataSource = dt;
                    dataGridView1.Refresh();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)// insert new Fixture
        {  //textBox7.Text == "" || textBox6.Text == "" || 
            if (textBox5.Text == "" || textBox4.Text == "" || textBox3.Text == "" || textBox2.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Please fill all the boxes");
            }
            else
            {
                //Query should insert a new Fixture  
                //refresh data grid to show the new updates
                int r = controllerObj.InsertFixture(Int32.Parse(textBox1.Text), textBox2.Text, textBox3.Text, Int32.Parse(textBox4.Text), Int32.Parse(textBox5.Text));
                if (r != 0) MessageBox.Show("fixture inserted successfully");
                DataTable dt = controllerObj.SelectAllFixtures();
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();
            }
        }

        private void button4_Click(object sender, EventArgs e)//delete button
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter fixture ID");
            }
            else
            {
                //Query should delete a Fixture given its id in textbox1 
                //refresh data grid to show the new updates
                int result = controllerObj.DeleteFixture(Int32.Parse(textBox1.Text));
                if (result == 0)
                {
                    MessageBox.Show("No rows are deleted");
                }
                else
                {
                    MessageBox.Show("The row is deleted successfully!");
                    DataTable dt = controllerObj.SelectAllFixtures();
                    dataGridView1.DataSource = dt;
                    dataGridView1.Refresh();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)//delete all fixtures
        {
            int result = controllerObj.DeleteAllFixtures();
            if (result == 0)
            {
                MessageBox.Show("No rows are deleted");
            }
            else
            {
                MessageBox.Show("All fixtures are deleted successfully!");
                DataTable dt = controllerObj.SelectAllFixtures();
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();
            }
        }

        private void button6_Click(object sender, EventArgs e)//update fixture score
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter fixture ID");
            }
            else if (textBox6.Text == "" || textBox7.Text == "")
            {
                MessageBox.Show("Please enter both clubs scores");
            }
            else
            {
                //Query should delete a Fixture given its id in textbox1 
                //refresh data grid to show the new updates
                int result = controllerObj.UpdateFixtureScore(Int32.Parse(textBox1.Text), Int32.Parse(textBox6.Text), Int32.Parse(textBox7.Text));
                if (result == 0)
                {
                    MessageBox.Show("Fixture is not updated");
                }
                else
                {
                    MessageBox.Show("Fixture score is updated successfully!");
                    DataTable dt = controllerObj.SelectAllFixtures();
                    dataGridView1.DataSource = dt;
                    dataGridView1.Refresh();
                }
            }
        }
    }
}
