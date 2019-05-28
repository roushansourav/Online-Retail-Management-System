using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Category
    {
        int cid;
        string cname;
        string cstatus;

        public int Cid { get => cid; set => cid = value; }
        public string Cname { get => cname; set => cname = value; }
        public string Cstatus { get => cstatus; set => cstatus = value; }
    }
}
