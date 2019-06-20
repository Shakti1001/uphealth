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

namespace NewWebApp.Proforma2
{
    public partial class DRepPrint : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((string)Session["criteria"] == null)
                {
                    Response.Redirect("~/login.aspx");
                }
                Response.Buffer = true;
                Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
                Response.Expires = -1500;
                Response.CacheControl = "no-cache";
                Label2.Text = "No of Records Found :" + (string)Session["NOR"];
                data();
            }

        }
        public void data()
        {
            try
            {
                runtab();
            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message;
            }
        }
        public void runtab()
        {
            string qrf = "SELECT     idno,senno,name, DateofBirth, Postname, PostingDistrict, PostingPlace, Homedistrict, Qualification, Specialization, Cadre FROM  dynamicQ WHERE " + (string)Session["criteria"] + "order by name,PostingDistrict";
            cl.ds = cl.DataFill(qrf);
            int j;
            string idnosr;
            if (cl.ds.Tables[0].Rows.Count > 0)
            {

                TableRow rw = new TableRow();
                rw.BorderWidth = 1;
                rw.ForeColor = System.Drawing.Color.Black;

                //TableCell tcell0 = new TableCell();
                //tcell0.Text = "SerialNo";
                //tcell0.BorderWidth = 1;
                //tcell0.BorderColor = System.Drawing.Color.SlateGray;
                //tcell0.ForeColor = System.Drawing.Color.Black;
                //rw.Cells.Add(tcell0);            

                TableCell tcell1 = new TableCell();
                tcell1.Text = "Name";
                tcell1.BorderWidth = 1;
                tcell1.BorderColor = System.Drawing.Color.SlateGray;
                tcell1.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell1);

                TableCell tcellS = new TableCell();
                tcellS.Text = "Sen No";
                tcellS.BorderWidth = 1;
                tcellS.BorderColor = System.Drawing.Color.SlateGray;
                tcellS.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcellS);

                TableCell tcell2 = new TableCell();
                tcell2.Text = "DateofBirth";
                tcell2.BorderWidth = 1;
                tcell2.BorderColor = System.Drawing.Color.SlateGray;
                tcell2.ForeColor = System.Drawing.Color.Black; ;
                rw.Cells.Add(tcell2);

                TableCell tcell3 = new TableCell();
                tcell3.Text = "Postname";
                tcell3.BorderWidth = 1;
                tcell3.BorderColor = System.Drawing.Color.SlateGray;
                tcell3.ForeColor = System.Drawing.Color.Black; ;
                rw.Cells.Add(tcell3);

                TableCell tcell4 = new TableCell();
                tcell4.Text = "PostingDistrict";//
                tcell4.BorderWidth = 1;
                tcell4.BorderColor = System.Drawing.Color.SlateGray;
                tcell4.ForeColor = System.Drawing.Color.Black; ;
                rw.Cells.Add(tcell4);

                TableCell tcell5 = new TableCell();
                tcell5.Text = "PostingPlace";//
                tcell5.BorderWidth = 1;
                tcell5.BorderColor = System.Drawing.Color.SlateGray;
                tcell5.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell5);

                TableCell tcell6 = new TableCell();
                tcell6.Text = "Homedistrict";//
                tcell6.BorderWidth = 1;
                tcell6.BorderColor = System.Drawing.Color.SlateGray;
                tcell6.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell6);

                TableCell tcell7 = new TableCell();
                tcell7.Text = "ComputerID";//
                tcell7.BorderWidth = 1;
                tcell7.BorderColor = System.Drawing.Color.SlateGray;
                tcell7.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell7);
                TableCell tcell8 = new TableCell();
                tcell8.Text = "Qualification";//
                tcell8.BorderWidth = 1;
                tcell8.BorderColor = System.Drawing.Color.SlateGray;
                tcell8.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell8);
                TableCell tcell9c = new TableCell();
                tcell9c.Text = "Specialization";//
                tcell9c.BorderWidth = 1;
                tcell9c.BorderColor = System.Drawing.Color.SlateGray;
                tcell9c.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell9c);
                TableCell tcell9q = new TableCell();
                tcell9q.Text = "Cadre";//
                tcell9q.BorderWidth = 1;
                tcell9q.BorderColor = System.Drawing.Color.SlateGray;
                tcell9q.ForeColor = System.Drawing.Color.Black;
                rw.Cells.Add(tcell9q);
                Table1.Rows.Add(rw);
                idnosr = "";
                for (j = 0; j <= cl.ds.Tables[0].Rows.Count - 1; j++)
                {
                    TableRow rw1 = new TableRow();
                    rw1.BorderWidth = 1;
                    rw1.BorderColor = System.Drawing.Color.SlateGray;
                    rw1.ForeColor = System.Drawing.Color.SlateGray;
                    //int l;
                    //TableCell tcellk1 = new TableCell();
                    //tcellk1.BorderWidth = 1;
                    //tcellk1.BorderColor = System.Drawing.Color.SlateGray;
                    //tcellk1.Text = Convert.ToString(j + 1);
                    ////tcellk1.Text = Convert.ToString("n");
                    //rw1.Cells.Add(tcellk1);

                    //if (cl.ds.Tables[0].Rows[j + 1][0].ToString() != cl.ds.Tables[0].Rows[j][0].ToString())
                    if (idnosr != cl.ds.Tables[0].Rows[j][0].ToString())
                    {
                        TableCell tcellk6 = new TableCell();
                        tcellk6.Text = cl.ds.Tables[0].Rows[j][2].ToString();
                        tcellk6.BorderWidth = 1;
                        tcellk6.BorderColor = System.Drawing.Color.SlateGray;
                        rw1.Cells.Add(tcellk6);

                        TableCell tcellkS = new TableCell();
                        tcellkS.Text = cl.ds.Tables[0].Rows[j][1].ToString();
                        tcellkS.BorderWidth = 1;
                        tcellkS.ForeColor = System.Drawing.Color.DarkGreen;
                        tcellkS.BorderColor = System.Drawing.Color.SlateGray;
                        rw1.Cells.Add(tcellkS);

                        TableCell tcellk7 = new TableCell();
                        tcellk7.BorderWidth = 1;
                        tcellk7.BorderColor = System.Drawing.Color.SlateGray;
                        tcellk7.Text = cl.ds.Tables[0].Rows[j][3].ToString();
                        rw1.Cells.Add(tcellk7);

                        TableCell tcellk8 = new TableCell();
                        tcellk8.Text = cl.ds.Tables[0].Rows[j][4].ToString();
                        tcellk8.BorderWidth = 1;
                        tcellk8.BorderColor = System.Drawing.Color.SlateGray;
                        rw1.Cells.Add(tcellk8);

                        TableCell tcellk2 = new TableCell();
                        tcellk2.Text = cl.ds.Tables[0].Rows[j][5].ToString();
                        tcellk2.BorderWidth = 1;
                        tcellk2.BorderColor = System.Drawing.Color.SlateGray;
                        rw1.Cells.Add(tcellk2);

                        TableCell tcellk4 = new TableCell();
                        tcellk4.BorderWidth = 1;
                        tcellk4.BorderColor = System.Drawing.Color.SlateGray;
                        tcellk4.Text = cl.ds.Tables[0].Rows[j][6].ToString();
                        rw1.Cells.Add(tcellk4);


                        TableCell tcellk3 = new TableCell();
                        tcellk3.Text = cl.ds.Tables[0].Rows[j][7].ToString();
                        tcellk3.BorderWidth = 1;
                        tcellk3.BorderColor = System.Drawing.Color.SlateGray;
                        rw1.Cells.Add(tcellk3);

                        TableCell tcellk5 = new TableCell();
                        tcellk5.Text = cl.ds.Tables[0].Rows[j][0].ToString();
                        tcellk5.BorderWidth = 1;
                        tcellk5.BorderColor = System.Drawing.Color.SlateGray;
                        rw1.Cells.Add(tcellk5);
                        tcellk5.Text = ("<a target='_blank' href=\'DoctorP2.aspx?idno=" + (cl.ds.Tables[0].Rows[j][0].ToString() + ("\'>" + tcellk5.Text + "</a>")));

                        TableCell tcellk3q = new TableCell();
                        tcellk3q.Text = cl.ds.Tables[0].Rows[j][8].ToString();
                        tcellk3q.BorderWidth = 1;
                        tcellk3q.BorderColor = System.Drawing.Color.SlateGray;
                        rw1.Cells.Add(tcellk3q);

                        TableCell tcellk3w = new TableCell();
                        tcellk3w.Text = cl.ds.Tables[0].Rows[j][9].ToString();
                        tcellk3w.BorderWidth = 1;
                        tcellk3w.BorderColor = System.Drawing.Color.SlateGray;
                        rw1.Cells.Add(tcellk3w);

                        TableCell tcellk3e = new TableCell();
                        tcellk3e.Text = cl.ds.Tables[0].Rows[j][10].ToString();
                        tcellk3e.BorderWidth = 1;
                        tcellk3e.BorderColor = System.Drawing.Color.SlateGray;
                        rw1.Cells.Add(tcellk3e);
                        idnosr = cl.ds.Tables[0].Rows[j][0].ToString();
                        //l = l + 1;
                    }
                    Table1.Rows.Add(rw1);


                }


            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "Sorry,No Record Found";
            }
        }
    }
}