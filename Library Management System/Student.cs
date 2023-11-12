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

namespace Library_Management_System
{
    public partial class Student : Form
    {
       public static string connect = ConfigurationManager.ConnectionStrings["library_Management_System"].ConnectionString;
        public SqlConnection conn = new SqlConnection(connect);
       
           
        public Student()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (name.Text == "")
                {
                    MessageBox.Show("Student Name is Mandarary");

                }
                else
                {
                    conn.Open();


                    SqlCommand sc = new SqlCommand("insert into students values( @name,@roll,@age,@phone,@email)", conn);
                    sc.Parameters.AddWithValue("@name", name.Text);
                    sc.Parameters.AddWithValue("@roll", roll.Text);
                    sc.Parameters.AddWithValue("@age", age.Text);
                    sc.Parameters.AddWithValue("@phone", phone.Text);
                    sc.Parameters.AddWithValue("@email", email.Text);

                    //SqlParameter p1 = new SqlParameter("@name", SqlDbType.VarChar);
                    //sc.Parameters.Add(p1).Value = name.Text;
                    //SqlParameter p2 = new SqlParameter("@roll", SqlDbType.VarChar);
                    //sc.Parameters.Add(p2).Value = roll.Text;

                    //SqlParameter p3 = new SqlParameter("@age", SqlDbType.VarChar);
                    //sc.Parameters.Add(p3).Value = age.Text ;

                    //SqlParameter p4 = new SqlParameter("@phone", SqlDbType.VarChar);
                    //sc.Parameters.Add(p4).Value = phone.Text;

                    //SqlParameter p5 = new SqlParameter("@email", SqlDbType.VarChar);
                    //sc.Parameters.Add(p5).Value = email.Text;
                             
                    int i = sc.ExecuteNonQuery();

                    if (i > 0)
                    {
                        MessageBox.Show("Data Inserted Successfully");
                        clear();
                        refresh();
              
                    }
                    else
                    {
                        MessageBox.Show("Data Not Inserted");
                        conn.Close();
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Error in Inserting :" + x);

            }
            
        }

       

        private void button5_Click(object sender, EventArgs e)
        {
           try
            {
                
                conn.Open();
                 SqlCommand sc = new SqlCommand("update students set stud_name=@name,stud_roll_no = @roll, stud_age = @age, stud_phone_no = @phone, stud_email = @email where stud_id=@id", conn);

                    sc.Parameters.AddWithValue("@id", id.Text);
                    sc.Parameters.AddWithValue("@name", name.Text);
                    sc.Parameters.AddWithValue("@roll", roll.Text);
                    sc.Parameters.AddWithValue("@age", age.Text);
                    sc.Parameters.AddWithValue("@phone", phone.Text);
                    sc.Parameters.AddWithValue("@email", email.Text);

                    int i = sc.ExecuteNonQuery();
                    conn.Close();
                    if (i > 0)
                    {
                        MessageBox.Show("Data Successfully Updated");
                    clear();
                    refresh();
                    }
                    else
                    {
                        MessageBox.Show("Data Not Update");
                    }
                
            }

            catch (Exception x)
            {
                MessageBox.Show("Error in Updating :" + x);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                
                conn.Open();
                SqlCommand sc = new SqlCommand("delete students where stud_id=@id", conn);

                sc.Parameters.AddWithValue("@id", id.Text);

                int i = sc.ExecuteNonQuery();
                conn.Close();
                if (i > 0)
                {
                    MessageBox.Show("Successfully Deleted");
                    refresh();
                }
                else
                {
                    MessageBox.Show("Select Data");
                }
            }
            catch(Exception x)
            {
                MessageBox.Show("Error in Deleting :"+x);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string val = textBox1.Text;

                SqlConnection conn = new SqlConnection(connect);
                conn.Open();

                SqlDataAdapter sda = new SqlDataAdapter("Select * from students where stud_id like '% " + val + "%'OR stud_name like'%" + val + "%' OR stud_roll_no like'%" + val + "%' OR stud_phone_no like'%" + val + "%'", conn);

                DataTable dt = new DataTable();
                sda.Fill(dt);

                dataGridView.DataSource = dt;
                refresh();
                conn.Close();

            }
            catch (Exception x)
            {
                MessageBox.Show("Error in Selecting" + x);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        public void clear()  
        {
            id.Text = "";
            name.Text = "";
            roll.Text = "";
            age.Text = "";
            phone.Text = "";
            email.Text = "";
        }
        public void refresh()
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select * from students",conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView.DataSource = dt;
           
        }

        
        private void button7_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    } 
