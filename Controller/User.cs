using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAO;
using System.Web.SessionState;
using System.Web;


namespace Controller
{
    public class User
    {
        public bool ValidateUser(Model.User u)
        {
            bool status = false;
            if (u.Uname != null & u.Upassword.Length >= 8)
            {
                
                DAO.User d1 = new DAO.User();
                if (!d1.CheckUser(u))
                {
                    d1.Insert(u);
                    status = true;
                }
                              
            }
            else
                status=false;
            return status;

        }

        public Model.User UserLoginValidation(string username, string password)
        {
            HttpContext context = HttpContext.Current;
            DAO.User d = new DAO.User();
            Model.User u = d.UserLogin(username);
            if (u.Upassword != null)
            {
                if (password.Equals(EncryptionDecryption.DecodeFrom64(u.Upassword)))
                {
                    return u;
                }
                else
                    return null;
            }
            else
                return null;

        }
        
    }
}
