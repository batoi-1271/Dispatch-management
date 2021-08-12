using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dispatch_management
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        Class_Login lg = new Class_Login();
        public static string ID_USER = "";

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ID_USER = lg.getID(txt_username.Text, txt_pass.Text);
            if (ID_USER != "")
            {
                HOME fmain = new HOME();
                fmain.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng !");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to exit?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
     
        private void txt_pass_TextChanged(object sender, EventArgs e)
        {
          
        }
       
    }
}
