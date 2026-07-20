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
    public partial class waterbill : UserControl
    {
        public waterbill()
        {
            InitializeComponent();
            this.Load += waterbill_Load;
            txtsearch.TextChanged += txtsearch_TextChanged;
            guna2Button1.Click += guna2Button1_Click;
            btn_edit.Click += btn_edit_Click;
            btn_delete.Click += btn_delete_Click;
        }

        private void waterbill_Load(object sender, EventArgs e)
        {
            LoadData("SELECT * FROM WaterBills");
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
            string query = "SELECT * FROM WaterBills WHERE TenantUnit LIKE '%" + txtsearch.Text + "%'";
            LoadData(query);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            double previous = double.Parse(monthly_fee.Text);
            double current = double.Parse(guna2TextBox2.Text);
            double rate = double.Parse(guna2TextBox4.Text);
            double fixedCharge = double.Parse(guna2TextBox5.Text);

            double consumption = current - previous;
            double total = (consumption * rate) + fixedCharge;

            guna2TextBox3.Text = consumption.ToString();
            txtTotalStudents.Text = total.ToString();

            SqlConnection con = Database.GetConnection();
            con.Open();
            string query = "INSERT INTO WaterBills (TenantUnit, ReadingMonth, PreviousReading, CurrentReading, UnitsRate, FixedCharge, TotalAmount) VALUES ('"
                + guna2TextBox1.Text + "', '"
                + txt_std_name.Text + "', '"
                + previous + "', '"
                + current + "', '"
                + rate + "', '"
                + fixedCharge + "', '"
                + total + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Water Bill Generated");
            LoadData("SELECT * FROM WaterBills");
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            int waterId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["WaterBillID"].Value);
            SqlConnection con = Database.GetConnection();
            con.Open();
            string query = "UPDATE WaterBills SET TenantUnit = '" + guna2TextBox1.Text + "', ReadingMonth = '" + txt_std_name.Text
                + "' WHERE WaterBillID = " + waterId;
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Water Bill Updated");
            LoadData("SELECT * FROM WaterBills");
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            int waterId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["WaterBillID"].Value);
            SqlConnection con = Database.GetConnection();
            con.Open();
            string query = "DELETE FROM WaterBills WHERE WaterBillID = " + waterId;
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Water Bill Deleted");
            LoadData("SELECT * FROM WaterBills");
        }
    }
}
