﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace NewWebApp.Proforma2
{
    public partial class Retiredocprint : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Label2.Text = SUBRequest.QueryString["DT1"];
            d1();
        }

        public void d1()
        {
            try
            {
                data();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");

            }
            finally
            {
                Label1.Visible = true;
            }
        }
        public void usecheckD()
        {
            bool i;
            i = cl.checklavel((string)Session["iduser"]);
            if (i == true)
            {
                //***************DISTRICT****************        
                if (Request.QueryString["Dis"] != "N")//DisId
                {
                    if (Request.QueryString["Dis"].Length == 1)
                    {
                        Uidt.Text = "DisId=" + Request.QueryString["Dis"] + "";
                    }
                    else
                    {
                        Uidt.Text = "DisId like '%" + Request.QueryString["Dis"] + "%'";
                    }
                }
                else { Uidt.Text = "DisId like '%'"; }
            }
            else
            {
                cl.ds = cl.DataFill("SELECT DisId FROM Ucreate WHERE (iduser ='" + (string)Session["iduser"] + "')");
                if (cl.ds.Tables[0].Rows.Count > 0)
                {
                    Uidt.Text = cl.ds.Tables[0].Rows[0][0].ToString();
                    Uidt.Text = "DisId=" + Uidt.Text + "";
                }
                else
                {
                    Response.Redirect("~/login.aspx");
                }
            }
        }
        public void data()
        {
            usecheckD();
            //cl.ds = cl.DataFill("SELECT Distinct(idno) as ComputerID,districtname as Posting,hname as Hospital,newpostname as Post,senno as Seniority, name as Name,convert(varchar,dob,103)as DateOfBirth FROM    factsheetsearchCriteria WHERE   (DATEDIFF(yy, dob, GETDATE()) >= 60)  order by districtname,hname, name");

            string q2;
            if (Request.QueryString["Div"] != "N")
            {
                if (Request.QueryString["Div"].Length == 1)
                {
                    q2 = "divid=" + Request.QueryString["Div"] + "";
                }
                else
                {
                    q2 = "divid like '%" + Request.QueryString["Div"] + "%'";
                }
                //Div = Request.QueryString["Div"];
            }
            else
            {

                //Div = "%";
                q2 = "divid like '%'";
            }
            //////if (Request.QueryString["Dis"] != "N")
            //////{
            //////    if (Request.QueryString["Dis"].Length == 1)
            //////    {
            //////        q1 = "divid";
            //////    }
            //////    else
            //////    {
            //////        q1 = "";
            //////    }
            //////    Dis = "%" + Request.QueryString["Dis"] + "%";
            //////}
            //////else
            //////{
            //////    Dis = "%";
            //////    //q1 = "";
            //////}

            ////if (Div != "%")
            ////{//Datediff(yyyy,convert(varchar(20),dob,101),'01/01/2008')>60 or Datediff(yyyy,convert(varchar(20),dob,101),'01/01/2009')>60
            ////    //cl.ds = cl.DataFill("SELECT DISTINCT  idno AS ComputerID, name AS Name, senno AS Seniority, newpostname AS Post, districtname AS Posting, hname AS Hospital, CONVERT(varchar, dob, 103) AS DateOfBirth,DATEDIFF(yy, dob, GETDATE()) AS Age,SUBSTRING(CONVERT(varchar, dob, 106), 3, 4) AS retdate,year(dob)+60 as X ,DATEDIFF(yy, dob, '" + Request.QueryString["DT1"] + "')as A,DATEDIFF(yy, dob, '" + Request.QueryString["DT2"] + "')as B FROM    factsheetsearchCriteria WHERE   (DATEDIFF(yy, dob, '" + Request.QueryString["DT2"] + "') = 60)  AND (DATEDIFF(dd, dob, '" + Request.QueryString["DT2"] + "') >= 365 * DATEDIFF(yy, dob, '" + Request.QueryString["DT2"] + "'))and  (divid =" + Convert.ToInt32(Div) + ") AND (DisId like '" + Uidt.Text + "')  order by districtname,hname,DATEDIFF(yy, dob, GETDATE())");
            ////    cl.ds = cl.DataFill("SELECT DISTINCT  idno AS ComputerID, name AS Name, senno AS Seniority, newpostname AS Post, districtname AS Posting, hname AS Hospital, CONVERT(varchar, dob, 103) AS DateOfBirth,DATEDIFF(yy, dob, GETDATE()) AS Age,SUBSTRING(CONVERT(varchar, dob, 106), 3, 4) AS retdate,year(dob)+60 as X ,DATEDIFF(yy, dob, '" + Request.QueryString["DT1"] + "')as A,DATEDIFF(yy, dob, '" + Request.QueryString["DT2"] + "')as B FROM    factsheetsearchCriteria WHERE    ( Datediff(yyyy,convert(varchar(20),dob,101),'" + Request.QueryString["DT1"] + "')>60 or Datediff(yyyy,convert(varchar(20),dob,101),'" + Request.QueryString["DT2"] + "')>60) and  (divid =" + Convert.ToInt32(Div) + ") AND (DisId like '" + Uidt.Text + "') And DATEDIFF(yy, dob, GETDATE())<62 order by districtname,hname,DATEDIFF(yy, dob, GETDATE())");//  (DATEDIFF(yy, dob, '" + Request.QueryString["DT2"] + "') = 60)  AND (DATEDIFF(dd, dob, '" + Request.QueryString["DT2"] + "') >= 365 * DATEDIFF(yy, dob, '" + Request.QueryString["DT2"] + "'))
            ////}
            ////else
            ////{
            ////    cl.ds = cl.DataFill("SELECT DISTINCT  idno AS ComputerID, name AS Name, senno AS Seniority, newpostname AS Post, districtname AS Posting, hname AS Hospital, CONVERT(varchar, dob, 103) AS DateOfBirth,DATEDIFF(yy, dob, GETDATE()) AS Age,SUBSTRING(CONVERT(varchar, dob, 106), 3, 4) AS retdate,year(dob)+60 as X ,DATEDIFF(yy, dob, '" + Request.QueryString["DT1"] + "')as A,DATEDIFF(yy, dob, '" + Request.QueryString["DT2"] + "')as B FROM    factsheetsearchCriteria WHERE ( Datediff(yyyy,convert(varchar(20),dob,101),'" + Request.QueryString["DT1"] + "')>60 or Datediff(yyyy,convert(varchar(20),dob,101),'" + Request.QueryString["DT2"] + "')>60)  and  (divid like'" + Div + "') AND (DisId like '" + Uidt.Text + "')And DATEDIFF(yy, dob, GETDATE())<62   order by districtname,hname,DATEDIFF(yy, dob, GETDATE())");// (DATEDIFF(yy, dob, '" + Request.QueryString["DT2"] + "') = 60)AND (DATEDIFF(dd, dob, '" + Request.QueryString["DT2"] + "') >= 365 * DATEDIFF(yy, dob, '" + Request.QueryString["DT2"] + "'))
            ////}
            string QQ = "SELECT DISTINCT  idno AS ComputerID, name AS Name, senno AS Seniority, newpostname AS Post, districtname AS Posting, hname AS Hospital, CONVERT(varchar, dob, 103) AS DateOfBirth,DATEDIFF(yy, dob, GETDATE()) AS Age,SUBSTRING(CONVERT(varchar, dob, 106), 3, 4) AS retdate,year(dob)+60 as X ,DATEDIFF(yy, dob, '" + Request.QueryString["DT1"] + "')as A,DATEDIFF(yy, dob, '" + Request.QueryString["DT2"] + "')as B FROM    factsheetsearchCriteria  WHERE ( Datediff(yyyy,convert(varchar(20),dob,101),'" + Request.QueryString["DT1"] + "')>60 or Datediff(yyyy,convert(varchar(20),dob,101),'" + Request.QueryString["DT2"] + "')>60) And " + q2 + "AND " + Uidt.Text + "And DATEDIFF(yy, dob, GETDATE())<62   order by districtname,hname,DATEDIFF(yy, dob, GETDATE())";
            cl.ds = cl.DataFill(QQ);
            int j;
            if (cl.ds.Tables[0].Rows.Count > 0)
            {
                Label1.Visible = false;
                TableRow rw = new TableRow();
                rw.BorderWidth = 1;
                rw.ForeColor = System.Drawing.Color.Black;

                TableCell tcell0 = new TableCell();
                tcell0.Text = "SerialNo";
                tcell0.BorderWidth = 1;
                tcell0.BorderColor = System.Drawing.Color.SlateGray;
                tcell0.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell0);

                TableCell tcell5 = new TableCell();
                tcell5.Text = "Name";//
                tcell5.BorderWidth = 1;
                tcell5.BorderColor = System.Drawing.Color.SlateGray;
                tcell5.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell5);


                TableCell tcell6 = new TableCell();
                tcell6.Text = "Seniority";//
                tcell6.BorderWidth = 1;
                tcell6.BorderColor = System.Drawing.Color.SlateGray;
                tcell6.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell6);

                TableCell tcell4 = new TableCell();
                tcell4.Text = "Post";//
                tcell4.BorderWidth = 1;
                tcell4.BorderColor = System.Drawing.Color.SlateGray;
                tcell4.ForeColor = System.Drawing.Color.Black; ;
                rw.Cells.Add(tcell4);

                TableCell tcell2 = new TableCell();
                tcell2.Text = "District";
                tcell2.BorderWidth = 1;
                tcell2.BorderColor = System.Drawing.Color.SlateGray;
                tcell2.ForeColor = System.Drawing.Color.Black; ;
                rw.Cells.Add(tcell2);

                TableCell tcell8 = new TableCell();
                tcell8.Text = "Last Posting Hospital";//
                tcell8.BorderWidth = 1;
                tcell8.BorderColor = System.Drawing.Color.SlateGray;
                tcell8.ForeColor = System.Drawing.Color.Black; ;
                rw.Cells.Add(tcell8);

                TableCell tcell3 = new TableCell();
                tcell3.Text = "Date Of Birth";
                tcell3.BorderWidth = 1;
                tcell3.BorderColor = System.Drawing.Color.SlateGray;
                tcell3.ForeColor = System.Drawing.Color.Black; ;
                rw.Cells.Add(tcell3);

                TableCell tcell1 = new TableCell();
                tcell1.Text = "Month And Year of Retirement";
                tcell1.BorderWidth = 1;
                tcell1.BorderColor = System.Drawing.Color.SlateGray;
                tcell1.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell1);


                Table1.Rows.Add(rw);
                for (j = 0; j <= cl.ds.Tables[0].Rows.Count - 1; j++)
                {
                    TableRow rw1 = new TableRow();
                    rw1.BorderWidth = 1;
                    rw1.BorderColor = System.Drawing.Color.SlateGray;
                    if (Convert.ToInt32(cl.ds.Tables[0].Rows[j][7].ToString()) >= 60)
                    {
                        rw1.ForeColor = System.Drawing.Color.SlateGray;
                    }
                    else
                    {
                        rw1.ForeColor = System.Drawing.Color.SlateGray;
                    }
                    //rw1.BackColor = System.Drawing.Color.SlateGray;

                    TableCell tcellk1 = new TableCell();
                    tcellk1.BorderWidth = 1;
                    tcellk1.BorderColor = System.Drawing.Color.SlateGray;
                    tcellk1.Text = Convert.ToString(j + 1);
                    rw1.Cells.Add(tcellk1);

                    TableCell tcellk6 = new TableCell();
                    //if (Convert.ToInt32(cl.ds.Tables[0].Rows[j][7].ToString()) >= 60)
                    //{
                    //}
                    //else
                    //{                   
                    //    tcellk6.ForeColor = System.Drawing.Color.Red;
                    //}
                    tcellk6.Text = cl.ds.Tables[0].Rows[j][1].ToString();
                    tcellk6.BorderWidth = 1;
                    tcellk6.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk6);

                    TableCell tcellk7 = new TableCell();
                    tcellk7.BorderWidth = 1;
                    tcellk7.BorderColor = System.Drawing.Color.SlateGray;
                    tcellk7.Text = cl.ds.Tables[0].Rows[j][2].ToString();
                    rw1.Cells.Add(tcellk7);
                    //tcellk7.Text = ("<a target='_blank' href=\'proforma1print.aspx?idno=" + (cl.ds.Tables[0].Rows[j][0].ToString() + ("\'>" + tcellk7.Text + "</a>")));

                    TableCell tcellk8 = new TableCell();
                    tcellk8.Text = cl.ds.Tables[0].Rows[j][3].ToString();
                    tcellk8.BorderWidth = 1;
                    tcellk8.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk8);


                    TableCell tcellk4 = new TableCell();
                    tcellk4.BorderWidth = 1;
                    tcellk4.BorderColor = System.Drawing.Color.SlateGray;
                    tcellk4.Text = cl.ds.Tables[0].Rows[j][4].ToString();
                    rw1.Cells.Add(tcellk4);


                    TableCell tcellk3 = new TableCell();
                    tcellk3.Text = cl.ds.Tables[0].Rows[j][5].ToString();
                    tcellk3.BorderWidth = 1;
                    tcellk3.BorderColor = System.Drawing.Color.SlateGray;
                    //tcellk3.ForeColor = System.Drawing.Color.DarkGreen;
                    rw1.Cells.Add(tcellk3);

                    TableCell tcellk5 = new TableCell();
                    tcellk5.Text = cl.ds.Tables[0].Rows[j][6].ToString();
                    tcellk5.BorderWidth = 1;
                    tcellk5.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk5);

                    TableCell tcellk2 = new TableCell();
                    //if (Convert.ToInt32(cl.ds.Tables[0].Rows[j][7].ToString()) >= 60)
                    //{
                    //    tcellk2.Text = "Retired";
                    //}
                    //else
                    //{
                    //    tcellk2.Text = cl.ds.Tables[0].Rows[j][7].ToString();
                    //    //tcellk2.ForeColor = System.Drawing.Color.Red;
                    //}
                    tcellk2.Text = cl.ds.Tables[0].Rows[j][8].ToString() + "/" + cl.ds.Tables[0].Rows[j][9].ToString();
                    tcellk2.BorderWidth = 1;
                    tcellk2.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk2);


                    Table1.Rows.Add(rw1);
                }
            }
            else
            {
                Label1.Visible = true;
            }
        } 
    }
}