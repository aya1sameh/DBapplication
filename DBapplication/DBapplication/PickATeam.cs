﻿using System;
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
        Controller controllerObj;
        public PickATeam(Form p, int id,int bank)
        {
            InitializeComponent();
            controllerObj = new Controller();
            MyParent = p;
            UserID = id;
            UserBank = bank;
            MyParent.Hide();
            textBox1.Text = UserBank.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //query get all un picked players : PlayersTable-UserTeamTable and show in dataGridView1
            //refresh datagrid to show data
            
            DataTable dt = controllerObj.SelectAllUserUnpickedTeam(UserID);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
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
            //query shows the user Team Players in dataGridView2
            //refresh datagrid to show data
            //DataTable dt2 = controllerObj.SelectAllUserPickedTeam(UserID);
            //dataGridView2.DataSource = dt2;
            //dataGridView2.Refresh();
            int rowindex = e.RowIndex;
            DataGridViewRow Row = dataGridView1.Rows[rowindex];
            int playerID = Int32.Parse(Row.Cells[0].ToString());
            int playerPrice= Int32.Parse(Row.Cells[4].ToString());

        }

        private void button1_Click(object sender, EventArgs e)//Remove selected player
        {
            //int playerID=//get from row selected player id in column1;
            //int playerPrice=//get from row selected player price ;
            //query deletes the player given its id in playerID and his owner id in UserID
            //query updates User Bank (Bank+=playerPrice) given UserID
            //UserBank=query get UserBank given UserID;
            textBox1.Text = UserBank.ToString();
        }

        private void button2_Click(object sender, EventArgs e)// Add selected player
        {
            //int playerID=//get from row selected player id in column1;
            //int playerPrice=//get from row selected player price ;
            //string PlayerPosition=//get from row selected player position;
            //query insert the player given its id in playerID and his owner id in UserID ///check if count(PlayerPosition) of the userPlayersPicked excceed the limited value AND Max limited number of players
            //query updates User Bank (Bank-=playerPrice) given UserID
            //UserBank=query get UserBank given UserID;
            textBox1.Text = UserBank.ToString();
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
    }
}
