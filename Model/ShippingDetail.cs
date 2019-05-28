using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ShippingDetail
    {
        int ship_id;
        int uid;
        int cart_id;
        string shipping_address;
        string name;
        string contact;
        string email;

        public int Ship_id { get => ship_id; set => ship_id = value; }
        public int Uid { get => uid; set => uid = value; }
        public int Cart_id { get => cart_id; set => cart_id = value; }
        public string Shipping_address { get => shipping_address; set => shipping_address = value; }
        public string Name { get => name; set => name = value; }
        public string Contact { get => contact; set => contact = value; }
        public string Email { get => email; set => email = value; }
    }
}
