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
    public partial class pmdDDOcrosscheck : System.Web.UI.Page
    {
        string qr;
        ClDatabase cl = new ClDatabase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if ((string)Session["iduser"] == null)
                {
                    Response.Redirect("~/login.aspx");
                }
                if ((string)Session["ddoname"] != null && (string)Session["ddopid"] != null)
                {
                    DDOText.Text = (string)Session["ddoname"];
                    DDOIDLab.Text = (string)Session["ddopid"];
                    SALcheck();
                }
                else
                {
                    this.MSGLabel.Text = "Please select Proper One...";
                }
            }
        }
        public void SALcheck()
        {
            qr = "SELECT  a.idno as ID,b.name as Name,a.gpfno as GPFNo,a.bankaccno as AccountNo,ISNULL(a.basicpay, 0) AS Basicpay, ISNULL(a.Gradepay, 0) AS Gradepay, ISNULL(a.Ehra, 0) AS Hra, ISNULL(a.cca, 0) AS Cca, ISNULL(a.perpay, 0) AS PersonalPay, ISNULL(a.tpay, 0) AS [TP.A.], ISNULL(a.sppay, 0) AS Sppay, ISNULL(a.pensionpay, 0) AS Pensionpay, ISNULL(a.gpf, 0) AS GpfDeduction, ISNULL(a.gisi, 0) AS [G.I.S. Insurance], ISNULL(a.giss, 0) AS [G.I.S. Saving], ISNULL(a.incometax,0) AS Incometax,a.stopsal FROM         pmd_Pay_sal_mast AS a INNER JOIN pmd_salaryselect AS b ON a.idno = b.idno where b.ddoid=" + (string)Session["ddopid"] + "";// ISNULL(a.gvr, 0) AS gvr, ISNULL(a.Dhra, 0) AS Dhra, ISNULL(a.payded, 0) AS payded, ISNULL(a.salded, 0) AS salded,
            cl.ds = cl.DataFill(qr);
            GridView1.DataSource = cl.ds;
            GridView1.DataBind();
        }

       
        /*protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Delete")
            {
                int RowIndex = Convert.ToInt32(e.CommandArgument);
                cl.ds = cl.DataFill("SELECT  a.idno as ID,b.name as Name,a.gpfno as GPFNo,a.bankaccno as AccountNo,ISNULL(a.basicpay, 0) AS Basicpay, ISNULL(a.Gradepay, 0) AS Gradepay,  ISNULL(a.npaall, 0) AS Npaall , ISNULL(a.Ehra, 0) AS Hra, ISNULL(a.cca, 0) AS Cca, ISNULL(a.perpay, 0) AS PersonalPay, ISNULL(a.tpay, 0) AS [TP.A.], ISNULL(a.sppay, 0) AS Sppay, ISNULL(a.pensionpay, 0) AS Pensionpay,  ISNULL(a.attendance, 0) AS Attendance,  ISNULL(a.gpf, 0) AS GpfDeduction, ISNULL(a.gisi, 0) AS [G.I.S. Insurance], ISNULL(a.giss, 0) AS [G.I.S. Saving], ISNULL(a.incometax,0) AS Incometax,a.stopsal FROM         Pay_sal_mast AS a INNER JOIN salaryselect AS b ON a.idno = b.idno where b.ddoid=" + (string)Session["ddopid"] + "");
                string idnum = cl.ds.Tables[0].Rows[RowIndex][0].ToString();
               // string idnum = GridView1.Rows[RowIndex].Columns[1].ToString();
                try
                {
                    cl.upcon.Open();
                    SqlCommand cmd = new SqlCommand("Delete from pay_sal_mast  where idno="+idnum+"", cl.upcon);
                    cmd.ExecuteNonQuery();
                    //SALcheck();
                    Response.Redirect("DDOcrosscheck.aspx");






                }
                catch (Exception ex)
                {
                    Response.Write("Error: + ex.Message");
                }

                finally
                { cl.upcon.Close(); }
           
            }
        }*/

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/pmdpayrole/pmdSaldetH.aspx");
        }
    }
}