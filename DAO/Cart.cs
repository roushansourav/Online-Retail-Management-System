using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;


namespace DAO
{
    public class Cart
    {
        SqlConnection con = new SqlConnection(SqlCon.constring);
        public List<Model.Cart> GetCarts(int userid,int cartid)
        {
            List<Model.Cart> cartList = new List<Model.Cart>();
            SqlDataAdapter da = new SqlDataAdapter("select * from cart where status='" + "pending" + "'"+" and uid="+userid+" and cart_id="+cartid, con);
            DataSet userset = new DataSet();
            da.Fill(userset, "Carts");
            for (int i = 0; i < userset.Tables["Carts"].Rows.Count; i++)
            {
                Model.Cart c = new Model.Cart();
                c.Cart_id = int.Parse(userset.Tables["Carts"].Rows[i][0].ToString());
                c.Uid = int.Parse(userset.Tables["Carts"].Rows[i][1].ToString());
                c.Pid = int.Parse(userset.Tables["Carts"].Rows[i][2].ToString());
                c.Pname = (userset.Tables["Carts"].Rows[i][3].ToString());
                c.Pimage = (userset.Tables["Carts"].Rows[i][4].ToString());
                c.Quantity = int.Parse(userset.Tables["Carts"].Rows[i][5].ToString());
                c.Amount = double.Parse(userset.Tables["Carts"].Rows[i][6].ToString());
                c.Status =userset.Tables["Carts"].Rows[i][7].ToString();
                c.Createdon=DateTime.Parse(userset.Tables["Carts"].Rows[i][8].ToString());

                cartList.Add(c);
            }
            return cartList;
        }

        public List<Model.Cart> GetCartsPaid(int userid, int cartid)
        {
            List<Model.Cart> cartList = new List<Model.Cart>();
            SqlDataAdapter da = new SqlDataAdapter("select * from cart where status='" + "paid" + "'" + " and uid=" + userid + " and cart_id=" + cartid, con);
            DataSet userset = new DataSet();
            da.Fill(userset, "Carts");
            for (int i = 0; i < userset.Tables["Carts"].Rows.Count; i++)
            {
                Model.Cart c = new Model.Cart();
                c.Cart_id = int.Parse(userset.Tables["Carts"].Rows[i][0].ToString());
                c.Uid = int.Parse(userset.Tables["Carts"].Rows[i][1].ToString());
                c.Pid = int.Parse(userset.Tables["Carts"].Rows[i][2].ToString());
                c.Pname = (userset.Tables["Carts"].Rows[i][3].ToString());
                c.Pimage = (userset.Tables["Carts"].Rows[i][4].ToString());
                c.Quantity = int.Parse(userset.Tables["Carts"].Rows[i][5].ToString());
                c.Amount = double.Parse(userset.Tables["Carts"].Rows[i][6].ToString());
                c.Status = userset.Tables["Carts"].Rows[i][7].ToString();
                c.Createdon = DateTime.Parse(userset.Tables["Carts"].Rows[i][8].ToString());

                cartList.Add(c);
            }
            return cartList;
        }

        public bool AddProductToCart(Model.Cart c)
        {
                SqlConnection con = new SqlConnection(SqlCon.constring);            
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into cart values(@id,@uid,@pid,@pname,@pimage,@quantity,@amount,@status,@createdon)", con);
                cmd.Parameters.AddWithValue("@id", c.Cart_id);
                cmd.Parameters.AddWithValue("@uid", c.Uid);
                cmd.Parameters.AddWithValue("@pid", c.Pid);
                cmd.Parameters.AddWithValue("@pname", c.Pname);
                cmd.Parameters.AddWithValue("@pimage", c.Pimage);
                cmd.Parameters.AddWithValue("@quantity", c.Quantity);
                cmd.Parameters.AddWithValue("@amount", c.Amount);
                cmd.Parameters.AddWithValue("@status", c.Status);
                cmd.Parameters.AddWithValue("@createdon", c.Createdon);
            int cnt = cmd.ExecuteNonQuery();
                con.Close();            
            if (cnt > 0)
                return true;
            else
                return false;
        }

