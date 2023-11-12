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
    public partial class Home_Page : Form
    {
        public Home_Page()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["library_Management_System"].ConnectionString);
      
        int i;  // variable for store  ExecuteNonQuery return value
     private string msg;
       public string nav_message { get { return msg; } set { msg = value; } }


        private void Home_Page_Load(object sender, EventArgs e)
        {
            pan_stud.Visible = false;   // for student entry register panel

            // nav_bar_message = txt_nav_instruction.Text;


            txt_time.Text = DateTime.Now.ToString();   // for current time and date
            timer2.Start();

            using (SqlCommand sc = new SqlCommand("Select  nav_message from stud_message ", conn))
            {
                conn.Open();
                SqlDataAdapter sda = new SqlDataAdapter(sc);
                DataSet ds = new DataSet();
                //sda.Fill(ds);
                conn.Close();


               // txt_nav_instruction.Text = ds.Tables[0].Rows[0][0].ToString();

            }
        }

        void refresh()   // Method for Clear data
        {
            txt_RollNo.Clear();
            txt_libId.Clear();
            txt_regId.Clear();
            txt_sname.Clear(); ;
            txt_department.Clear();
            txt_regId.ReadOnly = false;
            txt_libId.ReadOnly = false;
            txt_message.Visible = false;
        }
        
      int exist_reg()
      {

            //--Validation Propose feching data from to DB and store in value in Global Variable " i ";

            SqlCommand sc1 = new SqlCommand("select count(library_Id) from entry_register where library_Id ='" + txt_libId.Text + "' and out_Time is null and cast(reg_Date as date)= cast(GETDATE() AS date)", conn);

            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter(sc1);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            conn.Close();
           return i = int.Parse(ds.Tables[0].Rows[0][0].ToString());  // Core Concept

      }

        private string text;
        private int len = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            //if (len >text.Length )
            //{
            //    txt_welcome.Text = txt_welcome.Text + text.ElementAt(len);
            //    len++;
            //}

        }

   

        private void txt_time_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            
            txt_time.Text = DateTime.Now.ToString();
        }

        private void btn_reg_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            pan_stud.Visible = true;

        }

        private void txt_regId_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txt_nav_instruction_TextChanged(object sender, EventArgs e)
        {

        }

        private void byn_login_Click_1(object sender, EventArgs e)
        {
            admin_login ent_admin = new admin_login();

            ent_admin.Show();
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txt_regId.Text) || !string.IsNullOrEmpty(txt_libId.Text))
                {
                    using (SqlCommand sc = new SqlCommand("Select * from newStudent where library_Id='" + txt_libId.Text + "' or stud_RegisterNo='" + txt_regId.Text + "' ", conn))
                    {
                        conn.Open();
                        SqlDataAdapter sda = new SqlDataAdapter(sc);
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        conn.Close();

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            txt_regId.ReadOnly = true;
                            txt_libId.ReadOnly = true;

                            txt_libId.Text = ds.Tables[0].Rows[0][0].ToString();
                            txt_regId.Text = ds.Tables[0].Rows[0][1].ToString();
                            txt_sname.Text = ds.Tables[0].Rows[0][3].ToString();
                            txt_RollNo.Text = ds.Tables[0].Rows[0][2].ToString();
                            txt_department.Text = ds.Tables[0].Rows[0][6].ToString();

                        }
                        else
                        {
                            txt_message.Visible = true;
                            txt_message.Text = "Invaild Register Id Or Library Id ";
                            //MessageBox.Show("Invaild ID", "Invaild", MessageBoxButtons.OK, MessageBoxIcon.Warning); 

                        }
                    }


                }
                else
                {
                    // MessageBox.Show(" All Filled Must be filled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_message.Visible = true;
                    txt_message.Text = "All Filled Must be filled";
                }

            }
            catch (Exception x)
            {
                MessageBox.Show("Error" + x, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
            }
        }

        private void txt_cancel_Click(object sender, EventArgs e)
        {
            refresh();
            pan_stud.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                exist_reg();

                if (!string.IsNullOrEmpty(txt_libId.Text) && i == 0)
                {
                    SqlCommand sc = new SqlCommand("insert into  entry_register(library_Id,reg_Date,in_Time) values ('" + txt_libId.Text + "',getDate(),CONVERT(time,getdate()))", conn);
                    conn.Open();
                    int i = sc.ExecuteNonQuery();
                    conn.Close();

                    if (i > 0)
                    {
                        MessageBox.Show(" Welcome Registered Successfully", "WELCOME");
                        refresh();
                    }


                }
                else
                {
                    MessageBox.Show("This Registered Id Already Entered", "Invaild", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
                    refresh();
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Error" + x);
            }
        }

        private void btn_exist_Click(object sender, EventArgs e)
        {
            try
            {
                exist_reg();

                if (!string.IsNullOrEmpty(txt_libId.Text) && i == 1)
                {
                    SqlCommand sc = new SqlCommand("update entry_register set out_Time=convert(time,getdate()) where library_Id ='" + txt_libId.Text + "' and CAST(reg_Date AS DATE) = CAST(GETDATE() AS DATE)", conn);
                    conn.Open();
                    int i = sc.ExecuteNonQuery();
                    conn.Close();

                    if (i > 0)
                    {
                        MessageBox.Show("Registered Successfully", "Come Again", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        refresh();
                    }

                }
                else
                {
                    MessageBox.Show("Don't Exit Before Enter ", "Invaild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    refresh();
                }
            }

            catch (Exception x)
            {
                MessageBox.Show("Error" + x, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;

            }
        }
    }
}
