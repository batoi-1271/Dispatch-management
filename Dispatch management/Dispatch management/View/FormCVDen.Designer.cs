namespace Dispatch_management
{
    partial class FormCVDen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dptNgayDen = new System.Windows.Forms.DateTimePicker();
            this.dptNgayCv = new System.Windows.Forms.DateTimePicker();
            this.txtTrichYeu = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboLoaiCV = new System.Windows.Forms.ComboBox();
            this.cboNoiguitoi = new System.Windows.Forms.ComboBox();
            this.cboNguoikynhan = new System.Windows.Forms.ComboBox();
            this.txtSoCv = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.LvCVDen = new System.Windows.Forms.ListView();
            this.STT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.socongvan = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ngaycongvan = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ngayden = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.trichyeu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.loaicongvan = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.noiguiden = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nguoikynhan = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.errChiTiet = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errChiTiet)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dptNgayDen);
            this.groupBox1.Controls.Add(this.dptNgayCv);
            this.groupBox1.Controls.Add(this.txtTrichYeu);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cboLoaiCV);
            this.groupBox1.Controls.Add(this.cboNoiguitoi);
            this.groupBox1.Controls.Add(this.cboNguoikynhan);
            this.groupBox1.Controls.Add(this.txtSoCv);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(15, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1324, 244);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cập nhật thông tin";
            // 
            // dptNgayDen
            // 
            this.dptNgayDen.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dptNgayDen.Location = new System.Drawing.Point(554, 140);
            this.dptNgayDen.Name = "dptNgayDen";
            this.dptNgayDen.Size = new System.Drawing.Size(207, 27);
            this.dptNgayDen.TabIndex = 14;
            // 
            // dptNgayCv
            // 
            this.dptNgayCv.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dptNgayCv.Location = new System.Drawing.Point(554, 72);
            this.dptNgayCv.Name = "dptNgayCv";
            this.dptNgayCv.Size = new System.Drawing.Size(207, 27);
            this.dptNgayCv.TabIndex = 13;
            // 
            // txtTrichYeu
            // 
            this.txtTrichYeu.Location = new System.Drawing.Point(849, 72);
            this.txtTrichYeu.Multiline = true;
            this.txtTrichYeu.Name = "txtTrichYeu";
            this.txtTrichYeu.Size = new System.Drawing.Size(396, 147);
            this.txtTrichYeu.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(845, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(146, 20);
            this.label8.TabIndex = 12;
            this.label8.Text = "Trích yếu nội dung";
            // 
            // cboLoaiCV
            // 
            this.cboLoaiCV.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboLoaiCV.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboLoaiCV.FormattingEnabled = true;
            this.cboLoaiCV.Location = new System.Drawing.Point(151, 142);
            this.cboLoaiCV.Name = "cboLoaiCV";
            this.cboLoaiCV.Size = new System.Drawing.Size(216, 28);
            this.cboLoaiCV.TabIndex = 9;
            // 
            // cboNoiguitoi
            // 
            this.cboNoiguitoi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboNoiguitoi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboNoiguitoi.FormattingEnabled = true;
            this.cboNoiguitoi.Location = new System.Drawing.Point(151, 191);
            this.cboNoiguitoi.Name = "cboNoiguitoi";
            this.cboNoiguitoi.Size = new System.Drawing.Size(610, 28);
            this.cboNoiguitoi.TabIndex = 8;
            // 
            // cboNguoikynhan
            // 
            this.cboNguoikynhan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboNguoikynhan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboNguoikynhan.FormattingEnabled = true;
            this.cboNguoikynhan.Location = new System.Drawing.Point(151, 84);
            this.cboNguoikynhan.Name = "cboNguoikynhan";
            this.cboNguoikynhan.Size = new System.Drawing.Size(216, 28);
            this.cboNguoikynhan.TabIndex = 7;
            // 
            // txtSoCv
            // 
            this.txtSoCv.Location = new System.Drawing.Point(151, 33);
            this.txtSoCv.Name = "txtSoCv";
            this.txtSoCv.Size = new System.Drawing.Size(216, 27);
            this.txtSoCv.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "Loại công văn";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(414, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Ngày gửi đến";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(401, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ngày công văn";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nơi gửi tới";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Người ký nhận";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số công văn";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.LvCVDen);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 466);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1330, 275);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Hiển thị";
            // 
            // LvCVDen
            // 
            this.LvCVDen.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.STT,
            this.socongvan,
            this.ngaycongvan,
            this.ngayden,
            this.trichyeu,
            this.loaicongvan,
            this.noiguiden,
            this.nguoikynhan});
            this.LvCVDen.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LvCVDen.FullRowSelect = true;
            this.LvCVDen.GridLines = true;
            this.LvCVDen.Location = new System.Drawing.Point(3, 36);
            this.LvCVDen.Name = "LvCVDen";
            this.LvCVDen.Size = new System.Drawing.Size(1324, 236);
            this.LvCVDen.TabIndex = 0;
            this.LvCVDen.UseCompatibleStateImageBehavior = false;
            this.LvCVDen.View = System.Windows.Forms.View.Details;
            this.LvCVDen.SelectedIndexChanged += new System.EventHandler(this.LvCVDen_SelectedIndexChanged);
            // 
            // STT
            // 
            this.STT.Text = "STT";
            // 
            // socongvan
            // 
            this.socongvan.Text = "Số công văn";
            this.socongvan.Width = 126;
            // 
            // ngaycongvan
            // 
            this.ngaycongvan.Text = "Ngày công văn";
            this.ngaycongvan.Width = 135;
            // 
            // ngayden
            // 
            this.ngayden.Text = "Ngày đến";
            this.ngayden.Width = 114;
            // 
            // trichyeu
            // 
            this.trichyeu.Text = "Trích yếu";
            this.trichyeu.Width = 116;
            // 
            // loaicongvan
            // 
            this.loaicongvan.Text = "Loại công văn";
            this.loaicongvan.Width = 125;
            // 
            // noiguiden
            // 
            this.noiguiden.Text = "Nơi gửi đến";
            this.noiguiden.Width = 121;
            // 
            // nguoikynhan
            // 
            this.nguoikynhan.Text = "Người ký nhận";
            this.nguoikynhan.Width = 127;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(481, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(427, 36);
            this.label5.TabIndex = 2;
            this.label5.Text = "CẬP NHẬT CÔNG VĂN ĐẾN";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.btnThem);
            this.groupBox2.Controls.Add(this.btnSua);
            this.groupBox2.Controls.Add(this.btnXoa);
            this.groupBox2.Controls.Add(this.btnHuy);
            this.groupBox2.Controls.Add(this.btnThoat);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(91, 354);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1141, 106);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chức năng";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(948, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 36);
            this.button1.TabIndex = 7;
            this.button1.Text = "Xuất EXCEL";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(28, 38);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(110, 36);
            this.btnThem.TabIndex = 1;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(212, 38);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(110, 36);
            this.btnSua.TabIndex = 2;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(396, 38);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(110, 36);
            this.btnXoa.TabIndex = 3;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(580, 38);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(110, 36);
            this.btnHuy.TabIndex = 5;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(764, 38);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(110, 36);
            this.btnThoat.TabIndex = 6;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // errChiTiet
            // 
            this.errChiTiet.ContainerControl = this;
            // 
            // FormCVDen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 753);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormCVDen";
            this.Text = "Công văn đến";
            this.Load += new System.EventHandler(this.FormCVDen_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errChiTiet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboLoaiCV;
        private System.Windows.Forms.ComboBox cboNoiguitoi;
        private System.Windows.Forms.ComboBox cboNguoikynhan;
        private System.Windows.Forms.TextBox txtSoCv;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView LvCVDen;
        private System.Windows.Forms.TextBox txtTrichYeu;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ColumnHeader STT;
        private System.Windows.Forms.ColumnHeader socongvan;
        private System.Windows.Forms.ColumnHeader ngaycongvan;
        private System.Windows.Forms.ColumnHeader ngayden;
        private System.Windows.Forms.ColumnHeader trichyeu;
        private System.Windows.Forms.ColumnHeader loaicongvan;
        private System.Windows.Forms.ColumnHeader noiguiden;
        private System.Windows.Forms.ColumnHeader nguoikynhan;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.DateTimePicker dptNgayDen;
        private System.Windows.Forms.DateTimePicker dptNgayCv;
        private System.Windows.Forms.ErrorProvider errChiTiet;
        private System.Windows.Forms.Button button1;
    }
}