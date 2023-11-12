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
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LIBRARY_MANAGEMENT_SYSTEM
{
    public partial class Issue_book : Form
    {
        public Issue_book()
        {
            InitializeComponent();
        }


        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["library_Management_System"].ConnectionString);

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Issue_book_Load(object sender, EventArgs e)
        {
            SqlCommand sc = new SqlCommand("select bName from newBook",conn);
            conn.Open();
            SqlDataReader sdr = sc.ExecuteReader();

            while (sdr.Read())
            {
                for(int i = 0; i < sdr.FieldCount; i++)
                {
                    txt_bName.Items.Add(sdr.GetString(i));
                }
            }
            sdr.Close();
            conn.Close();



        }

        public int count;
       
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_RegisterId.Text != "")
                {
                  

                    SqlCommand sc = new SqlCommand("Select * from newStudent where stud_RegisterNo ='" +txt_RegisterId.Text+"'",conn);
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(sc);
                    DataSet ds = new DataSet();
                    da.Fill(ds);


                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        txt_libId.Text = ds.Tables[0].Rows[0][0].ToString();
                        txt_RollNo.Text = ds.Tables[0].Rows[0][2].ToString();
                        txt_sname.Text = ds.Tables[0].Rows[0][3].ToString();
                        

                        MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0][4]);

                        pictureBox2.Image = new Bitmap(ms);
                    }
                    else
                    {

                        MessageBox.Show("Invaild Register Id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        clear();

                    }

                    //------------------------------------------------------------------------
                    // Count to how many books have been issued the particular rollno

                    SqlCommand cmd = new SqlCommand("Select count(library_Id) from transation_log where library_Id ='" + txt_libId.Text + "'and return_Date is null ",conn);
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1);


                    count = int.Parse(ds1.Tables[0].Rows[0][0].ToString());
                    //-------------------------------------------------------------------------

                }
                else
                {
                    MessageBox.Show("Enter the Registered Id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
            finally { 
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            try {
                if (txt_bName.SelectedIndex != -1 && count <= 2)
                {
                    ////MessageBox.Show("Its working ");
                    string lib_Id = txt_libId.Text;
                    string book_Id = txt_bId.Text;
                    string issuedDate = txt_issueDate.Text;

                    SqlCommand sc = new SqlCommand("insert into transation_log(library_Id,book_Id,issue_Date) Values ('" + lib_Id + "','" + book_Id+ "','" + issuedDate + "')", conn);
                    conn.Open();
                    int i = sc.ExecuteNonQuery();
                    conn.Close();

                    if (i > 0)
                    {
                        MessageBox.Show("Successfully Registered", "Books Give Wisdow", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clear();
                    }

                }
                else
                {
                    MessageBox.Show("Two book allowed for one student ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clear();
                }

            }catch(Exception x)
            {
                MessageBox.Show("" + x);
            }
        }
        void clear()
        {
            txt_RegisterId.Clear();
            txt_libId.Clear();
            txt_bId.Clear();
            txt_RollNo.Clear();
            txt_sname.Clear();
            txt_bName.SelectedIndex = -1;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (txt_RegisterId.Text == "")
            {
                clear();
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
