using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMS
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void clear_Click(object sender, EventArgs e)
        {
            if (txtuser.Text == "" && txtpass.Text == "")
            {
                MessageBox.Show("Fields Are Empty");
            }
            else
            {
                txtuser.Clear();
                txtpass.Clear();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtpass.PasswordChar = '\0';
                checkBox1.Text = "Hide Password";
            }
            else
            {
                txtpass.PasswordChar = '*';
                checkBox1.Text = "Show Password";
            }
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (txtuser.Text == "soluiahub" && txtpass.Text == "1234")
            {
                Form1 f1 = new Form1();
                f1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please Invalid Username or Password");
            }
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
