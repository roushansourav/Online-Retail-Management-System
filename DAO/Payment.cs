using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.SqlClient;

namespace DAO
{
    public class Payment
    {
        public bool InsertPaymentDetail(Model.Payment py)
        {
            
            SqlConnection con = new SqlConnection(SqlCon.constring);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into payment_details values(@id,@uid,@cartid,@shipid,@amount,@cardnumber,@expirynumber,@cvv,@status,@date)", con);
            cmd.Parameters.AddWithValue("@id", py.Payment_id);
            cmd.Parameters.AddWithValue("@uid", py.Uid);
            cmd.Parameters.AddWithValue("@cartid", py.Cart_id);
            cmd.Parameters.AddWithValue("@shipid", py.Ship_id);
            cmd.Parameters.AddWithValue("@amount", py.Totalamount);
            cmd.Parameters.AddWithValue("@cardnumber", py.CardNumber);
            cmd.Parameters.AddWithValue("@expirynumber", py.ExpiryDate);
            cmd.Parameters.AddWithValue("@cvv", py.Cvv);
            cmd.Parameters.AddWithValue("@status", py.Status);
            cmd.Parameters.AddWithValue("@date", py.Paymentdate);
            cmd.ExecuteNonQuery();
            con.Close();

            SqlCommand cmd1 = new SqlCommand("update cart set status=@status where cart_id=@cartid and uid=@uid", con);
            con.Open();
            cmd1.Parameters.AddWithValue("@status", "paid");
            cmd1.Parameters.AddWithValue("@uid", py.Uid);
            cmd1.Parameters.AddWithValue("@cartid", py.Cart_id);
            int cnt = cmd1.ExecuteNonQuery();
            con.Close();
            Cart c = new Cart();
            Product p = new Product();
            p.UpdateProductStock(c.GetQuantityByUid(py.Uid, py.Cart_id));
            if (cnt>0)
                return true;
            else
                return false;
        }

        public void GetDetailsByUid(int uid,int transactionid)
        {

        }
    }
}
