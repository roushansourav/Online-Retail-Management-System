using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAO;

namespace Controller
{
    public class Shipping
    {
        public bool ShippingValidate(Model.ShippingDetail sd)
        {
            DAO.ShippingDetail dsd = new DAO.ShippingDetail();
            bool status = false;
            if(sd.Ship_id!=0 && sd.Uid!=0 && sd.Cart_id!=0 && sd.Contact!=null && sd.Name!=null && sd.Email!=null)
            {
                status=dsd.InsertShippingDetail(sd);
            }
            return status;
        }
    }
}
