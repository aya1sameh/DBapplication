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
    
    public partial class AdminSignUp : Form
    {
        private Form MyParent;
        private string Role = "";
        private Controller controllerObj;
        public AdminSignUp(Form p)
        {
            InitializeComponent();
            controllerObj = new Controller();
            MyParent = p;
            MyParent.Hide();
        }

        private void AdminSignUp_Load(object sender, EventArgs e)
        {

        }

        private void AdminSignUp_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            MyParent.Show();
        }

        private void textBox3_TextChanged(object sender, EventArgs e) //ID
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)//First Name
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)//Last Name
        {

        }

       

        private void button1_Click(object sender, EventArgs e)//Sign up button
        {
            if (radioButton1.Checked == true)
            {
                Role = "P";
            }
            else if (radioButton2.Checked == true)
            {
                Role = "F";
            }
            else if (radioButton3.Checked == true)
            {
                Role = "C";
            }
            else
            {
                Role = "";
            }
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Please enter all the values");
            }
            else if (Role == "") {
                MessageBox.Show("Please choose one of the Roles");
            }
            else
            {
                //query should insert new Admin given id,firstname,lastname,Role in global string Role
                int result = controllerObj.AdminSignUp(Int32.Parse(textBox3.Text), textBox1.Text, textBox2.Text, Role);

                if (result == 0)    //Check on Insert status                
                    MessageBox.Show("Failed to Sign Up");
                else
                    MessageBox.Show("Signed Up successfully!");
            }


        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)//Players Manager
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)//Fixtures Manager
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)//Clubs manager
        {

        }
    }
}
