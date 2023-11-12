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

namespace LIBRARY_MANAGEMENT_SYSTEM
{
    public partial class Add_Book : Form
    {
        public Add_Book()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["library_Management_System"].ConnectionString);
        private void txt_Name_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txt_bName.Text) && !string.IsNullOrEmpty(txt_bTopic.Text) && !string.IsNullOrEmpty(txt_bAuthor.Text) && !string.IsNullOrEmpty(txt_bPublisher.Text) && !string.IsNullOrEmpty(dateTimePicker1.Text) && !string.IsNullOrEmpty(txt_bPrice.Text) && !string.IsNullOrEmpty(txt_bQuentity.Text))
                {
                    SqlCommand sc = new SqlCommand("add_book", conn);
                    sc.CommandType = CommandType.StoredProcedure;

                    sc.Parameters.AddWithValue("@bName", txt_bName.Text.ToString());
                    sc.Parameters.AddWithValue("@bTopic", txt_bTopic.Text.ToString());
                    sc.Parameters.AddWithValue("@bAuthor", txt_bAuthor.Text.ToString());
                    sc.Parameters.AddWithValue("@bPublisher", txt_bPublisher.Text.ToString());
                    sc.Parameters.AddWithValue("@bDate", dateTimePicker1.Text.ToString());
                    sc.Parameters.AddWithValue("@bPrice", txt_bPrice.Text.ToString());
                    sc.Parameters.AddWithValue("@bQuantity", txt_bQuentity.Text.ToString());

                    conn.Open();
                    int i = sc.ExecuteNonQuery();
                    conn.Close();
                    //inser if clause for without blank file 

                    if (i > 0)
                    {
                        MessageBox.Show("Data Saved!", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        refresh();
                    }
                    else
                    {
                        MessageBox.Show("Check the DataFile !", "Fill All", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                else
                {
                    MessageBox.Show("All Filed Must be Filled", "Fill All", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Error" + x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void btn_Exist_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("It Will DELETE Your unSaved Data", "Are You Sure ?", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                this.Close();
            }
        }

        public void refresh()
        {
            txt_bName.Clear();
            txt_bTopic.Clear();
            txt_bAuthor.Clear();
            txt_bPublisher.Clear();
            txt_bPrice.Clear();
            txt_bQuentity.Clear();
        }

    }

}