        public bool CheckProductInCart(int cartid,int pid,int uid)
        {
            SqlConnection con = new SqlConnection(SqlCon.constring);
            con.Open();            
            SqlCommand cmd = new SqlCommand("select count(pid) from cart where cart_id=@id and uid=@uid and pid=@pid", con);
            cmd.Parameters.AddWithValue("@id", cartid);
            cmd.Parameters.AddWithValue("@uid", uid);
            cmd.Parameters.AddWithValue("@pid", pid);
            int cnt = int.Parse(cmd.ExecuteScalar().ToString());
            con.Close();
            if (cnt > 0)
            {
                SqlCommand cmd1 = new SqlCommand("select quantity from cart where cart_id=@id and uid=@uid and pid=@pid", con);
                cmd1.Parameters.AddWithValue("@id", cartid);
                cmd1.Parameters.AddWithValue("@uid", uid);
                cmd1.Parameters.AddWithValue("@pid", pid);
                con.Open();
                
                int quantity = int.Parse(cmd1.ExecuteScalar().ToString());
                SqlCommand cmd2 = new SqlCommand("update cart set quantity=@quantity where cart_id=@id and uid=@uid and pid=@pid", con);
                cmd2.Parameters.AddWithValue("@id", cartid);
                cmd2.Parameters.AddWithValue("@uid", uid);
                cmd2.Parameters.AddWithValue("@pid", pid);
                cmd2.Parameters.AddWithValue("@quantity", ++quantity);
                cmd2.ExecuteNonQuery();
                return true;
            }
                
            else
                return false;
        }


        public Dictionary<int,int> GetQuantityByUid(int uid,int cartid)
        {
            string query = "select pid,quantity from cart where uid="+uid+" and cart_id="+cartid;
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            Dictionary<int, int> quantity = new Dictionary<int, int>();
            DataSet productset = new DataSet();
            da.Fill(productset, "cartDic");

            for (int i = 0; i < productset.Tables["cartDic"].Rows.Count; i++)
            {
                quantity.Add(int.Parse(productset.Tables["CartDic"].Rows[i][0].ToString()), int.Parse(productset.Tables["CartDic"].Rows[i][1].ToString()));
                           
            }
            return quantity;
        }

        public void UpdateInCart(int cartid, int userid,Dictionary<int,int> quantdic)
        {
            SqlConnection con = new SqlConnection(SqlCon.constring);
            con.Open();
            foreach(var ch in quantdic)
            {
                SqlCommand cmd = new SqlCommand("update cart set quantity=@quant where pid=@pid and uid="+userid+" and cart_id="+cartid, con);
                cmd.Parameters.AddWithValue("@quant", ch.Value);
                cmd.Parameters.AddWithValue("@pid", ch.Key);
                cmd.ExecuteNonQuery();
                
            }
            con.Close();


        }

        public void DeleteProductFromCart(int cartid, int userid, List<int> pidList)
        {
            SqlConnection con = new SqlConnection(SqlCon.constring);
            con.Open();
            foreach (int n in pidList)
            {
                SqlCommand cmd = new SqlCommand("delete from cart where pid=@pid and uid=" + userid + " and cart_id=" + cartid, con);
                cmd.Parameters.AddWithValue("@pid", n);
                cmd.ExecuteNonQuery();

            }
            con.Close();


        }

        public int GetCart(int userid)
        {
            SqlConnection con = new SqlConnection(SqlCon.constring);
            con.Open();
            int cartid = 0;
            SqlCommand cmd = new SqlCommand("select cart_id from cart where uid=@uid and status='pending'", con);
            cmd.Parameters.AddWithValue("@uid", userid);
            if (cmd.ExecuteScalar() == null)
                cartid = 0;
            else
                cartid = int.Parse(cmd.ExecuteScalar().ToString());
            return cartid;

        }
            
        
    }
}
