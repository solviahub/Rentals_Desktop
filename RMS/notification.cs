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
    public partial class notification : UserControl
    {
        public notification()
        {
            InitializeComponent();
            this.Load += notification_Load;
            txtsearch.TextChanged += txtsearch_TextChanged;
            guna2Button1.Click += guna2Button1_Click;
            btn_edit.Click += btn_edit_Click;
            btn_delete.Click += btn_delete_Click;
        }

        private void notification_Load(object sender, EventArgs e)
        {
            LoadData("SELECT * FROM Notifications");
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
            string query = "SELECT * FROM Notifications WHERE Recipient LIKE '%" + txtsearch.Text + "%'";
            LoadData(query);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = Database.GetConnection();
            con.Open();
            string query = "INSERT INTO Notifications (Recipient, Channel, Message) VALUES ('"
                + guna2TextBox1.Text + "', '"
                + monthly_fee.Text + "', '"
                + txt_std_name.Text + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Notification Sent");
            LoadData("SELECT * FROM Notifications");
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["NotificationID"].Value);
            SqlConnection con = Database.GetConnection();
            con.Open();
            string query = "UPDATE Notifications SET Recipient = '" + guna2TextBox1.Text + "', Channel = '" + monthly_fee.Text
                + "', Message = '" + txt_std_name.Text + "' WHERE NotificationID = " + id;
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Notification Updated");
            LoadData("SELECT * FROM Notifications");
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["NotificationID"].Value);
            SqlConnection con = Database.GetConnection();
            con.Open();
            string query = "DELETE FROM Notifications WHERE NotificationID = " + id;
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Notification Deleted");
            LoadData("SELECT * FROM Notifications");
        }
    }
}
