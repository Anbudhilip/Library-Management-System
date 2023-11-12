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
    public partial class Add_Students : Form
    {
        public Add_Students()
        {
            InitializeComponent();
            
        }
       static string connect = @"Data Source=DESKTOP-UJ9035U;Initial Catalog=Librarydb;Integrated Security=True";

        public SqlConnection conn = new SqlConnection(connect);

       
        private void btn_refresh_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("It Will DELETE Your unSaved Data", "Are You Sure ?", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                this.Close();
            }
           
        }


        void refresh()
        {
            txt_id.Text = "";
            txt_RollNo.Text = "";
            txt_Name.Text = "";
            txt_Gender.Text = "";
            txt_Department.Text = "";
            txt_semaster.Text = "";
            txt_ContactNo.Text = "";
            txt_Email.Text = "";
            pictureBox1.Image = null;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            SqlCommand sc = new SqlCommand("insert into newStudent(stud_RegisterNo,stud_RollNo,stud_Name,stud_Image,stud_Gender,stud_Department,stud_Semester,stud_contact,stud_Email) values (@id,@rollNo,@name,@img,@gender,@department,@semester,@contact,@email)", conn);

            try
            {      if (!string.IsNullOrEmpty(txt_id.Text) && !string.IsNullOrEmpty(txt_RollNo.Text) && !string.IsNullOrEmpty(txt_Name.Text) && !string.IsNullOrEmpty(txt_Gender.Text) && !string.IsNullOrEmpty(txt_Department.Text) && !string.IsNullOrEmpty(txt_semaster.Text) && !string.IsNullOrEmpty(txt_ContactNo.Text) && !string.IsNullOrEmpty(txt_Email.Text) && pictureBox1.Image != null)
                {

                    SqlParameter p1 = new SqlParameter("@id", SqlDbType.VarChar);
                    sc.Parameters.Add(p1).Value = txt_id.Text;

                    SqlParameter p2 = new SqlParameter("@rollNo", SqlDbType.VarChar);
                    sc.Parameters.Add(p2).Value = txt_RollNo.Text;

                    SqlParameter p3 = new SqlParameter("@name", SqlDbType.VarChar);
                    sc.Parameters.Add(p3).Value = txt_Name.Text;

                    SqlParameter p4 = new SqlParameter("@img", SqlDbType.Image);
                    MemoryStream ms = new MemoryStream();
                    pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                    sc.Parameters.Add(p4).Value = ms.ToArray();

                    SqlParameter p5 = new SqlParameter("@gender", SqlDbType.VarChar);
                    sc.Parameters.Add(p5).Value = txt_Gender.Text;

                    SqlParameter p6 = new SqlParameter("@department", SqlDbType.VarChar);
                    sc.Parameters.Add(p6).Value = txt_Department.Text;

                    SqlParameter p7 = new SqlParameter("@semester", SqlDbType.VarChar);
                    sc.Parameters.Add(p7).Value = txt_semaster.Text;

                    SqlParameter p8 = new SqlParameter("@contact", SqlDbType.BigInt);
                    sc.Parameters.Add(p8).Value = txt_ContactNo.Text;

                    SqlParameter p9 = new SqlParameter("@email", SqlDbType.VarChar);
                    sc.Parameters.Add(p9).Value = txt_Email.Text;



                    //sc.Parameters.AddWithValue("@img", ms.ToArray());
                    conn.Open();
                    int i = sc.ExecuteNonQuery();

                    //inser if clause for without blank file 

                    if (i > 0)
                    {
                        MessageBox.Show("Register Successfully", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        refresh();
                    }
                    else
                    {
                        MessageBox.Show("", "Fill All", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                else
                {
                    MessageBox.Show(" All Filed Must be Filled", "Fill All", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btn_browse_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog() { Filter = "Image files(*.jpg;*.jpeg;)|*.jpg;*.jpeg", Multiselect = false };
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(ofd.FileName);

                }

            }
        }

        private void btn_refresh_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("It Will DELETE Your unSaved Data", "Are You Sure ?", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}

