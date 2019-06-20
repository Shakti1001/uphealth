using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace NewWebApp.proforma
{
    public partial class Cpostdetail : System.Web.UI.Page
    {
        public String QS, sr;
        protected void Page_Load(object sender, EventArgs e)
        {
            //<%=%>

            //QS = "SELECT divname, districtname, tehsilname, blockname, htype, hname, sno, bedoccupacy FROM hospitallist where divid=1";
            //this.SqlDataSource1.SelectCommand = QS;
            //Response.Write(QS);
            if (!Page.IsPostBack)
            {
                this.TextBox3.Text = (string)Session["post"];
                //sr = "SELECT divname, districtname, tehsilname, blockname, htype, hname, sno, bedoccupacy FROM hospitallist " + Request.QueryString["qr"] + "";
                sr = "SELECT divname, districtname, tehsilname, blockname, htype, hname, sno, bedoccupacy FROM hospitallist " + (string)Session["zr"] + " order by divname, districtname, tehsilname, blockname, htype";
                this.SqlDataSource1.SelectCommand = sr;

            }
            //<asp:SqlDataSource SelectCommand="<%=public_variable_name %>" ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
        }
    }
}