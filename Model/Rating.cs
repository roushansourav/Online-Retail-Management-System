using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Rating
    {
        int rid;
        int pid;
        int uid;
        int rating;
        string feedback;

        public int Rid { get => rid; set => rid = value; }
        public int Pid { get => pid; set => pid = value; }
        public int Uid { get => uid; set => uid = value; }
        public int Ratings { get => rating; set => rating = value; }
        public string Feedback { get => feedback; set => feedback = value; }
    }
}
