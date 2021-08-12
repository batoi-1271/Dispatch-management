using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Odbc;
using Excel = Microsoft.Office.Interop.Excel;


namespace Dispatch_management
{
    public partial class FormTimKiemCVDi : Form
    {
        public FormTimKiemCVDi()
        {
            InitializeComponent();
            cboNam.DataSource = setYear();

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
        Class_TKCVDi ob = new Class_TKCVDi();
        public void updateUI(string sql)
        {

            DataTable dt = new DataTable();
            dt = ob.LoadTable(sql);
            dataGridView1.DataSource = dt; //đổ dữ liệu vào datagridview
            dataGridView1.Refresh();
        }
        private void HienThi()
        {
            string sql1 = "select cvd.STT, cvd.SoCV, cvd.NgayCongVan, cvd.NgayDi, cvd.TrichYeu, lcv.TenLoaiCV, cq.TenCoQuan, ns.TenNhanSu FROM CONGVANDI cvd INNER join LOAICONGVAN lcv on cvd.MaLoaiCV = lcv.MaLoaiCV INner join COQUAN cq  on cvd.MaCoQuan = cq.MaCoQuan inner join NHANSU ns on cvd.MaNS = ns.MaNS";
            updateUI(sql1);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ban co muon Thoat khong", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        // Kiểm tra rỗng.
        private Boolean checkDataInput()
        {
            Boolean check = true;

            if (cboLoaiCV.Text.Trim() == "")
            {
                errChiTiet.SetError(cboLoaiCV, "Bạn không thể để trống loại công văn!");
                check = false;
                return check;
            }
            else
            {
                errChiTiet.Clear();
            }

            if (cboNguoiKG.Text.Trim() == "")
            {
                errChiTiet.SetError(cboNguoiKG, "Bạn không thể để trống tên nhân sự!");
                check = false;
                return check;
            }
            else
            {
                errChiTiet.Clear();
            }


            if (cboNoiGuiDi.Text.Trim() == "")
            {
                errChiTiet.SetError(cboNoiGuiDi, "Bạn không thể để trống địa chỉ!");
                check = false;
                return check;
            }
            else
            {
                errChiTiet.Clear();
            }

            return check;//trường hợp false all
        }

        private void FormTimKiemCVDi_Load(object sender, EventArgs e)
        {

            cboNam.Text = "";

            cboLoaiCV.DataSource = ob.LoadTable("SELECT * FROM LOAICONGVAN");
            cboLoaiCV.DisplayMember = "TenLoaiCV";
            cboLoaiCV.ValueMember = "MaLoaiCV";
            cboLoaiCV.Enabled = true;
            this.cboLoaiCV.SelectedIndex = -1;

            cboNguoiKG.DataSource = ob.LoadTable("SELECT * FROM NHANSU");
            cboNguoiKG.DisplayMember = "TenNhanSu";
            cboNguoiKG.ValueMember = "MaNS";
            cboNguoiKG.Enabled = true;
            this.cboNguoiKG.SelectedIndex = -1;


            cboNoiGuiDi.DataSource = ob.LoadTable("SELECT * FROM COQUAN");
            cboNoiGuiDi.DisplayMember = "TenCoQuan";
            cboNoiGuiDi.ValueMember = "MaCoQuan";
            cboNoiGuiDi.Enabled = true;
            this.cboNoiGuiDi.SelectedIndex = -1;

            HienThi();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Boolean ck = checkDataInput();
            if (ck == true)
            {
                string sql = "select cvd.STT, cvd.SoCV, cvd.NgayCongVan, cvd.NgayDi, cvd.TrichYeu, lcv.TenLoaiCV, cq.TenCoQuan, ns.TenNhanSu FROM CONGVANDI cvd INNER join LOAICONGVAN lcv on cvd.MaLoaiCV = lcv.MaLoaiCV INner join COQUAN cq  on cvd.MaCoQuan = cq.MaCoQuan inner join NHANSU ns on cvd.MaNS = ns.MaNS WHERE lcv.TenLoaiCV='"
                    + cboLoaiCV.Text.ToString() + "' and ns.TenNhanSu = '" + cboNguoiKG.Text.ToString() + "' and TenCoQuan = '" + cboNoiGuiDi.Text.ToString() + "'";
                updateUI(sql);
            }
        }
        private void cboLoaiCV_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select cvd.STT, cvd.SoCV, cvd.NgayCongVan, cvd.NgayDi, cvd.TrichYeu, lcv.TenLoaiCV, cq.TenCoQuan, ns.TenNhanSu FROM CONGVANDI cvd INNER join LOAICONGVAN lcv on cvd.MaLoaiCV = lcv.MaLoaiCV INner join COQUAN cq  on cvd.MaCoQuan = cq.MaCoQuan inner join NHANSU ns on cvd.MaNS = ns.MaNS WHERE lcv.TenLoaiCV='"
                + cboLoaiCV.Text.ToString() + "'";
            updateUI(sql);
        }

        private void cboThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select cvd.STT, cvd.SoCV, cvd.NgayCongVan, cvd.NgayDi, cvd.TrichYeu, lcv.TenLoaiCV, cq.TenCoQuan, ns.TenNhanSu FROM CONGVANDI cvd INNER join LOAICONGVAN lcv on cvd.MaLoaiCV = lcv.MaLoaiCV INner join COQUAN cq  on cvd.MaCoQuan = cq.MaCoQuan inner join NHANSU ns on cvd.MaNS = ns.MaNS WHERE MONTH(NgayDi)='"
                + cboThang.SelectedItem.ToString() + "'";
            updateUI(sql);
        }

