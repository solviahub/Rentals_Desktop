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

namespace RMS
{
    public partial class settings : UserControl
    {
        public settings()
        {
            InitializeComponent();
            this.Load += settings_Load;
            txtsearch.TextChanged += txtsearch_TextChanged;
            guna2Button1.Click += guna2Button1_Click;
            btn_edit.Click += btn_edit_Click;
            btn_delete.Click += btn_delete_Click;
        }

        private void settings_Load(object sender, EventArgs e)
        {
            LoadData("SELECT * FROM Settings");
        }

        private void LoadData(string query)
        {
            SqlConnection con = Database.GetConnection();
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Settings WHERE CompanyName LIKE '%" + txtsearch.Text + "%'";
            LoadData(query);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = Database.GetConnection();
            con.Open();
            string query = "INSERT INTO Settings (CompanyName, RegistrationNo, Phone, Email, Address, Currency, TaxRate) VALUES ('"
                + guna2TextBox1.Text + "', '"
                + txt_std_name.Text + "', '"
                + monthly_fee.Text + "', '"
                + guna2TextBox2.Text + "', '"
                + guna2TextBox3.Text + "', '"
                + guna2TextBox4.Text + "', '"
                + guna2TextBox5.Text + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Settings Saved");
            LoadData("SELECT * FROM Settings");
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["SettingID"].Value);
            SqlConnection con = Database.GetConnection();
            con.Open();
            string query = "UPDATE Settings SET CompanyName = '" + guna2TextBox1.Text + "', RegistrationNo = '" + txt_std_name.Text
                + "', Phone = '" + monthly_fee.Text + "', Email = '" + guna2TextBox2.Text
                + "', Address = '" + guna2TextBox3.Text + "', Currency = '" + guna2TextBox4.Text
                + "', TaxRate = '" + guna2TextBox5.Text + "' WHERE SettingID = " + id;
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Settings Updated");
            LoadData("SELECT * FROM Settings");
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["SettingID"].Value);
            SqlConnection con = Database.GetConnection();
            con.Open();
            string query = "DELETE FROM Settings WHERE SettingID = " + id;
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Settings Deleted");
            LoadData("SELECT * FROM Settings");
        }
    }
}
