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
    public partial class addbooking : Form
    {
        public addbooking()
        {
            InitializeComponent();
            btn_save.Click += btn_save_Click;
            btn_clear.Click += btn_clear_Click;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            SqlConnection con = Database.GetConnection();
            con.Open();
            string query = "INSERT INTO Bookings (BookingCode, TenantName, Item, Room, MonthlyFee, StartDate, EndDate, Status) VALUES ('"
                + txtroll.Text + "', '"
                + txt_std_name.Text + "', '"
                + guna2TextBox1.Text + "', '"
                + cmb_class.Text + "', '"
                + monthly_fee.Text + "', '"
                + admission_date.Value.ToString("yyyy-MM-dd") + "', '"
                + guna2DateTimePicker1.Value.ToString("yyyy-MM-dd") + "', '"
                + cmb_status.Text + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Booking Saved");
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txtroll.Clear();
            txt_std_name.Clear();
            guna2TextBox1.Clear();
            monthly_fee.Clear();
        }
    }
}
