using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SalesOffer
    {
        int sid;
        DateTime startdate;
        DateTime expirydate;
        int pid;
        double discount;
        string appliedon;
        int scid;

        public int Sid { get => sid; set => sid = value; }
        public DateTime Startdate { get => startdate; set => startdate = value; }
        public DateTime Expirydate { get => expirydate; set => expirydate = value; }
        public int Pid { get => pid; set => pid = value; }
        public double Discount { get => discount; set => discount = value; }
        public string Appliedon { get => appliedon; set => appliedon = value; }
        public int Scid { get => scid; set => scid = value; }
    }
}
