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
    public partial class Book_Info : Form
    {
        public Book_Info()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["library_Management_System"].ConnectionString);


        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Book_Info_Load(object sender, EventArgs e)
        {

        }
        void refresh()
        {
            txt_Bid.Clear();
             txt_Bname.Clear();
            txt_bookId.Clear();
            txt_BookName.Clear();
            txt_BookTopic.Clear();
            txt_BookAuthor.Clear();
            txt_BookPublisher.Clear();
            txt_BookDate.Clear();
            txt_BookPrice.Clear();
            txt_BookQuantity.Clear();
            txt_Bid.ReadOnly = false;
            txt_Bname.ReadOnly = false;
            chart1.Series.Clear();
            chart1.Titles.Clear();
            grid_BookTrans.DataSource = null;
            chart1.DataSource = null;



        }

        private void btn_submit_Click(object sender, EventArgs e)
        {

            try
            {
                if (!string.IsNullOrEmpty(txt_Bid.Text) || !string.IsNullOrEmpty(txt_Bname.Text))
                {
                    using (SqlCommand sc = new SqlCommand($"Select * from newBook where bId='{txt_Bid.Text }' or bName='{ txt_Bname.Text }' ", conn))
                    {
                        conn.Open();
                        SqlDataAdapter sda = new SqlDataAdapter(sc);
                        DataSet ds = new DataSet();
                        sda.Fill(ds);

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            txt_Bid.ReadOnly = true;
                            txt_Bname.ReadOnly = true;

                            txt_bookId.Text = ds.Tables[0].Rows[0][0].ToString();
                            txt_BookName.Text = ds.Tables[0].Rows[0][1].ToString();
                            txt_BookTopic.Text = ds.Tables[0].Rows[0][2].ToString();
                            txt_BookAuthor.Text = ds.Tables[0].Rows[0][3].ToString();
                            txt_BookPublisher.Text = ds.Tables[0].Rows[0][4].ToString();
                            txt_BookDate.Text = ds.Tables[0].Rows[0][5].ToString();
                            txt_BookPrice.Text = ds.Tables[0].Rows[0][6].ToString();
                            txt_BookQuantity.Text = ds.Tables[0].Rows[0][7].ToString();

                            if (!string.IsNullOrEmpty(txt_bookId.Text))
                            {
                                SqlCommand sc1 = new SqlCommand("fech_transaction", conn); // Entry Histroy
                                sc1.CommandType = CommandType.StoredProcedure;

                                SqlParameter p1 = new SqlParameter("@id", SqlDbType.VarChar);
                                sc1.Parameters.Add(p1).Value = txt_bookId.Text.ToString();

                                SqlDataAdapter sda1 = new SqlDataAdapter(sc1);
                                DataTable dt = new DataTable();
                                sda1.Fill(dt);
                                grid_BookTrans.DataSource = dt;


                                SqlCommand sc3 = new SqlCommand("Book_Id_chart", conn); // Char for student entry
                                sc3.CommandType = CommandType.StoredProcedure;
                                SqlParameter p3 = new SqlParameter("@id", SqlDbType.VarChar);
                                sc3.Parameters.Add(p3).Value = txt_bookId.Text.ToString();

                                SqlDataAdapter sda3 = new SqlDataAdapter(sc3);
                                DataTable dt2 = new DataTable();
                                sda3.Fill(dt2);
                                if (ds.Tables[0].Rows.Count != 0)
                                {
                                    chart1.DataSource = dt2;
                                    chart1.Titles.Add("Total No. of Entry");
                                    chart1.Series["bookChart"].XValueMember = "Total_Entry";
                                    chart1.Series["bookChart"].YValueMembers = "This_Book";
                                }
                                
                            }
                            else
                            {

                                MessageBox.Show("Invaild ID", "Invaild", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            }

                        }
                    }
                }
                else
                {
                    MessageBox.Show(" All Filled Must be filled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void txt_cancel_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void grid_BookTrans_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
