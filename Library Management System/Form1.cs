using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Library_Management_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student stud = new Student();
            stud.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Books obj2 = new Books();
            obj2.Show();
           

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Borrow obj3 = new Borrow();
            obj3.Show();
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Librarian obj4 = new Librarian();
            obj4.Show();
          
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
