using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace Dispatch_management
{
    class Class_Login
    {
        SqlConnection ketnoi = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyCongVan;Integrated Security=True");
        public DataTable Load_Table(String sql)
        {
            Class_Login ob = new Class_Login();
            ob.ketnoi.Open();
            SqlDataAdapter ad = new SqlDataAdapter(sql, ob.ketnoi);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            ob.ketnoi.Close();
            return dt;
        }

        public List<string> getName(string name) 
        {
            DataTable dt = Load_Table("SELECT name_user, user_name FROM tbl_user where user_name = '" +name+ "'");
            string nameuser = dt.Rows[0]["user_name"].ToString();
            string username = dt.Rows[0]["name_user"].ToString();
            List<string> inf = new List<string>();
            inf.Add(nameuser);
            inf.Add(username);
            return inf;
        }


        public string getID(string username, string pass)
        {
            string id = "";
            try
            {
                ketnoi.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_user WHERE user_name ='" + username + "' and pass='" + pass + "'", ketnoi);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        id = dr["id_user"].ToString();

                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi xảy ra khi truy vấn dữ liệu hoặc kết nối với server thất bại !");
            }
            finally
            {
                ketnoi.Close();
            }
            return id;
        }
        
    }
}
