using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace Dispatch_management
{
    class Class_ThongKe
    {
        SqlConnection ketnoi = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyCongVan;Integrated Security=True");
        
        public DataTable LoadTB(String sql)
        {
            Class_ThongKe ob = new Class_ThongKe();
            ob.ketnoi.Open();
            SqlDataAdapter ad = new SqlDataAdapter(sql, ob.ketnoi);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            ob.ketnoi.Close();
            return dt;
        }
    }
}
