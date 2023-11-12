using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LIBRARY_MANAGEMENT_SYSTEM
{
    public partial class Exercise1 : Form
    {
        public Exercise1()
        {
            InitializeComponent();
        }

        private void Exercise1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pie.Value += 1;
            pie.Text = pie.Value.ToString() + "%";
            if(pie.Value == 100)
            {
                timer1.Enabled = false;
              Home_Page obj = new Home_Page();
                
                obj.Show();
                this.Hide();
            }
        }

        private void pie_Click(object sender, EventArgs e)
        {

        }
    }
}






    
