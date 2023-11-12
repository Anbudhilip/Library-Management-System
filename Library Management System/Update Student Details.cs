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
    public partial class Update_Student_Details : Form
    {
        public Update_Student_Details()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["library_Management_System"].ConnectionString);




        private void button1_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    SqlCommand sc = new SqlCommand("Select * from newStudent", conn);
            //    conn.Open();
            //    SqlDataAdapter sda = new SqlDataAdapter(sc);
            //    DataSet ds = new DataSet();
            //    sda.Fill(ds);
            //    conn.Close();
            //    dataGridView1.DataSource = ds;
            //}
            //catch (Exception x)
            //{
            //    MessageBox.Show("Error" + x);
            //}

        }

        private void Update_Student_Details_Load(object sender, EventArgs e)
        {
            try
            {
                btn_browse.Visible = false;

                conn.Open();
                grid_refresh();
            }
            catch (Exception x)
            {
                MessageBox.Show("Error" + x);
            }
            finally { conn.Close(); }

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            string keyword = txt_search.Text;

            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM newStudent WHERE library_Id LIKE'%" + keyword + "%' OR stud_Name LIKE '%" + keyword + "%'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btn_browse.Visible = true;
            int rowIndex = e.RowIndex;
            txt_Id.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            txt_name.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            txt_topic.Text = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
            txt_author.Text = dataGridView1.Rows[rowIndex].Cells[5].Value.ToString();
            txt_publisher.Text = dataGridView1.Rows[rowIndex].Cells[6].Value.ToString();
            txt_Date.Text = dataGridView1.Rows[rowIndex].Cells[7].Value.ToString();
            txt_price.Text = dataGridView1.Rows[rowIndex].Cells[8].Value.ToString();
            txt_quantity.Text = dataGridView1.Rows[rowIndex].Cells[9].Value.ToString();


            MemoryStream ms = new MemoryStream((byte[])dataGridView1.Rows[rowIndex].Cells[4].Value);

            stud_img.Image = new Bitmap(ms);
        }
        void refresh()
        {
            txt_Id.Clear();
            txt_name.Clear();
            txt_topic.Clear();
            txt_author.Clear();
            txt_publisher.Clear();
            txt_Date.Clear();
            txt_quantity.Clear();
            stud_img.Image = null;
            txt_search.Clear();
            txt_price.Clear();
        }
        private void grid_refresh()
        {

            SqlCommand sc = new SqlCommand("Select * from newStudent", conn);
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            conn.Close();

            dataGridView1.DataSource = ds.Tables[0];
        }
        private void btn_browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog() { Filter = "Image files(*.jpg;*.jpeg;)|*.jpg;*.jpeg", Multiselect = false };
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    stud_img.Image = Image.FromFile(ofd.FileName);

                }

            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            SqlCommand sc = new SqlCommand("Update  newStudent set stud_RegisterNo =@id ,stud_RollNo =@rollNo,stud_Name=@name," +
                "stud_Image=@img,stud_Gender = @gender,stud_Department= @department,stud_Semester =@semester,stud_contact=@contact," +
                "stud_Email=@email where stud_RegisterNo ='" + txt_Id.Text+ "'", conn);

            try
            {       ////asign value for parameter

                SqlParameter p1 = new SqlParameter("@id", SqlDbType.VarChar);
                sc.Parameters.Add(p1).Value = txt_Id.Text;

                SqlParameter p2 = new SqlParameter("@rollNo", SqlDbType.VarChar);
                sc.Parameters.Add(p2).Value = txt_name.Text;

                SqlParameter p3 = new SqlParameter("@name", SqlDbType.VarChar);
                sc.Parameters.Add(p3).Value = txt_topic.Text;

                SqlParameter p4 = new SqlParameter("@img", SqlDbType.Image);
                MemoryStream ms = new MemoryStream();
                stud_img.Image.Save(ms, stud_img.Image.RawFormat);
                sc.Parameters.Add(p4).Value = ms.ToArray();

                SqlParameter p5 = new SqlParameter("@gender", SqlDbType.VarChar);
                sc.Parameters.Add(p5).Value = txt_author.Text;

                SqlParameter p6 = new SqlParameter("@department", SqlDbType.VarChar);
                sc.Parameters.Add(p6).Value = txt_publisher.Text;

                SqlParameter p7 = new SqlParameter("@semester", SqlDbType.VarChar);
                sc.Parameters.Add(p7).Value = txt_Date.Text;

                SqlParameter p8 = new SqlParameter("@contact", SqlDbType.BigInt);
                sc.Parameters.Add(p8).Value = txt_price.Text;

                SqlParameter p9 = new SqlParameter("@email", SqlDbType.VarChar);
                sc.Parameters.Add(p9).Value = txt_quantity.Text;



                //sc.Parameters.AddWithValue("@img", ms.ToArray());
                conn.Open();
                int i = sc.ExecuteNonQuery();

                //inser if clause for without blank file 

                if (i > 0)
                {
                    MessageBox.Show("Register Successfully", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refresh();
                    grid_refresh();
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand sc = new SqlCommand("delete from newStudent where stud_RegisterNo =@id ", conn);
                SqlParameter p1 = new SqlParameter("@id", SqlDbType.VarChar);
                sc.Parameters.Add(p1).Value = txt_Id.Text;
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
                    MessageBox.Show("", "Fill All", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void btn_submit_Click(object sender, EventArgs e)
        {
            dashboard back1 = new dashboard();
            this.Close();
            back1.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_quantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_price_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Date_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_publisher_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_author_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_topic_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Id_TextChanged(object sender, EventArgs e)
        {

        }

        private void stud_img_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}