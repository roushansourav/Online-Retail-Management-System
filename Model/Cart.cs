using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Cart
    {
        int cart_id;
        int uid;
        int pid;
        string pname;
        string pimage;
        int quantity;
        double amount;
        string status;
        DateTime createdon;

        public int Cart_id { get => cart_id; set => cart_id = value; }
        public int Uid { get => uid; set => uid = value; }
        public int Pid { get => pid; set => pid = value; }
        public string Pname { get => pname; set => pname = value; }
        public string Pimage { get => pimage; set => pimage = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public double Amount { get => amount; set => amount = value; }
        public string Status { get => status; set => status = value; }
        public DateTime Createdon { get => createdon; set => createdon = value; }
    }
}
