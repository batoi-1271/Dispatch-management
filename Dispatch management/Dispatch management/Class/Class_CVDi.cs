using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Dispatch_management
{
    class Class_CVDi
    {
        string soCV, trichYeu, loaiCV, noiGDi, nguoiKG;
        DateTime ngayCV, ngayDi;

        public Class_CVDi() { }
        public Class_CVDi(string soCV, DateTime ngayCV, DateTime ngayDi, string trichYeu, string loaiCV, string noiGDi, string nguoiKG)
        {
            this.soCV = soCV;
            this.ngayCV = ngayCV;
            this.ngayDi = ngayDi;
            this.trichYeu = trichYeu;
            this.loaiCV = loaiCV;
            this.noiGDi = noiGDi;
            this.nguoiKG = nguoiKG;
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
            SqlCommand cmd = new SqlCommand("select cvd.SoCV, cvd.NgayCongVan, cvd.NgayDi, cvd.TrichYeu, lcv.TenLoaiCV, cq.TenCoQuan, ns.TenNhanSu FROM CONGVANDI cvd INNER join LOAICONGVAN lcv on cvd.MaLoaiCV = lcv.MaLoaiCV INner join COQUAN cq  on cvd.MaCoQuan = cq.MaCoQuan inner join NHANSU ns on cvd.MaNS = ns.MaNS", conn);

            SqlDataReader Doc = cmd.ExecuteReader();

            int i = 0;
            while (Doc.Read())
            {
                item.Items.Add((i + 1).ToString());
                item.Items[i].SubItems.Add(Doc[0].ToString());
                item.Items[i].SubItems.Add(Doc[1].ToString());
                item.Items[i].SubItems.Add(Doc[2].ToString());
                item.Items[i].SubItems.Add(Doc[3].ToString());
                item.Items[i].SubItems.Add(Doc[4].ToString());
                item.Items[i].SubItems.Add(Doc[5].ToString());
                item.Items[i].SubItems.Add(Doc[6].ToString());
                i++;
            }
            conn.Close();

            //System.InvalidOperationException
        }

            public bool KT_Key (string key)
        {
            bool kt = false;
            string sql = "SELECT SoCV FROM CONGVANDI";
            DataTable DT = new DataTable();
            SqlCommand com = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = com;
            da.Fill(DT);
            DT.AcceptChanges();
            foreach(DataRow row in DT.Rows)
            {
                string maSP = row["SoCV"].ToString();
                if (String.Compare(maSP.Trim(), key.Trim(), true) == 0)
                {
                    kt = true;
                    break;
                }
            }
            return kt; 
        }
        //Lenh insert 
            public void Insert(Class_CVDi ob)
        {
            string sql = "INSERT INTO CONGVANDI VALUES(N'" + ob.soCV + " ', N' " + ob.ngayCV + "', N'" + ob.ngayDi + "',N'" + ob.trichYeu + "', N'" + ob.loaiCV +"', N'" + ob.noiGDi +"', N'"+ ob.nguoiKG +"')";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

        }
        //Lenh update
            public void Update(Class_CVDi ob)
        {
            string sql = "Update CONGVANDI set SoCV='" + ob.soCV + "',NgayCongVan='" + ob.ngayCV + "', NgayDi='" + ob.ngayDi + "', TrichYeu='" + ob.trichYeu + "', MaLoaiCV='" + ob.loaiCV + "', MaCoQuan='" + ob.noiGDi + "', MaNS='" + ob.nguoiKG + "' where SoCV='" + ob.soCV + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        //Lenh delete
            public void Delete(Class_CVDi ob)
        {
            string sql = "DELETE from CONGVANDI where SoCV='" + ob.soCV + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (System.Data.SqlClient.SqlException)
            {
                
            }
            conn.Close();
        }

        public DataTable Load_Table(String sql)
        {
            Class_CVDi ob = new Class_CVDi();
            ob.conn.Open();
            SqlDataAdapter ad = new SqlDataAdapter(sql, ob.conn);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            ob.conn.Close();
            return dt;
        }
    }
}
