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
        private Form MyParent;
        private Controller controllerObj;
        public AdminP(Form p)
        {
            InitializeComponent();
            controllerObj = new Controller();
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
            if (textBox10.Text == ""  || textBox9.Text == ""  || textBox8.Text == ""  || textBox7.Text=="" || textBox6.Text == "" || textBox5.Text == "" || textBox4.Text == "" || textBox3.Text == "" || textBox2.Text == "" || textBox1.Text == "") {
                MessageBox.Show("Please fill all the boxes");
            }
            else {
                //Query should update the player info given the player ID in textBox1
                int result = controllerObj.UpdatePlayerInfo(Int32.Parse(textBox1.Text), textBox2.Text, textBox3.Text, Int32.Parse(textBox4.Text), Int32.Parse(textBox5.Text), Int32.Parse(textBox6.Text), Int32.Parse(textBox7.Text));    

                if (result == 0)    //Check on update status                
                    MessageBox.Show("Failed to Update");                
                else                
                    MessageBox.Show("Updated successfully!");                
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) // data grid to show All players Info
        {
            //Query should show all the players info in datagrid
             DataTable dt = controllerObj.ShowPlayers();
            //refresh data grid to show the data
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)//Price
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)//Club ID
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)//Position
        {

        }

        private void button3_Click(object sender, EventArgs e)// Insert new Player
        {
            if (textBox10.Text == "" || textBox9.Text == "" || textBox8.Text == "" || textBox7.Text == "" || textBox6.Text == "" || textBox5.Text == "" || textBox4.Text == "" || textBox3.Text == "" || textBox2.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Please fill all the boxes");
            }
            else
            {
                int result = controllerObj.InsertPlayer(Int32.Parse(textBox1.Text), textBox2.Text, textBox3.Text, char.Parse(textBox8.Text), Int32.Parse(textBox9.Text), Int32.Parse(textBox10.Text), Int32.Parse(textBox6.Text), Int32.Parse(textBox7.Text), Int32.Parse(textBox4.Text), Int32.Parse(textBox5.Text));//Query should Insert a new Player

                if (result == 0)    //Check on Insert status                
                    MessageBox.Show("Failed to Insert");             
                else                
                    MessageBox.Show("Inserted successfully!");                
            }
        }

        private void button4_Click(object sender, EventArgs e)// delete a player button
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter player ID");
            }
            else
            {
                int result = controllerObj.DeletePlayer(Int32.Parse(textBox1.Text));//Query should Delete the player given his ID in textbox1

                if (result == 0)    //Check on Insert status                
                    MessageBox.Show("Failed to Delete");
                else
                    MessageBox.Show("Deleted successfully!");
            }
        }
    }
}
