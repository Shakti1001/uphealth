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

namespace NewWebApp.Guest
{
    public partial class yearrepo : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();


        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Visible = false;
            for (int i = 2014; i <= 2017; i++)
            {
                int j = i + 1;
                string fy = i.ToString() + "-" + j.ToString();
                Drpyear.Items.Add(fy);

            }
            //Drpyear.Items.Insert(0, "-Select-");
            Drpyear.Items.Insert(0, new ListItem("-Select-", "0"));
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            // Lblcid.Visible = false;
            //  Lblmon.Visible = false;
            // Lblyear.Visible = false;
            //  cmpid.Visible = false;
            //  Drpmon.Visible = false;
            //  Drpyear.Visible = false;
            //  Button1.Visible = false;
            /*int idno = Convert.ToInt32(cmpid.Text);
            Session["idnum"] = idno;
            int month = Convert.ToInt32(Drpmon.SelectedValue);
            Session["Smonth"] = month;
            int year = Convert.ToInt32(Drpyear.SelectedValue);
            Session["Syear"] = year;
            if (Drpmon.SelectedIndex == 0 || Drpyear.SelectedIndex == 0)
            {
                Label1.Visible = true;
                Label1.Text = "Select Month or Year";
            }
            else
            {

                Response.Redirect("payslip.aspx");
            }*/
            int idno = Convert.ToInt32(cmpid.Text);
            Session["idnum"] = idno;
            // int month = Convert.ToInt32(Drpmon.SelectedValue);
            // Session["Smonth"] = month;
            // string fmonth = Drpmon.SelectedItem.Text.ToString();
            //Session["fsmonth"] = fmonth;
            string fyear = Drpyear.SelectedValue;
            Session["Fyear"] = fyear;

            if (Convert.ToInt32(fyear.Substring(0, 4)) == 0)
            {
                Label1.Visible = true;
                Label1.Text = "Select Year";
            }
            else
            {
                Response.Redirect("~/Guest/yearlyrepo.aspx");
            }

        }

        protected void Drpyear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Authenticate/login.aspx");
        }
    }
}