using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewWebApp.paramedicalstaff
{
    public partial class P2report : System.Web.UI.Page
    {
        Class1 c = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                c.gv(GridView1, "select * from pmdfactsheet where idno='" + Request.QueryString["idno"] + "'");
            }

        }
    }
}