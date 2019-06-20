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

namespace NewWebApp.paramedicalstaff
{
    public partial class paraCurrentlistprint : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["iduser"] == null)
            {
                Response.Redirect("~/Authenticate/login.aspx");
            }
            else
            {
                d1();//data();// runqual();
            }
        }
        public void usecheckD()
        {
            bool i;
            i = cl.checklavel((string)Session["iduser"]);
            if (i == true)
            {
                distsublbl.Text = "";
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
                //// changes on date june 10 2011
                //    //    //DDO and Userid match
                //    if ((string)Session["UsDisId"] != null && (string)Session["ddoid"] != null)
                //    {
                //        Uidt.Text = (string)Session["UsDisId"];
                //        Uidt.Text = "DisId=" + Uidt.Text + "";
                //        //distsublbl.Text = cl.getdistlv((string)Session["UsHtype"]);
                //        distsublbl.Text=" and poposting in (select sno from hospitalname where ddoid=" + (string)Session["ddoid"] + ")";

                //        //cl.ds = cl.DataFill("SELECT DisId FROM Ucreate WHERE (iduser ='" + (string)Session["iduser"] + "')");
                //        //if (cl.ds.Tables[0].Rows.Count > 0)
                //        //{
                //        //    Uidt.Text = cl.ds.Tables[0].Rows[0][0].ToString();
                //        //    Uidt.Text = "DisId=" + Uidt.Text + "";
                //        //}
                //        //else
                //        //{
                //        //    Response.Redirect("~/login.aspx");
                //        //}
                //    }
                //// *************************************************
                //// Hospital allotted to user  (string)Session["iduser"]
                if ((string)Session["iduser"] != null && (string)Session["UsDisId"] != null)
                {
                    Uidt.Text = (string)Session["UsDisId"];
                    Uidt.Text = "DisId=" + Uidt.Text + "";
                    distsublbl.Text = " and poposting in (select sno from hospitalname where ddoid=" + (string)Session["iduser"] + ")";
                }
                else
                {
                    Response.Redirect("~/Authenticate/login.aspx");
                }
            }
        }



        public void d1()
        {
            usecheckD();
            string q1, q2, q3, q4, q5, q6;//string Div, DHna, DHt, post, cad, lav;//Dist,
            //**************HOSPITAL TYPE*****************        
            //if (Request.QueryString["DT"] != "N")
            //{
            //    if (Request.QueryString["DT"].Length == 1)
            //    {
            //        //DHt = Request.QueryString["DT"];
            //        q1 = "hid='" + Request.QueryString["DT"] + "'";
            //    }
            //    else
            //    {
            //        //DHt = "Like" + "%" + Request.QueryString["DT"] + "%";
            //        q1 = "hid Like '%" + Request.QueryString["DT"] + "%'";
            //    }
            //}
            //else
            //{ 
            // //DHt ="Like" + "%";
            //    q1 = "hid Like '%'";
            //}
            //**************HOSPITAL NAME*****************
            if (Request.QueryString["HN"] != "N")
            {  //DHna = "%" + Request.QueryString["HN"] + "%";
                q2 = "sno like '%" + Request.QueryString["HN"] + "%'";
            }
            else
            {
                //DHna = "%";
                q2 = "sno like '%'";
            }
            //****************POST***************
            if (Request.QueryString["Post"] != "N")
            {
                if (Request.QueryString["post"].Length == 1)
                {
                    //post = Request.QueryString["post"];
                    q3 = "postid=" + Request.QueryString["post"] + "";
                }
                else
                {
                    //post = "Like" + "%" + Request.QueryString["post"] + "%";
                    q3 = "postid like '%" + Request.QueryString["post"] + "%' ";
                }
            }
            else
            {
                //post ="Like"+ "%";
                q3 = "postid like '%'";
            }
            //***************LEVEL****************
            //if (Request.QueryString["lavel"] != "N")
            //{
            //    if (Request.QueryString["lavel"].Length == 1)
            //    {
            //        //lav = Request.QueryString["lavel"];
            //        q4 = "lavel='" + Request.QueryString["lavel"] + "'";
            //    }
            //    else
            //    {
            //        //lav = "Like" + "%" + Request.QueryString["lavel"] + "%";
            //        q4="lavel like '%"+Request.QueryString["lavel"]+ " %'";
            //    }
            //}
            //else { 
            //    //lav = "Like" + "%";
            //    q4 = "lavel like '%'";
            //}
            //****************CADRE***************
            if (Request.QueryString["cader"] != "N")
            {
                if (Request.QueryString["cader"].Length == 1)
                {
                    //cad = Request.QueryString["cader"];
                    q5 = "cadreid=" + Request.QueryString["cader"] + "";
                }
                else
                {
                    //cad = "Like" + "%" + Request.QueryString["cader"] + "%";
                    q5 = "cadreid like '%" + Request.QueryString["cader"] + "%'";
                }
            }
            else
            {
                //cad = "Like" + "%";
                q5 = "cadreid like '%'";
            }
            //*************Division***********
            if (Request.QueryString["Div"] != "N")
            {
                if (Request.QueryString["cader"].Length == 1)
                {
                    //Div = Request.QueryString["Div"];
                    q6 = "divid=" + Request.QueryString["Div"] + "";
                }
                else
                {
                    //Div = "Like" + "%" + Request.QueryString["Div"] + "%";
                    q6 = "divid like '% '" + Request.QueryString["Div"] + "'%'";
                }
            }
            else
            {
                //Div = "%";
                q6 = "divid like '%'";
            }//div ,dist,
            string qr = q6 + "AND " + Uidt.Text + "AND " + q2 + "AND " + q3 + "AND " + q5 + "";
            //string qr = q1 + "AND " + q2 + "AND " + q3 + "AND " + q4 + "AND " + q5 + "AND " + q6 + "AND " + Uidt.Text +"";
            //string qrf = "SELECT Distinct(idno) as ComputerID,districtname as Posting,hname as Hospital,name as Name,newpostname as Post, convert(varchar,doposting,103)as DateOfPosting,senno as Seniority FROM   paracurrentsearchCriteria WHERE " + qr + " " + distsublbl.Text + " order by districtname,hname,name";
            string qrf = "SELECT Distinct(idno) as ComputerID,districtname,hname as Hospital,name as Name,cadrename,feedingcadre, designame as post,convert(varchar,doposting,103)as DateOfPosting FROM   paracurrentsearchCriteria  WHERE " + qr + " " + distsublbl.Text + " ";


            //District,Place Of Posting,Name,Post,Date Of Posting,Seniority,ComputerID
            //string qrf = "SELECT Distinct(idno) as ComputerID,name as Name,senno as Seniority, newpostname as Post,districtname as Posting,hname as Hospital,convert(varchar,doposting,103)as DateOfPosting FROM   currentsearchCriteria WHERE " + qr + "order by districtname,hname,name";
            //ComputerID,Name,Seniority,Post,District,Place Of Posting,Date Of Posting
            cl.ds = cl.DataFill(qrf);
            int j;


            if (cl.ds.Tables[0].Rows.Count > 0)
            {
                strq.Visible = false;
                TableRow rw = new TableRow();
                rw.BorderWidth = 1;
                rw.ForeColor = System.Drawing.Color.Black;

                TableCell tcell0 = new TableCell();
                tcell0.Text = "SerialNo";
                tcell0.BorderWidth = 1;
                tcell0.BorderColor = System.Drawing.Color.SlateGray;
                tcell0.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell0);



                TableCell tcell77 = new TableCell();
                tcell77.Text = "ComputerID";//
                tcell77.BorderWidth = 1;
                tcell77.BorderColor = System.Drawing.Color.SlateGray;
                tcell77.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell77);

                TableCell tcell1 = new TableCell();
                tcell1.Text = "District";
                tcell1.BorderWidth = 1;
                tcell1.BorderColor = System.Drawing.Color.SlateGray;
                tcell1.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell1);

                TableCell tcell2 = new TableCell();
                tcell2.Text = "Place Of Posting";
                tcell2.BorderWidth = 1;
                tcell2.BorderColor = System.Drawing.Color.SlateGray;
                tcell2.ForeColor = System.Drawing.Color.Black; ;
                rw.Cells.Add(tcell2);

                TableCell tcell3 = new TableCell();
                tcell3.Text = "Name";
                tcell3.BorderWidth = 1;
                tcell3.BorderColor = System.Drawing.Color.SlateGray;
                tcell3.ForeColor = System.Drawing.Color.Black; ;
                rw.Cells.Add(tcell3);

                TableCell tcell4 = new TableCell();
                tcell4.Text = "Cadre";//
                tcell4.BorderWidth = 1;
                tcell4.BorderColor = System.Drawing.Color.SlateGray;
                tcell4.ForeColor = System.Drawing.Color.Black; ;
                rw.Cells.Add(tcell4);



                TableCell tcell99 = new TableCell();
                tcell99.Text = "FeedingCadre";
                tcell99.BorderWidth = 1;
                tcell99.BorderColor = System.Drawing.Color.SlateGray;
                tcell99.ForeColor = System.Drawing.Color.Black; ;
                rw.Cells.Add(tcell99);





                TableCell tcell5 = new TableCell();
                tcell5.Text = "Designation";//
                tcell5.BorderWidth = 1;
                tcell5.BorderColor = System.Drawing.Color.SlateGray;
                tcell5.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell5);

                TableCell tcell6 = new TableCell();
                tcell6.Text = "Date Of Posting";//
                tcell6.BorderWidth = 1;
                tcell6.BorderColor = System.Drawing.Color.SlateGray;
                tcell6.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell6);



                Table1.Rows.Add(rw);
                for (j = 0; j <= cl.ds.Tables[0].Rows.Count - 1; j++)
                {
                    TableRow rw1 = new TableRow();
                    rw1.BorderWidth = 1;
                    rw1.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.ForeColor = System.Drawing.Color.SlateGray;

                    TableCell tcellk1 = new TableCell();
                    tcellk1.BorderWidth = 1;
                    tcellk1.BorderColor = System.Drawing.Color.SlateGray;
                    tcellk1.Text = Convert.ToString(j + 1);
                    tcell1.HorizontalAlign = HorizontalAlign.Center;
                    rw1.Cells.Add(tcellk1);


                    TableCell tcellk5 = new TableCell();
                    tcellk5.Text = cl.ds.Tables[0].Rows[j][0].ToString();
                    tcellk5.BorderWidth = 1;
                    tcellk5.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk5);
                    tcellk5.Text = ("<a target='_blank' href=\'DoctorP2.aspx?idno=" + (cl.ds.Tables[0].Rows[j][0].ToString() + ("\'>" + tcellk5.Text + "</a>")));
                    Table1.Rows.Add(rw1);



                    TableCell tcellk6 = new TableCell();
                    tcellk6.Text = cl.ds.Tables[0].Rows[j][1].ToString();
                    tcellk6.BorderWidth = 1;
                    tcellk6.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk6);
                    //tcellk6.Text = ("<a target='_blank' href=\'proforma1print.aspx?idno=" + (cl.ds.Tables[0].Rows[j][0].ToString() + ("\'>" + tcellk6.Text + "</a>")));

                    TableCell tcellk7 = new TableCell();
                    tcellk7.BorderWidth = 1;
                    tcellk7.BorderColor = System.Drawing.Color.SlateGray;
                    tcellk7.Text = cl.ds.Tables[0].Rows[j][2].ToString();
                    rw1.Cells.Add(tcellk7);

                    TableCell tcellk8 = new TableCell();
                    tcellk8.Text = cl.ds.Tables[0].Rows[j][3].ToString();
                    tcellk8.BorderWidth = 1;
                    tcellk8.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk8);

                    TableCell tcellk2 = new TableCell();
                    tcellk2.Text = cl.ds.Tables[0].Rows[j][4].ToString();
                    tcellk2.BorderWidth = 1;
                    tcellk2.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk2);


                    TableCell tcellk4 = new TableCell();
                    tcellk4.BorderWidth = 1;
                    tcellk4.BorderColor = System.Drawing.Color.SlateGray;
                    tcellk4.Text = cl.ds.Tables[0].Rows[j][5].ToString();
                    rw1.Cells.Add(tcellk4);


                    TableCell tcellk3 = new TableCell();
                    tcellk3.Text = cl.ds.Tables[0].Rows[j][6].ToString();
                    tcellk3.BorderWidth = 1;
                    tcellk3.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk3);

                    TableCell tcell64 = new TableCell();
                    tcell64.Text = cl.ds.Tables[0].Rows[j][7].ToString();
                    tcell64.BorderWidth = 1;
                    tcell64.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcell64);


                }
            }

        }

        public void data()
        {
            usecheckD();
            string Div, DHna, DHt, post, cad, lav;//Dist,
            //**************HOSPITAL TYPE*****************        
            if (Request.QueryString["DT"] != "N")
            { DHt = "%" + Request.QueryString["DT"] + "%"; }
            else { DHt = "%"; }
            //**************HOSPITAL NAME*****************
            if (Request.QueryString["HN"] != "N")
            { DHna = "%" + Request.QueryString["HN"] + "%"; }
            else { DHna = "%"; }
            //****************POST***************
            if (Request.QueryString["Post"] != "N")
            { post = "%" + Request.QueryString["Post"] + "%"; }
            else { post = "%"; }
            //***************LEVEL****************
            //if (Request.QueryString["lavel"] != "N")
            //{ lav = "%" + Request.QueryString["lavel"] + "%"; }
            //else { lav = "%"; }
            //****************CADRE***************
            if (Request.QueryString["cader"] != "N")
            { cad = "%" + Request.QueryString["cader"] + "%"; }
            else { cad = "%"; }
            //*************Division***********
            if (Request.QueryString["Div"] != "N")
            { Div = Request.QueryString["Div"]; }
            else { Div = "%"; }
            if (Div != "%")
            {
                //cl.ds = cl.DataFill("SELECT Distinct(idno) as ComputerID,name as Name,gpfno,cadrename, designame as post, hname as Hospital,convert(varchar,doposting,103)as DateOfPosting FROM   paracurrentsearchCriteria  WHERE (divid = '" + Convert.ToInt32(Div) + "') and (DisId like '" + Uidt.Text + "')AND (hid LIKE '" + DHt + "') AND (sno LIKE '" + DHna + "')  AND (postid LIKE '" + post + "') AND (lavel LIKE '" + lav + "') AND (cadreid LIKE '" + cad + "') order by districtname,hname,name");

                cl.ds = cl.DataFill("SELECT Distinct(idno) as ComputerID,name as Name,gpfno,cadrename, designame as post, hname as Hospital,convert(varchar,doposting,103)as DateOfPosting FROM   paracurrentsearchCriteria  WHERE (divid = '" + Convert.ToInt32(Div) + "') and (DisId like '" + Uidt.Text + "')AND (hid LIKE '" + DHt + "') AND (sno LIKE '" + DHna + "')  AND (postid LIKE '" + post + "')  AND (cadreid LIKE '" + cad + "') order by districtname,hname,name");
            }
            else if (Div == "%")
            {
                //cl.ds = cl.DataFill("SELECT Distinct(idno) as ComputerID,name as Name,gpfno,cadrename, designame as post, hname as Hospital,convert(varchar,doposting,103)as DateOfPosting FROM   paracurrentsearchCriteria  WHERE (divid LIKE '" + Div + "') and (DisId like '" + Uidt.Text + "')AND (hid LIKE '" + DHt + "') AND (sno LIKE '" + DHna + "')  AND (postid LIKE '" + post + "') AND (lavel LIKE '" + lav + "') AND (cadreid LIKE '" + cad + "') order by districtname,hname,name");

                cl.ds = cl.DataFill("SELECT Distinct(idno) as ComputerID,name as Name,gpfno,cadrename, designame as post, hname as Hospital,convert(varchar,doposting,103)as DateOfPosting FROM   paracurrentsearchCriteria  WHERE (divid LIKE '" + Div + "') and (DisId like '" + Uidt.Text + "')AND (hid LIKE '" + DHt + "') AND (sno LIKE '" + DHna + "')  AND (postid LIKE '" + post + "')  AND (cadreid LIKE '" + cad + "') order by districtname,hname,name");
            }
            int j;
            if (cl.ds.Tables[0].Rows.Count > 0)
            {
                strq.Visible = false;
                TableRow rw = new TableRow();
                rw.BorderWidth = 1;
                rw.ForeColor = System.Drawing.Color.Black;

                TableCell tcell0 = new TableCell();
                tcell0.Text = "SerialNo";
                tcell0.BorderWidth = 1;
                tcell0.BorderColor = System.Drawing.Color.SlateGray;
                tcell0.ForeColor = System.Drawing.Color.Black;
                //tcell0.HorizontalAlign=System
                rw.Cells.Add(tcell0);

                TableCell tcell1 = new TableCell();
                tcell1.Text = "ComputerID";
                tcell1.BorderWidth = 1;
                tcell1.BorderColor = System.Drawing.Color.SlateGray;
                tcell1.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell1);

                TableCell tcell2 = new TableCell();
                tcell2.Text = "Name";
                tcell2.BorderWidth = 1;
                tcell2.BorderColor = System.Drawing.Color.SlateGray;
                tcell2.ForeColor = System.Drawing.Color.Black; ;
                rw.Cells.Add(tcell2);

                TableCell tcell3 = new TableCell();
                tcell3.Text = "Seniority";
                tcell3.BorderWidth = 1;
                tcell3.BorderColor = System.Drawing.Color.SlateGray;
                tcell3.ForeColor = System.Drawing.Color.Black; ;
                rw.Cells.Add(tcell3);

                TableCell tcell4 = new TableCell();
                tcell4.Text = "Post";//
                tcell4.BorderWidth = 1;
                tcell4.BorderColor = System.Drawing.Color.SlateGray;
                tcell4.ForeColor = System.Drawing.Color.Black; ;
                rw.Cells.Add(tcell4);

                TableCell tcell5 = new TableCell();
                tcell5.Text = "District";//
                tcell5.BorderWidth = 1;
                tcell5.BorderColor = System.Drawing.Color.SlateGray;
                tcell5.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell5);

                TableCell tcell6 = new TableCell();
                tcell6.Text = "Place Of Posting";//
                tcell6.BorderWidth = 1;
                tcell6.BorderColor = System.Drawing.Color.SlateGray;
                tcell6.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell6);

                TableCell tcell7 = new TableCell();
                tcell7.Text = "Date Of Posting";//
                tcell7.BorderWidth = 1;
                tcell7.BorderColor = System.Drawing.Color.SlateGray;
                tcell7.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell7);

                Table1.Rows.Add(rw);
                for (j = 0; j <= cl.ds.Tables[0].Rows.Count - 1; j++)
                {
                    TableRow rw1 = new TableRow();
                    rw1.BorderWidth = 1;
                    rw1.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.ForeColor = System.Drawing.Color.SlateGray;

                    TableCell tcellk1 = new TableCell();
                    tcellk1.BorderWidth = 1;
                    tcellk1.BorderColor = System.Drawing.Color.SlateGray;
                    tcellk1.Text = Convert.ToString(j + 1);
                    rw1.Cells.Add(tcellk1);

                    TableCell tcellk6 = new TableCell();
                    tcellk6.Text = cl.ds.Tables[0].Rows[j][0].ToString();
                    tcellk6.BorderWidth = 1;
                    tcellk6.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk6);
                    tcellk6.Text = ("<a target='_blank' href=\'proforma1print.aspx?idno=" + (cl.ds.Tables[0].Rows[j][0].ToString() + ("\'>" + tcellk6.Text + "</a>")));

                    TableCell tcellk7 = new TableCell();
                    tcellk7.BorderWidth = 1;
                    tcellk7.BorderColor = System.Drawing.Color.SlateGray;
                    tcellk7.Text = cl.ds.Tables[0].Rows[j][1].ToString();
                    rw1.Cells.Add(tcellk7);

                    TableCell tcellk8 = new TableCell();
                    tcellk8.Text = cl.ds.Tables[0].Rows[j][2].ToString();
                    tcellk8.BorderWidth = 1;
                    tcellk8.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk8);

                    TableCell tcellk2 = new TableCell();
                    tcellk2.Text = cl.ds.Tables[0].Rows[j][3].ToString();
                    tcellk2.BorderWidth = 1;
                    tcellk2.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk2);

                    TableCell tcellk4 = new TableCell();
                    tcellk4.BorderWidth = 1;
                    tcellk4.BorderColor = System.Drawing.Color.SlateGray;
                    tcellk4.Text = cl.ds.Tables[0].Rows[j][4].ToString();
                    rw1.Cells.Add(tcellk4);


                    TableCell tcellk3 = new TableCell();
                    tcellk3.Text = cl.ds.Tables[0].Rows[j][5].ToString();
                    tcellk3.BorderWidth = 1;
                    tcellk3.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk3);

                    TableCell tcellk5 = new TableCell();
                    tcellk5.Text = cl.ds.Tables[0].Rows[j][6].ToString();
                    tcellk5.BorderWidth = 1;
                    tcellk5.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk5);
                    Table1.Rows.Add(rw1);

                }
            }
            else
            {
                strq.Visible = true;
                //Response.Write(Request.QueryString["time"] + "," + Request.QueryString["Div"] + "," + Request.QueryString["Dis"] + "," + Request.QueryString["DT"] + "," + Request.QueryString["HN"] + "," + Request.QueryString["Post"] + "," + Request.QueryString["lavel"] + "," + Request.QueryString["cader"]);
            }
        }


        public void runqual()
        {
            //***************DIVISION****************(string)Session["fullname"]
            string divid, districtid, DHt, DHna, post, cad, lav;
            if ((string)Session["dividC"] != "")
            { divid = "%" + (string)Session["dividC"] + "%"; }
            else { divid = "%"; }
            //***************DISTRICT****************
            if ((string)Session["districtidC"] != "")
            { districtid = "%" + (string)Session["districtidC"] + "%"; }
            else { districtid = "%"; }
            //**************HOSPITAL TYPE*****************
            if ((string)Session["DHtC"] != "")
            { DHt = "%" + (string)Session["DHtC"] + "%"; }
            else { DHt = "%"; }
            //**************HOSPITAL NAME*****************
            if ((string)Session["DHnaC"] != "")
            { DHna = "%" + (string)Session["DHnaC"] + "%"; }
            else { DHna = "%"; }
            //****************POST***************
            if ((string)Session["postC"] != "")
            { post = "%" + (string)Session["postC"] + "%"; }
            else { post = "%"; }
            //***************CADRE****************
            if ((string)Session["cadC"] != "")
            { cad = "%" + (string)Session["cadC"] + "%"; }
            else { cad = "%"; }
            //***************LEVEL****************
            if ((string)Session["lavC"] != "")
            { lav = "%" + (string)Session["lavC"] + "%"; }//Convert.ToInt32((string)Session["lavC"])
            else { lav = "%"; }

            cl.ds = cl.DataFill("SELECT Distinct(idno) as ComputerID,name as Name,gpfno,cadrename, designame as post, hname as Hospital,convert(varchar,doposting,103)as DateOfPosting FROM   paracurrentsearchCriteria  WHERE (divid LIKE '" + divid + "') AND (DisId LIKE '" + districtid + "')AND (  LIKE '" + DHt + "') AND (sno LIKE '" + DHna + "')AND (postid LIKE '" + post + "') AND (cadreid LIKE '" + cad + "')  order by districtname,hname, name");
            int j;
            if (cl.ds.Tables[0].Rows.Count > 0)
            {
                TableRow rw = new TableRow();
                rw.BorderWidth = 1;
                //rw.BorderColor = System.Drawing.Color.SlateGray;
                //rw.BackColor = System.Drawing.Color.BurlyWood;
                rw.ForeColor = System.Drawing.Color.Black;

                TableCell tcell0 = new TableCell();
                tcell0.Text = "SerialNo";
                tcell0.BorderWidth = 1;
                tcell0.BorderColor = System.Drawing.Color.SlateGray;
                tcell0.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell0);

                TableCell tcell5 = new TableCell();
                tcell5.Text = "District";//
                tcell5.BorderWidth = 1;
                tcell5.BorderColor = System.Drawing.Color.SlateGray;
                tcell5.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell5);

                TableCell tcell6 = new TableCell();
                tcell6.Text = "Place Of Posting";//
                tcell6.BorderWidth = 1;
                tcell6.BorderColor = System.Drawing.Color.SlateGray;
                tcell6.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell6);

                TableCell tcell7 = new TableCell();
                tcell7.Text = "Date Of Posting";//
                tcell7.BorderWidth = 1;
                tcell7.BorderColor = System.Drawing.Color.SlateGray;
                tcell7.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell7);

                TableCell tcell1 = new TableCell();
                tcell1.Text = "ComputerID";
                tcell1.BorderWidth = 1;
                tcell1.BorderColor = System.Drawing.Color.SlateGray;
                tcell1.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell1);

                TableCell tcell3 = new TableCell();
                tcell3.Text = "Seniority";
                tcell3.BorderWidth = 1;
                tcell3.BorderColor = System.Drawing.Color.SlateGray;
                tcell3.ForeColor = System.Drawing.Color.Black; ;
                rw.Cells.Add(tcell3);

                TableCell tcell2 = new TableCell();
                tcell2.Text = "Name";
                tcell2.BorderWidth = 1;
                tcell2.BorderColor = System.Drawing.Color.SlateGray;
                tcell2.ForeColor = System.Drawing.Color.Black; ;
                rw.Cells.Add(tcell2);

                TableCell tcell4 = new TableCell();
                tcell4.Text = "Post";//
                tcell4.BorderWidth = 1;
                tcell4.BorderColor = System.Drawing.Color.SlateGray;
                tcell4.ForeColor = System.Drawing.Color.Black; ;
                rw.Cells.Add(tcell4);



                //TableCell tcellX1 = new TableCell();
                //tcellX1.Text = "Print";
                //tcellX1.BorderWidth = 1;
                //tcellX1.BorderColor = System.Drawing.Color.SlateGray;
                //rw.Cells.Add(tcellX1);

                Table1.Rows.Add(rw);
                for (j = 0; j <= cl.ds.Tables[0].Rows.Count - 1; j++)
                {
                    TableRow rw1 = new TableRow();
                    rw1.BorderWidth = 1;
                    rw1.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.ForeColor = System.Drawing.Color.SlateGray;
                    //rw1.BackColor = System.Drawing.Color.LemonChiffon;

                    TableCell tcellk1 = new TableCell();
                    tcellk1.BorderWidth = 1;
                    tcellk1.BorderColor = System.Drawing.Color.SlateGray;
                    tcellk1.Text = Convert.ToString(j + 1);
                    rw1.Cells.Add(tcellk1);

                    TableCell tcellk6 = new TableCell();
                    tcellk6.Text = cl.ds.Tables[0].Rows[j][4].ToString();
                    tcellk6.BorderWidth = 1;
                    tcellk6.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk6);

                    TableCell tcellk7 = new TableCell();
                    tcellk7.BorderWidth = 1;
                    tcellk7.BorderColor = System.Drawing.Color.SlateGray;
                    tcellk7.Text = cl.ds.Tables[0].Rows[j][5].ToString();
                    rw1.Cells.Add(tcellk7);

                    TableCell tcellk8 = new TableCell();
                    tcellk8.Text = cl.ds.Tables[0].Rows[j][6].ToString();
                    tcellk8.BorderWidth = 1;
                    tcellk8.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk8);

                    TableCell tcellk2 = new TableCell();
                    tcellk2.Text = cl.ds.Tables[0].Rows[j][0].ToString();
                    tcellk2.BorderWidth = 1;
                    tcellk2.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk2);

                    TableCell tcellk4 = new TableCell();
                    tcellk4.BorderWidth = 1;
                    tcellk4.BorderColor = System.Drawing.Color.SlateGray;
                    tcellk4.Text = cl.ds.Tables[0].Rows[j][1].ToString();
                    rw1.Cells.Add(tcellk4);


                    TableCell tcellk3 = new TableCell();
                    tcellk3.Text = cl.ds.Tables[0].Rows[j][2].ToString();
                    tcellk3.BorderWidth = 1;
                    tcellk3.BorderColor = System.Drawing.Color.SlateGray;
                    //tcellk3.ForeColor = System.Drawing.Color.DarkGreen;
                    rw1.Cells.Add(tcellk3);

                    TableCell tcellk5 = new TableCell();
                    tcellk5.Text = cl.ds.Tables[0].Rows[j][3].ToString();
                    tcellk5.BorderWidth = 1;
                    tcellk5.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk5);



                    //TableCell tcellk13 = new TableCell();
                    //tcellk13.Text = "Print";
                    //tcellk13.BorderWidth = 1;
                    //tcellk13.BorderColor = System.Drawing.Color.SlateGray;
                    //rw1.Cells.Add(tcellk13);
                    //tcellk13.Text = ("<a target='_blank' href=\'proforma1print.aspx?idno=" + (cl.ds.Tables[0].Rows[j][0].ToString() + ("\'>" + tcellk13.Text + "</a>")));//("\'>"  + tcellk10.Text +"</a>")));
                    Table1.Rows.Add(rw1);

                }
            }
        }
    }
}