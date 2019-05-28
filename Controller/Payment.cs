using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAO;


namespace Controller
{
    public class Payment
    {
        DAO.Payment pyd = new DAO.Payment();
        public bool ValidatePayment(Model.Payment py)
        {
            bool status = false;
            if (py.Cart_id != 0 & py.Ship_id != 0 & py.Uid != 0 & py.CardNumber != null & py.Totalamount != 0)
            {
                if (pyd.InsertPaymentDetail(py))
                    status = true;
                else
                    status = false;
            }
            return status;

        }
    }
}
