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
        Controller controllerObj;
        private int UserID;
        private Form MyParent;
        private int UserBank;
        private int UserPoints;
        private int playerID;
        private int playerPrice;
        private int playerPoints;
        private int wildcardUsed;
        private int tripleplayerUsed;
        char position;
        private bool wildcard_activated;
        public PickATeam(Form p, int id,int bank, int points)
        {
            InitializeComponent();
            controllerObj = new Controller();
            MyParent = p;
            UserID = id;
            UserPoints = points;
            UserBank = bank;
            MyParent.Hide();
            textBox1.Text = UserBank.ToString();
            wildcard_activated = false;
            DataTable dt = controllerObj.SelectUsersUsedWildcard(UserID);               //query returns 0 or 1 from the used attribute with name=wildcard given UserID
            wildcardUsed = dt.Rows[0].Field<int>(0);
            dt = controllerObj.SelectUsersUsedTriplecaptain(UserID);      //query returns 0 or 1 from the used attribute with name=triplecaptain given UserID
            tripleplayerUsed = dt.Rows[0].Field<int>(0);
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
                position=Char.Parse(Row.Cells[3].Value.ToString());
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
                DataTable dt1 = controllerObj.SelectAllUserUnpickedTeam(UserID);
                DataTable dt2= controllerObj.SelectAllUserPickedTeam(UserID);
                switch (position)
                {
                    case 'G':
                        dt1 = controllerObj.SelectAllUserUnpickedGK(UserID);
                        dt2 = controllerObj.SelectAllUserPickedGK(UserID);
                        break;
                    case 'D':
                        dt1 = controllerObj.SelectAllUserUnpickedDef(UserID);
                        dt2 = controllerObj.SelectAllUserPickedDef(UserID);
                        break;
                    case 'M':
                        dt1 = controllerObj.SelectAllUserUnpickedMid(UserID);
                        dt2 = controllerObj.SelectAllUserPickedMid(UserID);
                        break;
                    case 'F':
                        dt1 = controllerObj.SelectAllUserUnpickedFwd(UserID);
                        dt2 = controllerObj.SelectAllUserPickedFwd(UserID);
                        break;

                }
                textBox1.Text = UserBank.ToString();
                dataGridView1.DataSource = dt1;
                dataGridView1.Refresh();
                dataGridView2.DataSource = dt2;
                dataGridView2.Refresh();
            }

            
        }

        private void button2_Click(object sender, EventArgs e)// Add selected player
        {
           
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
            if (wildcard_activated)
            {
                if ((UserBank - (playerPrice / 2) ) < 0)
                {
                    MessageBox.Show("Funds not avilable to complete your transfer !");
                    return;
                }
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
                int result = controllerObj.UpdateUsedWildcard(UserID);
                if (result == 0)
                {
                    MessageBox.Show("Failed to Update user's used wild card");
                }
                else
                {
                    MessageBox.Show("user's used wild card updated succesfully");
                }
                //query update attribute used for wildcard to be = 1 given UserID
            }
            else {
                if ((UserBank - playerPrice) < 0)
                {
                    MessageBox.Show("Funds not avilable to complete your transfer !");
                    return;
                }
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
            if (dataGridView2.SelectedRows.Count == 1)
            {
                DataGridViewRow Row = this.dataGridView2.SelectedRows[0];
                playerPoints = Int32.Parse(Row.Cells[0].Value.ToString());

                int result1 = controllerObj.UpdateUserScore(UserID, UserPoints+(2*playerPoints));
                if (result1 == 0)
                    MessageBox.Show("Failed to update user's score");
                else
                {
                    UserPoints = UserPoints + (2 * playerPoints);
                    MessageBox.Show("User Score Updated successfully !");

                }
                result1 = controllerObj.UpdateUsedTriplecaptain(UserID);
                if (result1 == 0)
                    MessageBox.Show("Failed to update user's used triple triple");
                else
                {
                    MessageBox.Show("user's used triple triple Updated successfully !");

                }


            }

            else
                MessageBox.Show("select a player to be triple captained !");



        }

        private void button3_Click(object sender, EventArgs e)//show goal keepers
        {

            //show all picked goal keepers in datagrid2
            //show all unpicked goal keepers in datagrid
            //refresh both datagrids
            DataTable dt = controllerObj.SelectAllUserUnpickedGK(UserID);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            DataTable dt2 = controllerObj.SelectAllUserPickedGK(UserID);
            dataGridView2.DataSource = dt2;
            dataGridView2.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)//show defenders
        {
            //show all picked defenders in datagrid2
            //show all unpicked defenders in datagrid
            //refresh both datagrids
            DataTable dt = controllerObj.SelectAllUserUnpickedDef(UserID);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            DataTable dt2 = controllerObj.SelectAllUserPickedDef(UserID);
            dataGridView2.DataSource = dt2;
            dataGridView2.Refresh();
        }

        private void button5_Click(object sender, EventArgs e)//show midfielders
        {
            //show all picked midfielders in datagrid2
            //show all unpicked midfielders in datagrid
            //refresh both datagrids
            DataTable dt = controllerObj.SelectAllUserUnpickedMid(UserID);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            DataTable dt2 = controllerObj.SelectAllUserPickedMid(UserID);
            dataGridView2.DataSource = dt2;
            dataGridView2.Refresh();
        }

        private void button6_Click(object sender, EventArgs e)//show forward
        {
            //show all picked forward in datagrid2
            //show all unpicked forward in datagrid
            //refresh both datagrids
            DataTable dt = controllerObj.SelectAllUserUnpickedFwd(UserID);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            DataTable dt2 = controllerObj.SelectAllUserPickedFwd(UserID);
            dataGridView2.DataSource = dt2;
            dataGridView2.Refresh();
        }


        private void button8_Click(object sender, EventArgs e)//use wild card
        {
            wildcard_activated = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
