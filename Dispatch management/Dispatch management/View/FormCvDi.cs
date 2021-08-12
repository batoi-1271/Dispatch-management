using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Dispatch_management
{
    public partial class FormCvDi : Form
    {
        public FormCvDi()
        {
            InitializeComponent();
        }
        Class_CVDi ob = new Class_CVDi();
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ban co muon Thoat khong", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
        //Đặt giá trị mặc định và xóa trắng textbox
        private void SetDefaultControl()
        {
            txtSoCv.Clear();
            dptNgayCv.Value = DateTime.Now;
            dptNgayDi.Value = DateTime.Now;
            txtTrichYeu.Clear();
            cboNguoikygui.Text = "";
            cboLoaiCV.Text = "";
            cboNoiguidi.Text = "";
            errChiTiet.Clear();

        }

        private void FormCvDi_Load(object sender, EventArgs e)
        {
            list_detail = pq.list_per(pq.id_per(Login.ID_USER));

            cboNguoikygui.DataSource = ob.Load_Table("SELECT * FROM NHANSU");
            cboNguoikygui.DisplayMember = "TenNhanSu";
            cboNguoikygui.ValueMember = "MaNS";
            cboNguoikygui.Enabled = true;
            this.cboNguoikygui.SelectedIndex = -1;

            cboLoaiCV.DataSource = ob.Load_Table("SELECT * FROM LOAICONGVAN");
            cboLoaiCV.DisplayMember = "TenLoaiCV";
            cboLoaiCV.ValueMember = "MaLoaiCV";
            cboLoaiCV.Enabled = true;
            this.cboLoaiCV.SelectedIndex = -1;

            cboNoiguidi.DataSource = ob.Load_Table("SELECT * FROM COQUAN");
            cboNoiguidi.DisplayMember = "TenCoQuan";
            cboNoiguidi.ValueMember = "MaCoQuan";
            cboNoiguidi.Enabled = true;
            this.cboNoiguidi.SelectedIndex = -1;

            ob.Hienthi(LvCVDi);
        }

        Decentralization pq = new Decentralization();
        List<string> list_detail;
        public Boolean checkper(string code)
        {
            Boolean check = false;
            foreach (string item in list_detail)
            {
                if (item == code)
                {
                    check = true;
                    break;
                }
            }
            return check;
        }

        // Kiểm tra rỗng.
        private Boolean checkDataInput()
        {
            Boolean check = true;
            //Số CV
            if (txtSoCv.Text.Trim() == "")
            {
                errChiTiet.SetError(txtSoCv, "Bạn không thể để trống Số CV!");
                check = false;
                return check;
            }
            else
            {
                errChiTiet.Clear();
            }
            //Người ký nhận
            if (cboNguoikygui.Text.Trim() == "")
            {
                errChiTiet.SetError(cboNguoikygui, "Bạn không thể để trống Người ký nhận!");
                check = false;
                return check;
            }
            else
            {
                errChiTiet.Clear();
            }

            //Loại CV
            if (cboLoaiCV.Text.Trim() == "")
            {
                errChiTiet.SetError(cboLoaiCV, "Bạn không thể để trống Loại CV!");
                check = false;
                return check;
            }
            else
            {
                errChiTiet.Clear();
            }
            //Nơi gửi tới
            if (cboNoiguidi.Text.Trim() == "")
            {
                errChiTiet.SetError(cboNoiguidi, "Bạn không thể để trống Nơi gửi tới!");
                check = false;
                return check;
            }
            else
            {
                errChiTiet.Clear();
            }
            //Trích yếu
            if (txtTrichYeu.Text.Trim() == "")
            {
                errChiTiet.SetError(txtTrichYeu, "Bạn không thể để trống Trích yếu!");
                check = false;
                return check;
            }
            else
            {
                errChiTiet.Clear();
            }
            //Kiểm tra ngày CV, lỗi nếu người sử dụng nhập vào ngày CV lớn hơn ngày hiện tại
            if (dptNgayCv.Value > DateTime.Now)
            {
                errChiTiet.SetError(dptNgayCv, "Ngày công văn không hợp lệ!");
                check = false;
                return check;
            }
            else
            {
                errChiTiet.Clear();
            }
            //Kiểm tra ngày CV đi xem có lớn hơn ngày CV không
            if (dptNgayDi.Value < dptNgayCv.Value)
            {
                errChiTiet.SetError(dptNgayDi, "Ngày CV đến nhỏ hơn ngày CV!");
                check = false;
                return check;
            }
            else
            {
                errChiTiet.Clear();
            }
            return check;//trường hợp false all
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (checkper("ADD") == true)
            {
            Boolean ck = checkDataInput();
            if (ck == true)
            {//dữ liệu nhập hợp lệ
                //Nếu nút Thêm enable thì thực hiện thêm mới
                Class_CVDi ob = new Class_CVDi(txtSoCv.Text, dptNgayCv.Value.Date, dptNgayDi.Value.Date, txtTrichYeu.Text, cboLoaiCV.SelectedValue.ToString(), cboNoiguidi.SelectedValue.ToString(), cboNguoikygui.SelectedValue.ToString());
                if (ob.KT_Key(txtSoCv.Text) == true)
                {
                    DialogResult result = MessageBox.Show("Agency code cannot be the same.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    ob.Insert(ob);
                    ob.Hienthi(LvCVDi);
                    SetDefaultControl();
                    MessageBox.Show("More success!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            }
            else
            {
                MessageBox.Show("You have no right!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (checkper("Edit") == true)
            {
            DialogResult tl = MessageBox.Show("Do you want to fix it?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tl == DialogResult.Yes)
            {
                try
                {
                    Class_CVDi ob = new Class_CVDi(txtSoCv.Text, dptNgayCv.Value.Date, dptNgayDi.Value.Date, txtTrichYeu.Text, cboLoaiCV.SelectedValue.ToString(), cboNoiguidi.SelectedValue.ToString(), cboNguoikygui.SelectedValue.ToString());
                    ob.Update(ob);
                    ob.Hienthi(LvCVDi);
                    SetDefaultControl();
                    MessageBox.Show("More success!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (System.FormatException)
                {
                    DialogResult tb = MessageBox.Show("Have not entered information", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            }
            else
            {
                MessageBox.Show("You have no right!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (checkper("DEl") == true)
            {
            if (txtSoCv.Text.Trim() == "")
            {
                MessageBox.Show("You have not selected a record to delete!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;//dừng lại lệnh xóa khi gặp lỗi
            }
            DialogResult tl = MessageBox.Show("You may want to delete?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tl == DialogResult.Yes)
            {
                try
                {
                    Class_CVDi ob = new Class_CVDi(txtSoCv.Text, Convert.ToDateTime(dptNgayCv.Value), Convert.ToDateTime(dptNgayDi.Value), txtTrichYeu.Text, cboLoaiCV.SelectedValue.ToString(), cboNoiguidi.SelectedValue.ToString(), cboNguoikygui.SelectedValue.ToString());
                    ob.Delete(ob);
                    ob.Hienthi(LvCVDi);
                    SetDefaultControl();
                    btnThem.Enabled = true;
                    MessageBox.Show("More success!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (System.FormatException)
                {

                }
            }
            }
            else
            {
                MessageBox.Show("You have no right!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        

        private void LvCVDi_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Hien thi nut sua
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThem.Enabled = false;
            btnHuy.Enabled = true;
                foreach (ListViewItem item in LvCVDi.SelectedItems)
                {
                    txtSoCv.Text = item.SubItems[1].Text;
                    dptNgayCv.Value = Convert.ToDateTime(item.SubItems[2].Text);
                    dptNgayDi.Value = Convert.ToDateTime(item.SubItems[3].Text);
                    txtTrichYeu.Text = item.SubItems[4].Text;
                    cboLoaiCV.Text = item.SubItems[5].Text;
                    cboNoiguidi.Text = item.SubItems[6].Text;
                    cboNguoikygui.Text = item.SubItems[7].Text;
                    
                }

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            //Thiết lập lại các nút như ban đầu
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnThem.Enabled = true;
            //xoa trang
            SetDefaultControl();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application xla = new Microsoft.Office.Interop.Excel.Application(); //Khởi tạo Excel
                xla.Visible = true;
                Microsoft.Office.Interop.Excel.Workbook wb = xla.Workbooks.Add(Microsoft.Office.Interop.Excel.XlSheetType.xlWorksheet); //Khởi tạo workbook
                // lấy tập hợp các trang tính trong sổ làm việc

                /********************* Create new sheet (Activity List) ***************************/
                Microsoft.Office.Interop.Excel.Worksheet ws = ((Microsoft.Office.Interop.Excel.Worksheet)xla.ActiveSheet); //Khởi tạo worksheet
                ws.Columns.AutoFit();

                // đặt tên cho sheet
                ws.Name = "CV Di sheet";
                int i = 1;
                int j = 1;
                int jj = LvCVDi.Columns.Count;
                // lấy ra hàng tiêu đề
                for (int rr = 0; rr < jj; rr++)
                {
                    ws.Cells[i, j] = LvCVDi.Columns[rr].Text;
                    j = j + 1;
                }
                i = 2;
                j = 1;
                //lấy ra các hàng trong DS
                foreach (ListViewItem lista in LvCVDi.Items)
                {
                    ws.Cells[i, j] = lista.Text.ToString();
                    foreach (ListViewItem.ListViewSubItem drv in lista.SubItems)
                    {
                        ws.Cells[i, j] = drv.Text.ToString();
                        j += 1;
                    }
                    j = 1;
                    i += 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
