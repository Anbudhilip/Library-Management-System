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

namespace LIBRARY_MANAGEMENT_SYSTEM
{
    public partial class Entry_Register : Form
    {
        public Entry_Register()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["library_Management_System"].ConnectionString);
        private void Entry_Register_Load(object sender, EventArgs e)
        {
            try
            {
                SqlCommand sc = new SqlCommand("trans_Record", conn);
                sc.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(sc);
                DataSet ds = new DataSet();
                sda.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];

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

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap imagebmp = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(imagebmp, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
            e.Graphics.DrawImage(imagebmp, 120, 20);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();
        }
    }
}
