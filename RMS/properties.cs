using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RMS
{
    public partial class properties : UserControl
    {
        public properties()
        {
            InitializeComponent();
            this.Load += properties_Load;
            txtsearch.TextChanged += txtsearch_TextChanged;
            btn_edit.Click += btn_edit_Click;
            btn_delete.Click += btn_delete_Click;
        }

        private void properties_Load(object sender, EventArgs e)
        {
            LoadData("SELECT * FROM Properties");
        }

        private void LoadData(string query)
        {
            SqlConnection con = Database.GetConnection();
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            txtTotalStudents.Text = dt.Rows.Count.ToString();
            con.Close();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Properties WHERE PropertyName LIKE '%" + txtsearch.Text + "%' OR RollNo LIKE '%" + txtsearch.Text + "%'";
            LoadData(query);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            addproperty pro = new addproperty();
            pro.Show();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            addproperty pro = new addproperty();
            pro.Show();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            string rollNo = dataGridView1.CurrentRow.Cells["RollNo"].Value.ToString();
            SqlConnection con = Database.GetConnection();
            con.Open();
            string query = "DELETE FROM Properties WHERE RollNo = '" + rollNo + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Property Deleted");
            LoadData("SELECT * FROM Properties");
        }
    }
}
