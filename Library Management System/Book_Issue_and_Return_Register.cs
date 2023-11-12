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
using System.IO;

namespace LIBRARY_MANAGEMENT_SYSTEM
{
    public partial class Book_Issue_and_Return_Register : Form
    {
        public Book_Issue_and_Return_Register()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Library_Management_System"].ConnectionString);

        int count;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_search.Text != "")
                {


                    SqlCommand sc = new SqlCommand("tbl_stud", conn);
                    sc.CommandType = CommandType.StoredProcedure;

                    SqlParameter p1 = new SqlParameter("@id", SqlDbType.VarChar);
                    sc.Parameters.Add(p1).Value = txt_search.Text.ToString();
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(sc);
                    DataSet ds = new DataSet();
                    da.Fill(ds);


                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        txt_lib.Text = ds.Tables[0].Rows[0][0].ToString();
                        txt_Id.Text = ds.Tables[0].Rows[0][1].ToString();
                        txt_name.Text = ds.Tables[0].Rows[0][3].ToString();
                        text_roll.Text = ds.Tables[0].Rows[0][2].ToString();
                        txt_department.Text = ds.Tables[0].Rows[0][6].ToString();
                        txt_gender.Text = ds.Tables[0].Rows[0][5].ToString();
                        txt_Contact.Text = ds.Tables[0].Rows[0][8].ToString();
                        txt_email.Text = ds.Tables[0].Rows[0][9].ToString();
                        MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0][4]);

                        img.Image = new Bitmap(ms);



                        //-- txt_Contact----------------------------------------------------------------------
                        // C txt_email.Tount to how many books have been issued the particular rollno

                        SqlCommand cmd = new SqlCommand("Select count(library_Id) from transation_log where library_Id ='" + txt_lib.Text + "'and return_Date is null ", conn);
                        SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                        DataSet ds1 = new DataSet();
                        da1.Fill(ds1);
                       

                        count = int.Parse(ds1.Tables[0].Rows[0][0].ToString());
                        //-------------------------------------------------------------------------

                        //if (dataGridView1.Rows[0].Cells[0].Value == null)
                        //{
                        //    SqlCommand sc2 = new SqlCommand("select * from transation_log where library_Id='" + txt_lib.Text + "'and return_Date is null ", conn);
                        //    int i = 0;

                        //    SqlDataReader dr = sc2.ExecuteReader();
                        //    while (dr.Read())
                        //    {
                        //        i++;
                        //        dataGridView1.Rows.Add(dr[4].ToString(), dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());

                        //    }
                        //    dr.Close();

                        load_grid();
                        //    SqlCommand sc2 = new SqlCommand("fech_trans_grid ", conn);
                        //sc2.CommandType = CommandType.StoredProcedure;
                        //SqlDataAdapter da2 = new SqlDataAdapter(sc2);
                        //    DataSet ds2 = new DataSet();
                        //    da2.Fill(ds2);

                        //    if (ds2.Tables[0].Rows.Count != 0)
                        //    {
                        //        dataGridView1.DataSource = ds2.Tables[0];


                        //}
                        //dataGridView1.Columns["TRANSACTION NO"].Width = 70;

                    }
                    else
                    {

                        MessageBox.Show("Invaild ID", "Invaild", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        
                    }

                }
                else
                {
                    MessageBox.Show("Enter the Student Library Id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_search.Clear();
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

        void load_grid()
        {
            try
            {

                SqlCommand sc2 = new SqlCommand("select * from transation_log where library_Id='" + txt_lib.Text + "'and return_Date is null ", conn);
           
                SqlDataAdapter sda = new SqlDataAdapter(sc2);
                DataSet ds = new DataSet();
                sda.Fill(ds);
               
                if(ds.Tables[0].Rows.Count != 0)
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = ds.Tables[0];
                }
                
                //int i = 0;
                //conn.Open();
                //SqlDataReader dr = sc2.ExecuteReader();
                //while (dr.Read())
                //{
                //    i++;
                //    dataGridView1.Rows.Add(dr[4].ToString(), dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());

                //}
                //dr.Close();


                //else
                //{

                //}

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

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_search.Text != "" &&count <= 2)
                {

                    SqlCommand sc = new SqlCommand("book_issue", conn);
                    sc.CommandType = CommandType.StoredProcedure;

                    SqlParameter p1 = new SqlParameter("@book_id", SqlDbType.Int);
                    sc.Parameters.Add(p1).Value = txt_bId.Text.ToString();

                    SqlParameter p2 = new SqlParameter("@lib_id", SqlDbType.Int);
                    sc.Parameters.Add(p2).Value = txt_lib.Text.ToString();

                    SqlParameter p3 = new SqlParameter("@issue_date", SqlDbType.VarChar);
                    sc.Parameters.Add(p3).Value = txt_issueDate.Text.ToString();

                    conn.Open();
                    int i = sc.ExecuteNonQuery();
                    conn.Close();
                    if (i > 0)
                    {
                       
                        MessageBox.Show("Successfully Registered", "Books Give Wisdow", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_bId.Clear();
                        load_grid();
                    }

                }
                else
                {
                    MessageBox.Show(" Three books allowed for one student ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_bId.Clear();
                }

            }
            catch (Exception x)
            {
                MessageBox.Show("Error" + x, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_bookId.Text != "")
                {
                    SqlCommand sc = new SqlCommand("update transation_log set return_Date=@return_date where book_id =@bid ", conn);

                    SqlParameter p1 = new SqlParameter("@return_date", SqlDbType.VarChar);
                    sc.Parameters.Add(p1).Value = txt_dateretun.Text;

                    SqlParameter p2 = new SqlParameter("@bid", SqlDbType.Int);
                    sc.Parameters.Add(p2).Value = txt_bookId.Text;

                    conn.Open();
                    int i = sc.ExecuteNonQuery();
                    conn.Close();


                    if (i > 0)
                    {
                        MessageBox.Show("Successfully Updated");
                        txt_bookId.Clear();
                        load_grid();
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Error" + x, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        void clear()
        {
            txt_bId.Clear();
            txt_lib.Clear();
            txt_bookId.Clear();
            txt_Id.Clear();
            txt_name.Clear();
            text_roll.Clear();
            txt_department.Clear();
            txt_gender.Clear();
            img.Image = null;
            
            txt_bookId.Clear();
            
            txt_search.Clear();
            txt_email.Clear();
            txt_Contact.Clear();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txt_bId.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
           
            txt_bookId.Clear();
        }
 

        private void dataGridView1_RowHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                txt_bookId.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            catch (Exception x)
            {
                MessageBox.Show(" " + x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Book_Issue_and_Return_Register_Load(object sender, EventArgs e)
        {

        }
    }
}



