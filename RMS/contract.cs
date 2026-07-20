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
    public partial class contract : UserControl
    {
        public contract()
        {
            InitializeComponent();
            this.Load += contract_Load;
            txtsearch.TextChanged += txtsearch_TextChanged;
            btn_add.Click += btn_add_Click;
            btn_edit.Click += btn_edit_Click;
            btn_delete.Click += btn_delete_Click;
            guna2Button1.Click += guna2Button1_Click;
            guna2Button2.Click += guna2Button2_Click;
            guna2Button3.Click += guna2Button3_Click;
            guna2Button4.Click += guna2Button4_Click;
        }

        private void contract_Load(object sender, EventArgs e)
        {
            LoadData("SELECT * FROM Contracts");
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
            string query = "SELECT * FROM Contracts WHERE TenantName LIKE '%" + txtsearch.Text + "%' OR PropertyName LIKE '%" + txtsearch.Text + "%'";
            LoadData(query);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            SqlConnection con = Database.GetConnection();
            con.Open();
            string query = "INSERT INTO Contracts (PropertyName, TenantName, StartDate, EndDate, MonthlyPayment, Duration, PaymentDay, Note) VALUES ('"
                + txt_std_name.Text + "', '"
                + guna2TextBox1.Text + "', '"
                + guna2DateTimePicker1.Value.ToString("yyyy-MM-dd") + "', '"
                + admission_date.Value.ToString("yyyy-MM-dd") + "', '"
                + monthly_fee.Text + "', '"
                + guna2TextBox2.Text + "', '"
                + guna2TextBox3.Text + "', '"
                + txtaddress.Text + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Contract Added");
            LoadData("SELECT * FROM Contracts");
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            int contractId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ContractID"].Value);
            SqlConnection con = Database.GetConnection();
            con.Open();
            string query = "UPDATE Contracts SET PropertyName = '" + txt_std_name.Text + "', TenantName = '" + guna2TextBox1.Text
                + "', MonthlyPayment = '" + monthly_fee.Text + "', Duration = '" + guna2TextBox2.Text
                + "', PaymentDay = '" + guna2TextBox3.Text + "', Note = '" + txtaddress.Text
                + "' WHERE ContractID = " + contractId;
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Contract Updated");
            LoadData("SELECT * FROM Contracts");
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            int contractId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ContractID"].Value);
            SqlConnection con = Database.GetConnection();
            con.Open();
            string query = "DELETE FROM Contracts WHERE ContractID = " + contractId;
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Contract Deleted");
            LoadData("SELECT * FROM Contracts");
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Contract Generated");
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Printing Contract");
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Contract Emailed");
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("PDF Generated");
        }
    }
}
