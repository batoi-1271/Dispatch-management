using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;


namespace Dispatch_management
{
    public partial class FRMThongKeCVDi : Form
    {
        public FRMThongKeCVDi()
        {
            InitializeComponent();
            cboNam.DataSource = setYear();

        }
        Class_ThongKe ob = new Class_ThongKe();
        private void FRMThongKeCVDi_Load(object sender, EventArgs e)
        {
            cboNam.Text = "";

            cboMaCV.DataSource = ob.LoadTB("select * from LOAICONGVAN");
            cboMaCV.DisplayMember = "TenLoaiCV";
            cboMaCV.ValueMember = "MaLoaiCV";
            cboMaCV.Enabled = true;
            this.cboMaCV.SelectedIndex = -1;
            //this.reportViewer1.RefreshReport();
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

        public void ReportCVDi(string sql)
        {
            DataTable dt = new DataTable();
            dt = ob.LoadTB(sql);
            reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = @"D:\Dispatch management\Dispatch management\Dispatch management\Report_CVDi.rdlc";

            if (dt.Rows.Count > 0)
            {
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "DataSet_CVDi";
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

        private void button1_Click(object sender, EventArgs e)
        {
            Boolean ck = checkDataInput();
            if (ck == true)
            {
                string sql = "select * from CONGVANDI where month(NgayDi) = '" + cboThang.SelectedItem.ToString() + "' and year(NgayDi) = '" + cboNam.SelectedItem.ToString() + "'";
                ReportCVDi(sql);
            }
            
        }

        private void cboThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select * from CONGVANDI where month(NgayDi) = '" + cboThang.SelectedItem.ToString() + "'";
            ReportCVDi(sql);
        }

        private void cboNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select * from CONGVANDI where year(NgayDi) = '" + cboNam.SelectedItem.ToString() + "'";
            ReportCVDi(sql);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cboMaCV.SelectedIndex = -1;
            cboThang.Text = "";
            cboNam.Text = "";
            errChiTiet.Clear();
        }

        private void btnBaocao_Click(object sender, EventArgs e)
        {
            if (cboMaCV.Text.Trim() == "")
            {
                errChiTiet.SetError(cboMaCV, "Bạn không thể để trống!");
            }
            else
            {
                string sql = "select * from CONGVANDI where MaLoaiCV = '" + cboMaCV.SelectedValue.ToString() + "'";
                ReportCVDi(sql);
                errChiTiet.Clear();
            }
        }
    }
}
