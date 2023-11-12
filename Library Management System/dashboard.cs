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
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Configuration;


namespace LIBRARY_MANAGEMENT_SYSTEM
{
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
        }
       private string name;  /// <summary>
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["library_Management_System"].ConnectionString);
        public string librarian_name { get { return name; } set { name = value; } }

        private void dashboard_Load(object sender, EventArgs e)
        {
            lib_name.Text = name;    // Assign Value the property

            nav_message_pannel.Visible = false;
            home_pannel.Visible = true;
           

            txt_time.Text = DateTime.Now.ToString();   // for current time and date
            timer1.Start();



        }

        private void eXISTToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
            
        }

        private void vIEWBOOKSToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aDDSTUDENTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Students pg1 = new Add_Students();
            pg1.Show();

        }

        
        private void aDDNEWBOOKSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Book pg2 = new Add_Book();
            pg2.Show();
        }

        private void iSSUEDBOOKSToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

      

private void rETURNBOOKREGISTERFORMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            return_Book pg3 = new return_Book();
            pg3.Show();

        }

        private void iSSUEBOOKSREGISTERFORMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Issue_book pg4 = new Issue_book();
            pg4.Show();

        }

        private void rETURNBOOKSToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void updateStudentDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Update_Student_Details pg5 = new Update_Student_Details();
            pg5.Show();
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
           

        }

        private void sTUDENTLISTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Student_Info pg6 = new Student_Info();
            pg6.Show();
        }

        private void uPDATEBOOKDETAILSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Update_Book_Details pg7 = new Update_Book_Details();
            pg7.Show();
        }

        private void bookInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Book_Info pg8 = new Book_Info();
            pg8.Show();
        }

        private void pOPULARBOOKSToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void eNTRYLOGBOOKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Entry_Register pg9 = new Entry_Register();
            pg9.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private Image NormalImage;
        private Image HoverImage;

        public Image ImageNormal
        {
            get { return NormalImage; }
            set { NormalImage = value; }
        }

        public Image ImageHover
        {
            get { return HoverImage; }
            set { HoverImage = value; }
        }
        private void button1_MouseHover(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void customerButton1_Click(object sender, EventArgs e)
        {

        }

        private void nToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { System.Diagnostics.Process.Start("notepad.exe"); }
            catch (Exception x)
            {
                MessageBox.Show("Error" + x.Message);
            }
        }

        private void mSWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { System.Diagnostics.Process.Start("word.exe"); }
            catch (Exception x)
            {
                MessageBox.Show("Error" + x.Message);
            }
        }

        private void mSOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { System.Diagnostics.Process.Start("excel.exe"); }
            catch (Exception x)
            {
                MessageBox.Show("Error" + x.Message);
            }
        }

        private void mSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { System.Diagnostics.Process.Start("calc.exe"); }
            catch (Exception x)
            {
                MessageBox.Show("Error" + x.Message);
            }
        }

        private void ckmmandPromptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { System.Diagnostics.Process.Start("cmd.exe"); }
            catch (Exception x)
            {
                MessageBox.Show("Error" + x.Message);
            }
        }

        private void magniferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { System.Diagnostics.Process.Start("magnify.exe"); }

            catch (Exception x)
            {
                MessageBox.Show("Error" + x.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach(dashboard page in this.MdiChildren)
            {
                page.Close();
            }            
                 
        }

        private void bOOKTRANACTIONSREGISTERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Book_Issue_and_Return_Register pg5 = new Book_Issue_and_Return_Register();
            pg5.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You Want to Exist", "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void mESSAGEINNAVBARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nav_message_pannel.Visible = true;
            home_pannel.Visible = false;
           
        }

        private void btn_nav_mess_submit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_nav_mess.Text))
            {
                string query = "update  stud_message set nav_message =@mess";
                SqlCommand sc = new SqlCommand(query,conn);

                SqlParameter p2 = new SqlParameter("@mess", SqlDbType.VarChar);
                sc.Parameters.Add(p2).Value = txt_nav_mess.Text.ToString();
                conn.Open();
                int i = sc.ExecuteNonQuery();
                conn.Close();
                if (i > 0)
                {
                    MessageBox.Show("Successfully Updated", "Password Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refresh();
                }
                else
                {

                    MessageBox.Show("SomeThing Error, Try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    refresh();

                }

            }


        }

        private void btn_home_Click(object sender, EventArgs e)
        {
          
            Home_Page obj = new Home_Page();
            obj.Show();
           
        }

        private void bOOKTRANSACTIONSHISTORYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                BookRecord obj = new BookRecord();
                obj.Show();
            }
           
             catch (Exception x)
            {
                MessageBox.Show("Error" + x.Message);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txt_uname.Text) && !string.IsNullOrEmpty(txt_old_pwd.Text))
                {
                    SqlCommand sc = new SqlCommand("admin_log", conn);
                    sc.CommandType = CommandType.StoredProcedure;

                    SqlParameter p2 = new SqlParameter("@uname", SqlDbType.VarChar);
                    sc.Parameters.Add(p2).Value = txt_uname.Text.ToString();

                    SqlParameter p3 = new SqlParameter("@pwd", SqlDbType.VarChar);
                    sc.Parameters.Add(p3).Value = txt_old_pwd.Text.ToString();

                    conn.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(sc);
                    DataSet ds = new DataSet();
                    sda.Fill(ds);

                    conn.Close();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(txt_newpwd.Text)&& !string.IsNullOrEmpty(txt_cpwd.Text)&& txt_newpwd.Text== txt_cpwd.Text)
                        {
                            string query = "update admin_login set user_pwd=@pwd";


                            SqlCommand Sc1 = new SqlCommand(query, conn);
                            SqlParameter p5 = new SqlParameter("@pwd", SqlDbType.VarChar);
                            Sc1.Parameters.Add(p5).Value = txt_newpwd.Text.ToString();

                            conn.Open();
                            int i = Sc1.ExecuteNonQuery();
                            conn.Close();
                            if (i > 0)
                            {
                                MessageBox.Show("Successfully Updated", "Password Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                refresh();
                            }
                            else
                            {

                                MessageBox.Show("SomeThing Error, Try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                refresh();

                            }
                        }
                    
                        else
                        {

                            MessageBox.Show("New Password and Confirm Password Invaild", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            refresh(); ;

                        }
                    }
                    else
                    {
                        MessageBox.Show("Invaild UserName Or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        refresh();
                    }
                }
                else
                {
                    MessageBox.Show("All Filed Must be Filled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void home_pannel_Paint(object sender, PaintEventArgs e)
        {

        }
        void refresh()
        {
            txt_newpwd.Clear();
            txt_old_pwd.Clear();
            txt_uname.Clear();
            txt_cpwd.Clear();
            txt_nav_mess.Clear();



        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void cHANNGEPASSWORDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            home_pannel.Visible = true;
            nav_message_pannel.Visible = false;
        }
    }
    
}
