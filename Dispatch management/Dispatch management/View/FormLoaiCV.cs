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
    public partial class FormLoaiCV : Form
    {
        public FormLoaiCV()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ban co muon Thoat khong", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
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
            txtMaLoai.Clear();
            txtTenLoai.Clear();
            errChiTiet.Clear();
        }

        private void FormLoaiCV_Load(object sender, EventArgs e)
        {
            list_detail = pq.list_per(pq.id_per(Login.ID_USER));
            Class_LoaiCV ob = new Class_LoaiCV();
            ob.Hienthi(LvLoaiCV);
        }

        // Kiểm tra rỗng.
        private Boolean checkDataInput()
        {
            Boolean check = true;
            //Kiểm tra mã CV có bị để trống không
            if (txtMaLoai.Text.Trim() == "")
            {
                errChiTiet.SetError(txtMaLoai, "Bạn không thể để trống mã CV!");
                check = false;
                return check;
            }
            else
            {
                errChiTiet.Clear();
            }
            //Tên loại
            if (txtTenLoai.Text.Trim() == "")
            {
                errChiTiet.SetError(txtTenLoai, "Bạn không thể để trống tên loại CV!");
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
                Class_LoaiCV ob = new Class_LoaiCV(txtMaLoai.Text, txtTenLoai.Text);
                if (ob.KT_check(txtMaLoai.Text) == true)
                {
                    DialogResult result = MessageBox.Show("Dispatch type code cannot be the same.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
                else
                {
                    ob.Insert(ob);
                    ob.Hienthi(LvLoaiCV);
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
                        Class_LoaiCV ob = new Class_LoaiCV(txtMaLoai.Text, txtTenLoai.Text);
                        ob.Update(ob);
                        ob.Hienthi(LvLoaiCV);
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
            if (txtMaLoai.Text.Trim() == "")
            {
                MessageBox.Show("You have not selected a record to delete!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;//dừng lại lệnh xóa khi gặp lỗi
            }
            DialogResult tl = MessageBox.Show("You may want to delete?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tl == DialogResult.Yes)
            {
                try
                {
                    Class_LoaiCV ob = new Class_LoaiCV(txtMaLoai.Text, txtTenLoai.Text);
                    ob.Delete(ob);
                    ob.Hienthi(LvLoaiCV);
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

        private void LvLoaiCV_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Hien thi nut sua
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThem.Enabled = false;
            btnHuy.Enabled = true;
                foreach (ListViewItem item in LvLoaiCV.SelectedItems)
                {
                    txtMaLoai.Text = item.SubItems[1].Text;
                    txtTenLoai.Text = item.SubItems[2].Text;
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
