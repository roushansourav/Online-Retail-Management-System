using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SubCategory
    {
        int scid;
        int cid;
        string scname;
        string sstatus;

        public int Scid { get => scid; set => scid = value; }
        public int Cid { get => cid; set => cid = value; }
        public string Scname { get => scname; set => scname = value; }
        public string Sstatus { get => sstatus; set => sstatus = value; }
    }
}
