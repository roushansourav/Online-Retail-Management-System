using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DAO;
using System.Data;
using Model;

namespace DAO
{
    public class Product
    {
        SqlConnection con = new SqlConnection(SqlCon.constring);
       public List<Model.Product> GetProducts(int subcid)
        {
            List<Model.Product> productList = new List<Model.Product>();
            SqlDataAdapter da = new SqlDataAdapter("select * from products where scid="+subcid, con);
            DataSet productset = new DataSet();
            da.Fill(productset, "Products");
            for (int i = 0; i < productset.Tables["Products"].Rows.Count; i++)
            {
                Model.Product p = new Model.Product();
                p.Pid = int.Parse(productset.Tables["Products"].Rows[i][0].ToString());
                p.Pname = productset.Tables["Products"].Rows[i][1].ToString();
                p.Pimage = productset.Tables["Products"].Rows[i][2].ToString();
                p.Scid = int.Parse(productset.Tables["Products"].Rows[i][3].ToString());
                p.Pstock= int.Parse(productset.Tables["Products"].Rows[i][4].ToString());
                p.Pdesc = productset.Tables["Products"].Rows[i][5].ToString();
                p.Pprice = double.Parse(productset.Tables["Products"].Rows[i][6].ToString());
                p.Pbrand = productset.Tables["Products"].Rows[i][7].ToString();
                p.Pgender = productset.Tables["Products"].Rows[i][8].ToString();
                productList.Add(p);
            }

            return productList;
        }
        public List<Model.Product> GetProductsById(int pid)
        {
            List<Model.Product> productList = new List<Model.Product>();
            SqlDataAdapter da = new SqlDataAdapter("select * from products where pid=" + pid, con);
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

        public Model.Product GetProductsCartById(int pid)
        {
            List<Model.Product> productList = new List<Model.Product>();
            SqlDataAdapter da = new SqlDataAdapter("select * from products where pid=" + pid, con);
            DataSet productset = new DataSet();
            da.Fill(productset, "Products");
            Model.Product p = new Model.Product();
            for (int i = 0; i < productset.Tables["Products"].Rows.Count; i++)
            {
                
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

            return p;
        }

        public List<Model.Product> GetProductByCategory(string category,string searchkey)
        {
            string query = "select p.pid,p.pname,p.pimage,p.scid,pstock,p.pdesc,pprice,pbrand,pgender from category c join subcategory sc on c.cid = sc.cid join products p on p.scid = sc.scid where cname = '"+category+"' and pname like '%"+searchkey+"%'";
            List<Model.Product> productList = new List<Model.Product>();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
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

            return productList; ;
        }

        public void UpdateProductStock(Dictionary<int,int> quantity)
        {
            foreach(var ch in quantity)
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("select pstock from products where pid=@pid", con);
                cmd1.Parameters.AddWithValue("@pid", ch.Key);
                int stock = int.Parse(cmd1.ExecuteScalar().ToString());
                stock -= ch.Value;
                con.Close();
                con.Open();
                SqlCommand cmd2 = new SqlCommand("update products set pstock=@quant where pid=@pid", con);
                cmd2.Parameters.AddWithValue("@quant", stock);
                cmd2.Parameters.AddWithValue("@pid", ch.Key);
                cmd2.ExecuteNonQuery();
                con.Close();
            }
        }



    }
}
