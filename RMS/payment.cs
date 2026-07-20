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
    public partial class payment : UserControl
    {
        public payment()
        {
            InitializeComponent();
            this.Load += payment_Load;
            txtsearch.TextChanged += txtsearch_TextChanged;
            btn_delete.Click += btn_delete_Click;
        }

        private void payment_Load(object sender, EventArgs e)
        {
            LoadData("SELECT * FROM Payments");
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
            string query = "SELECT * FROM Payments WHERE TenantName LIKE '%" + txtsearch.Text + "%' OR TaxID LIKE '%" + txtsearch.Text + "%'";
            LoadData(query);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            addpayment pro = new addpayment();
            pro.Show();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            string taxId = dataGridView1.CurrentRow.Cells["TaxID"].Value.ToString();
            SqlConnection con = Database.GetConnection();
            con.Open();
            string query = "DELETE FROM Payments WHERE TaxID = '" + taxId + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Payment Deleted");
            LoadData("SELECT * FROM Payments");
        }
    }
}
