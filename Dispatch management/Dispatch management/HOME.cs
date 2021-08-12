using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Dispatch_management
{
    public partial class HOME : Form
    {

        public HOME()
        {
            InitializeComponent();
        }

        private void thốngKêTheoNgàyToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripDropDownButton2_Click(object sender, EventArgs e)
        {

        }

        private void cậpNhậtCơQuanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form cq = new FormCoQuan();
            cq.Show();
        }

        private void cậpNhậtLoạiCôngVănToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form lcv = new FormLoaiCV();
            lcv.Show();
        }

        private void cậpNhậtCôngVănĐếnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form cvd = new FormCVDen();
            cvd.Show();
        }

        private void cậpNhậtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form cvdi = new FormCvDi();
            cvdi.Show();
        }

        private void cậpNhậtNhânSựToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ns = new FormNhanSu();
            ns.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form TKCVD = new FormTimKiemCVDen();
            TKCVD.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Form TKCVDi = new FormTimKiemCVDi();
            TKCVDi.Show();
        }

        private void HOME_Load(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Logged in successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripDropDownButton8_Click(object sender, EventArgs e)
        {
            Form rpCvDen = new FRMThongKeCVDen();
            rpCvDen.Show();
        }

        private void toolStripDropDownButton9_Click(object sender, EventArgs e)
        {
            Form rpCvDi = new FRMThongKeCVDi();
            rpCvDi.Show();
        }

        private void đổiNgườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Form log = new Login();
            log.Show();
        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Version: 1.58.2 (user setup)\n Commit: c3f126316369cd610563c75b1b1725e0679adfb3\n Date: 2021-07-14T22:10:15.214Z \n Electron: 12.0.13 \n Chrome: 89.0.4389.128 \n Node.js: 14.16.0 V8: 8.9.255.25-electron.0 \n OS: Windows_NT x64 10.0.19043", "Dispatch management", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void toolStripDropDownButton4_Click(object sender, EventArgs e)
        {
            Form user = new Inf_User();
            user.Show();
        }


    }
}
