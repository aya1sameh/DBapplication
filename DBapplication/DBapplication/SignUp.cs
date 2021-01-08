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
    public partial class SignUp : Form
    {
        private Controller controllerObj;
        private Form MyParent;
        public SignUp(Form p)
        {
            InitializeComponent();
            controllerObj = new Controller();
            MyParent = p;
            MyParent.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)//id
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)//FirstName
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)//LastName
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)//Password
        {

        }

        private void button1_Click(object sender, EventArgs e)//register
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Please fill all boxes");
            }
            else {
                
                int result2 = controllerObj.InsertUser(Int32.Parse(textBox1.Text), textBox2.Text, textBox3.Text, Int32.Parse(textBox4.Text));
                if (result2 == 0 )
                {
                    MessageBox.Show("Unable to create user try another id");
                }
                else {
                    MessageBox.Show("User created successfully !");
                    int result = controllerObj.InsertChips(Int32.Parse(textBox1.Text));
                    UserHome a = new UserHome(this, Int32.Parse(textBox1.Text));
                    a.Show();
                }

                

            }

        }

        private void SignUp_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            MyParent.Show();
        }
    }
}
