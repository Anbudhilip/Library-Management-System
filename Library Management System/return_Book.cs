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
    public partial class return_Book : Form
    {
        public return_Book()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["library_Management_System"].ConnectionString);

        private void return_Book_Load(object sender, EventArgs e)
        {
            //panel4.Visible = false;
            panel4.Visible = false;
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            if (txt_RegisterId.Text != "" || txt_libId.Text != "")
            {
                string reg_id = txt_RegisterId.Text;
                string lib_id = txt_libId.Text;

                string query = "Select * from newStudent where library_Id='" + lib_id + "' or stud_RegisterNo = '" + reg_id + "' ";
                //

                SqlCommand sc = new SqlCommand(query,conn);
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(sc);
                DataSet ds = new DataSet();
                da.Fill(ds);
                conn.Close();
                if (ds.Tables[0].Rows.Count != 0)
                {
                    
                    txt_RollNo.Text = ds.Tables[0].Rows[0][2].ToString();
                    txt_sname.Text = ds.Tables[0].Rows[0][3].ToString();
                    txt_department.Text = ds.Tables[0].Rows[0][6].ToString();
                    lib_id = ds.Tables[0].Rows[0][0].ToString();
                    reg_id = ds.Tables[0].Rows[0][1].ToString();
                    MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0][4]);

                    pictureBox2.Image = new Bitmap(ms);
                   

                    if (lib_id != "")
                    {
                        SqlCommand sc2 = new SqlCommand("select * from transation_log where library_Id='" + lib_id + "' ", conn);
                        conn.Open();
                        SqlDataAdapter da2 = new SqlDataAdapter(sc2);
                        DataSet ds2 = new DataSet();
                        da2.Fill(ds2);

                        if (ds2.Tables[0].Rows.Count != 0)
                        {
                            dataGridView1.DataSource = ds2.Tables[0];

                        }
                        else
                        {

                        }
                    }
                }

            }
            else
            {
                MessageBox.Show("Enter Registered Id or Library Id", "Fill the Filed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            
        }
        int bId;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            panel4.Visible = true;
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
               //MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                bId= int.Parse(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
               
            }

            SqlCommand sc = new SqlCommand("Select * from  newBook where bId='" + bId + "' ", conn);

            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sc);
            DataSet ds = new DataSet();
            da.Fill(ds);
          

            txt_bId.Text = ds.Tables[0].Rows[0][0].ToString();
            txt_bName.Text= ds.Tables[0].Rows[0][1].ToString();
            conn.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_retunDate.Text != "" && txt_bId.Text != "" && txt_bName.Text != "")
            {
                SqlCommand sc = new SqlCommand("update transation_log set return_Date=@return_date where book_id =@bid ", conn);

                SqlParameter p1 = new SqlParameter("@return_date", SqlDbType.VarChar);
                sc.Parameters.Add(p1).Value = txt_retunDate.Text;

                SqlParameter p2 = new SqlParameter("@bid", SqlDbType.Int);
                sc.Parameters.Add(p2).Value = txt_bId.Text;

                conn.Open();
                int i = sc.ExecuteNonQuery();
                conn.Close();

                if (i > 0)
                {
                    MessageBox.Show("Successfully Updated");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you want Exist", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                panel4.Visible = false;
                
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
