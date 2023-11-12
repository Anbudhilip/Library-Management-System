using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace LIBRARY_MANAGEMENT_SYSTEM
{
    public partial class Student_Info : Form
    {
        public Student_Info()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["library_Management_System"].ConnectionString);

        private void submit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txt_regId.Text) || !string.IsNullOrEmpty(txt_libId.Text))
                {
                   
                    using (SqlCommand sc = new SqlCommand($"Select * from newStudent where library_Id='{txt_libId.Text }' or stud_RegisterNo='{ txt_regId.Text }' ", conn)) 
                    
                    //using (SqlCommand sc = new SqlCommand("fech_Stud ", conn))
                    {
                        //sc.CommandType = CommandType.StoredProcedure;

                       // sc.Parameters.AddWithValue("@id", txt_libId.Text.ToString());
                        conn.Open();
                        SqlDataAdapter sda = new SqlDataAdapter(sc);
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                       
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            txt_regId.ReadOnly = true;
                            txt_libId.ReadOnly = true;

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

                            if (!string.IsNullOrEmpty(txt_lib.Text))
                            {
                                SqlCommand sc1 = new SqlCommand("tbl_entry_reg",conn); // Entry Histroy
                                sc1.CommandType = CommandType.StoredProcedure;

                                SqlParameter p1 = new SqlParameter("@id",SqlDbType.VarChar);
                                sc1.Parameters.Add(p1).Value = txt_lib.Text.ToString();

                                SqlDataAdapter sda1 = new SqlDataAdapter(sc1);
                                DataTable dt = new DataTable();
                                sda1.Fill(dt);
                                grid_entry.DataSource = dt;


                                SqlCommand sc2 = new SqlCommand("tbl_book_trans", conn); // Book Transaction Histroy
                                sc2.CommandType = CommandType.StoredProcedure;
                                SqlParameter p2 = new SqlParameter("@id", SqlDbType.VarChar);
                                sc2.Parameters.Add(p2).Value = txt_lib.Text.ToString();

                                SqlDataAdapter sda2 = new SqlDataAdapter(sc2);
                                DataTable dt1 = new DataTable();
                                sda2.Fill(dt1);
                                book_trans.DataSource = dt1;


                                SqlCommand sc3 = new SqlCommand("library_Id_Entered", conn); // Char for student entry
                                sc3.CommandType = CommandType.StoredProcedure;
                                SqlParameter p3 = new SqlParameter("@id",SqlDbType.VarChar);
                                sc3.Parameters.Add(p3).Value = txt_lib.Text.ToString();

                                SqlDataAdapter sda3 = new SqlDataAdapter(sc3);
                                DataTable dt2 = new DataTable();
                                sda3.Fill(dt2);

                                // SqlDataReader dt2 = sc3.ExecuteReader();

                                chart1.DataSource = dt2;

                                //chart1.Series.Clear();
                                //Series series = new Series("Total No. of Entry ");
                                //series.ChartType = SeriesChartType.Pie;
                                //Series.Points.DataBind(dt.DefaultView, "Total Entry", "This Library_ID", null);

                               
                                chart1.Titles.Add("This Book Transaction");
                                chart1.Series["Entry"].XValueMember = "Total_Entry";
                                chart1.Series["Entry"].YValueMembers = "Id_Entered";

                                //chart1.Series["Total No. of Entry"].Points.AddXY(dt2[0].ToString(), dt2[1].ToString());

                            }



                        }
                        else
                        {
                           
                           MessageBox.Show("Invaild ID", "Invaild", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                             refresh();
                        }
                    }


                }
                else
                {
                     MessageBox.Show(" All Filled Must be filled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   
                }

            }
            catch (Exception x)
            {
                MessageBox.Show("Error" + x, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                        conn.Close();
                }
            }
        }
        void refresh()
        {
            img.Image = null;
            txt_regId.Clear();
            txt_libId.Clear();
            txt_lib.Clear();
            txt_Id.Clear();
            txt_name.Clear();
            text_roll.Clear();
            txt_department.Clear();
            txt_gender.Clear();
            txt_Contact.Clear();
            txt_email.Clear();
            txt_regId.ReadOnly = false;
            txt_libId.ReadOnly = false;
            grid_entry.DataSource = null;
            book_trans.DataSource = null;
            chart1.Series.Clear();
            chart1.Titles.Clear();


        }
        private void Student_Info_Load(object sender, EventArgs e)
        {

        }

        
        private void chart1_Click(object sender, EventArgs e)
        {

        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void chart1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