        private void cboNoiGuiDi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select cvd.STT, cvd.SoCV, cvd.NgayCongVan, cvd.NgayDi, cvd.TrichYeu, lcv.TenLoaiCV, cq.TenCoQuan, ns.TenNhanSu FROM CONGVANDI cvd INNER join LOAICONGVAN lcv on cvd.MaLoaiCV = lcv.MaLoaiCV INner join COQUAN cq  on cvd.MaCoQuan = cq.MaCoQuan inner join NHANSU ns on cvd.MaNS = ns.MaNS WHERE cq.TenCoQuan='"
                + cboNoiGuiDi.Text.ToString() + "'";
            updateUI(sql);
        }

        private void cboNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select cvd.STT, cvd.SoCV, cvd.NgayCongVan, cvd.NgayDi, cvd.TrichYeu, lcv.TenLoaiCV, cq.TenCoQuan, ns.TenNhanSu FROM CONGVANDI cvd INNER join LOAICONGVAN lcv on cvd.MaLoaiCV = lcv.MaLoaiCV INner join COQUAN cq  on cvd.MaCoQuan = cq.MaCoQuan inner join NHANSU ns on cvd.MaNS = ns.MaNS WHERE YEAR(NgayDi)='"
                + cboNam.SelectedItem.ToString() + "'";
            updateUI(sql);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dptTuNgay.Value = DateTime.Now;
            dptDenNgay.Value = DateTime.Now;
            cboLoaiCV.SelectedIndex = -1;
            cboNoiGuiDi.SelectedIndex = -1;
            cboNguoiKG.SelectedIndex = -1;
            cboThang.Text = "";
            cboNam.Text = "";

            HienThi();
        }

        private void cboNguoiKG_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select cvd.STT, cvd.SoCV, cvd.NgayCongVan, cvd.NgayDi, cvd.TrichYeu, lcv.TenLoaiCV, cq.TenCoQuan, ns.TenNhanSu FROM CONGVANDI cvd INNER join LOAICONGVAN lcv on cvd.MaLoaiCV = lcv.MaLoaiCV INner join COQUAN cq  on cvd.MaCoQuan = cq.MaCoQuan inner join NHANSU ns on cvd.MaNS = ns.MaNS WHERE ns.TenNhanSu='"
                + cboNguoiKG.Text.ToString() + "'";
            updateUI(sql);
        }

        private void dptDenNgay_ValueChanged(object sender, EventArgs e)
        {
            int ngaydi = Int32.Parse(dptTuNgay.Value.ToString("dd"));
            int ngayden = Int32.Parse(dptDenNgay.Value.ToString("dd"));
            int thangdi = Int32.Parse(dptTuNgay.Value.ToString("MM"));
            int thangden = Int32.Parse(dptDenNgay.Value.ToString("MM"));
            int namdi = Int32.Parse(dptTuNgay.Value.ToString("yyyy"));
            int namden = Int32.Parse(dptDenNgay.Value.ToString("yyyy"));

            string sql = "select cvd.STT, cvd.SoCV, cvd.NgayCongVan, cvd.NgayDi, cvd.TrichYeu, lcv.TenLoaiCV, cq.TenCoQuan, ns.TenNhanSu FROM CONGVANDI cvd INNER join LOAICONGVAN lcv on cvd.MaLoaiCV = lcv.MaLoaiCV INner join COQUAN cq  on cvd.MaCoQuan = cq.MaCoQuan inner join NHANSU ns on cvd.MaNS = ns.MaNS WHERE "
                + "day(cvd.NgayDi) >=" + ngaydi + " and day(cvd.NgayDi)<=" + ngayden + " and month(cvd.NgayDi) >=" + thangdi + " and month(cvd.NgayDi) <=" + thangden + " and year(cvd.NgayDi) >= " + namdi + " and year(cvd.NgayDi) <= " + namden;
            updateUI(sql);

        }

        private void dptTuNgay_ValueChanged(object sender, EventArgs e)
        {
        }

        private void cboThang_TextChanged(object sender, EventArgs e)
        {

        }
        private void copyAlltoClipboard()
        {
            //Lấy hàng tiêu đề.
            dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dataGridView1.MultiSelect = true;
            //to remove the first blank column from datagridview so called "Row Header"
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectAll();
            DataObject dataObj = dataGridView1.GetClipboardContent();
                if (dataObj != null)
                    Clipboard.SetDataObject(dataObj);
        }

        private void button5_Click(object sender, EventArgs e)
        {

            copyAlltoClipboard();
            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlexcel = new Excel.Application();
            xlexcel.Visible = true;
            xlWorkBook = xlexcel.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            Excel.Range CR = (Excel.Range)xlWorkSheet.Cells[1, 1];
            CR.Select();
            xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);      
        }
    }
}
