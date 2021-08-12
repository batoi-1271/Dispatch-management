using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Dispatch_management
{
    class Class_NhanSu
    {
        string maNS, tenNS, chucVu;
        public Class_NhanSu() { }
        public Class_NhanSu(string maNS, string tenNS, string chucVu)
        {
            this.maNS = maNS;
            this.tenNS = tenNS;
            this.chucVu = chucVu;

        }

        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyCongVan;Integrated Security=True");
        public void Hienthi(ListView item)
        {
            item.Items.Clear();
            try
            {
                conn.Open();
            }
            catch (System.InvalidOperationException)
            {
                //
            }
            SqlCommand cmd = new SqlCommand("select * from NHANSU", conn);
            SqlDataReader Doc = cmd.ExecuteReader();

            int i = 0;
            while (Doc.Read())
            {
                item.Items.Add((i + 1).ToString());
                item.Items[i].SubItems.Add(Doc[0].ToString());
                item.Items[i].SubItems.Add(Doc[1].ToString());
                item.Items[i].SubItems.Add(Doc[2].ToString());
                i++;
            }
            conn.Close();

            //System.InvalidOperationException
        }

        public bool KT_check(string key)
        {

            bool kt = false;
            string sql = "SELECT MaNS FROM NHANSU";
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            dt.AcceptChanges();
            foreach (DataRow row in dt.Rows)
            {
                string maCQ = row["MaNS"].ToString();

                if (String.Compare(maCQ.Trim(), key.Trim(), true) == 0)
                {
                    kt = true; 
                    break;
                }
            }
            return kt;
        }

        //Lenh insert 
        public void Insert(Class_NhanSu ob)
        {
            string sql = "INSERT INTO NHANSU VALUES(N'" + ob.maNS + "', N'" + ob.tenNS + "', N'" + ob.chucVu + "')";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

        }
        //Lenh update
        public void Update(Class_NhanSu ob)
        {
            string sql = "Update NHANSU set MaNS='" + ob.maNS + "', TenNhanSu='" + ob.tenNS + "', ChucVu='" + ob.chucVu + "' where MaNS='" + ob.maNS + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        //Lenh delete
        public void Delete(Class_NhanSu ob)
        {
            string sql = "DELETE from NHANSU where MaNS='" + ob.maNS + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (System.Data.SqlClient.SqlException)
            {
                //
            }
            conn.Close();
        }

        public DataTable Load_Table(String sql)
        {
            Class_NhanSu ob = new Class_NhanSu();
            ob.conn.Open();
            SqlDataAdapter ad = new SqlDataAdapter(sql, ob.conn);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            ob.conn.Close();
            return dt;
        }
    }
}
