using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Dispatch_management
{
    class Class_CoQuan
    {
        string maCQ, tenCQ, diaChi;
        string SDT;
        public Class_CoQuan() { }
        public Class_CoQuan(string maCQ, string tenCQ, string diaChi, string SDT)
        {
            this.maCQ = maCQ;
            this.tenCQ = tenCQ;
            this.diaChi = diaChi;
            this.SDT = SDT;
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
            SqlCommand cmd = new SqlCommand("select * from COQUAN", conn);
            SqlDataReader Doc = cmd.ExecuteReader();

            int i = 0;
            while (Doc.Read())
            {
                item.Items.Add((i + 1).ToString());
                item.Items[i].SubItems.Add(Doc[0].ToString());
                item.Items[i].SubItems.Add(Doc[1].ToString());
                item.Items[i].SubItems.Add(Doc[2].ToString());
                item.Items[i].SubItems.Add(Doc[3].ToString());
                i++;
            }
            conn.Close();

            //System.InvalidOperationException
        }

        public bool KT_check(string key)
        {

            bool kt = false;
            string sql = "SELECT MaCoQuan FROM COQUAN";
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            dt.AcceptChanges();
            foreach (DataRow row in dt.Rows)
            {
                string maCQ = row["MaCoQuan"].ToString();

                if (String.Compare(maCQ.Trim(), key.Trim(), true) == 0)
                {
                    kt = true; 
                    break;
                }
            }
            return kt;
        }

        public bool KT_check_SDT(string key)
        {

            bool kt = false;
            string sql = "SELECT SDT FROM COQUAN";
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            dt.AcceptChanges();
            foreach (DataRow row in dt.Rows)
            {

                string SDT = row["SDT"].ToString();
                if (String.Compare(SDT.Trim(), key.Trim(), true) == 0)
                {
                    kt = true;
                    break;
                }
            }
            return kt;
        }
        //Lenh insert 
        public void Insert(Class_CoQuan ob)
        {
            string sql = "INSERT INTO COQUAN VALUES(N'" + ob.maCQ + " ', N' " + ob.tenCQ + "', N'" + ob.diaChi + "',N'" + ob.SDT + "')";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

        }
        //Lenh update
        public void Update(Class_CoQuan ob)
        {
            string sql = "Update COQUAN set MaCoQuan='" + ob.maCQ + "', TenCoQuan='" + ob.tenCQ + "', DiaChi='" + ob.diaChi + "', SDT='" + ob.SDT + "' where MaCoQuan='" + ob.maCQ + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        //Lenh delete
        public void Delete(Class_CoQuan ob)
        {
            string sql = "DELETE from COQUAN where MaCoQuan='" + ob.maCQ + "'";
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
            Class_CoQuan ob = new Class_CoQuan();
            ob.conn.Open();
            SqlDataAdapter ad = new SqlDataAdapter(sql, ob.conn);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            ob.conn.Close();
            return dt;
        }
    }
}
