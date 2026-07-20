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
    public partial class tenants : UserControl
    {
        public tenants()
        {
            InitializeComponent();
            this.Load += tenants_Load;
            txtsearch.TextChanged += txtsearch_TextChanged;
            btn_edit.Click += btn_edit_Click;
            btn_delete.Click += btn_delete_Click;
        }

        private void tenants_Load(object sender, EventArgs e)
        {
            LoadData("SELECT * FROM Tenants");
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
            string query = "SELECT * FROM Tenants WHERE TenantName LIKE '%" + txtsearch.Text + "%' OR RollNo LIKE '%" + txtsearch.Text + "%'";
            LoadData(query);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            addtenants pro = new addtenants();
            pro.Show();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            addtenants pro = new addtenants();
            pro.Show();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            string rollNo = dataGridView1.CurrentRow.Cells["RollNo"].Value.ToString();
            SqlConnection con = Database.GetConnection();
            con.Open();
            string query = "DELETE FROM Tenants WHERE RollNo = '" + rollNo + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Tenant Deleted");
            LoadData("SELECT * FROM Tenants");
        }
    }
}
