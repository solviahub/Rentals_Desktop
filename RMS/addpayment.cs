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
    public partial class addpayment : Form
    {
        public addpayment()
        {
            InitializeComponent();
            btn_save.Click += btn_save_Click;
            btn_edit.Click += btn_edit_Click;
            btn_clear.Click += btn_clear_Click;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            SqlConnection con = Database.GetConnection();
            con.Open();
            string query = "INSERT INTO Payments (TaxID, PropertyName, TenantName, Amount, PaymentType, PaymentMethod, DueDate, PayDate, Status) VALUES ('"
                + txtroll.Text + "', '"
                + txt_std_name.Text + "', '"
                + txt_father.Text + "', '"
                + txtemail.Text + "', '"
                + cmb_gender.Text + "', '"
                + guna2ComboBox1.Text + "', '"
                + admission_date.Value.ToString("yyyy-MM-dd") + "', '"
                + guna2DateTimePicker1.Value.ToString("yyyy-MM-dd") + "', '"
                + cmb_status.Text + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Payment Saved");
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            SqlConnection con = Database.GetConnection();
            con.Open();
            string query = "UPDATE Payments SET PropertyName = '" + txt_std_name.Text + "', TenantName = '" + txt_father.Text
                + "', Amount = '" + txtemail.Text + "', PaymentType = '" + cmb_gender.Text
                + "', PaymentMethod = '" + guna2ComboBox1.Text + "', DueDate = '" + admission_date.Value.ToString("yyyy-MM-dd")
                + "', PayDate = '" + guna2DateTimePicker1.Value.ToString("yyyy-MM-dd") + "', Status = '" + cmb_status.Text
                + "' WHERE TaxID = '" + txtroll.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Payment Updated");
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txtroll.Clear();
            txt_std_name.Clear();
            txt_father.Clear();
            txtemail.Clear();
        }
    }
}
