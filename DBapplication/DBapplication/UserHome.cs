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
        private int UserID;
        private Form MyParent;
        Controller controllerObj;
        public UserHome(Form p,int id)
        {
            InitializeComponent();
            controllerObj = new Controller();
            MyParent = p;
            UserID = id;
            MyParent.Hide();
            textBox1.Text = UserID.ToString();
           controllerObj = new Controller();
            
            int rank=0, bank=0, points=0, maxpoints=0, avgpoints=0;

            DataTable dt=controllerObj.GetUserInfo(UserID,ref rank,ref bank, ref points,ref maxpoints,ref avgpoints);

            //DataRow Row= dt.Rows[0];
            
            string team_name = dt.Rows[0].Field<string>(0);          // Row.Cells[0].Value.ToString();  //Row.ToString();
            textBox2.Text =Convert.ToString(rank);         //Query get user rank given id in UserID
            textBox3.Text =Convert.ToString(bank);          //Query get bank rank given id in UserID
            textBox4.Text =Convert.ToString(avgpoints);          //Query get Avg score of all users
            textBox5.Text =Convert.ToString(points);              //Query get user score given id in UserID
            textBox6.Text = Convert.ToString(maxpoints);        //Query get Max score of all users
            textBox7.Text = team_name;                          //Query get user Team Name given id in UserID
        }

        private void UserHome_Load(object sender, EventArgs e)
        {
            
            DataTable dt = controllerObj.SelectAllUserTeam(UserID);
            dataGridView2.DataSource = dt;
            dataGridView2.Refresh();
            DataTable dt2 = controllerObj.SelectAllUserLeagues(UserID);
            dataGridView1.DataSource = dt2;
            dataGridView1.Refresh();
            DataTable dt3 = controllerObj.SelectAllUserChips(UserID);
            dataGridView5.DataSource = dt3;
            dataGridView5.Refresh();
            DataTable dt4 = controllerObj.SelectAllFixtures();
            dataGridView3.DataSource = dt4;
            dataGridView3.Refresh();
            DataTable dt5 = controllerObj.SelectAllHomeClubs();
            dataGridView4.DataSource = dt5;
            dataGridView4.Refresh();


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
            DataTable dt = controllerObj.SelectAllUserLeagues(UserID);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)//User Team
        {
            //query return user team in  dataGridView2
            //refresh datagrid to show the data
            DataTable dt = controllerObj.SelectAllUserTeam(UserID);
            dataGridView2.DataSource = dt;
            dataGridView2.Refresh();
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)//User chips
        {
            //query return user chips in  dataGridView5
            //refresh datagrid to show the data
            DataTable dt = controllerObj.SelectAllUserTeam(UserID);
            dataGridView2.DataSource = dt;
            dataGridView2.Refresh();
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
            PickATeam a = new PickATeam(this, UserID, Int32.Parse(textBox3.Text), Int32.Parse(textBox5.Text));
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
                //query update User Team name given UserID
                int result = controllerObj.UpdateUserTeamName(UserID, textBox7.Text);
                if (result == 0)
                {
                  MessageBox.Show("name is not updated");
                }
                else {
                  MessageBox.Show("Team name is updated successfully");
                }

            }
        }

        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataTable dt = controllerObj.SelectAllUserTeam(UserID);
            dataGridView2.DataSource = dt;
            dataGridView2.Refresh();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            DataTable dt = controllerObj.SelectAllUserLeagues(UserID);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            DataTable dt = controllerObj.SelectAllUserTeam(UserID);
            dataGridView2.DataSource = dt;
            dataGridView2.Refresh();

        }

        private void dataGridView5_DoubleClick(object sender, EventArgs e)
        {
            DataTable dt5 = controllerObj.SelectAllHomeClubs();
            dataGridView4.DataSource = dt5;
            dataGridView4.Refresh();
        }
    }
}
