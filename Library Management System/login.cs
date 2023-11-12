using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            

            if (box2.Text == ""|| box1.Text=="")
            {
                MessageBox.Show("Enter User Name And Password Without Empty");
            }else if(box1.Text=="Admin" && box2.Text == "Admin"){

                MessageBox.Show("Login Successfully");
                Form1 obj1 = new Form1();
                obj1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invaild User Name or Password");
            }
        }
    }
}
