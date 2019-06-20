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

namespace NewWebApp.proforma
{
    public partial class P1vsP2 : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        DataSet ds = new DataSet();
        //int k;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Hdata();
                newp1andp2();
                // doctname();
                //SELECT   divname,  districtname, tehsilname, blockname, htype, hname, sno, bedoccupacy FROM         hospitallist WHERE     (districtid ='" + Uidt.Text + "')
            }
        }
        public void Hdata()
        {
            cl.ds = cl.DataFill("SELECT   divname,  districtname, tehsilname, blockname, htype, hname,  bedoccupacy FROM         hospitallist WHERE sno='" + Request.QueryString["sno"] + "'");//    sno = '" + Request.QueryString["sno"] + "'  ");//'" + Convert.ToInt32((string)Session["insertid"]) + "'

            if (cl.ds.Tables[0].Rows.Count > 0)
            {
                if (!(cl.ds.Tables[0].Rows[0][0].ToString().Equals(System.DBNull.Value)))
                {
                    this.LDiv.Text = cl.ds.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    this.LDiv.Text = "N.A";
                }
                if (!(cl.ds.Tables[0].Rows[0][1].ToString().Equals(System.DBNull.Value)))
                {
                    this.LDist.Text = cl.ds.Tables[0].Rows[0][1].ToString();
                }
                else
                {
                    LDist.Text = "N.A";
                }
                if (!(cl.ds.Tables[0].Rows[0][2].ToString().Equals(System.DBNull.Value)))
                {
                    this.LTN.Text = cl.ds.Tables[0].Rows[0][2].ToString();
                }
                else
                {
                    LTN.Text = "N.A";
                }

                if (!(cl.ds.Tables[0].Rows[0][3].ToString().Equals(System.DBNull.Value)))
                {
                    this.LBN.Text = cl.ds.Tables[0].Rows[0][3].ToString();

                }
                else
                {
                    LBN.Text = "N.A";
                }
                if (!(cl.ds.Tables[0].Rows[0][4].ToString().Equals(System.DBNull.Value)))
                {
                    this.LHT.Text = cl.ds.Tables[0].Rows[0][4].ToString();
                }
                else
                {
                    LHT.Text = "N.A";
                }
                if (!(cl.ds.Tables[0].Rows[0][5].ToString().Equals(System.DBNull.Value)))
                {
                    this.Name.Text = cl.ds.Tables[0].Rows[0][5].ToString();

                }
                else
                {
                    Name.Text = "N.A";
                }
                if (!(cl.ds.Tables[0].Rows[0][6].ToString().Equals(System.DBNull.Value)))
                {
                    this.LBed.Text = cl.ds.Tables[0].Rows[0][6].ToString();

                }
                else
                {
                    LBed.Text = "N.A";
                }


            }
        }
        public void newp1andp2()
        {
            int j;
            cl.ds = cl.DataFill("SELECT     Distinct(post.newpostid) as newpostid, post.newpostname, hospitalrecord.posts, (hospitalrecord.withcadre+ hospitalrecord.withoutcadre) as filledpost, hospitalrecord.Extrapost,hospitalrecord.posts - hospitalrecord.withcadre - hospitalrecord.withoutcadre - hospitalrecord.Extrapost AS vacantpost FROM  hospitalrecord INNER JOIN  post ON hospitalrecord.postid = post.newpostid INNER JOIN hospitalname ON hospitalrecord.hnameid = hospitalname.sno WHERE  hospitalname.sno='" + Request.QueryString["sno"] + "'  ORDER BY post.newpostname ");// hospitalname.sno='" + Request.QueryString["sno"] + "'    AND postingdetails.dorelieve IS NULL)");
            if (cl.ds.Tables[0].Rows.Count > 0)
            {
                TableRow rw = new TableRow();
                //rw.BorderWidth = 1;
                rw.BorderColor = System.Drawing.Color.Black;
                TableCell tcell1 = new TableCell();
                tcell1.Text = "Serial No";
                tcell1.BorderWidth = 1;
                tcell1.BorderColor = System.Drawing.Color.Black;
                tcell1.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell1);

                TableCell tcell2 = new TableCell();
                tcell2.Text = "Post Name";
                tcell2.BorderWidth = 1;
                tcell2.BorderColor = System.Drawing.Color.Black;
                tcell2.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell2);

                TableCell tcell3 = new TableCell();
                tcell3.Text = "Saction Post";
                tcell3.BorderWidth = 1;
                tcell3.BorderColor = System.Drawing.Color.Black;
                tcell3.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell3);

                TableCell tcell4 = new TableCell();
                tcell4.Text = "Filled Post";
                tcell4.BorderWidth = 1;
                tcell4.BorderColor = System.Drawing.Color.Black;
                tcell4.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell4);

                TableCell tcell6 = new TableCell();
                tcell6.Text = "Extra Doctors";
                tcell6.BorderWidth = 1;
                tcell6.BorderColor = System.Drawing.Color.Black;
                tcell6.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell6);

                TableCell tcell7 = new TableCell();
                tcell7.Text = "Vaccant Post";
                tcell7.BorderWidth = 1;
                tcell7.BorderColor = System.Drawing.Color.Black;
                tcell7.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell7);

                TableCell tcell5 = new TableCell();
                tcell5.Text = "Posted Doctors" + "<Br>" + "As per P2 records";
                tcell5.BorderWidth = 1;
                tcell5.BorderColor = System.Drawing.Color.Black;
                tcell5.ForeColor = System.Drawing.Color.Red;
                rw.Cells.Add(tcell5);

                Table2.Rows.Add(rw);

                for (j = 0; j <= cl.ds.Tables[0].Rows.Count - 1; j++)
                {
                    TableRow rw1 = new TableRow();
                    rw1.BorderWidth = 1;
                    rw1.BorderColor = System.Drawing.Color.Black;
                    TableCell tcell11 = new TableCell();
                    tcell11.BorderWidth = 1;
                    tcell11.BorderColor = System.Drawing.Color.Black;
                    tcell11.ForeColor = System.Drawing.Color.Black;
                    //tcell11.Text = cl.ds.Tables[0].Rows[j][0].ToString();
                    tcell11.Text = Convert.ToString(j + 1);
                    rw1.Cells.Add(tcell11);

                    TableCell tcell21 = new TableCell();//Post Name
                    tcell21.Text = cl.ds.Tables[0].Rows[j][1].ToString();
                    tcell21.BorderWidth = 1;
                    tcell21.BorderColor = System.Drawing.Color.Black;
                    tcell21.ForeColor = System.Drawing.Color.Black;
                    rw1.Cells.Add(tcell21);

                    TableCell tcell31 = new TableCell();//Saction Post
                    tcell31.Text = cl.ds.Tables[0].Rows[j][2].ToString();
                    tcell31.BorderWidth = 1;
                    tcell31.BorderColor = System.Drawing.Color.Black;
                    tcell31.ForeColor = System.Drawing.Color.Black;
                    rw1.Cells.Add(tcell31);

                    TableCell tcell41 = new TableCell();//Filled Post
                    tcell41.Text = cl.ds.Tables[0].Rows[j][3].ToString();
                    tcell41.BorderWidth = 1;
                    tcell41.BorderColor = System.Drawing.Color.Black;
                    tcell41.ForeColor = System.Drawing.Color.Black;
                    rw1.Cells.Add(tcell41);

                    TableCell tcellXX1 = new TableCell();//Extra Doctors
                    tcellXX1.Text = cl.ds.Tables[0].Rows[j][1].ToString();
                    tcell41.BorderWidth = 1;
                    tcellXX1.BorderColor = System.Drawing.Color.Black;
                    tcellXX1.ForeColor = System.Drawing.Color.Black;
                    //rw1.Cells.Add(tcellXX1);                             


                    TableCell tcell61 = new TableCell();//Vaccant Post
                    if (!(cl.ds.Tables[0].Rows[j][4].ToString().Equals(System.DBNull.Value)))
                    {
                        if (tcell61.Text == "")
                        {
                            tcell61.Text = cl.ds.Tables[0].Rows[j][4].ToString();
                        }
                        else
                        {
                            tcell61.Text = "";
                        }
                    }
                    tcell61.BorderWidth = 1;
                    tcell61.BorderColor = System.Drawing.Color.Black;
                    tcell61.ForeColor = System.Drawing.Color.Black;
                    rw1.Cells.Add(tcell61);

                    TableCell tcell71 = new TableCell();
                    tcell71.Text = cl.ds.Tables[0].Rows[j][5].ToString();
                    tcell71.BorderWidth = 1;
                    tcell71.BorderColor = System.Drawing.Color.Black;
                    tcell71.ForeColor = System.Drawing.Color.Black;
                    rw1.Cells.Add(tcell71);

                    TableCell tcell51 = new TableCell();//Currentally Posted Doctors
                    int a = Convert.ToInt32(cl.ds.Tables[0].Rows[j][0]);
                    cl.ds1 = cl.DataFill2("SELECT TOP 100 PERCENT post.newpostname,dbo.personaldetails.name, dbo.personaldetails.idno, dbo.post.newpostid, dbo.currentposted.poposting FROM         dbo.hospitalrecord INNER JOIN dbo.post ON dbo.hospitalrecord.postid = dbo.post.newpostid INNER JOIN dbo.hospitalname ON dbo.hospitalrecord.hnameid = dbo.hospitalname.sno INNER JOIN dbo.currentposted ON dbo.post.newpostid = dbo.currentposted.postid AND dbo.hospitalname.districtid = dbo.currentposted.districtid AND dbo.hospitalname.sno = dbo.currentposted.poposting INNER JOIN dbo.personaldetails ON dbo.currentposted.idno = dbo.personaldetails.idno WHERE     (dbo.hospitalname.sno = " + Request.QueryString["sno"] + ")AND (dbo.post.newpostid =" + a + " )  ORDER BY post.newpostname,dbo.personaldetails.name");
                    if (cl.ds1.Tables[0].Rows.Count > 0)
                    {
                        for (int kk = 0; kk <= cl.ds1.Tables[0].Rows.Count - 1; kk++)
                        {
                            tcell51.Text = tcell51.Text + cl.ds1.Tables[0].Rows[kk][1].ToString() + "<Br>";
                            tcell51.BorderColor = System.Drawing.Color.Black;
                            tcell51.ForeColor = System.Drawing.Color.Blue;
                        }
                    }
                    else
                    {
                        tcell51.ForeColor = System.Drawing.Color.SlateGray;
                        tcell51.Text = "P2 Not Found";
                    }
                    tcell51.BorderWidth = 1;
                    rw1.Cells.Add(tcell51);
                    Table2.Rows.Add(rw1);






                    ////****************************************mmm
                    //tcell51.Text = "";
                    //////////int a = Convert.ToInt32(cl.ds.Tables[0].Rows[j][5]);
                    //////////SqlDataAdapter v1 = new SqlDataAdapter("SELECT TOP 100 PERCENT post.newpostname,dbo.personaldetails.name, dbo.personaldetails.idno, dbo.post.newpostid, dbo.currentposted.poposting FROM         dbo.hospitalrecord INNER JOIN dbo.post ON dbo.hospitalrecord.postid = dbo.post.newpostid INNER JOIN dbo.hospitalname ON dbo.hospitalrecord.hnameid = dbo.hospitalname.sno INNER JOIN dbo.currentposted ON dbo.post.newpostid = dbo.currentposted.postid AND dbo.hospitalname.districtid = dbo.currentposted.districtid AND dbo.hospitalname.sno = dbo.currentposted.poposting INNER JOIN dbo.personaldetails ON dbo.currentposted.idno = dbo.personaldetails.idno WHERE     (dbo.hospitalname.sno = " + Request.QueryString["sno"] + ")AND (dbo.post.newpostid =" + a + " )  ORDER BY post.newpostname,dbo.personaldetails.name", ClDatabase.ConnectionString);
                    ////////////cl.ds = cl.DataFill("SELECT TOP 100 PERCENT post.newpostname,dbo.personaldetails.name, dbo.personaldetails.idno, dbo.post.newpostid, dbo.currentposted.poposting FROM         dbo.hospitalrecord INNER JOIN dbo.post ON dbo.hospitalrecord.postid = dbo.post.newpostid INNER JOIN dbo.hospitalname ON dbo.hospitalrecord.hnameid = dbo.hospitalname.sno INNER JOIN dbo.currentposted ON dbo.post.newpostid = dbo.currentposted.postid AND dbo.hospitalname.districtid = dbo.currentposted.districtid AND dbo.hospitalname.sno = dbo.currentposted.poposting INNER JOIN dbo.personaldetails ON dbo.currentposted.idno = dbo.personaldetails.idno WHERE     (dbo.hospitalname.sno = 575)AND (dbo.post.newpostid =" + a + " )  ORDER BY post.newpostname,dbo.personaldetails.name");
                    //////////DataSet d2 = new DataSet();
                    //////////cl.upcon.Open();
                    //////////v1.Fill(d2);
                    //////////cl.upcon.Close();
                    //////////if (d2.Tables[0].Rows.Count == 0)
                    //////////{
                    //////////    tcell51.Text = "P2 Not Found";
                    //////////    //tcell51.Font.Size = System.Drawing.FontStyle.Italic;//Color.Black
                    //////////    tcell51.ForeColor = System.Drawing.Color.SlateGray;
                    //////////}
                    //////////else
                    //////////{
                    //////////    for (int kk = 0; kk < d2.Tables[0].Rows.Count; kk++)
                    //////////    {
                    //////////        tcell51.Text = tcell51.Text + d2.Tables[0].Rows[kk][1].ToString() + "<Br>";
                    //////////        tcell51.BorderColor = System.Drawing.Color.Black;
                    //////////        tcell51.ForeColor = System.Drawing.Color.Black;
                    //////////    }
                    //////////}

                    //////////tcell51.BorderWidth = 1;
                    //////////rw1.Cells.Add(tcell51);

                    //int a = Convert.ToInt32(cl.ds.Tables[0].Rows[j][5]);
                    //SqlDataAdapter v1 = new SqlDataAdapter("SELECT TOP 100 PERCENT post.newpostname,dbo.personaldetails.name, dbo.personaldetails.idno, dbo.post.newpostid, dbo.currentposted.poposting FROM         dbo.hospitalrecord INNER JOIN dbo.post ON dbo.hospitalrecord.postid = dbo.post.newpostid INNER JOIN dbo.hospitalname ON dbo.hospitalrecord.hnameid = dbo.hospitalname.sno INNER JOIN dbo.currentposted ON dbo.post.newpostid = dbo.currentposted.postid AND dbo.hospitalname.districtid = dbo.currentposted.districtid AND dbo.hospitalname.sno = dbo.currentposted.poposting INNER JOIN dbo.personaldetails ON dbo.currentposted.idno = dbo.personaldetails.idno WHERE     (dbo.hospitalname.sno = " + Request.QueryString["sno"] + ")AND (dbo.post.newpostid =" + a + " )  ORDER BY post.newpostname,dbo.personaldetails.name", ClDatabase.ConnectionString);
                    //DataSet d2 = new DataSet();
                    //cl.upcon.Open();
                    //v1.Fill(d2);
                    //cl.upcon.Close();
                    //if (d2.Tables[0].Rows.Count == 0)
                    //{
                    //    tcell51.Text = "P2 Not Found";
                    //    tcell51.ForeColor = System.Drawing.Color.SlateGray;
                    //}
                    //else
                    //{
                    //    for (int kk = 0; kk < d2.Tables[0].Rows.Count; kk++)
                    //    {
                    //        tcell51.Text = tcell51.Text + d2.Tables[0].Rows[kk][1].ToString() + "<Br>";
                    //        tcell51.BorderColor = System.Drawing.Color.Black;
                    //        tcell51.ForeColor = System.Drawing.Color.Black;
                    //    }
                    //}

                    //TableRow rw2 = new TableRow();
                    //rw2.BorderWidth = 1;
                    //rw2.BorderColor = System.Drawing.Color.Black;
                    //TableCell tcellx2 = new TableCell();                
                    //tcellx2.Text = "<hr>";
                    ////tcellx2.BorderWidth =System.Drawing.Size "<100%>";
                    //tcellx2.BorderColor = System.Drawing.Color.Black;
                    //tcellx2.ForeColor = System.Drawing.Color.Black;
                    //rw2.Cells.Add(tcellx2);
                    //Table2.Rows.Add(rw2);
                    //TableHeaderRow rx = new TableHeaderRow();
                    //rx.BorderWidth = 1;
                    //Table2.Rows.Add(rx);
                    //Response.Write("<tr><td>&nbsp;</td></tr>");
                }
            }
            //for (l1 = 0; l1<=cl.ds.Tables[0].Rows.Count - 1; l1++)
            //{
            //    int a = Convert.ToInt32(cl.ds.Tables[0].Rows[l1][5]);
            //    doctname(a);
            //}

        }
        public void doctname(int sr)
        {
            int j1;
            //cl.ds = cl.DataFill("SELECT TOP 100 PERCENT post.newpostname,dbo.personaldetails.name, dbo.personaldetails.idno, dbo.post.newpostid, dbo.currentposted.poposting FROM         dbo.hospitalrecord INNER JOIN dbo.post ON dbo.hospitalrecord.postid = dbo.post.newpostid INNER JOIN dbo.hospitalname ON dbo.hospitalrecord.hnameid = dbo.hospitalname.sno INNER JOIN dbo.currentposted ON dbo.post.newpostid = dbo.currentposted.postid AND dbo.hospitalname.districtid = dbo.currentposted.districtid AND dbo.hospitalname.sno = dbo.currentposted.poposting INNER JOIN dbo.personaldetails ON dbo.currentposted.idno = dbo.personaldetails.idno WHERE     (dbo.hospitalname.sno = 575)AND (dbo.post.newpostid =78 )  ORDER BY post.newpostname,dbo.personaldetails.name");// '" + Table2.FindControl("tcellXX1.Text").ToString() + "'
            cl.ds = cl.DataFill("SELECT TOP 100 PERCENT post.newpostname,dbo.personaldetails.name, dbo.personaldetails.idno, dbo.post.newpostid, dbo.currentposted.poposting FROM         dbo.hospitalrecord INNER JOIN dbo.post ON dbo.hospitalrecord.postid = dbo.post.newpostid INNER JOIN dbo.hospitalname ON dbo.hospitalrecord.hnameid = dbo.hospitalname.sno INNER JOIN dbo.currentposted ON dbo.post.newpostid = dbo.currentposted.postid AND dbo.hospitalname.districtid = dbo.currentposted.districtid AND dbo.hospitalname.sno = dbo.currentposted.poposting INNER JOIN dbo.personaldetails ON dbo.currentposted.idno = dbo.personaldetails.idno WHERE     (dbo.hospitalname.sno = '" + Request.QueryString["sno"] + "')AND (dbo.post.newpostid =" + sr + " )  ORDER BY post.newpostname,dbo.personaldetails.name");// '" + Table2.FindControl("tcellXX1.Text").ToString() + "'
            if (cl.ds.Tables[0].Rows.Count > 0)
            {
                Table t = new Table();
                TableRow rw = new TableRow();
                //rw.BorderWidth = 1;
                rw.BorderColor = System.Drawing.Color.Black;
                for (j1 = 0; j1 <= cl.ds.Tables[0].Rows.Count - 1; j1++)
                {

                    t.ID = j1.ToString();
                    TableRow rw1 = new TableRow();
                    rw1.BorderWidth = 1;
                    rw1.BorderColor = System.Drawing.Color.Black;

                    TableCell tcell11 = new TableCell();
                    tcell11.BorderColor = System.Drawing.Color.Black;
                    tcell11.ForeColor = System.Drawing.Color.Black;
                    int k;
                    for (k = 0; k <= j1; k++)
                    {
                        if (cl.ds.Tables[0].Rows[j1][0].ToString() != cl.ds.Tables[0].Rows[k][0].ToString())
                        {
                            tcell11.Text = cl.ds.Tables[0].Rows[j1][1].ToString() + "/" + cl.ds.Tables[0].Rows[j1][2].ToString();
                        }
                    }
                    tcell11.Text = tcell11.Text + "," + cl.ds.Tables[0].Rows[j1][1].ToString() + "/" + cl.ds.Tables[0].Rows[j1][2].ToString();
                    rw1.Cells.Add(tcell11);
                    t.Rows.Add(rw1);
                }
            }

        }  
    }
}