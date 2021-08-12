using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Dispatch_management
{
    class Class_LoaiCV
    {
        string maLoai, tenLoai;
        public Class_LoaiCV() { }
        public Class_LoaiCV(string maLoai, string tenLoai)
        {
            this.maLoai = maLoai;
            this.tenLoai = tenLoai;
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
            SqlCommand cmd = new SqlCommand("select * from LOAICONGVAN", conn);
            SqlDataReader Doc = cmd.ExecuteReader();

            int i = 0;
            while (Doc.Read())
            {
                item.Items.Add((i + 1).ToString());
                item.Items[i].SubItems.Add(Doc[0].ToString());
                item.Items[i].SubItems.Add(Doc[1].ToString());
                i++;
            }
            conn.Close();

            //System.InvalidOperationException
        }

        public bool KT_check(string key)
        {

            bool kt = false;
            string sql = "SELECT MaLoaiCV FROM LOAICONGVAN";
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            dt.AcceptChanges();
            foreach (DataRow row in dt.Rows)
            {
                string maCQ = row["MaLoaiCV"].ToString();

                if (String.Compare(maCQ.Trim(), key.Trim(), true) == 0)
                {
                    kt = true; 
                    break;
                }
            }
            return kt;
        }

        //Lenh insert 
        public void Insert(Class_LoaiCV ob)
        {
            string sql = "INSERT INTO LOAICONGVAN VALUES(N'" + ob.maLoai + " ', N' " + ob.tenLoai + "')";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

        }
        //Lenh update
        public void Update(Class_LoaiCV ob)
        {
            string sql = "Update LOAICONGVAN set TenloaiCV='" + ob.tenLoai + "', MaLoaiCV='" + ob.maLoai + "' where MaLoaiCV='" + ob.maLoai + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        //Lenh delete
        public void Delete(Class_LoaiCV ob)
        {
            string sql = "DELETE from LOAICONGVAN where MaLoaiCV='" + ob.maLoai + "'";
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
            Class_LoaiCV ob = new Class_LoaiCV();
            ob.conn.Open();
            SqlDataAdapter ad = new SqlDataAdapter(sql, ob.conn);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            ob.conn.Close();
            return dt;
        }
    }
}
