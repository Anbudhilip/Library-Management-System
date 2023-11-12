using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LIBRARY_MANAGEMENT_SYSTEM
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        static string connect = ConfigurationManager.ConnectionStrings["library_Management_System"].ConnectionString;
        public SqlConnection conn = new SqlConnection(connect);
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand sc = new SqlCommand("insert into trans_log(issued_date)values (@gender)", conn);
           
            if (radioButton1.Checked)
            {
                SqlParameter p1 = new SqlParameter("@gender", SqlDbType.VarChar);
                sc.Parameters.Add(p1).Value = radioButton1.Text;
            }
           else if (radioButton1.Checked)
            {
                SqlParameter p1 = new SqlParameter("@gender", SqlDbType.VarChar);
                sc.Parameters.Add(p1).Value = radioButton2.Text;
            }
            else{
                MessageBox.Show("Select Data");

            }
            conn.Open();
            int i= sc.ExecuteNonQuery();
            if (i > 0)
            {
                MessageBox.Show("Data Saved!", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Check the DataFile !", "Fill All", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            conn.Close();

        }
    }
}
