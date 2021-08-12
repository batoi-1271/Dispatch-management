using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;


namespace Dispatch_management
{
    public partial class FRMThongKeCVDen : Form
    {
        public FRMThongKeCVDen()
        {
            InitializeComponent();
            cboNam.DataSource = setYear();

        }
        Class_ThongKe ob = new Class_ThongKe();

        private void FRMThongKeCVDen_Load(object sender, EventArgs e)
        {
            cboNam.Text = "";

            cboMaCV.DataSource = ob.LoadTB("select * from LOAICONGVAN");
            cboMaCV.DisplayMember = "TenLoaiCV";
            cboMaCV.ValueMember = "MaLoaiCV";
            cboMaCV.Enabled = true;
            this.cboMaCV.SelectedIndex = -1;
        }
        public List<string> setYear()
        {
            List<string> year = new List<string>();
            for (int i = 2015; i <= 2021; i++)
            {
                year.Add(i.ToString());
            }
            return year;
        }

        // Kiểm tra rỗng.
        private Boolean checkDataInput()
        {
            Boolean check = true;

            if (cboThang.Text.Trim() == "")
            {
                errChiTiet.SetError(cboThang, "Bạn không thể để trống tháng");
                check = false;
                return check;
            }
            else
            {
                errChiTiet.Clear();
            }

            if (cboNam.Text.Trim() == "")
            {
                errChiTiet.SetError(cboNam, "Bạn không thể để trống năm!");
                check = false;
                return check;
            }
            else
            {
                errChiTiet.Clear();
            }

            return check;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void ReportCVDen (string sql) 
        {
            DataTable dt = new DataTable();
            dt = ob.LoadTB(sql);
            reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = @"D:\Dispatch management\Dispatch management\Dispatch management\Report_CVDen.rdlc";

            if (dt.Rows.Count > 0)
            {
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "DataSet_CVDen"; 
                rds.Value = dt;
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rds);
                reportViewer1.RefreshReport();
            }
            else
            {
               // MessageBox.Show("No Data", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnBaocao_Click(object sender, EventArgs e)
        {
            //Boolean check = true;
            if (cboMaCV.Text.Trim() == "")
            {
                errChiTiet.SetError(cboMaCV, "Bạn không thể để trống!");
            }
            else
            {
                string sql = "select * from CONGVANDEN where MaLoaiCV = '" + cboMaCV.SelectedValue.ToString() + "'";
                ReportCVDen(sql);
                errChiTiet.Clear();
            }
            
            
        }

        private void cboThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select * from CONGVANDEN where month(NgayDen) = '" + cboThang.SelectedItem.ToString() + "'";
            ReportCVDen(sql);
        }

        private void cboNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select * from CONGVANDEN where year(NgayDen) = '" + cboNam.SelectedItem.ToString() + "'";
            ReportCVDen(sql);
        }

        private void cboMaCV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            cboMaCV.SelectedIndex = -1;
            cboThang.Text = "";
            cboNam.Text = "";
            errChiTiet.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Boolean ck = checkDataInput();
            if (ck == true)
            {
                string sql = "select * from CONGVANDEN where month(NgayDen) = '" + cboThang.SelectedItem.ToString() + "' and year(NgayDen) = '" + cboNam.SelectedItem.ToString() + "'";
                ReportCVDen(sql);
            }
        }
    }
}
