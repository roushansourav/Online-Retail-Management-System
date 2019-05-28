using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Payment
    {
        Int64 payment_id;
        int uid;
        int cart_id;
        int ship_id;
        double totalamount;
        string cardNumber;
        string expiryDate;
        string cvv;
        string status;
        DateTime paymentdate;

        public int Uid { get => uid; set => uid = value; }
        public int Cart_id { get => cart_id; set => cart_id = value; }
        public int Ship_id { get => ship_id; set => ship_id = value; }
        public double Totalamount { get => totalamount; set => totalamount = value; }
        public string CardNumber { get => cardNumber; set => cardNumber = value; }
        public string ExpiryDate { get => expiryDate; set => expiryDate = value; }
        public string Cvv { get => cvv; set => cvv = value; }
        public string Status { get => status; set => status = value; }
        public Int64 Payment_id { get => payment_id; set => payment_id = value; }
        public DateTime Paymentdate { get => paymentdate; set => paymentdate = value; }
    }
}
