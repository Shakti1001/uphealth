﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewWebApp.Guest
{
    public partial class genpaySlip : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();


        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Visible = false;
            for (int i = 2015; i <= 2016; i++)
            {

                Drpyear.Items.Add(i.ToString());

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
            int month = Convert.ToInt32(Drpmon.SelectedValue);
            Session["Smonth"] = month;
            string fmonth = Drpmon.SelectedItem.Text.ToString();
            Session["fsmonth"] = fmonth;
            int year = Convert.ToInt32(Drpyear.SelectedValue);
            Session["Syear"] = year;

            if (month == 0 || year == 0)
            {
                Label1.Visible = true;
                Label1.Text = "Select Month or Year";
            }
            else
            {
                Response.Redirect("payslip.aspx");
            }

        }



        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Proformachoice.aspx");

        }
        
        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Authenticate/login.aspx");
        }
    }
}