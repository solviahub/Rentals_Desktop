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
    public partial class electricitybill : UserControl
    {
        public electricitybill()
        {
            InitializeComponent();
            this.Load += electricitybill_Load;
            txtsearch.TextChanged += txtsearch_TextChanged;
            guna2Button1.Click += guna2Button1_Click;
            btn_edit.Click += btn_edit_Click;
            btn_delete.Click += btn_delete_Click;
        }

        private void electricitybill_Load(object sender, EventArgs e)
        {
            LoadData("SELECT * FROM ElectricityBills");
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
            string query = "SELECT * FROM ElectricityBills WHERE TenantUnit LIKE '%" + txtsearch.Text + "%'";
            LoadData(query);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            double previous = double.Parse(monthly_fee.Text);
            double current = double.Parse(guna2TextBox2.Text);
            double rate = double.Parse(guna2TextBox4.Text);
            double fixedCharge = double.Parse(guna2TextBox5.Text);
            double vat = double.Parse(guna2TextBox6.Text);

            double consumption = current - previous;
            double total = (consumption * rate) + fixedCharge;
            total = total + (total * vat / 100);

            guna2TextBox3.Text = consumption.ToString();
            txtTotalStudents.Text = total.ToString();

            SqlConnection con = Database.GetConnection();
            con.Open();
            string query = "INSERT INTO ElectricityBills (TenantUnit, ReadingMonth, PreviousReading, CurrentReading, UnitsRate, FixedCharge, VatPercent, TotalAmount) VALUES ('"
                + guna2TextBox1.Text + "', '"
                + txt_std_name.Text + "', '"
                + previous + "', '"
                + current + "', '"
                + rate + "', '"
                + fixedCharge + "', '"
                + vat + "', '"
                + total + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Electricity Bill Generated");
            LoadData("SELECT * FROM ElectricityBills");
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            int elecId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ElecBillID"].Value);
            SqlConnection con = Database.GetConnection();
            con.Open();
            string query = "UPDATE ElectricityBills SET TenantUnit = '" + guna2TextBox1.Text + "', ReadingMonth = '" + txt_std_name.Text
                + "' WHERE ElecBillID = " + elecId;
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Electricity Bill Updated");
            LoadData("SELECT * FROM ElectricityBills");
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            int elecId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ElecBillID"].Value);
            SqlConnection con = Database.GetConnection();
            con.Open();
            string query = "DELETE FROM ElectricityBills WHERE ElecBillID = " + elecId;
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Electricity Bill Deleted");
            LoadData("SELECT * FROM ElectricityBills");
        }
    }
}
