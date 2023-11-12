using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;


namespace Library_Management_System
{
    public partial class admin : Form
    {

        public SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["library_Management_System"].ConnectionString);
        public admin()
        {
            InitializeComponent();
        }
        public Student obj1 = new Student();

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                string query = textBox1.Text;
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
               
            }
            catch(Exception x)
            {
                MessageBox.Show("Error :" + x);

            }
            finally
            {
                conn.Close();

            }

        }
    }
}
