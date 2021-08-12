using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Dispatch_management
{
    public partial class FormTimKiemCVDen : Form
    {
        public FormTimKiemCVDen()
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
        Class_TKCVDen ob = new Class_TKCVDen();
        public void updateUI(string sql)
        {

            DataTable dt = new DataTable();
            dt = ob.LoadTable(sql);
            dataGridView1.DataSource = dt; //đổ dữ liệu vào datagridview
            dataGridView1.Refresh();
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
            
            if (cboNguoiKN.Text.Trim() == "")
            {
                errChiTiet.SetError(cboNguoiKN, "Bạn không thể để trống tên nhân sự!");
                check = false;
                return check;
            }
            else
            {
                errChiTiet.Clear();
            }

            
            if (cboNoiGuiDen.Text.Trim() == "")
            {
                errChiTiet.SetError(cboNoiGuiDen, "Bạn không thể để trống địa chỉ!");
                check = false;
                return check;
            }
            else
            {
                errChiTiet.Clear();
            }
            
            return check;//trường hợp false all
        }

        private void HienThi()
        {
            string sql1 = "select cvd.STT, cvd.SoCV, cvd.NgayCongVan, cvd.NgayDen, cvd.TrichYeu, lcv.TenLoaiCV, cq.TenCoQuan, ns.TenNhanSu FROM CONGVANDEN cvd INNER join LOAICONGVAN lcv on cvd.MaLoaiCV = lcv.MaLoaiCV INner join COQUAN cq  on cvd.MaCoQuan = cq.MaCoQuan inner join NHANSU ns on cvd.MaNS = ns.MaNS";
            updateUI(sql1);
        }
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dptTuNgay.Value = DateTime.Now;
            dptDenNgay.Value = DateTime.Now;
            cboLoaiCV.SelectedIndex = -1;
            cboNoiGuiDen.SelectedIndex = -1;
            cboNguoiKN.SelectedIndex = -1;
            cboThang.Text = "";
            cboNam.Text = "";

            HienThi();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ban co muon Thoat khong", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void FormTimKiemCVDen_Load(object sender, EventArgs e)
        {
            cboNam.Text = "";

            cboLoaiCV.DataSource = ob.LoadTable("SELECT * FROM LOAICONGVAN");
            cboLoaiCV.DisplayMember = "TenLoaiCV";
            cboLoaiCV.ValueMember = "MaLoaiCV";
            cboLoaiCV.Enabled = true;
            this.cboLoaiCV.SelectedIndex = -1;

            cboNguoiKN.DataSource = ob.LoadTable("SELECT * FROM NHANSU");
            cboNguoiKN.DisplayMember = "TenNhanSu";
            cboNguoiKN.ValueMember = "MaNS";
            cboNguoiKN.Enabled = true;
            this.cboNguoiKN.SelectedIndex = -1;


            cboNoiGuiDen.DataSource = ob.LoadTable("SELECT * FROM COQUAN");
            cboNoiGuiDen.DisplayMember = "TenCoQuan";
            cboNoiGuiDen.ValueMember = "MaCoQuan";
            cboNoiGuiDen.Enabled = true;
            this.cboNoiGuiDen.SelectedIndex = -1;

            HienThi();
        }

        private void cboNguoiKN_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select cvd.STT, cvd.SoCV, cvd.NgayCongVan, cvd.NgayDen, cvd.TrichYeu, lcv.TenLoaiCV, cq.TenCoQuan, ns.TenNhanSu FROM CONGVANDEN cvd INNER join LOAICONGVAN lcv on cvd.MaLoaiCV = lcv.MaLoaiCV INner join COQUAN cq  on cvd.MaCoQuan = cq.MaCoQuan inner join NHANSU ns on cvd.MaNS = ns.MaNS WHERE ns.TenNhanSu='"
                + cboNguoiKN.Text.ToString() + "'";
            updateUI(sql);
        }

        private void cboLoaiCV_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select cvd.STT, cvd.SoCV, cvd.NgayCongVan, cvd.NgayDen, cvd.TrichYeu, lcv.TenLoaiCV, cq.TenCoQuan, ns.TenNhanSu FROM CONGVANDEN cvd INNER join LOAICONGVAN lcv on cvd.MaLoaiCV = lcv.MaLoaiCV INner join COQUAN cq  on cvd.MaCoQuan = cq.MaCoQuan inner join NHANSU ns on cvd.MaNS = ns.MaNS WHERE lcv.TenLoaiCV='"
               + cboLoaiCV.Text.ToString() + "'";
            updateUI(sql);
        }

        private void cboNoiGuiDen_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select cvd.STT, cvd.SoCV, cvd.NgayCongVan, cvd.NgayDen, cvd.TrichYeu, lcv.TenLoaiCV, cq.TenCoQuan, ns.TenNhanSu FROM CONGVANDEN cvd INNER join LOAICONGVAN lcv on cvd.MaLoaiCV = lcv.MaLoaiCV INner join COQUAN cq  on cvd.MaCoQuan = cq.MaCoQuan inner join NHANSU ns on cvd.MaNS = ns.MaNS WHERE cq.TenCoQuan='"
                + cboNoiGuiDen.Text.ToString() + "'";
            updateUI(sql);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Boolean ck = checkDataInput();
            if (ck == true)
            {
                string sql = "select cvd.STT, cvd.SoCV, cvd.NgayCongVan, cvd.NgayDen, cvd.TrichYeu, lcv.TenLoaiCV, cq.TenCoQuan, ns.TenNhanSu FROM CONGVANDEN cvd INNER join LOAICONGVAN lcv on cvd.MaLoaiCV = lcv.MaLoaiCV INner join COQUAN cq  on cvd.MaCoQuan = cq.MaCoQuan inner join NHANSU ns on cvd.MaNS = ns.MaNS WHERE lcv.TenLoaiCV='"
                    + cboLoaiCV.Text.ToString() + "' and ns.TenNhanSu = '" + cboNguoiKN.Text.ToString() + "' and TenCoQuan = '" + cboNoiGuiDen.Text.ToString() + "'";
                updateUI(sql);
            }
        }

        private void cboThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select cvd.STT, cvd.SoCV, cvd.NgayCongVan, cvd.NgayDen, cvd.TrichYeu, lcv.TenLoaiCV, cq.TenCoQuan, ns.TenNhanSu FROM CONGVANDEN cvd INNER join LOAICONGVAN lcv on cvd.MaLoaiCV = lcv.MaLoaiCV INner join COQUAN cq  on cvd.MaCoQuan = cq.MaCoQuan inner join NHANSU ns on cvd.MaNS = ns.MaNS WHERE MONTH(NgayDen)='"
                + cboThang.SelectedItem.ToString() + "'";
            updateUI(sql);
        }

        private void cboNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select cvd.STT, cvd.SoCV, cvd.NgayCongVan, cvd.NgayDen, cvd.TrichYeu, lcv.TenLoaiCV, cq.TenCoQuan, ns.TenNhanSu FROM CONGVANDEN cvd INNER join LOAICONGVAN lcv on cvd.MaLoaiCV = lcv.MaLoaiCV INner join COQUAN cq  on cvd.MaCoQuan = cq.MaCoQuan inner join NHANSU ns on cvd.MaNS = ns.MaNS WHERE YEAR(NgayDen)='"
                + cboNam.SelectedItem.ToString() + "'";
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

            string sql = "select cvd.STT, cvd.SoCV, cvd.NgayCongVan, cvd.NgayDen, cvd.TrichYeu, lcv.TenLoaiCV, cq.TenCoQuan, ns.TenNhanSu FROM CONGVANDEN cvd INNER join LOAICONGVAN lcv on cvd.MaLoaiCV = lcv.MaLoaiCV INner join COQUAN cq  on cvd.MaCoQuan = cq.MaCoQuan inner join NHANSU ns on cvd.MaNS = ns.MaNS WHERE "
                + "day(cvd.NgayDen) >=" + ngaydi + " and day(cvd.NgayDen)<=" + ngayden + " and month(cvd.NgayDen) >=" + thangdi + " and month(cvd.NgayDen) <=" + thangden + " and year(cvd.NgayDen) >= " + namdi + " and year(cvd.NgayDen) <= " + namden;
            updateUI(sql);
        }

        private void copyAlltoClipboard()
        {
            //Lấy hàng tiêu đề.
            dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dataGridView1.MultiSelect = true;
            //to remove the first blank column from datagridview
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectAll();
            DataObject dataObj = dataGridView1.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            copyAlltoClipboard();
            // tạo đối tượng Application mà chúng ta có thể sử dụng trong các hàm thành viên.
            Microsoft.Office.Interop.Excel.Application xlExcel;
            //open the workbook
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlExcel = new Excel.Application();
            xlExcel.Visible = true;
            xlWorkBook = xlExcel.Workbooks.Add(misValue);
            // chọn trang tính đầu tiên
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            // tìm phạm vi đã sử dụng trong trang tính
            Excel.Range CR = (Excel.Range)xlWorkSheet.Cells[1, 1];
            CR.Select();
            xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true); 
        }
    }
}
