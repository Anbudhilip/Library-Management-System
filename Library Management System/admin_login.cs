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

namespace LIBRARY_MANAGEMENT_SYSTEM
{
    public partial class admin_login : Form
    {
        public admin_login()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["library_Management_System"].ConnectionString);
        
        string captchatext;
      
       //private string uname;
        //public string  Name1 { get { return txt_uName.Text; } set { txt_uName.Text = value; } }

        private void admin_login_Load(object sender, EventArgs e)
        {
            captchatext = GenerateRandomCaptchaText();
            cap_gen.Image = GenerateCaptchaImage(captchatext);

            //a obj3 = new dashboard();
            //obj3.u_name.Text = "This";
            //obj3.Show();

        }
        void refresh()
        {
           
            txt_captcha.Clear();
            txt_uName.Clear();
            txt_pass.Clear();
         
        }
         
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txt_uName.Text) && !string.IsNullOrEmpty(txt_pass.Text))
                {
                    SqlCommand sc = new SqlCommand("admin_log", conn);
                    sc.CommandType = CommandType.StoredProcedure;

                    SqlParameter p2 = new SqlParameter("@uname", SqlDbType.VarChar);
                    sc.Parameters.Add(p2).Value = txt_uName.Text.ToString();

                    SqlParameter p3 = new SqlParameter("@pwd", SqlDbType.VarChar);
                    sc.Parameters.Add(p3).Value = txt_pass.Text.ToString();


                    SqlDataAdapter sda = new SqlDataAdapter(sc);
                    DataSet ds = new DataSet();
                    sda.Fill(ds);

                    if (ds.Tables[0].Rows.Count != 0)
                    {                      
                    
                        if (string.Equals(txt_captcha.Text, captchatext, StringComparison.OrdinalIgnoreCase))
                        {
                            dashboard db = new dashboard();

                            db.librarian_name = txt_uName.Text;                  //   By Property pass value to Dashboard
                            this.Close();
                            db.Show();
                        }
                        else
                        {

                            MessageBox.Show("Invaild Captcha", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            refresh();
                            captchatext = GenerateRandomCaptchaText();
                            cap_gen.Image = GenerateCaptchaImage(captchatext);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invaild UserName Or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        refresh();
                        captchatext = GenerateRandomCaptchaText();
                        cap_gen.Image = GenerateCaptchaImage(captchatext);
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txt_pass.UseSystemPasswordChar = true;
            }
            else
            {
                txt_pass.UseSystemPasswordChar = false;
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            captchatext = GenerateRandomCaptchaText();
            cap_gen.Image = GenerateCaptchaImage(captchatext);

        }
        private Image GenerateCaptchaImage(string text)
        {
            Bitmap image = new Bitmap(cap_gen.Width, cap_gen.Height);
            Graphics graphics = Graphics.FromImage(image);

            // Create a white background
            // graphics.FillRectangle(Brushes.White, 0, 0, image.Width, image.Height);

            // Draw the CAPTCHA text
            graphics.DrawString(text, new Font("Algerian", 16), Brushes.Black, new PointF(10, 10));

            return image;

        }
        private string GenerateRandomCaptchaText()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, 4).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
