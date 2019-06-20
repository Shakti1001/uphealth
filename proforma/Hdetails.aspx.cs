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
    public partial class Hdetails : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Hdata();
                runpost();
                //SELECT   divname,  districtname, tehsilname, blockname, htype, hname, sno, bedoccupacy FROM         hospitallist WHERE     (districtid ='" + Uidt.Text + "')
            }
        }
        public void Hdata()
        {
            cl.ds = cl.DataFill("SELECT   divname,  districtname, tehsilname, blockname, htype, hname,  bedoccupacy FROM         hospitallist WHERE     sno = '" + Request.QueryString["sno"] + "'  ");//'" + Convert.ToInt32((string)Session["insertid"]) + "'

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
        public void runpost()
        {
            int j;//("SELECT     post.newpostname, hospitalrecord.posts, hospitalrecord.withcadre, hospitalrecord.withoutcadre, hospitalrecord.Extrapost,hospitalrecord.posts - hospitalrecord.withcadre - hospitalrecord.withoutcadre - hospitalrecord.Extrapost AS vacantpost FROM  hospitalrecord INNER JOIN  post ON hospitalrecord.postid = post.newpostid INNER JOIN hospitalname ON hospitalrecord.hnameid = hospitalname.sno WHERE   hospitalname.sno='" + Request.QueryString["sno"] + "'ORDER BY post.newpostname ")
            cl.ds = cl.DataFill("SELECT     post.newpostname,specialization.spname, hospitalrecord.posts FROM hospitalrecord INNER JOIN post ON hospitalrecord.postid = post.newpostid INNER JOIN hospitalname ON hospitalrecord.hnameid = hospitalname.sno INNER JOIN specialization ON hospitalrecord.speciality = specialization.spid WHERE   hospitalname.sno='" + Request.QueryString["sno"] + "'ORDER BY post.newpostname ");// AND postingdetails.dorelieve IS NULL)");
            if (cl.ds.Tables[0].Rows.Count > 0)
            {
                TableRow rw = new TableRow();
                rw.BorderColor = System.Drawing.Color.Black;
                TableCell tcell1 = new TableCell();
                tcell1.Text = "Serial No";
                tcell1.BorderWidth = 1;
                tcell1.BorderColor = System.Drawing.Color.Black;
                tcell1.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell1);

                TableCell tcell2 = new TableCell();
                tcell2.Text = "Name Of  Post";
                tcell2.BorderWidth = 1;
                tcell2.BorderColor = System.Drawing.Color.Black;
                tcell2.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell2);

                TableCell tcell3 = new TableCell();
                tcell3.Text = "Speciality";
                tcell3.BorderWidth = 1;
                tcell3.BorderColor = System.Drawing.Color.Black;
                tcell3.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell3);

                TableCell tcell4 = new TableCell();
                tcell4.Text = "Number Of Sanctioned Post";
                tcell4.BorderWidth = 1;
                //tcell4.
                tcell4.BorderColor = System.Drawing.Color.Black;
                tcell4.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell4);


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

                    TableCell tcell21 = new TableCell();
                    tcell21.Text = cl.ds.Tables[0].Rows[j][0].ToString();
                    tcell21.BorderWidth = 1;
                    tcell21.BorderColor = System.Drawing.Color.Black;
                    tcell21.ForeColor = System.Drawing.Color.Black;
                    rw1.Cells.Add(tcell21);

                    TableCell tcell31 = new TableCell();
                    tcell31.Text = cl.ds.Tables[0].Rows[j][1].ToString();
                    tcell31.BorderWidth = 1;
                    tcell31.BorderColor = System.Drawing.Color.Black;
                    tcell31.ForeColor = System.Drawing.Color.Black;
                    rw1.Cells.Add(tcell31);

                    TableCell tcell41 = new TableCell();
                    tcell41.Text = cl.ds.Tables[0].Rows[j][2].ToString();
                    tcell41.BorderWidth = 1;
                    tcell41.BorderColor = System.Drawing.Color.Black;
                    tcell41.ForeColor = System.Drawing.Color.Black;
                    rw1.Cells.Add(tcell41);

                    //TableCell tcell51 = new TableCell();
                    //tcell51.Text = cl.ds.Tables[0].Rows[j][3].ToString();
                    //tcell51.BorderWidth = 1;
                    //tcell51.BorderColor = System.Drawing.Color.Black;
                    //tcell51.ForeColor = System.Drawing.Color.Black;
                    //rw1.Cells.Add(tcell51);

                    //TableCell tcell61 = new TableCell();
                    //tcell61.Text = cl.ds.Tables[0].Rows[j][4].ToString();
                    //tcell61.BorderWidth = 1;
                    //tcell61.BorderColor = System.Drawing.Color.Black;
                    //tcell61.ForeColor = System.Drawing.Color.Black;
                    //rw1.Cells.Add(tcell61);

                    //TableCell tcell71 = new TableCell();
                    //tcell71.Text = cl.ds.Tables[0].Rows[j][5].ToString();
                    //tcell71.BorderWidth = 1;
                    //tcell71.BorderColor = System.Drawing.Color.Black;
                    //tcell71.ForeColor = System.Drawing.Color.Black;
                    //rw1.Cells.Add(tcell71);
                    Table2.Rows.Add(rw1);

                }
            }
        }
        
    }
}