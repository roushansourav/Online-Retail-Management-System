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
    public class ShippingDetail
    {
        public bool InsertShippingDetail(Model.ShippingDetail sd)
        {
            SqlConnection con = new SqlConnection(SqlCon.constring);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into shipping_details values(@ship_id,@uid,@cart_id,@address,@name,@contact,@email)", con);
            cmd.Parameters.AddWithValue("@ship_id", sd.Ship_id);
            cmd.Parameters.AddWithValue("@uid", sd.Uid);
            cmd.Parameters.AddWithValue("@cart_id", sd.Ship_id);
            cmd.Parameters.AddWithValue("@address", sd.Shipping_address);
            cmd.Parameters.AddWithValue("@name", sd.Name);
            cmd.Parameters.AddWithValue("@contact", sd.Contact);
            cmd.Parameters.AddWithValue("@email", sd.Email);
            int cnt=cmd.ExecuteNonQuery();
            con.Close();
            if (cnt > 0)
                return true;
            else
                return false;
        }

        public Model.ShippingDetail GetShippingDetail(int ship_id)
        {
            
            SqlConnection con = new SqlConnection(SqlCon.constring);
            SqlDataAdapter da = new SqlDataAdapter("select * from shipping_details where ship_id=" + ship_id, con);
            DataSet shipset = new DataSet();
            da.Fill(shipset, "Shipping");
            Model.ShippingDetail sd = new Model.ShippingDetail();
               
            sd.Cart_id = int.Parse(shipset.Tables["Shipping"].Rows[0][2].ToString());
            sd.Uid = int.Parse(shipset.Tables["Shipping"].Rows[0][1].ToString());
            sd.Shipping_address = shipset.Tables["Shipping"].Rows[0][3].ToString();
            sd.Name = shipset.Tables["Shipping"].Rows[0][4].ToString();
            sd.Contact = shipset.Tables["Shipping"].Rows[0][5].ToString();
            sd.Email = shipset.Tables["Shipping"].Rows[0][6].ToString();
            return sd;

        }

        public Model.ShippingDetail GetShippingDetailByPaymentId(int paymentid)
        {

            SqlConnection con = new SqlConnection(SqlCon.constring);
            SqlDataAdapter da = new SqlDataAdapter("select * from shipping_details where ship_id in (select ship_id from payment_details where payment_id="+paymentid+")", con);
            DataSet shipset = new DataSet();
            da.Fill(shipset, "Shipping");
            Model.ShippingDetail sd = new Model.ShippingDetail();

            sd.Cart_id = int.Parse(shipset.Tables["Shipping"].Rows[0][2].ToString());
            sd.Uid = int.Parse(shipset.Tables["Shipping"].Rows[0][1].ToString());
            sd.Shipping_address = shipset.Tables["Shipping"].Rows[0][3].ToString();
            sd.Name = shipset.Tables["Shipping"].Rows[0][4].ToString();
            sd.Contact = shipset.Tables["Shipping"].Rows[0][5].ToString();
            sd.Email = shipset.Tables["Shipping"].Rows[0][6].ToString();
            return sd;

        }
    }
}
