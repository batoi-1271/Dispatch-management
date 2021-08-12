using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Dispatch_management
{
    class Decentralization
    {
        string UID = Login.ID_USER;
        SqlConnection ketnoi = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyCongVan;Integrated Security=True");

       
        public string id_per(string id_user)
        {
            string id = "";
            try
            {
                ketnoi.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_per_relationship WHERE id_user_rel ='" + id_user + "'", ketnoi);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["suspended"].ToString() == "False")
                        {
                            id = dr["id_per_rel"].ToString();
                        }
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

        public List<string> list_per(string id_per)
        {
            List<string> termsList = new List<string>();
            try
            {
                ketnoi.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_permision_detail WHERE id_per ='" + id_per + "'", ketnoi);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        termsList.Add(dr["code_action"].ToString());
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
            return termsList;
        }

    }
}
