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
    public partial class Update_Book_Details : Form
    {
        public Update_Book_Details()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["library_Management_System"].ConnectionString);
        private void Update_Book_Details_Load(object sender, EventArgs e)
        {
           
            try
            {
                conn.Open();
                grid_refresh();
            }
            catch (Exception x)
            {
                MessageBox.Show("Error" + x);
            }
            finally { conn.Close(); }
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            string keyword = txt_search.Text;

            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM newBook WHERE bId LIKE'%" + keyword + "%' OR bName LIKE '%" + keyword + "%'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            txt_bId.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            txt_bName.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            txt_bTopic.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            txt_bAuthor.Text = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
            txt_bPublisher.Text = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
            txt_bDate.Text = dataGridView1.Rows[rowIndex].Cells[5].Value.ToString();
            txt_bPrice.Text = dataGridView1.Rows[rowIndex].Cells[6].Value.ToString();
            txt_bQuantity.Text = dataGridView1.Rows[rowIndex].Cells[7].Value.ToString();

        }
       private void refresh()
        {
            txt_bId.Clear();
            txt_bName.Clear();
            txt_bTopic.Clear();
            txt_bAuthor.Clear();
            txt_bPublisher.Clear();
            txt_bDate.Clear();
            txt_bPrice.Clear();
            txt_bQuantity.Clear();
            txt_search.Clear();
          
       }
        private void grid_refresh()
        {

            SqlCommand sc = new SqlCommand("Select * from newBook", conn);
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            conn.Close();

            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand sc = new SqlCommand("update newBook set bName=@name,bTopic=@Topic,bAuthor=@author,bPublisher=@publisher,bDate=@date,bPrice=@price,bQuantity=@quantity where bId =@bid ", conn);

                SqlParameter p2 = new SqlParameter("@name", SqlDbType.VarChar);
                sc.Parameters.Add(p2).Value = txt_bName.Text.ToString();

                SqlParameter p3 = new SqlParameter("@Topic", SqlDbType.VarChar);
                sc.Parameters.Add(p3).Value = txt_bTopic.Text.ToString();

                SqlParameter p4 = new SqlParameter("@author", SqlDbType.VarChar);
                sc.Parameters.Add(p4).Value = txt_bAuthor.Text.ToString();

                SqlParameter p5 = new SqlParameter("@date", SqlDbType.VarChar);
                sc.Parameters.Add(p5).Value = txt_bDate.Text.ToString();

                SqlParameter p6 = new SqlParameter("@price", SqlDbType.VarChar);
                sc.Parameters.Add(p6).Value = txt_bPrice.Text.ToString();

                SqlParameter p7 = new SqlParameter("@quantity", SqlDbType.VarChar);
                sc.Parameters.Add(p7).Value = txt_bQuantity.Text.ToString();

                SqlParameter p8 = new SqlParameter("@publisher", SqlDbType.VarChar);
                sc.Parameters.Add(p8).Value = txt_bPublisher.Text.ToString();

                SqlParameter p9 = new SqlParameter("@bid", SqlDbType.VarChar);
                sc.Parameters.Add(p9).Value = txt_bId.Text.ToString();

                conn.Open();
                int i = sc.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Register Successfully", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refresh();
                    grid_refresh();
                }
            }
            catch(Exception x)
            {
                MessageBox.Show("Error:" + x);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand sc = new SqlCommand("delete from newBook where bId =@id ", conn);
                SqlParameter p1 = new SqlParameter("@id", SqlDbType.VarChar);
                sc.Parameters.Add(p1).Value = txt_bId.Text;
                conn.Open();
                int i = sc.ExecuteNonQuery();

                if (i > 0)
                {
                    MessageBox.Show("Register Successfully", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refresh();
                    grid_refresh();
                }
                else
                {
                    MessageBox.Show("Something Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

            }
            catch (Exception x)
            {
                MessageBox.Show("Error:" + x);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }


            }
        }

        private void btn_exist_Click(object sender, EventArgs e)
        {
            refresh();
        }
    }
}
