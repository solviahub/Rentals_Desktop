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
    public partial class addproperty : Form
    {
        public addproperty()
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
            string query = "INSERT INTO Properties (RollNo, PropertyName, Category, Owner, Units, Address, MonthlyPayment, Status, DateAdded) VALUES ('"
                + txtroll.Text + "', '"
                + txt_std_name.Text + "', '"
                + cmb_gender.Text + "', '"
                + txt_father.Text + "', '"
                + txtemail.Text + "', '"
                + txtaddress.Text + "', '"
                + monthly_fee.Text + "', '"
                + cmb_status.Text + "', '"
                + admission_date.Value.ToString("yyyy-MM-dd") + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Property Saved");
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            SqlConnection con = Database.GetConnection();
            con.Open();
            string query = "UPDATE Properties SET PropertyName = '" + txt_std_name.Text + "', Category = '" + cmb_gender.Text
                + "', Owner = '" + txt_father.Text + "', Units = '" + txtemail.Text + "', Address = '" + txtaddress.Text
                + "', MonthlyPayment = '" + monthly_fee.Text + "', Status = '" + cmb_status.Text
                + "' WHERE RollNo = '" + txtroll.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Property Updated");
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txtroll.Clear();
            txt_std_name.Clear();
            txt_father.Clear();
            txtemail.Clear();
            txtaddress.Clear();
            monthly_fee.Clear();
        }
    }
}
