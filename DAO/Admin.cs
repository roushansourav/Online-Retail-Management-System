using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.SqlClient;
using System.Data;


namespace DAO
{
    public class Admin
    {
        SqlConnection con = new SqlConnection(SqlCon.constring);
        public List<Model.User> GetUsers()
        {
            List<Model.User> userList = new List<Model.User>();            
            SqlDataAdapter da = new SqlDataAdapter("select * from users where role='"+"user"+"'", con);
            DataSet userset = new DataSet();
            da.Fill(userset, "Users");
            for (int i = 0; i < userset.Tables["Users"].Rows.Count; i++)
            {
                Model.User u = new Model.User();
                u.Uid = int.Parse(userset.Tables["Users"].Rows[i][0].ToString());
                u.Uname = userset.Tables["Users"].Rows[i][1].ToString();
                u.Uusername = null;
                u.Upassword = null;
                u.Uemail = userset.Tables["Users"].Rows[i][4].ToString();
                u.Ugender = userset.Tables["Users"].Rows[i][5].ToString();
                u.Umobile = userset.Tables["Users"].Rows[i][6].ToString();
                u.Udate = Convert.ToDateTime(userset.Tables["Users"].Rows[i][7].ToString());
                u.UDOB = Convert.ToDateTime(userset.Tables["Users"].Rows[i][8].ToString());
                u.Urole = userset.Tables["Users"].Rows[i][9].ToString();
                u.Uaddress = userset.Tables["Users"].Rows[i][10].ToString();
                userList.Add(u);
            }
            return userList;
        }

        public bool DeleteUser(int id)
        {
            SqlCommand cmd = new SqlCommand("delete from users where uid=@id", con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", id);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else
                return false;
        }

        public List<Model.Product> GetProducts()
        {
            List<Model.Product> productList = new List<Model.Product>();
            SqlDataAdapter da = new SqlDataAdapter("select * from products", con);
            DataSet productset = new DataSet();
            da.Fill(productset, "Products");
            for (int i = 0; i < productset.Tables["Products"].Rows.Count; i++)
            {
                Model.Product p = new Model.Product();
                p.Pid = int.Parse(productset.Tables["Products"].Rows[i][0].ToString());
                p.Pname = productset.Tables["Products"].Rows[i][1].ToString();
                p.Pimage = productset.Tables["Products"].Rows[i][2].ToString();
                p.Scid = int.Parse(productset.Tables["Products"].Rows[i][3].ToString());
                p.Pstock = int.Parse(productset.Tables["Products"].Rows[i][4].ToString());
                p.Pdesc = productset.Tables["Products"].Rows[i][5].ToString();
                p.Pprice = double.Parse(productset.Tables["Products"].Rows[i][6].ToString());
                p.Pbrand = productset.Tables["Products"].Rows[i][7].ToString();
                p.Pgender = productset.Tables["Products"].Rows[i][8].ToString();
                productList.Add(p);
            }
            return productList;
        }

        public bool DeleteProduct(int id)
        {
            SqlCommand cmd = new SqlCommand("delete from products where pid=@id", con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", id);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else
                return false;
        }

        public List<Model.Category> GetCategory()
        {
            List<Model.Category> categoryList = new List<Model.Category>();
            SqlDataAdapter da = new SqlDataAdapter("select * from category", con);
            DataSet categoryset = new DataSet();
            da.Fill(categoryset, "Category");
            for (int i = 0; i < categoryset.Tables["Category"].Rows.Count; i++)
            {
                Model.Category c = new Model.Category();

                c.Cid = int.Parse(categoryset.Tables["Category"].Rows[i][0].ToString());
                c.Cname = categoryset.Tables["Category"].Rows[i][1].ToString();
                c.Cstatus = categoryset.Tables["Category"].Rows[i][2].ToString();
                categoryList.Add(c);
            }
            
            return categoryList;
        }

        public bool DeleteCategory(int id)
        {
            SqlCommand cmd = new SqlCommand("delete from category where cid=@id", con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", id);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else
                return false;
        }

        public List<Model.SubCategory> GetSubCategory()
        {
            List<Model.SubCategory> subcategoryList = new List<Model.SubCategory>();
            SqlDataAdapter da = new SqlDataAdapter("select * from subcategory", con);
            DataSet subcategoryset = new DataSet();
            da.Fill(subcategoryset, "SubCategory");
            for (int i = 0; i < subcategoryset.Tables["SubCategory"].Rows.Count; i++)
            {
                Model.SubCategory sc = new Model.SubCategory();
                sc.Scid = int.Parse(subcategoryset.Tables["SubCategory"].Rows[i][0].ToString());
                sc.Cid = int.Parse(subcategoryset.Tables["SubCategory"].Rows[i][1].ToString());
                sc.Scname = subcategoryset.Tables["SubCategory"].Rows[i][2].ToString();
                sc.Sstatus = subcategoryset.Tables["SubCategory"].Rows[i][3].ToString();
                subcategoryList.Add(sc);
            }
            return subcategoryList;
        }

        public bool DeleteSubCategory(int id)
        {
            SqlCommand cmd = new SqlCommand("delete from subcategory where scid=@id", con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", id);
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            else
                return false;
        }
    }
}
