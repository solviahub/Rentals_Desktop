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
    public partial class billgenerator : UserControl
    {
        public billgenerator()
        {
            InitializeComponent();
            this.Load += billgenerator_Load;
            txtsearch.TextChanged += txtsearch_TextChanged;
            guna2Button1.Click += guna2Button1_Click;
            btn_edit.Click += btn_edit_Click;
            btn_delete.Click += btn_delete_Click;
        }

        private void billgenerator_Load(object sender, EventArgs e)
        {
            LoadData("SELECT * FROM RentBills");
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
            string query = "SELECT * FROM RentBills WHERE TenantName LIKE '%" + txtsearch.Text + "%' OR PropertyName LIKE '%" + txtsearch.Text + "%'";
            LoadData(query);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = Database.GetConnection();
            con.Open();
            string query = "INSERT INTO RentBills (PropertyName, TenantName, BillingMonth, Duration, PaymentDay, DueDate) VALUES ('"
                + txt_std_name.Text + "', '"
                + guna2TextBox1.Text + "', '"
                + monthly_fee.Text + "', '"
                + guna2TextBox2.Text + "', '"
                + guna2TextBox3.Text + "', '"
                + admission_date.Value.ToString("yyyy-MM-dd") + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Bill Generated");
            LoadData("SELECT * FROM RentBills");
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            int billId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["RentBillID"].Value);
            SqlConnection con = Database.GetConnection();
            con.Open();
            string query = "UPDATE RentBills SET PropertyName = '" + txt_std_name.Text + "', TenantName = '" + guna2TextBox1.Text
                + "', BillingMonth = '" + monthly_fee.Text + "', Duration = '" + guna2TextBox2.Text
                + "', PaymentDay = '" + guna2TextBox3.Text + "' WHERE RentBillID = " + billId;
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Bill Updated");
            LoadData("SELECT * FROM RentBills");
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            int billId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["RentBillID"].Value);
            SqlConnection con = Database.GetConnection();
            con.Open();
            string query = "DELETE FROM RentBills WHERE RentBillID = " + billId;
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Bill Deleted");
            LoadData("SELECT * FROM RentBills");
        }
    }
}
