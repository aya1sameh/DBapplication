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
        int UserID;
        Form MyParent;
        public UserHome(Form p,int id)
        {
            InitializeComponent();
            MyParent = p;
            UserID = id;
            MyParent.Hide();
            textBox1.Text = UserID.ToString();
            //textBox2.Text=//Query get user rank given id in UserID
            //textBox3.Text =//Query get bank rank given id in UserID
            //textBox4.Text =//Query get Avg score of all users
            //textBox5.Text =//Query get user score given id in UserID
            //textBox6.Text =//Query get Max score of all users
            //textBox7.Text =//Query get user Team Name given id in UserID
        }

        private void UserHome_Load(object sender, EventArgs e)
        {

        }

        private void UserHome_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            MyParent.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)//id
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e) //rank
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)//bank
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) //User Leagues
        {
            //query return all user leagues in  dataGridView1
            //refresh datagrid to show the data
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)//User Team
        {
            //query return user team in  dataGridView2
            //refresh datagrid to show the data
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)//User chips
        {
            //query return user chips in  dataGridView5
            //refresh datagrid to show the data
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)//All fixtures
        {
            //query return All fixtures in  dataGridView3
            //refresh datagrid to show the data
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)//All clubs
        {
            //query return All clubs in  dataGridView4
            //refresh datagrid to show the data
        }

        private void textBox4_TextChanged(object sender, EventArgs e)//avg score
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)//user score
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)//max score
        {

        }

        private void button1_Click(object sender, EventArgs e)//create new league
        {
            //new form of leagues
            NewLeagueCreation a = new NewLeagueCreation(this, UserID);
            a.Show();
        }

        private void button2_Click(object sender, EventArgs e)//update team
        {
            //new form of players update
            PickATeam a = new PickATeam(this, UserID, Int32.Parse(textBox3.Text));
            a.Show();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)//Team Name
        {

        }

        private void button3_Click(object sender, EventArgs e)//Update Team Name
        {
            if (textBox7.Text == "")
            {
                MessageBox.Show("Please enter Team Name");
            }
            else
            {
                //int result=//query update User Team name given UserID
                //if (result == 0)
                //{
                //  MessageBox.Show("name is not updated");
                //}
                //else {
                //  MessageBox.Show("Team name is updated successfully");
                //}

            }
        }
    }
}
