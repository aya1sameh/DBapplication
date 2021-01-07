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
    public partial class PickATeam : Form
    {
        private int UserID;
        private Form MyParent;
        private int UserBank;
        private int playerID;
        private int playerPrice;
        Controller controllerObj;
        private int wildcardUsed;
        private int tripleplayerUsed;
        public PickATeam(Form p, int id,int bank)
        {
            InitializeComponent();
            controllerObj = new Controller();
            MyParent = p;
            UserID = id;
            UserBank = bank;
            MyParent.Hide();
            textBox1.Text = UserBank.ToString();
            //wildcardUsed=//query returns 0 or 1 from the used attribute with name=wildcard given UserID
            //tripleplayerUsed=//query returns 0 or 1 from the used attribute with name=triplecaptain given UserID
            if (wildcardUsed==1) {
                this.button8.Enabled = false;
            }
            if (tripleplayerUsed==1)
            {
                this.button9.Enabled = false;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*//query get all un picked players : PlayersTable-UserTeamTable and show in dataGridView1
            //refresh datagrid to show data
            
            DataTable dt = controllerObj.SelectAllUserUnpickedTeam(UserID);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();*/
        }

        private void PickATeam_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            MyParent.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*//query shows the user Team Players in dataGridView2
            //refresh datagrid to show data
            DataTable dt2 = controllerObj.SelectAllUserPickedTeam(UserID);
            dataGridView2.DataSource = dt2;
            dataGridView2.Refresh();*/
            

        }

        private void button1_Click(object sender, EventArgs e)//Remove selected player
        {
            //int playerID=//get from row selected player id in column1;
            //int playerPrice=//get from row selected player price ;
            //query deletes the player given its id in playerID and his owner id in UserID
            //query updates User Bank (Bank+=playerPrice) given UserID
            //UserBank=query get UserBank given UserID;
            if (dataGridView2.SelectedRows.Count == 1)
            {
                DataGridViewRow Row = this.dataGridView2.SelectedRows[0];
                playerID = Int32.Parse(Row.Cells[0].Value.ToString());
                playerPrice = Int32.Parse(Row.Cells[4].Value.ToString());
            }
            else
            {
                MessageBox.Show("Please select only one player to remove");
                return;
            }
            
            int result1 = controllerObj.RemovePlayer(playerID, UserID);
            int result2 = controllerObj.UpdateBank(UserID, UserBank + playerPrice, ref UserBank);
            if (result1 == 0)
                MessageBox.Show("Failed to Remove Player");
            else if (result2 == 0)
                MessageBox.Show("Failed to Update Bank");
            else
            {
                MessageBox.Show("Player Added & Bank Updated successfully !");
                textBox1.Text = UserBank.ToString();
                DataTable dt1 = controllerObj.SelectAllUserUnpickedTeam(UserID);
                dataGridView1.DataSource = dt1;
                dataGridView1.Refresh();
                DataTable dt2 = controllerObj.SelectAllUserPickedTeam(UserID);
                dataGridView2.DataSource = dt2;
                dataGridView2.Refresh();
            }

            
        }

        private void button2_Click(object sender, EventArgs e)// Add selected player
        {
            //int playerID=//get from row selected player id in column1;
            //int playerPrice=//get from row selected player price ;
            //string PlayerPosition=//get from row selected player position;
            //query insert the player given its id in playerID and his owner id in UserID ///check if count(PlayerPosition) of the userPlayersPicked excceed the limited value AND Max limited number of players
            //query updates User Bank (Bank-=playerPrice) given UserID
            //UserBank=query get UserBank given UserID;
            if (dataGridView1.SelectedRows.Count == 1)
            {
                DataGridViewRow Row = this.dataGridView1.SelectedRows[0];
                playerID = Int32.Parse(Row.Cells[0].Value.ToString());
                playerPrice = Int32.Parse(Row.Cells[4].Value.ToString());
            }
            else
            {
                MessageBox.Show("Please select only one player to Add");
                return;
            }
            if (wildcardUsed == 2)
            {
                int result1 = controllerObj.AddPlayer(playerID, UserID);
                int result2 = controllerObj.UpdateBank(UserID, UserBank - (playerPrice/2), ref UserBank);
                if (result1 == 0)
                    MessageBox.Show("Failed to Add Player");
                else if (result2 == 0)
                    MessageBox.Show("Failed to Update Bank");
                else
                {
                    MessageBox.Show("Player Added & Bank Updated successfully !");
                    textBox1.Text = UserBank.ToString();
                    DataTable dt1 = controllerObj.SelectAllUserUnpickedTeam(UserID);
                    dataGridView1.DataSource = dt1;
                    dataGridView1.Refresh();
                    DataTable dt2 = controllerObj.SelectAllUserPickedTeam(UserID);
                    dataGridView2.DataSource = dt2;
                    dataGridView2.Refresh();
                }
                //query update attribute used for wildcard to be = 1 given UserID
            }
            else {
                int result1 = controllerObj.AddPlayer(playerID, UserID);
                int result2 = controllerObj.UpdateBank(UserID, UserBank - playerPrice, ref UserBank);
                if (result1 == 0)
                    MessageBox.Show("Failed to Add Player");
                else if (result2 == 0)
                    MessageBox.Show("Failed to Update Bank");
                else
                {
                    MessageBox.Show("Player Added & Bank Updated successfully !");
                    textBox1.Text = UserBank.ToString();
                    DataTable dt1 = controllerObj.SelectAllUserUnpickedTeam(UserID);
                    dataGridView1.DataSource = dt1;
                    dataGridView1.Refresh();
                    DataTable dt2 = controllerObj.SelectAllUserPickedTeam(UserID);
                    dataGridView2.DataSource = dt2;
                    dataGridView2.Refresh();
                }
            }
            
        }

        private void PickATeam_Load(object sender, EventArgs e)
        {
            DataTable dt = controllerObj.SelectAllUserUnpickedTeam(UserID);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            DataTable dt2 = controllerObj.SelectAllUserPickedTeam(UserID);
            dataGridView2.DataSource = dt2;
            dataGridView2.Refresh();

        }

        private void button9_Click(object sender, EventArgs e)//use triple player
        {
            //int PlayerScore=//get row selected to get player score 
            //query that updates the user score by + 3*PlayerScore given UserID
            //query update attribute used for triple player to be = 1 given UserID
        }

        private void button3_Click(object sender, EventArgs e)//show goal keepers
        {
            //show all picked goal keepers in datagrid2
            //show all unpicked goal keepers in datagrid
            //refresh both datagrids
        }

        private void button4_Click(object sender, EventArgs e)//show defenders
        {
            //show all picked defenders in datagrid2
            //show all unpicked defenders in datagrid
            //refresh both datagrids
        }

        private void button5_Click(object sender, EventArgs e)//show midfielders
        {
            //show all picked midfielders in datagrid2
            //show all unpicked midfielders in datagrid
            //refresh both datagrids
        }

        private void button6_Click(object sender, EventArgs e)//show forward
        {
            //show all picked forward in datagrid2
            //show all unpicked forward in datagrid
            //refresh both datagrids
        }


        private void button8_Click(object sender, EventArgs e)//use wild card
        {
            wildcardUsed = 2;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
