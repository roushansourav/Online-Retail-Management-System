using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Product
    {
        int pid;
        string pname;
        string pimage;
        int scid;
        int pstock;
        string pdesc;
        double pprice;
        string pbrand;
        string pgender;

        public int Pid { get => pid; set => pid = value; }
        public string Pname { get => pname; set => pname = value; }
        public string Pimage { get => pimage; set => pimage = value; }
        public int Scid { get => scid; set => scid = value; }
        public int Pstock { get => pstock; set => pstock = value; }
        public string Pdesc { get => pdesc; set => pdesc = value; }
        public double Pprice { get => pprice; set => pprice = value; }
        public string Pbrand { get => pbrand; set => pbrand = value; }
        public string Pgender { get => pgender; set => pgender = value; }
    }
}
