using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Dispatch_management
{
    class Class_TKCVDi
    {
         string soCV, trichYeu, tenLoaiCV, tenCQ, tenNS;
        DateTime ngayCV, ngayDi;
        public Class_TKCVDi(string soCV, string trichYeu, string tenLoaiCV, string tenCQ, string tenNS, DateTime ngayCV, DateTime ngayDi)
        {
            this.soCV = soCV;
            this.ngayCV = ngayCV;
            this.ngayDi = ngayDi;
            this.trichYeu = trichYeu;
            this.tenLoaiCV = tenLoaiCV;
            this.tenCQ = tenCQ;
            this.tenNS = tenNS;
        }
        public Class_TKCVDi() { }
        SqlConnection ketnoi = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyCongVan;Integrated Security=True");

        public DataTable LoadTable(string sql)
        {
            ketnoi.Open();

            SqlCommand com = new SqlCommand(sql, ketnoi); //bat dau truy van
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
            DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            try
            {
                da.Fill(dt);
            }
            catch (System.Data.SqlClient.SqlException) { }
            ketnoi.Close();
            return dt;
        }
        public void Excecute(string sql)
        {
            ketnoi.Open();
            SqlCommand thuchienlenh = new SqlCommand(sql, ketnoi);
            try
            {
                thuchienlenh.ExecuteNonQuery();
            }
            catch (System.Data.SqlClient.SqlException) { }
            ketnoi.Close();
        }

    }
        
}
