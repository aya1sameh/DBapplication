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
    {
        private Form MyParent;
        private Controller controllerObj;

        public AdminC(Form p)
        {
            InitializeComponent();
            controllerObj = new Controller();
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
        {  //textBox4.Text=="" || 
            if (textBox3.Text == "" || textBox2.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Please fill all the boxes");
            }
            else
            {
                //Query should update the Club info given the club ID in textBox1
                //refresh data grid to show the new updates
                int r = controllerObj.UpdateHomeClubInfo(Int32.Parse(textBox1.Text), textBox2.Text, Int32.Parse(textBox3.Text));
                int s = controllerObj.UpdateAwayClubInfo(Int32.Parse(textBox1.Text), textBox2.Text, Int32.Parse(textBox3.Text));
                if (r != 0 && s != 0)
                {
                    MessageBox.Show("club data updated successfully");
                    DataTable dt = controllerObj.SelectAllHomeClubs();
                    dataGridView1.DataSource = dt;
                    dataGridView1.Refresh();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) //datagrid shows club info
        {
            //Query should show all the Clubs info in datagrid
            //refresh data grid to show the data
            DataTable dt = controllerObj.SelectAllHomeClubs();
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)// Position
        {

        }

        private void button3_Click(object sender, EventArgs e)//insert new club button
        {   //textBox4.Text == "" || textBox3.Text == "" || 
            if (textBox2.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Please fill all the boxes");
            }
            else
            {
                //Query should insert a new Club 
                //refresh data grid to show the new updates
                int r = controllerObj.InsertHomeClub(Int32.Parse(textBox1.Text), textBox2.Text);
                int s = controllerObj.InsertAwayClub(Int32.Parse(textBox1.Text), textBox2.Text);
                if (r != 0 && s != 0) MessageBox.Show("Club inserted successfully");
                DataTable dt = controllerObj.SelectAllHomeClubs();
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();


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
                int result = controllerObj.DeleteHomeClub(Int32.Parse(textBox1.Text));
                int result2 = controllerObj.DeleteAwayClub(Int32.Parse(textBox1.Text));
                if (result == 0 || result2==0)
                {
                    MessageBox.Show("No rows are deleted");
                }
                else
                {
                    MessageBox.Show("The row is deleted successfully!");
                    DataTable dt = controllerObj.SelectAllHomeClubs();
                    dataGridView1.DataSource = dt;
                    dataGridView1.Refresh();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)//delete all clubs
        {
            int result = controllerObj.DeleteAllHomeClubs();
            int result2 = controllerObj.DeleteAllAwayClubs();
            if (result == 0 || result2==0 )
            {
                MessageBox.Show("No rows are deleted");
            }
            else
            {
                MessageBox.Show("All Clubs are deleted successfully!");
                DataTable dt = controllerObj.SelectAllHomeClubs();
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();

            }
        }

        private void button6_Click(object sender, EventArgs e)//update club points only
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter Club ID");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Please enter Club new points");
            }
            else
            {
                int result = controllerObj.UpdateHomeClubPoints(Int16.Parse(textBox1.Text), Int32.Parse(textBox3.Text));
                int result2 = controllerObj.UpdateAwayClubPoints(Int16.Parse(textBox1.Text), Int32.Parse(textBox3.Text));
                if (result == 0 || result2==0 )
                {
                    MessageBox.Show("Club is not updated");
                }
                else
                {
                    MessageBox.Show("Club is updated successfully!");
                    DataTable dt = controllerObj.SelectAllHomeClubs();
                    dataGridView1.DataSource = dt;
                    dataGridView1.Refresh();

                }
            }
        }
    }
}
