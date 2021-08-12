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
    public partial class FormCoQuan : Form
    {
        public FormCoQuan()
        {
            InitializeComponent();
        }

        private void FormCoQuan_Load(object sender, EventArgs e)
        {
            list_detail = pq.list_per(pq.id_per(Login.ID_USER));
            Class_CoQuan ob = new Class_CoQuan();
            ob.Hienthi(LvCoQuan);
        }

        //Đặt giá trị mặc định và xóa trắng textbox
        private void SetDefaultControl()
        {
            txtMaCoQuan.Clear();
            txtTenCoQuan.Clear();
            txtDiaChi.Clear();
            txtSDT.Text = "0";
            errChiTiet.Clear();
        }
        // Kiểm tra rỗng.
        private Boolean checkDataInput()
        {
            Boolean check = true;
            //Kiểm tra mã cơ quan có bị để trống không
            if (txtMaCoQuan.Text.Trim() == "")
            {
                errChiTiet.SetError(txtMaCoQuan, "Bạn không thể để trống mã cơ quan!");
                check = false;
                return check;
            }
            else
            {
                errChiTiet.Clear();
            }
            //Tên cơ quan
            if (txtTenCoQuan.Text.Trim() == "")
            {
                errChiTiet.SetError(txtTenCoQuan, "Bạn không thể để trống tên cơ quan!");
                check = false;
                return check;
            }
            else
            {
                errChiTiet.Clear();
            }

            //Kiểm tra địa chỉ xem có để trống không
            if (txtDiaChi.Text.Trim() == "")
            {
                errChiTiet.SetError(txtDiaChi, "Bạn không thể để trống địa chỉ!");
                check = false;
                return check;
            }
            else
            {
                errChiTiet.Clear();
            }
            //Kiểm tra SDT
            if (txtSDT.Text == "")
            {
                errChiTiet.SetError(txtSDT, "Bạn không thể để trống SDT!");
                check = false;
                return check;
            }
            else
            {
                errChiTiet.Clear();
            }
            return check;//trường hợp false all
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

    
        private void btnThem_Click(object sender, EventArgs e)
        {
            
            if (checkper("ADD") == true)
            {
            Boolean ck = checkDataInput();
            if (ck == true)
            {//dữ liệu nhập hợp lệ
                //Nếu nút Thêm enable thì thực hiện thêm mới
                Class_CoQuan ob = new Class_CoQuan(txtMaCoQuan.Text, txtTenCoQuan.Text, txtDiaChi.Text, txtSDT.Text);
                if (ob.KT_check(txtMaCoQuan.Text) == true)
                {
                    DialogResult result = MessageBox.Show("Agency code cannot be the same.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (ob.KT_check_SDT(txtSDT.Text) == true)
                {
                    DialogResult result = MessageBox.Show("SMS code cannot be the same.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    ob.Insert(ob);
                    ob.Hienthi(LvCoQuan);
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
                    Class_CoQuan ob = new Class_CoQuan(txtMaCoQuan.Text, txtTenCoQuan.Text, txtDiaChi.Text, txtSDT.Text);
                    ob.Update(ob);
                    ob.Hienthi(LvCoQuan);
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
                if (txtMaCoQuan.Text.Trim() == "")
                {
                    MessageBox.Show("You have not selected a record to delete!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;//dừng lại lệnh xóa khi gặp lỗi
                }
                DialogResult tl = MessageBox.Show("You may want to delete?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (tl == DialogResult.Yes)
                    {
                     try
                        {
                        Class_CoQuan ob = new Class_CoQuan(txtMaCoQuan.Text, txtTenCoQuan.Text, txtDiaChi.Text, txtSDT.Text);
                        ob.Delete(ob);
                        ob.Hienthi(LvCoQuan);
                        SetDefaultControl();
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

        private void LvCoQuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Hien thi nut sua
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThem.Enabled = false;
            btnHuy.Enabled = true;

                foreach (ListViewItem item in LvCoQuan.SelectedItems)
                {
                    txtMaCoQuan.Text = item.SubItems[1].Text;
                    txtTenCoQuan.Text = item.SubItems[2].Text;
                    txtDiaChi.Text = item.SubItems[3].Text;
                    txtSDT.Text = item.SubItems[4].Text;
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

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Xác thực rằng phím vừa nhấn không phải CTRL hoặc không phải dạng số
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Nếu bạn muốn, bạn có thể cho phép nhập số thực với dấu chấm
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

  


    }
}
