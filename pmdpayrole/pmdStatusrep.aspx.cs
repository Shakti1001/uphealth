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
using System.Data.SqlClient;

namespace NewWebApp.pmdpayrole
{
    public partial class pmdStatusrep : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        protected void Page_Load(object sender, EventArgs e)
        {

            showReport();
        }
        public void showReport()
        {
            cl.upcon.Open();
            cl.ds = cl.DataFill("select DisId,districtname,userid,username,count(pmd_pay_sal_mast.idno)as BasicRecord from hospitaldistrict,Ucreate left outer join pmd_pay_sal_mast on iduser=pmd_pay_sal_mast.ddocode where not Disid=0 and DisId=districtid group by pmd_pay_sal_mast.ddocode,username,DisId,userid,districtname order by DisId ,BasicRecord desc ");
            Status_Report.DataSource = cl.ds;
            lblsum.Text = cl.ds.Tables[0].Compute("SUM(BasicRecord)", string.Empty).ToString();
            Status_Report.DataBind();
            cl.upcon.Close();


        }
        protected void Status_Report_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        int i = 1;
        protected void Status_Report_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblSerial = (Label)e.Row.FindControl("lblSerial");
                lblSerial.Text = i.ToString();
                i++;
            }
        }
    }
}