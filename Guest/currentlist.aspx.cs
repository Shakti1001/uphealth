using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace NewWebApp.Guest
{
    public partial class currentlist : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["DBCS"].ToString(); // connection string
        protected void Page_Load(object sender, EventArgs e)
        {
            d1();
        }
        public void usecheckD()
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



        public void d1()
        {
            usecheckD();
            string q1, q2, q3, q4, q5, q6;//string Div, DHna, DHt, post, cad, lav;//Dist,

            //**************HOSPITAL TYPE*****************        
            if (Request.QueryString["DT"] != "N")
            {
                if (Request.QueryString["DT"].Length == 1)
                {

                    q1 = "hid='" + Request.QueryString["DT"] + "'";
                }
                else
                {

                    q1 = "hid Like '%" + Request.QueryString["DT"] + "%'";
                }
            }
            else
            {

                q1 = "hid Like '%'";
            }
            //**************HOSPITAL NAME*****************
            if (Request.QueryString["HN"] != "N")
            {
                q2 = "sno like '%" + Request.QueryString["HN"] + "%'";
            }
            else
            {

                q2 = "sno like '%'";
            }
            //****************POST***************
            if (Request.QueryString["Post"] != "N")
            {
                if (Request.QueryString["post"].Length == 1)
                {

                    q3 = "postid=" + Request.QueryString["post"] + "";
                }
                else
                {

                    q3 = "postid like '%" + Request.QueryString["post"] + "%' ";
                }
            }
            else
            {

                q3 = "postid like '%'";
            }
            //***************LEVEL****************
            if (Request.QueryString["lavel"] != "N")
            {
                if (Request.QueryString["lavel"].Length == 1)
                {

                    q4 = "lavel='" + Request.QueryString["lavel"] + "'";
                }
                else
                {

                    q4 = "lavel like '%" + Request.QueryString["lavel"] + " %'";
                }
            }
            else
            {

                q4 = "lavel like '%'";
            }
            //****************CADRE***************
            if (Request.QueryString["cader"] != "N")
            {
                if (Request.QueryString["cader"].Length == 1)
                {

                    q5 = "cadreid=" + Request.QueryString["cader"] + "";
                }
                else
                {

                    q5 = "cadreid like '%" + Request.QueryString["cader"] + "%'";
                }
            }
            else
            {

                q5 = "cadreid like '%'";
            }
            //*************Division***********



            string qr = q1 + "AND " + q2 + "AND " + q3 + "AND " + q5 + "AND " + q4 + " AND " + Uidt.Text + "";




            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand com6 = new SqlCommand("SELECT Distinct(idno) as ComputerID ,districtname as District, hname as Hospital,name as Name,senno as Seniority,newpostname as Post, doposting FROM   currentsearchCriteria  WHERE " + qr + "  order by districtname,hname,name", con); // table name 
            SqlDataAdapter da6 = new SqlDataAdapter(com6);
            DataSet ds6 = new DataSet();
            da6.Fill(ds6);  // fill dataset
            int j;

            if (ds6.Tables[0].Rows.Count > 0)
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


                TableCell tcell6 = new TableCell();
                tcell6.Text = "Seniority No.";//
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

                /*  TableCell tcell5 = new TableCell();
                  tcell5.Text = "Date Of Joining";//
                  tcell5.BorderWidth = 1;
                  tcell5.BorderColor = System.Drawing.Color.SlateGray;
                  tcell5.ForeColor = System.Drawing.Color.Black;
                  rw.Cells.Add(tcell5);*/


                TableCell tcell51 = new TableCell();
                tcell51.Text = "Date Of Posting";//
                tcell51.BorderWidth = 1;
                tcell51.BorderColor = System.Drawing.Color.SlateGray;
                tcell51.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell51);


                TableCell tcell7 = new TableCell();
                tcell7.Text = "ComputerID";//
                tcell7.BorderWidth = 1;
                tcell7.BorderColor = System.Drawing.Color.SlateGray;
                tcell7.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell7);

                Table1.Rows.Add(rw);
                for (j = 0; j <= ds6.Tables[0].Rows.Count - 1; j++)
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
                    tcellk6.Text = ds6.Tables[0].Rows[j][1].ToString();
                    tcellk6.BorderWidth = 1;
                    tcellk6.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk6);
                    //tcellk6.Text = ("<a target='_blank' href=\'proforma1print.aspx?idno=" + (cl.ds.Tables[0].Rows[j][0].ToString() + ("\'>" + tcellk6.Text + "</a>")));

                    TableCell tcellk7 = new TableCell();
                    tcellk7.BorderWidth = 1;
                    tcellk7.BorderColor = System.Drawing.Color.SlateGray;
                    tcellk7.Text = ds6.Tables[0].Rows[j][2].ToString();
                    rw1.Cells.Add(tcellk7);

                    TableCell tcellk8 = new TableCell();
                    tcellk8.Text = ds6.Tables[0].Rows[j][3].ToString();
                    tcellk8.BorderWidth = 1;
                    tcellk8.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk8);

                    TableCell tcellk2 = new TableCell();
                    tcellk2.Text = ds6.Tables[0].Rows[j][4].ToString();
                    tcellk2.BorderWidth = 1;
                    tcellk2.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk2);

                    TableCell tcellk4 = new TableCell();
                    tcellk4.BorderWidth = 1;
                    tcellk4.BorderColor = System.Drawing.Color.SlateGray;
                    tcellk4.Text = ds6.Tables[0].Rows[j][5].ToString();
                    rw1.Cells.Add(tcellk4);


                    TableCell tcellk3 = new TableCell();
                    tcellk3.Text = ds6.Tables[0].Rows[j][6].ToString();
                    tcellk3.BorderWidth = 1;
                    tcellk3.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk3);


                    /* TableCell tcellk31 = new TableCell();
                     tcellk31.Text = ds6.Tables[0].Rows[j][7].ToString();
                     tcellk31.BorderWidth = 1;
                     tcellk31.BorderColor = System.Drawing.Color.SlateGray;
                     rw1.Cells.Add(tcellk31);*/

                    TableCell tcellk5 = new TableCell();
                    tcellk5.Text = ds6.Tables[0].Rows[j][0].ToString();
                    tcellk5.BorderWidth = 1;
                    tcellk5.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.Cells.Add(tcellk5);
                    tcellk5.Text = ("<a target='_blank' href=\'DoctorP2.aspx?idno=" + (ds6.Tables[0].Rows[j][0].ToString() + ("\'>" + tcellk5.Text + "</a>")));
                    Table1.Rows.Add(rw1);

                }
            }
        }
    }
}