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
    public partial class Inf_User : Form
    {
        public Inf_User()
        {
            InitializeComponent();
        }
        Class_Login lg = new Class_Login();      

        private void Inf_User_Load(object sender, EventArgs e)
        {
            lbtenTK.Text = lg.getName("admin")[0];
            lbTenU.Text = lg.getName("admin")[1];
                   
        }
    }
}
