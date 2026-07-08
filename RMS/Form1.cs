using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dashboard1.Visible = false;
            tenants1.Visible = false;
            properties1.Visible = false;
            contract1.Visible = false;
            booking1.Visible = false;
            billgenerator1.Visible = false;
            electricitybill1.Visible = false;
            waterbill1.Visible = false;
            payment1.Visible = false;
            report1.Visible = false;
            notification1.Visible = false;
            settings1.Visible = false;


        }

        private void dashboard_Click(object sender, EventArgs e)
        {
            dashboard1.Visible = true;
            dashboard1.BringToFront();

            tenants1.Visible = false;
            properties1.Visible = false;
            contract1.Visible = false;
            booking1.Visible = false;
            billgenerator1.Visible = false;
            electricitybill1.Visible = false;
            waterbill1.Visible = false;
            payment1.Visible = false;
            report1.Visible = false;
            notification1.Visible = false;
            settings1.Visible = false;
        }

        private void btn_staff_Click(object sender, EventArgs e)
        {
            tenants1.Visible = true;
            tenants1.BringToFront();

            dashboard1.Visible = false;
            properties1.Visible = false;
            contract1.Visible = false;
            booking1.Visible = false;
            billgenerator1.Visible = false;
            electricitybill1.Visible = false;
            waterbill1.Visible = false;
            payment1.Visible = false;
            report1.Visible = false;
            notification1.Visible = false;
            settings1.Visible = false;
        }

        private void menu_Click(object sender, EventArgs e)
        {
            properties1.Visible = true;
            properties1.BringToFront();

            dashboard1.Visible = false;
            tenants1.Visible = false;
            contract1.Visible = false;
            booking1.Visible = false;
            billgenerator1.Visible = false;
            electricitybill1.Visible = false;
            waterbill1.Visible = false;
            payment1.Visible = false;
            report1.Visible = false;
            notification1.Visible = false;
            settings1.Visible = false;
        }

        private void btn_report_Click(object sender, EventArgs e)
        {
            contract1.Visible = true;
            contract1.BringToFront();

            dashboard1.Visible = false;
            tenants1.Visible = false;
            properties1.Visible = false;
            booking1.Visible = false;
            billgenerator1.Visible = false;
            electricitybill1.Visible = false;
            waterbill1.Visible = false;
            payment1.Visible = false;
            report1.Visible = false;
            notification1.Visible = false;
            settings1.Visible = false;
        }

        private void menu3_Click(object sender, EventArgs e)
        {
            booking1.Visible = true;
            booking1.BringToFront();

            dashboard1.Visible = false;
            tenants1.Visible = false;
            properties1.Visible = false;
            contract1.Visible = false;
            billgenerator1.Visible = false;
            electricitybill1.Visible = false;
            waterbill1.Visible = false;
            payment1.Visible = false;
            report1.Visible = false;
            notification1.Visible = false;
            settings1.Visible = false;
        }

        private void menu4_Click(object sender, EventArgs e)
        {
            billgenerator1.Visible = true;
            billgenerator1.BringToFront();


            dashboard1.Visible = false;
            tenants1.Visible = false;
            properties1.Visible = false;
            contract1.Visible = false;
            booking1.Visible = false;
            electricitybill1.Visible = false;
            waterbill1.Visible = false;
            payment1.Visible = false;
            report1.Visible = false;
            notification1.Visible = false;
            settings1.Visible = false;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            electricitybill1.Visible = true;
            electricitybill1.BringToFront();

            dashboard1.Visible = false;
            tenants1.Visible = false;
            properties1.Visible = false;
            contract1.Visible = false;
            booking1.Visible = false;
            billgenerator1.Visible = false;
            waterbill1.Visible = false;
            payment1.Visible = false;
            report1.Visible = false;
            notification1.Visible = false;
            settings1.Visible = false;
        }

        private void btn_timetable_Click(object sender, EventArgs e)
        {
            waterbill1.Visible = true;
            waterbill1.BringToFront();

            dashboard1.Visible = false;
            tenants1.Visible = false;
            properties1.Visible = false;
            contract1.Visible = false;
            booking1.Visible = false;
            billgenerator1.Visible = false;
            electricitybill1.Visible = false;
            payment1.Visible = false;
            report1.Visible = false;
            notification1.Visible = false;
            settings1.Visible = false;
        }

        private void menu5_Click(object sender, EventArgs e)
        {
            payment1.Visible = true;
            payment1.BringToFront();

            dashboard1.Visible = false;
            tenants1.Visible = false;
            properties1.Visible = false;
            contract1.Visible = false;
            booking1.Visible = false;
            billgenerator1.Visible = false;
            electricitybill1.Visible = false;
            waterbill1.Visible = false;
            report1.Visible = false;
            notification1.Visible = false;
            settings1.Visible = false;
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            report1.Visible = true;
            report1.BringToFront();

            dashboard1.Visible = false;
            tenants1.Visible = false;
            properties1.Visible = false;
            contract1.Visible = false;
            booking1.Visible = false;
            billgenerator1.Visible = false;
            electricitybill1.Visible = false;
            waterbill1.Visible = false;
            payment1.Visible = false;
            notification1.Visible = false;
            settings1.Visible = false;
        }

        private void menu2_Click(object sender, EventArgs e)
        {
            notification1.Visible = true;
            notification1.BringToFront();

            dashboard1.Visible = false;
            tenants1.Visible = false;
            properties1.Visible = false;
            contract1.Visible = false;
            booking1.Visible = false;
            billgenerator1.Visible = false;
            electricitybill1.Visible = false;
            waterbill1.Visible = false;
            payment1.Visible = false;
            report1.Visible = false;
            settings1.Visible = false;
            
        }

        private void btn_settings_Click(object sender, EventArgs e)
        {
            settings1.Visible = true;
            settings1.BringToFront();

            dashboard1.Visible = false;
            tenants1.Visible = false;
            properties1.Visible = false;
            contract1.Visible = false;
            booking1.Visible = false;
            billgenerator1.Visible = false;
            electricitybill1.Visible = false;
            waterbill1.Visible = false;
            payment1.Visible = false;
            report1.Visible = false;
            notification1.Visible = false;
            
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
           
            login log = new login();
            log.Show();
            this.Hide();
        }
    }
}
