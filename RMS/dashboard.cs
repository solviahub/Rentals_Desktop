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
    public partial class dashboard : UserControl
    {
        public dashboard()
        {
            InitializeComponent();
            this.Load += dashboard_Load;
        }

        private void dashboard_Load(object sender, EventArgs e)
        {
            SqlConnection con = Database.GetConnection();
            con.Open();

            SqlDataAdapter da1 = new SqlDataAdapter("SELECT * FROM Tenants", con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;

            SqlDataAdapter da2 = new SqlDataAdapter("SELECT * FROM Payments", con);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;

            txtTotalStudents.Text = dt1.Rows.Count.ToString();

            con.Close();
        }
    }
}
