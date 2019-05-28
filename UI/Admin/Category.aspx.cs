using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Admin
{
    public partial class Category : System.Web.UI.Page
    {
        DAO.Admin a = new DAO.Admin();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(IsPostBack) && Session["Role"].ToString() == "admin")
            {
                BindView();
            }
            else
            {
                Response.Redirect("~/AccessDenied.aspx");
            }
        }
        private void BindView()
        {
            GridView1.DataSource = a.GetCategory();
            GridView1.DataBind();

        }
    }
}