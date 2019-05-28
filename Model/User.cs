using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User
    {
        int uid;
        string uname;
        string uusername;
        string upassword;
        string uemail;
        string ugender;
        string umobile;
        DateTime udate;
        DateTime uDOB;
        string urole;
        string uaddress;
        string uimage;

        public int Uid { get => uid; set => uid = value; }
        public string Uname { get => uname; set => uname = value; }
        public string Uusername { get => uusername; set => uusername = value; }
        public string Upassword { get => upassword; set => upassword = value; }
        public string Uemail { get => uemail; set => uemail = value; }
        public string Ugender { get => ugender; set => ugender = value; }
        public string Umobile { get => umobile; set => umobile = value; }
        public DateTime Udate { get => udate; set => udate = value; }
        public DateTime UDOB { get => uDOB; set => uDOB = value; }
        public string Urole { get => urole; set => urole = value; }
        public string Uaddress { get => uaddress; set => uaddress = value; }
        public string Uimage { get => uimage; set => uimage = value; }
    }
}
