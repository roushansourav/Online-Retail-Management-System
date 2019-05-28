using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Admin
{
    public partial class User : System.Web.UI.Page
    {
        DAO.Admin a = new DAO.Admin();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"].ToString() == "admin")
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
            
            GridView1.DataSource = a.GetUsers();
            GridView1.DataBind(); 

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            //int id = int.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());            
            int id= int.Parse(row.Cells[1].Text);
            a.DeleteUser(id);
            Response.Write(id);
            BindView();
        }
    }
}