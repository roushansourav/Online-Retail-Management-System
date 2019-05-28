using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAO;

namespace Controller
{
    public class Cart
    {
        public bool AddToCartValidate(Model.Cart c)
        {
            bool valid = false;
            if(c.Cart_id!=0 & c.Pid!=0 & c.Uid !=0)
            {
                DAO.Cart dc = new DAO.Cart();
                if(dc.CheckProductInCart(c.Cart_id,c.Pid,c.Uid))
                {
                    valid = false;
                }
                else
                {
                    dc.AddProductToCart(c);
                    valid = true;
                }

            }
            return valid;
        }
       

    }
}
