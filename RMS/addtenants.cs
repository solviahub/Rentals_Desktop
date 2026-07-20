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
    public partial class addtenants : Form
    {
        public addtenants()
        {
            InitializeComponent();
            btn_save.Click += btn_save_Click;
            btn_clear.Click += btn_clear_Click;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            string inRelationship = checkBox1.Checked ? "Yes" : "No";

            SqlConnection con = Database.GetConnection();
            con.Open();
            string query = "INSERT INTO Tenants (RollNo, TenantName, Gender, DateOfBirth, NationalID, Phone, Email, Address, Occupation, Room, MonthlyFee, DateAdded, Status, InRelationship) VALUES ('"
                + txtroll.Text + "', '"
                + txt_std_name.Text + "', '"
                + cmb_gender.Text + "', '"
                + date_of_birth.Value.ToString("yyyy-MM-dd") + "', '"
                + txt_father.Text + "', '"
                + txt_father_id.Text + "', '"
                + txtemail.Text + "', '"
                + txtaddress.Text + "', '"
                + guna2TextBox1.Text + "', '"
                + cmb_class.Text + "', '"
                + monthly_fee.Text + "', '"
                + admission_date.Value.ToString("yyyy-MM-dd") + "', '"
                + cmb_status.Text + "', '"
                + inRelationship + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Tenant Saved");
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txtroll.Clear();
            txt_std_name.Clear();
            txt_father.Clear();
            txt_father_id.Clear();
            txtemail.Clear();
            txtaddress.Clear();
            guna2TextBox1.Clear();
            monthly_fee.Clear();
        }
    }
}
