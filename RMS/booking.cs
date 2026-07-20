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
    public partial class booking : UserControl
    {
        public booking()
        {
            InitializeComponent();
            this.Load += booking_Load;
            txtsearch.TextChanged += txtsearch_TextChanged;
            btn_delete.Click += btn_delete_Click;
        }

        private void booking_Load(object sender, EventArgs e)
        {
            LoadData("SELECT * FROM Bookings");
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
            string query = "SELECT * FROM Bookings WHERE TenantName LIKE '%" + txtsearch.Text + "%' OR BookingCode LIKE '%" + txtsearch.Text + "%'";
            LoadData(query);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            addbooking pro = new addbooking();
            pro.Show();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            string code = dataGridView1.CurrentRow.Cells["BookingCode"].Value.ToString();
            SqlConnection con = Database.GetConnection();
            con.Open();
            string query = "DELETE FROM Bookings WHERE BookingCode = '" + code + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Booking Deleted");
            LoadData("SELECT * FROM Bookings");
        }
    }
}
