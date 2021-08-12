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
    public partial class FormNhanSu : Form
    {
        public FormNhanSu()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to exit?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
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
        private void SetDefaultControl()
        {
            txtMaNS.Clear();
            txtTenNS.Clear();
            txtChucvu.Clear();
            errChiTiet.Clear();
        }
        // Kiểm tra rỗng.
        private Boolean checkDataInput()
        {
            Boolean check = true;
            //Kiểm tra mã nhân sự có bị để trống không
            if (txtMaNS.Text.Trim() == "")
            {
                errChiTiet.SetError(txtMaNS, "Bạn không thể để trống mã nhân sự!");
                check = false;
                return check;
            }
            else
            {
                errChiTiet.Clear();
            }
            //Tên nhân sự
            if (txtTenNS.Text.Trim() == "")
            {
                errChiTiet.SetError(txtTenNS, "Bạn không thể để trống tên nhân sự!");
                check = false;
                return check;
            }
            else
            {
                errChiTiet.Clear();
            }
            //Chức vụ nhân sự
            if (txtChucvu.Text.Trim() == "")
            {
                errChiTiet.SetError(txtChucvu, "Bạn không thể để trống tên nhân sự!");
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
                    Class_NhanSu ob = new Class_NhanSu(txtMaNS.Text, txtTenNS.Text, txtChucvu.Text);
                    if (ob.KT_check(txtMaNS.Text) == true)
                    {
                        DialogResult result = MessageBox.Show("Personnel code cannot be the same.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    else
                    {
                        ob.Insert(ob);
                        ob.Hienthi(LvNhanSu);
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
                        Class_NhanSu ob = new Class_NhanSu(txtMaNS.Text, txtTenNS.Text, txtChucvu.Text);
                        ob.Update(ob);
                        ob.Hienthi(LvNhanSu);
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
                if (txtMaNS.Text.Trim() == "")
                {
                    MessageBox.Show("You have not selected a record to delete!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;//dừng lại lệnh xóa khi gặp lỗi
                }
                DialogResult tl = MessageBox.Show("You may want to delete?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (tl == DialogResult.Yes)
                {
                    try
                    {
                        Class_NhanSu ob = new Class_NhanSu(txtMaNS.Text, txtTenNS.Text, txtChucvu.Text);
                        ob.Delete(ob);
                        ob.Hienthi(LvNhanSu);
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

        private void FormNhanSu_Load(object sender, EventArgs e)
        {
            list_detail = pq.list_per(pq.id_per(Login.ID_USER));
            Class_NhanSu ob = new Class_NhanSu();
            ob.Hienthi(LvNhanSu);
        }

        private void LvNhanSu_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Hien thi nut sua
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThem.Enabled = false;
            btnHuy.Enabled = true;
                foreach (ListViewItem item in LvNhanSu.SelectedItems)
                {
                    txtMaNS.Text = item.SubItems[1].Text;
                    txtTenNS.Text = item.SubItems[2].Text;
                    txtChucvu.Text = item.SubItems[3].Text;
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
    }
}
