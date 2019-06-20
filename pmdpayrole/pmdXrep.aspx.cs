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
using System.IO;

namespace NewWebApp.pmdpayrole
{
    public partial class pmdXrep : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        string q1, q2, q3, q4, q5, qr, finalqr, finalqr1, q6;
        //ReportDocument  rpt= new ReportDocument();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if ((string)Session["iduser"] == null)
                {
                    Response.Redirect("~/Authenticate/login.aspx"); //jump to first page for login
                }

                if ((string)Session["ddoname"] != null && (string)Session["ddopid"] != null)
                {
                    salary();
                }

            }

        }
        protected void Page_unload(object sender, EventArgs e)
        {
            //rpt.Close();
            //rpt.Dispose();
        }

        public void sumsalary()
        {
            cl.ds = cl.DataFill(finalqr1);
            int j;
            if (cl.ds.Tables[0].Rows.Count > 0)
            {
                TableRow rwvXG = new TableRow();
                rwvXG.Width = Unit.Percentage(100);
                rwvXG.BorderWidth = 1;
                rwvXG.BorderColor = System.Drawing.Color.SlateGray;

                TableCell tcellxv2G = new TableCell();
                tcellxv2G.Attributes.Add("colspan", "17");
                tcellxv2G.Text = "Grand Total";
                tcellxv2G.ForeColor = System.Drawing.Color.Maroon;
                rwvXG.Cells.Add(tcellxv2G);
                Table1.Rows.Add(rwvXG);
                for (j = 0; j <= cl.ds.Tables[0].Rows.Count - 1; j++)
                {

                    TableRow rws1 = new TableRow();//...............................1st Line...................................
                    rws1.Width = Unit.Percentage(100);
                    rws1.BorderWidth = 1;
                    rws1.BorderColor = System.Drawing.Color.Black;
                    rws1.ForeColor = System.Drawing.Color.Black;
                    TableCell tcellvs0 = new TableCell();
                    tcellvs0.BorderWidth = 1;
                    tcellvs0.BorderColor = System.Drawing.Color.SlateGray;
                    tcellvs0.Text = "";
                    rws1.Cells.Add(tcellvs0);

                    TableCell tcellvs1 = new TableCell();
                    tcellvs1.BorderWidth = 1;
                    tcellvs1.BorderColor = System.Drawing.Color.SlateGray;
                    tcellvs1.Text = "";
                    rws1.Cells.Add(tcellvs1);

                    //TableCell tcellvs2 = new TableCell();
                    //tcellvs2.BorderWidth = 1;
                    //tcellvs2.BorderColor = System.Drawing.Color.SlateGray;
                    //tcellvs2.Text = cl.ds.Tables[0].Rows[j][3].ToString();//basic
                    //rws1.Cells.Add(tcellvs2);
                    TableCell tcellvs2 = new TableCell();
                    tcellvs2.BorderWidth = 1;
                    tcellvs2.BorderColor = System.Drawing.Color.SlateGray;
                    tcellvs2.Text = cl.ds.Tables[0].Rows[j]["Gradepay"].ToString();//Gradepay
                    rws1.Cells.Add(tcellvs2);

                    TableCell tcellvs3 = new TableCell();
                    tcellvs3.BorderWidth = 1;
                    tcellvs3.BorderColor = System.Drawing.Color.SlateGray;
                    tcellvs3.Text = cl.ds.Tables[0].Rows[j]["dapay"].ToString();//Da Pay
                    rws1.Cells.Add(tcellvs3);

                    TableCell tcellvs4 = new TableCell();
                    tcellvs4.BorderWidth = 1;
                    tcellvs4.BorderColor = System.Drawing.Color.SlateGray;
                    tcellvs4.Text = cl.ds.Tables[0].Rows[j]["hra"].ToString();//HRA
                    rws1.Cells.Add(tcellvs4);

                    TableCell tcellvs5 = new TableCell();
                    tcellvs5.BorderWidth = 1;
                    tcellvs5.BorderColor = System.Drawing.Color.SlateGray;
                    tcellvs5.Text = cl.ds.Tables[0].Rows[j]["cca"].ToString();//CCA
                    rws1.Cells.Add(tcellvs5);

                    TableCell tcellvs6 = new TableCell();
                    tcellvs6.BorderWidth = 1;
                    tcellvs6.BorderColor = System.Drawing.Color.SlateGray;
                    tcellvs6.Text = cl.ds.Tables[0].Rows[j]["othall6"].ToString();//Oth All6
                    rws1.Cells.Add(tcellvs6);

                    TableCell tcellvs7 = new TableCell();
                    tcellvs7.BorderWidth = 1;
                    tcellvs7.BorderColor = System.Drawing.Color.SlateGray;
                    tcellvs7.Text = cl.ds.Tables[0].Rows[j]["fixall2"].ToString();//Fixed All.2
                    rws1.Cells.Add(tcellvs7);

                    TableCell tcellvs8 = new TableCell();
                    tcellvs8.BorderWidth = 1;
                    tcellvs8.BorderColor = System.Drawing.Color.SlateGray;
                    //gross total Pay = basic+daypay+hra+cca+othall6+fixall2+
                    //           tcellvs8.Text = Convert.ToString(Convert.ToDouble(cl.ds.Tables[0].Rows[j]["basicpay"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["daypay"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["hra"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["cca"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["othall6"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["fixall2"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["othall1"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j][20].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j][21].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j][22].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j][23].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j][24].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j][33].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j][34].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j][35].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j][36].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j][37].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j][38].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j][46].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j][47].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j][48].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j][56].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j][49].ToString()));

                    // tcellvs8.Text = Convert.ToString(Convert.ToDouble(cl.ds.Tables[0].Rows[j]["basicpay"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["dapay"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["hra"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["cca"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["othall6"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["fixall2"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["othall1"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["npaall"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["othall4"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["dearnesspay"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["fixall3"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["GpfA"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["othall2"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["salarrear"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["hill"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["pensionpay"].ToString()) - Convert.ToDouble(cl.ds.Tables[0].Rows[j]["salded"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["gpf4"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["otharrear"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["othall5"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["fixall1"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["gpf4"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["Gradepay"].ToString()));
                    tcellvs8.Text = Convert.ToString(Convert.ToDouble(cl.ds.Tables[0].Rows[j]["basicpay"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["dapay"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["hra"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["cca"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["othall6"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["fixall2"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["othall1"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["npaall"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["othall4"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["dearnesspay"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["fixall3"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["othall2"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["salarrear"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["hill"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["pensionpay"].ToString()) - Convert.ToDouble(cl.ds.Tables[0].Rows[j]["salded"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["otharrear"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["othall5"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["othall3"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["fixall1"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["Gradepay"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["perpay"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["sppay"].ToString()));
                    tcellvs8.ForeColor = System.Drawing.Color.Black;
                    rws1.Cells.Add(tcellvs8);

                    TableCell tcellvs9 = new TableCell();
                    tcellvs9.BorderWidth = 1;
                    tcellvs9.BorderColor = System.Drawing.Color.SlateGray;
                    tcellvs9.Text = cl.ds.Tables[0].Rows[j]["gpf"].ToString();//              
                    rws1.Cells.Add(tcellvs9);

                    TableCell tcellvs10 = new TableCell();
                    tcellvs10.BorderWidth = 1;
                    tcellvs10.BorderColor = System.Drawing.Color.SlateGray;
                    tcellvs10.Text = cl.ds.Tables[0].Rows[j]["gvr"].ToString();
                    rws1.Cells.Add(tcellvs10);

                    TableCell tcellvs11 = new TableCell();
                    tcellvs11.BorderWidth = 1;
                    tcellvs11.BorderColor = System.Drawing.Color.SlateGray;
                    tcellvs11.Text = cl.ds.Tables[0].Rows[j]["hba1inst"].ToString();
                    rws1.Cells.Add(tcellvs11);

                    TableCell tcellvs12 = new TableCell();
                    tcellvs12.BorderWidth = 1;
                    tcellvs12.BorderColor = System.Drawing.Color.SlateGray;
                    tcellvs12.Text = cl.ds.Tables[0].Rows[j]["hba1iinst"].ToString();
                    rws1.Cells.Add(tcellvs12);

                    TableCell tcellvs13 = new TableCell();
                    tcellvs13.BorderWidth = 1;
                    tcellvs13.BorderColor = System.Drawing.Color.SlateGray;
                    tcellvs13.Text = cl.ds.Tables[0].Rows[j]["pli"].ToString();
                    rws1.Cells.Add(tcellvs13);

                    TableCell tcellvs14 = new TableCell();
                    tcellvs14.BorderWidth = 1;
                    tcellvs14.BorderColor = System.Drawing.Color.SlateGray;
                    tcellvs14.Text = cl.ds.Tables[0].Rows[j]["incometax"].ToString();
                    rws1.Cells.Add(tcellvs14);

                    TableCell tcellvs15 = new TableCell();
                    tcellvs15.BorderWidth = 1;
                    tcellvs15.BorderColor = System.Drawing.Color.SlateGray;
                    tcellvs15.Text = cl.ds.Tables[0].Rows[j]["elecbill"].ToString();//Soc. Ded. ...........Ebill....              

                    rws1.Cells.Add(tcellvs15);

                    TableCell tcellvs16 = new TableCell();
                    tcellvs16.BorderWidth = 1;
                    tcellvs16.BorderColor = System.Drawing.Color.SlateGray;
                    tcellvs16.Text = cl.ds.Tables[0].Rows[j]["sded"].ToString();
                    //tcellvs16.Text = Convert.ToString(Convert.ToDouble(cl.ds.Tables[0].Rows[j]["gpf"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["vehiinst"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["gpfiv"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["gpf4adv"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["gvr"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["hba1inst"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["hba1iinst"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["elecbill"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["incometax"].ToString())  + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["hrr"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["hba2inst"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["hba2iinst"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["gisi"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["ded1"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["vehinst"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["hba3inst"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["hba3iinst"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["giss"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["ded2"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["vehinst"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["corinst"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["coriinst"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["ded3"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["GpfA"].ToString()));//+ Convert.ToDouble(cl.ds.Tables[0].Rows[j][31].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j][44].ToString())
                    tcellvs16.ForeColor = System.Drawing.Color.Black;
                    rws1.Cells.Add(tcellvs16);

                    Table1.Rows.Add(rws1);
                    ///////////////////////////////////
                    TableRow rwvsn = new TableRow();//........................2nd Line......................................
                    rwvsn.Width = Unit.Percentage(100);
                    rwvsn.BorderWidth = 1;
                    rwvsn.BorderColor = System.Drawing.Color.SlateGray;
                    rwvsn.ForeColor = System.Drawing.Color.Black;
                    TableCell tcellnvs0 = new TableCell();
                    // tcellnvs0.Text = cl.ds.Tables[0].Rows[j][""].ToString();//Name
                    tcellnvs0.Text = "";
                    tcellnvs0.BorderWidth = 1;
                    tcellnvs0.BorderColor = System.Drawing.Color.SlateGray;
                    tcellnvs0.ForeColor = System.Drawing.Color.Black;
                    rwvsn.Cells.Add(tcellnvs0);

                    TableCell tcellnvs1 = new TableCell();
                    tcellnvs1.Text = cl.ds.Tables[0].Rows[j]["plino"].ToString();//Pli No
                    tcellnvs1.BorderWidth = 1;
                    tcellnvs1.BorderColor = System.Drawing.Color.SlateGray;
                    rwvsn.Cells.Add(tcellnvs1);

                    TableCell tcellnvs2 = new TableCell();
                    tcellnvs2.Text = cl.ds.Tables[0].Rows[j]["perpay"].ToString();//Per. Pay
                    tcellnvs2.BorderWidth = 1;
                    tcellnvs2.BorderColor = System.Drawing.Color.SlateGray;
                    rwvsn.Cells.Add(tcellnvs2);

                    TableCell tcellnvs3 = new TableCell();
                    tcellnvs3.Text = cl.ds.Tables[0].Rows[j]["othall1"].ToString();//Oth Allw1//transport allowance
                    tcellnvs3.BorderWidth = 1;
                    tcellnvs3.BorderColor = System.Drawing.Color.SlateGray;
                    rwvsn.Cells.Add(tcellnvs3);

                    TableCell tcellnvs4 = new TableCell();
                    tcellnvs4.Text = cl.ds.Tables[0].Rows[j]["npaall"].ToString();//NPA
                    tcellnvs4.BorderWidth = 1;
                    tcellnvs4.BorderColor = System.Drawing.Color.SlateGray;
                    rwvsn.Cells.Add(tcellnvs4);

                    TableCell tcellnvs5 = new TableCell();
                    tcellnvs5.Text = cl.ds.Tables[0].Rows[j]["othall4"].ToString();//Oth Allw4
                    tcellnvs5.BorderWidth = 1;
                    tcellnvs5.BorderColor = System.Drawing.Color.SlateGray;
                    rwvsn.Cells.Add(tcellnvs5);

                    TableCell tcellnvs6 = new TableCell();
                    tcellnvs6.Text = cl.ds.Tables[0].Rows[j]["dearnesspay"].ToString();//Dear.Pay
                    tcellnvs6.BorderWidth = 1;
                    tcellnvs6.BorderColor = System.Drawing.Color.SlateGray;
                    rwvsn.Cells.Add(tcellnvs6);

                    TableCell tcellnvs7 = new TableCell();
                    tcellnvs7.Text = cl.ds.Tables[0].Rows[j]["fixall3"].ToString();//Fixed All.3
                    tcellnvs7.BorderWidth = 1;
                    tcellnvs7.BorderColor = System.Drawing.Color.SlateGray;
                    rwvsn.Cells.Add(tcellnvs7);


                    TableCell tcellnvs8 = new TableCell();
                    tcellnvs8.Text = " ";
                    tcellnvs8.BorderWidth = 1;
                    tcellnvs8.BorderColor = System.Drawing.Color.SlateGray;
                    tcellnvs8.ForeColor = System.Drawing.Color.Black;
                    rwvsn.Cells.Add(tcellnvs8);

                    TableCell tcellnvs9 = new TableCell();
                    tcellnvs9.Text = cl.ds.Tables[0].Rows[j]["GpfA"].ToString();//GpfA
                    tcellnvs9.BorderWidth = 1;
                    tcellnvs9.BorderColor = System.Drawing.Color.SlateGray;
                    rwvsn.Cells.Add(tcellnvs9);

                    TableCell tcellnvs10 = new TableCell();
                    tcellnvs10.Text = cl.ds.Tables[0].Rows[j]["hrr"].ToString();//Hrr
                    tcellnvs10.BorderWidth = 1;
                    tcellnvs10.BorderColor = System.Drawing.Color.SlateGray;
                    rwvsn.Cells.Add(tcellnvs10);

                    TableCell tcellnvs11 = new TableCell();
                    tcellnvs11.Text = cl.ds.Tables[0].Rows[j]["hba2inst"].ToString();//Hba2
                    tcellnvs11.BorderWidth = 1;
                    tcellnvs11.BorderColor = System.Drawing.Color.SlateGray;
                    rwvsn.Cells.Add(tcellnvs11);

                    TableCell tcellnv12 = new TableCell();
                    tcellnv12.Text = cl.ds.Tables[0].Rows[j]["hba2iinst"].ToString();//Hba2 Int.
                    tcellnv12.BorderWidth = 1;
                    tcellnv12.BorderColor = System.Drawing.Color.SlateGray;
                    rwvsn.Cells.Add(tcellnv12);

                    TableCell tcellnvs13 = new TableCell();
                    tcellnvs13.Text = cl.ds.Tables[0].Rows[j]["gisi"].ToString();//Gis. I.F.
                    tcellnvs13.BorderWidth = 1;
                    tcellnvs13.BorderColor = System.Drawing.Color.SlateGray;
                    rwvsn.Cells.Add(tcellnvs13);

                    TableCell tcellnvs14 = new TableCell();
                    tcellnvs14.Text = cl.ds.Tables[0].Rows[j]["ded1"].ToString();//Mis. Ded1
                    tcellnvs14.BorderWidth = 1;
                    tcellnvs14.BorderColor = System.Drawing.Color.SlateGray;
                    rwvsn.Cells.Add(tcellnvs14);

                    TableCell tcellnvs15 = new TableCell();

                    tcellnvs15.Text = Convert.ToString(Convert.ToDouble(cl.ds.Tables[0].Rows[j]["gpf"].ToString()) +
                        Convert.ToDouble(cl.ds.Tables[0].Rows[j]["vehiinst"].ToString()) +
                        Convert.ToDouble(cl.ds.Tables[0].Rows[j]["gpfiv"].ToString()) +
                        Convert.ToDouble(cl.ds.Tables[0].Rows[j]["gpf4adv"].ToString()) +
                        Convert.ToDouble(cl.ds.Tables[0].Rows[j]["gvr"].ToString()) +
                        Convert.ToDouble(cl.ds.Tables[0].Rows[j]["hba1inst"].ToString()) +
                        Convert.ToDouble(cl.ds.Tables[0].Rows[j]["hba1iinst"].ToString()) +
                        Convert.ToDouble(cl.ds.Tables[0].Rows[j]["elecbill"].ToString()) +
                        Convert.ToDouble(cl.ds.Tables[0].Rows[j]["incometax"].ToString()) +
                        Convert.ToDouble(cl.ds.Tables[0].Rows[j]["hrr"].ToString()) +
                        Convert.ToDouble(cl.ds.Tables[0].Rows[j]["hba2inst"].ToString()) +
                        Convert.ToDouble(cl.ds.Tables[0].Rows[j]["hba2iinst"].ToString()) +
                        Convert.ToDouble(cl.ds.Tables[0].Rows[j]["gisi"].ToString()) +
                        Convert.ToDouble(cl.ds.Tables[0].Rows[j]["ded1"].ToString()) +
                        Convert.ToDouble(cl.ds.Tables[0].Rows[j]["vehinst"].ToString()) +
                        Convert.ToDouble(cl.ds.Tables[0].Rows[j]["hba3inst"].ToString()) +
                        Convert.ToDouble(cl.ds.Tables[0].Rows[j]["hba3iinst"].ToString()) +
                        Convert.ToDouble(cl.ds.Tables[0].Rows[j]["giss"].ToString()) +
                        Convert.ToDouble(cl.ds.Tables[0].Rows[j]["ded2"].ToString()) +
                        Convert.ToDouble(cl.ds.Tables[0].Rows[j]["corinst"].ToString()) +
                        Convert.ToDouble(cl.ds.Tables[0].Rows[j]["coriinst"].ToString()) +
                        Convert.ToDouble(cl.ds.Tables[0].Rows[j]["ded3"].ToString()) +
                        Convert.ToDouble(cl.ds.Tables[0].Rows[j]["GpfA"].ToString()));//+ Convert.ToDouble(cl.ds.Tables[0].Rows[j][31].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j][44].ToString())

                    //tcellnvs15.Text = cl.ds.Tables[0].Rows[j]["lic"].ToString();//Lic/Rd 
                    tcellnvs15.BorderWidth = 1;
                    tcellnvs15.BorderColor = System.Drawing.Color.SlateGray;
                    rwvsn.Cells.Add(tcellnvs15);

                    TableCell tcellnvs16 = new TableCell();
                    //tcellnvs16.Text = " ";
                    tcellnvs16.Text = cl.ds.Tables[0].Rows[j]["lic"].ToString();//Lic/Rd 

                    tcellnvs16.BorderWidth = 1;
                    tcellnvs16.BorderColor = System.Drawing.Color.SlateGray;
                    rwvsn.Cells.Add(tcellnvs16);
                    Table1.Rows.Add(rwvsn);
                    ////////////////////////////////////
                    TableRow rwnesv = new TableRow();
                    rwnesv.Width = Unit.Percentage(100);
                    rwnesv.BorderWidth = 1;
                    rwnesv.BorderColor = System.Drawing.Color.SlateGray;
                    rwnesv.ForeColor = System.Drawing.Color.Black;

                    TableCell tcellnevs0 = new TableCell();
                    tcellnevs0.Text = "";
                    //tcellnevs0.Text = cl.ds.Tables[0].Rows[j][32].ToString();//Designation
                    tcellnevs0.BorderWidth = 1;
                    tcellnevs0.BorderColor = System.Drawing.Color.SlateGray;
                    tcellnevs0.ForeColor = System.Drawing.Color.Black;
                    rwnesv.Cells.Add(tcellnevs0);

                    TableCell tcellnevs1 = new TableCell();//..........................3rd Line.............................
                    tcellnevs1.Text = "";
                    tcellnevs1.BorderWidth = 1;
                    tcellnevs1.BorderColor = System.Drawing.Color.SlateGray;
                    rwnesv.Cells.Add(tcellnevs1);

                    TableCell tcellnevs2 = new TableCell();
                    tcellnevs2.Text = cl.ds.Tables[0].Rows[j]["sppay"].ToString();//Spl.Pay
                    tcellnevs2.BorderWidth = 1;
                    tcellnevs2.BorderColor = System.Drawing.Color.SlateGray;
                    rwnesv.Cells.Add(tcellnevs2);

                    TableCell tcellnevs3 = new TableCell();
                    tcellnevs3.Text = cl.ds.Tables[0].Rows[j]["othall2"].ToString();//Oth Allw2
                    tcellnevs3.BorderWidth = 1;
                    tcellnevs3.BorderColor = System.Drawing.Color.SlateGray;
                    rwnesv.Cells.Add(tcellnevs3);

                    TableCell tcellnevs4 = new TableCell();
                    tcellnevs4.Text = cl.ds.Tables[0].Rows[j]["salarrear"].ToString();//Sal Arr
                    tcellnevs4.BorderWidth = 1;
                    tcellnevs4.BorderColor = System.Drawing.Color.SlateGray;
                    rwnesv.Cells.Add(tcellnevs4);

                    TableCell tcellnevs5 = new TableCell();
                    tcellnevs5.Text = cl.ds.Tables[0].Rows[j]["hill"].ToString();//Hill Allw
                    tcellnevs5.BorderWidth = 1;
                    tcellnevs5.BorderColor = System.Drawing.Color.SlateGray;
                    rwnesv.Cells.Add(tcellnevs5);

                    TableCell tcellnevs6 = new TableCell();
                    tcellnevs6.Text = cl.ds.Tables[0].Rows[j]["pensionpay"].ToString();//Pen.Pay
                    tcellnevs6.BorderWidth = 1;
                    tcellnevs6.BorderColor = System.Drawing.Color.SlateGray;
                    rwnesv.Cells.Add(tcellnevs6);

                    TableCell tcellnevs7 = new TableCell();
                    tcellnevs7.Text = cl.ds.Tables[0].Rows[j]["salded"].ToString();//Sal Ded************************
                    tcellnevs7.BorderWidth = 1;
                    tcellnevs7.BorderColor = System.Drawing.Color.SlateGray;
                    rwnesv.Cells.Add(tcellnevs7);


                    TableCell tcellnevs8 = new TableCell();
                    tcellnevs8.Text = " ";
                    tcellnevs8.BorderWidth = 1;
                    tcellnevs8.BorderColor = System.Drawing.Color.SlateGray;
                    tcellnevs8.ForeColor = System.Drawing.Color.Black;
                    rwnesv.Cells.Add(tcellnevs8);

                    TableCell tcellnevs9 = new TableCell();
                    tcellnevs9.Text = cl.ds.Tables[0].Rows[j]["gpfiv"].ToString();//Gpf IV
                    tcellnevs9.BorderWidth = 1;
                    tcellnevs9.BorderColor = System.Drawing.Color.SlateGray;
                    rwnesv.Cells.Add(tcellnevs9);

                    TableCell tcellnevs10 = new TableCell();//Veh. adv.
                    tcellnevs10.Text = cl.ds.Tables[0].Rows[j]["vehinst"].ToString();
                    tcellnevs10.BorderWidth = 1;
                    tcellnevs10.BorderColor = System.Drawing.Color.SlateGray;
                    rwnesv.Cells.Add(tcellnevs10);

                    TableCell tcellnevs11 = new TableCell();//Hba3
                    tcellnevs11.Text = cl.ds.Tables[0].Rows[j]["hba3inst"].ToString();
                    tcellnevs11.BorderWidth = 1;
                    tcellnevs11.BorderColor = System.Drawing.Color.SlateGray;
                    rwnesv.Cells.Add(tcellnevs11);

                    TableCell tcellnevs12 = new TableCell();//Hba3 Int.
                    tcellnevs12.Text = cl.ds.Tables[0].Rows[j]["hba3iinst"].ToString();
                    tcellnevs12.BorderWidth = 1;
                    tcellnevs12.BorderColor = System.Drawing.Color.SlateGray;
                    rwnesv.Cells.Add(tcellnevs12);

                    TableCell tcellnevs13 = new TableCell();//Gis. S.F
                    tcellnevs13.Text = cl.ds.Tables[0].Rows[j]["giss"].ToString();
                    tcellnevs13.BorderWidth = 1;
                    tcellnevs13.BorderColor = System.Drawing.Color.SlateGray;
                    rwnesv.Cells.Add(tcellnevs13);

                    TableCell tcellnevs14 = new TableCell();//Mis. Ded2
                    tcellnevs14.Text = cl.ds.Tables[0].Rows[j]["ded2"].ToString();
                    tcellnevs14.BorderWidth = 1;
                    tcellnevs14.BorderColor = System.Drawing.Color.SlateGray;
                    rwnesv.Cells.Add(tcellnevs14);

                    TableCell tcellnevs15 = new TableCell();
                    tcellnevs15.Text = Convert.ToString(Convert.ToDouble(tcellvs8.Text) - Convert.ToDouble(tcellnvs15.Text));
                    //tcellnevs15.Text = cl.ds.Tables[0].Rows[j]["elecbill"].ToString(); 
                    tcellnevs15.BorderWidth = 1;
                    tcellnevs15.BorderColor = System.Drawing.Color.SlateGray;
                    rwnesv.Cells.Add(tcellnevs15);

                    TableCell tcellnevs16 = new TableCell();

                    tcellnevs16.Text = Convert.ToString(Convert.ToDouble(tcellnevs15.Text) - (Convert.ToDouble(tcellnvs16.Text) + Convert.ToDouble(tcellvs16.Text) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["rdded"].ToString())));//...................................................................................
                    tcellnevs16.BorderWidth = 1;
                    tcellnevs16.BorderColor = System.Drawing.Color.SlateGray;
                    tcellnevs16.ForeColor = System.Drawing.Color.Black;
                    rwnesv.Cells.Add(tcellnevs16);
                    Table1.Rows.Add(rwnesv);
                    ///////////////////////////////////
                    TableRow rwnewvs = new TableRow();
                    rwnewvs.Width = Unit.Percentage(100);
                    rwnewvs.BorderWidth = 1;
                    rwnewvs.BorderColor = System.Drawing.Color.SlateGray;
                    rwnewvs.ForeColor = System.Drawing.Color.Black;

                    TableCell tcellnewvs0 = new TableCell();//Attendance
                    tcellnewvs0.Text = "";// cl.ds.Tables[0].Rows[j][45].ToString();
                    tcellnewvs0.BorderWidth = 1;
                    tcellnewvs0.BorderColor = System.Drawing.Color.SlateGray;
                    rwnewvs.Cells.Add(tcellnewvs0);



                    TableCell tcellnewvs1 = new TableCell();
                    tcellnewvs1.Text = cl.ds.Tables[0].Rows[j]["basicpay"].ToString(); // "Basic";
                    tcellnewvs1.BorderWidth = 1;
                    tcellnewvs1.BorderColor = System.Drawing.Color.SlateGray;
                    rwnewvs.Cells.Add(tcellnewvs1);

                    TableCell tcellnewvs2 = new TableCell();
                    tcellnewvs2.Text = Convert.ToString(Convert.ToDouble(cl.ds.Tables[0].Rows[j]["basicpay"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["Gradepay"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["perpay"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["sppay"].ToString()));// "Pay";
                    tcellnewvs2.BorderWidth = 1;
                    tcellnewvs2.BorderColor = System.Drawing.Color.SlateGray;
                    rwnewvs.Cells.Add(tcellnewvs2);


                    TableCell tcellnewvs3 = new TableCell();//Oth Allw3
                    tcellnewvs3.Text = cl.ds.Tables[0].Rows[j]["othall3"].ToString();
                    tcellnewvs3.BorderWidth = 1;
                    tcellnewvs3.BorderColor = System.Drawing.Color.SlateGray;
                    rwnewvs.Cells.Add(tcellnewvs3);



                    TableCell tcellnewvs4 = new TableCell();//Oth Arr
                    tcellnewvs4.Text = cl.ds.Tables[0].Rows[j]["otharrear"].ToString();
                    tcellnewvs4.BorderWidth = 1;
                    tcellnewvs4.BorderColor = System.Drawing.Color.SlateGray;
                    rwnewvs.Cells.Add(tcellnewvs4);

                    TableCell tcellnewvs5 = new TableCell();//Oth Allw5
                    tcellnewvs5.Text = cl.ds.Tables[0].Rows[j]["othall5"].ToString();
                    tcellnewvs5.BorderWidth = 1;
                    tcellnewvs5.BorderColor = System.Drawing.Color.SlateGray;
                    rwnewvs.Cells.Add(tcellnewvs5);

                    TableCell tcellnewvs6 = new TableCell();
                    tcellnewvs6.Text = cl.ds.Tables[0].Rows[j]["fixall1"].ToString();
                    tcellnewvs6.BorderWidth = 1;
                    tcellnewvs6.BorderColor = System.Drawing.Color.SlateGray;
                    rwnewvs.Cells.Add(tcellnewvs6);

                    TableCell tcellnewvs7 = new TableCell();
                    tcellnewvs7.Text = " ";
                    tcellnewvs7.BorderWidth = 1;
                    tcellnewvs7.BorderColor = System.Drawing.Color.SlateGray;
                    tcellnewvs7.ForeColor = System.Drawing.Color.Black;
                    rwnewvs.Cells.Add(tcellnewvs7);

                    TableCell tcellnewvs8 = new TableCell();
                    tcellnewvs8.Text = " ";
                    tcellnewvs8.BorderWidth = 1;
                    tcellnewvs8.BorderColor = System.Drawing.Color.SlateGray;
                    tcellnewvs8.ForeColor = System.Drawing.Color.Black;
                    rwnewvs.Cells.Add(tcellnewvs8);

                    TableCell tcellnewvs9 = new TableCell();
                    tcellnewvs9.Text = cl.ds.Tables[0].Rows[j]["gpf4adv"].ToString();
                    tcellnewvs9.BorderWidth = 1;
                    tcellnewvs9.BorderColor = System.Drawing.Color.SlateGray;
                    tcellnewvs9.ForeColor = System.Drawing.Color.Black;
                    rwnewvs.Cells.Add(tcellnewvs9);
                    /////////////nitin
                    TableCell tcellnewvs10 = new TableCell();
                    tcellnewvs10.Text = cl.ds.Tables[0].Rows[j]["vehiinst"].ToString();
                    tcellnewvs10.BorderWidth = 1;
                    tcellnewvs10.BorderColor = System.Drawing.Color.SlateGray;
                    rwnewvs.Cells.Add(tcellnewvs10);

                    TableCell tcellnewvs11 = new TableCell();
                    tcellnewvs11.Text = cl.ds.Tables[0].Rows[j]["corinst"].ToString();
                    tcellnewvs11.BorderWidth = 1;
                    tcellnewvs11.BorderColor = System.Drawing.Color.SlateGray;
                    rwnewvs.Cells.Add(tcellnewvs11);

                    TableCell tcellnewvs12 = new TableCell();
                    tcellnewvs12.Text = cl.ds.Tables[0].Rows[j]["coriinst"].ToString();
                    tcellnewvs12.BorderWidth = 1;
                    tcellnewvs12.BorderColor = System.Drawing.Color.SlateGray;
                    rwnewvs.Cells.Add(tcellnewvs12);

                    TableCell tcellnewvs13 = new TableCell();// "Gis Total";
                    tcellnewvs13.Text = cl.ds.Tables[0].Rows[j]["gistot"].ToString();
                    tcellnewvs13.BorderWidth = 1;
                    tcellnewvs13.BorderColor = System.Drawing.Color.SlateGray;
                    rwnewvs.Cells.Add(tcellnewvs13);

                    TableCell tcellnewvs14 = new TableCell();// "Mis ded3 ";
                    //tcellnewvs13.Text = Convert.ToString(Convert.ToDouble(cl.ds.Tables[0].Rows[j][29].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j][43].ToString()));
                    tcellnewvs14.Text = Convert.ToString(Convert.ToDouble(cl.ds.Tables[0].Rows[j]["ded1"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["ded2"].ToString()));

                    tcellnewvs14.ForeColor = System.Drawing.Color.Black;
                    tcellnewvs14.BorderWidth = 1;
                    tcellnewvs14.BorderColor = System.Drawing.Color.SlateGray;
                    rwnewvs.Cells.Add(tcellnewvs14);


                    TableCell tcellnewvs15 = new TableCell();//remarks

                    tcellnewvs15.Text = cl.ds.Tables[0].Rows[j]["rdded"].ToString();
                    tcellnewvs15.BorderWidth = 1;
                    tcellnewvs15.BorderColor = System.Drawing.Color.SlateGray;
                    rwnewvs.Cells.Add(tcellnewvs15);

                    TableCell tcellnewvs16 = new TableCell();
                    tcellnewvs16.Text = "";
                    tcellnewvs16.BorderWidth = 1;
                    tcellnewvs16.BorderColor = System.Drawing.Color.SlateGray;
                    rwnewvs.Cells.Add(tcellnewvs16);
                    Table1.Rows.Add(rwnewvs);

                    TableRow rwvXs = new TableRow();
                    rwvXs.Width = Unit.Percentage(100);
                    rwvXs.BorderWidth = 1;
                    rwvXs.BorderColor = System.Drawing.Color.SlateGray;
                    TableCell tcellxv2s = new TableCell();
                    //tcellxv2.Text = "<hr>";
                    tcellxv2s.Text = "<Br>";
                    rwvXs.Cells.Add(tcellxv2s);
                    Table1.Rows.Add(rwvXs);

                }

            }


        }

        public void usecheck()
        {
            bool i;
            i = cl.checklavel((string)Session["iduser"]);
            if (i == true)
            {
                Uidt.Text = "%";
            }
            else
            {
                cl.ds = cl.DataFill("SELECT DisId FROM Ucreate WHERE (iduser ='" + (string)Session["iduser"] + "')");
                if (cl.ds.Tables[0].Rows.Count > 0)
                {
                    Uidt.Text = cl.ds.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    Response.Redirect("~/login.aspx");
                }
            }
        }



        public void salary()
        {
            string pftype = Request.QueryString["pftype"];
            //**************years*****************        
            if (Request.QueryString["years"] != "N")
            {
                q1 = "a.Syear=" + Request.QueryString["years"] + "";
                YearLabel.Text = Request.QueryString["years"];
            }
            //**************Months*****************
            if (Request.QueryString["Months"] != "N")
            {
                q2 = "a.Smonth=" + Request.QueryString["Months"] + "";
                MonthLabel.Text = Request.QueryString["Mtext"];
            }

            //****************DDOID***************        
            q3 = "s.ddoid=" + (string)Session["ddopid"] + "";
            //******************SectionID****************

            //******************HeadID****************
            if (Request.QueryString["HeadID"] != "ALL")
            {
                if (Request.QueryString["HeadID"].Length == 1)
                {
                    q5 = "Pay_Head.headid=" + Request.QueryString["HeadID"] + "";
                }
                else
                {
                    q5 = "Pay_Head.headid like '%" + Request.QueryString["HeadID"] + "%' ";
                }
            }
            else
            {
                q5 = "Pay_Head.headid like '%'";
            }


            if (Request.QueryString["adminunit"] != "0")
            {
                q6 = "a.adminunit=" + Request.QueryString["adminunit"] + "";


                qr = q1 + "  AND  " + q2 + "  AND  " + q3 + "  AND " + q5 + "  AND " + q6 + "";

            }
            else
            {
                q6 = "";
                qr = q1 + "  AND  " + q2 + "  AND  " + q3 + "  AND " + q5 + "";
            }

            int option = Convert.ToInt32(pftype);
            if (option != 0)
            {


                if (option == 1)//GPF+Not Alloted
                {


                    finalqr = "SELECT     Pay_Head.headname, s.poposting, a.idno, s.senno, a.gpfno, ISNULL(a.basicpay, 0) AS basicpay, ISNULL(a.dapay, 0) AS dapay, ISNULL(a.hra, 0) AS hra, ISNULL(a.cca,                       0) AS cca, ISNULL(a.othall5, 0) AS othall6, ISNULL(a.fixall2, 0) AS fixall2, ISNULL(a.gpf, 0) AS gpf, ISNULL(a.gvr, 0) AS gvr, ISNULL(a.hba1inst, 0) AS hba1inst,                       ISNULL(a.hba1iinst, 0) AS hba1iinst, ISNULL(a.elecbill, 0) AS elecbill, ISNULL(a.pli, 0) AS pli, ISNULL(a.incometax, 0) AS incometax, 0 AS totded, ISNULL(a.Society, 0)                       AS socded, s.name, ISNULL(a.plino, 0) AS plino, ISNULL(a.perpay, 0) AS perpay, ISNULL(a.othall1, 0) AS othall1, ISNULL(a.npaall, 0) AS npaall, ISNULL(a.othall4, 0)                       AS othall4, ISNULL(a.dearnesspay, 0) AS dearnesspay, ISNULL(a.fixall3, 0) AS fixall3, ISNULL(a.Gpfadv, 0) AS GpfA, ISNULL(a.hrr, 0) AS hrr, ISNULL(a.hba2inst, 0)                       AS hba2inst, ISNULL(a.hba2iinst, 0) AS hba2iinst, ISNULL(a.gisi, 0) AS gisi, ISNULL(a.ded1, 0) AS ded1, ISNULL(a.Licrd, 0) AS Licrd, s.post, ISNULL(a.sppay, 0)                       AS sppay, ISNULL(a.othall2, 0) AS othall2, ISNULL(a.salarrear, 0) AS salarrear, ISNULL(a.tpay, 0) AS hill, ISNULL(a.pensionpay, 0) AS pensionpay, ISNULL(a.salded, 0)                       AS salded, ISNULL(a.vehinst, 0) AS vehinst, ISNULL(a.vehiinst, 0) AS vehiinst, ISNULL(a.hba3inst, 0) AS hba3inst, ISNULL(a.hba3iinst, 0) AS hba3iinst, ISNULL(a.giss, 0) AS giss,                       ISNULL(a.ded2, 0) AS ded2, ISNULL(a.attendance, 0) AS attendance, ISNULL(a.othall3, 0) AS othall3, ISNULL(a.otharrear, 0) AS otharrear, ISNULL(a.othall5, 0)                       AS othall5, ISNULL(a.fixall1, 0) AS fixall1, 0 AS gpf4, ISNULL(a.vehinst, 0) AS vehinst, ISNULL(a.vehiinst, 0) AS vehiinst, ISNULL(a.corinst, 0) AS corinst, ISNULL(a.coriinst, 0) AS coriinst, 0 AS gistot,                       ISNULL(a.ded3, 0) AS ded3, a.remarks,a.note, Pay_Head.headname AS Expr1,                                        CAST(pmd_Pay_Scale.llimit AS varchar) + ' -' + CAST(pmd_Pay_Scale.ulimit AS varchar) AS payscale, ISNULL(a.Gradepay, 0) AS Gradepay, ISNULL(a.gpfiv, 0) AS gpfiv, ISNULL(a.lic, 0) AS lic, ISNULL(a.gpf4adv, 0) as gpf4adv,ISNULL(a.rdded, 0) as rdded,ISNULL(a.socded, 0) as sded,ISNULL(a.pranr, 0) as pranr ,ISNULL(a.monthr, 0) as monthr    FROM         pmdcalulatedsalary AS a INNER JOIN                      pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN                      Pay_Head ON a.headid = Pay_Head.headid INNER JOIN                      pmd_Pay_Scale ON a.scaleid = pmd_Pay_Scale.scaleid WHERE " + qr + " and   a.pftype=1  order by Pay_Head.headname,poposting,basicpay ";
                    finalqr1 = " SELECT     COUNT(a.idno) AS noofemp, NULL AS senno, NULL AS gpfno, ISNULL(SUM(a.basicpay), 0) AS basicpay, ISNULL(SUM(a.dapay), 0) AS dapay, ISNULL(SUM(a.hra), 0)                       AS hra, ISNULL(SUM(a.cca), 0) AS cca, ISNULL(SUM(a.othall5), 0) AS othall6, ISNULL(SUM(a.fixall2), 0) AS fixall2, ISNULL(SUM(a.gpf), 0) AS gpf, ISNULL(SUM(a.gvr), 0)                       AS gvr, ISNULL(SUM(a.hba1inst), 0) AS hba1inst, ISNULL(SUM(a.hba1iinst), 0) AS hba1iinst, ISNULL(SUM(a.elecbill), 0) AS elecbill, ISNULL(SUM(a.pli), 0) AS pli,                       ISNULL(SUM(a.incometax), 0) AS incometax, 0 AS totded, ISNULL(SUM(a.Society), 0) AS socded, NULL AS name, 0 AS plino, ISNULL(SUM(a.perpay), 0) AS perpay,                       ISNULL(SUM(a.othall1), 0) AS othall1, ISNULL(SUM(a.npaall), 0) AS npaall, ISNULL(SUM(a.othall4), 0) AS othall4, ISNULL(SUM(a.dearnesspay), 0) AS dearnesspay,                       ISNULL(SUM(a.fixall3), 0) AS fixall3, ISNULL(SUM(a.Gpfadv), 0) AS GpfA, ISNULL(SUM(a.hrr), 0) AS hrr, ISNULL(SUM(a.hba2inst), 0) AS hba2inst,                       ISNULL(SUM(a.hba2iinst), 0) AS hba2iinst, ISNULL(SUM(a.gisi), 0) AS gisi, ISNULL(SUM(a.ded1), 0) AS ded1, ISNULL(SUM(a.Licrd), 0) AS Licrd, NULL AS post,                       ISNULL(SUM(a.sppay), 0) AS sppay, ISNULL(SUM(a.othall2), 0) AS othall2, ISNULL(SUM(a.salarrear), 0) AS salarrear, ISNULL(SUM(a.tpay), 0) AS hill,                       ISNULL(SUM(a.pensionpay), 0) AS pensionpay, ISNULL(SUM(a.salded), 0) AS salded, ISNULL(SUM(a.vehinst), 0) AS vehinst,ISNULL(SUM(a.vehiinst), 0) AS vehiinst, ISNULL(SUM(a.hba3inst), 0)                       AS hba3inst, ISNULL(SUM(a.hba3iinst), 0) AS hba3iinst, ISNULL(SUM(a.giss), 0) AS giss, ISNULL(SUM(a.ded2), 0) AS ded2, ISNULL(SUM(a.attendance), 0)                       AS attendance, ISNULL(SUM(a.othall3), 0) AS othall3, ISNULL(SUM(a.otharrear), 0) AS otharrear, ISNULL(SUM(a.othall5), 0) AS othall5, ISNULL(SUM(a.fixall1), 0)  AS fixall1, 0 AS gpf4, ISNULL(SUM(a.vehinst), 0) AS vehinst, ISNULL(SUM(a.vehiinst), 0) AS vehiinst, ISNULL(SUM(a.corinst), 0) AS corinst, ISNULL(SUM(a.coriinst), 0) AS coriinst, SUM(a.gisi) + SUM(a.giss)                       AS gistot, ISNULL(SUM(a.ded3), 0) AS ded3, ISNULL(SUM(a.Gradepay), 0) AS Gradepay, ISNULL(SUM(a.gpfiv), 0) AS gpfiv, ISNULL(SUM(a.lic), 0) AS lic,ISNULL(SUM(a.gpf4adv), 0) AS gpf4adv,ISNULL(SUM(a.rdded), 0) AS rdded,ISNULL(SUM(a.socded), 0) AS sded FROM         pmdcalulatedsalary AS a INNER JOIN                     pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN                      Pay_Head ON a.headid = Pay_Head.headid INNER JOIN                      PMD_pay_Scale ON a.scaleid = PMD_pay_Scale.scaleid WHERE " + qr + "and  a.pftype=1";
                }
                if (option == 2)//PRAN
                {

                    finalqr = "SELECT     Pay_Head.headname, s.poposting, a.idno, s.senno, a.gpfno, ISNULL(a.basicpay, 0) AS basicpay, ISNULL(a.dapay, 0) AS dapay, ISNULL(a.hra, 0) AS hra, ISNULL(a.cca,                       0) AS cca, ISNULL(a.othall5, 0) AS othall6, ISNULL(a.fixall2, 0) AS fixall2, ISNULL(a.gpf, 0) AS gpf, ISNULL(a.gvr, 0) AS gvr, ISNULL(a.hba1inst, 0) AS hba1inst,                       ISNULL(a.hba1iinst, 0) AS hba1iinst, ISNULL(a.elecbill, 0) AS elecbill, ISNULL(a.pli, 0) AS pli, ISNULL(a.incometax, 0) AS incometax, 0 AS totded, ISNULL(a.Society, 0)                       AS socded, s.name, ISNULL(a.plino, 0) AS plino, ISNULL(a.perpay, 0) AS perpay, ISNULL(a.othall1, 0) AS othall1, ISNULL(a.npaall, 0) AS npaall, ISNULL(a.othall4, 0)                       AS othall4, ISNULL(a.dearnesspay, 0) AS dearnesspay, ISNULL(a.fixall3, 0) AS fixall3, ISNULL(a.Gpfadv, 0) AS GpfA, ISNULL(a.hrr, 0) AS hrr, ISNULL(a.hba2inst, 0)                       AS hba2inst, ISNULL(a.hba2iinst, 0) AS hba2iinst, ISNULL(a.gisi, 0) AS gisi, ISNULL(a.ded1, 0) AS ded1, ISNULL(a.Licrd, 0) AS Licrd, s.post, ISNULL(a.sppay, 0)                       AS sppay, ISNULL(a.othall2, 0) AS othall2, ISNULL(a.salarrear, 0) AS salarrear, ISNULL(a.tpay, 0) AS hill, ISNULL(a.pensionpay, 0) AS pensionpay, ISNULL(a.salded, 0)                       AS salded, ISNULL(a.vehinst, 0) AS vehinst, ISNULL(a.vehiinst, 0) AS vehiinst, ISNULL(a.hba3inst, 0) AS hba3inst, ISNULL(a.hba3iinst, 0) AS hba3iinst, ISNULL(a.giss, 0) AS giss,                       ISNULL(a.ded2, 0) AS ded2, ISNULL(a.attendance, 0) AS attendance, ISNULL(a.othall3, 0) AS othall3, ISNULL(a.otharrear, 0) AS otharrear, ISNULL(a.othall5, 0)                       AS othall5, ISNULL(a.fixall1, 0) AS fixall1, 0 AS gpf4, ISNULL(a.vehinst, 0) AS vehinst, ISNULL(a.vehiinst, 0) AS vehiinst, ISNULL(a.corinst, 0) AS corinst, ISNULL(a.coriinst, 0) AS coriinst, 0 AS gistot,                       ISNULL(a.ded3, 0) AS ded3, a.remarks,a.note, Pay_Head.headname AS Expr1,                                        CAST(pmd_Pay_Scale.llimit AS varchar) + ' -' + CAST(pmd_Pay_Scale.ulimit AS varchar) AS payscale, ISNULL(a.Gradepay, 0) AS Gradepay, ISNULL(a.gpfiv, 0) AS gpfiv, ISNULL(a.lic, 0) AS lic, ISNULL(a.gpf4adv, 0) as gpf4adv,ISNULL(a.rdded, 0) as rdded,ISNULL(a.socded, 0) as sded ,ISNULL(a.pranr, 0) as pranr ,ISNULL(a.monthr, 0) as monthr  FROM         pmdcalulatedsalary AS a INNER JOIN                      pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN                      Pay_Head ON a.headid = Pay_Head.headid INNER JOIN                      pmd_Pay_Scale ON a.scaleid = pmd_Pay_Scale.scaleid WHERE " + qr + " and  a.pftype=2 order by Pay_Head.headname,poposting,Basicpay   ";
                    finalqr1 = "SELECT     COUNT(a.idno) AS noofemp, NULL AS senno, NULL AS gpfno, ISNULL(SUM(a.basicpay), 0) AS basicpay, ISNULL(SUM(a.dapay), 0) AS dapay, ISNULL(SUM(a.hra), 0)                       AS hra, ISNULL(SUM(a.cca), 0) AS cca, ISNULL(SUM(a.othall5), 0) AS othall6, ISNULL(SUM(a.fixall2), 0) AS fixall2, ISNULL(SUM(a.gpf), 0) AS gpf, ISNULL(SUM(a.gvr), 0)                       AS gvr, ISNULL(SUM(a.hba1inst), 0) AS hba1inst, ISNULL(SUM(a.hba1iinst), 0) AS hba1iinst, ISNULL(SUM(a.elecbill), 0) AS elecbill, ISNULL(SUM(a.pli), 0) AS pli,                       ISNULL(SUM(a.incometax), 0) AS incometax, 0 AS totded, ISNULL(SUM(a.Society), 0) AS socded, NULL AS name, 0 AS plino, ISNULL(SUM(a.perpay), 0) AS perpay,                       ISNULL(SUM(a.othall1), 0) AS othall1, ISNULL(SUM(a.npaall), 0) AS npaall, ISNULL(SUM(a.othall4), 0) AS othall4, ISNULL(SUM(a.dearnesspay), 0) AS dearnesspay,                       ISNULL(SUM(a.fixall3), 0) AS fixall3, ISNULL(SUM(a.Gpfadv), 0) AS GpfA, ISNULL(SUM(a.hrr), 0) AS hrr, ISNULL(SUM(a.hba2inst), 0) AS hba2inst,                       ISNULL(SUM(a.hba2iinst), 0) AS hba2iinst, ISNULL(SUM(a.gisi), 0) AS gisi, ISNULL(SUM(a.ded1), 0) AS ded1, ISNULL(SUM(a.Licrd), 0) AS Licrd, NULL AS post,                       ISNULL(SUM(a.sppay), 0) AS sppay, ISNULL(SUM(a.othall2), 0) AS othall2, ISNULL(SUM(a.salarrear), 0) AS salarrear, ISNULL(SUM(a.tpay), 0) AS hill,                       ISNULL(SUM(a.pensionpay), 0) AS pensionpay, ISNULL(SUM(a.salded), 0) AS salded, ISNULL(SUM(a.vehinst), 0) AS vehinst,ISNULL(SUM(a.vehiinst), 0) AS vehiinst ,ISNULL(SUM(a.hba3inst), 0)    AS hba3inst, ISNULL(SUM(a.hba3iinst), 0) AS hba3iinst, ISNULL(SUM(a.giss), 0) AS giss, ISNULL(SUM(a.ded2), 0) AS ded2, ISNULL(SUM(a.attendance), 0)                       AS attendance, ISNULL(SUM(a.othall3), 0) AS othall3, ISNULL(SUM(a.otharrear), 0) AS otharrear, ISNULL(SUM(a.othall5), 0) AS othall5, ISNULL(SUM(a.fixall1), 0)  AS fixall1, 0 AS gpf4, ISNULL(SUM(a.vehinst), 0) AS vehinst, ISNULL(SUM(a.vehiinst), 0) AS vehiinst, ISNULL(SUM(a.corinst), 0) AS corinst, ISNULL(SUM(a.coriinst), 0) AS coriinst, SUM(a.gisi) + SUM(a.giss)                       AS gistot, ISNULL(SUM(a.ded3), 0) AS ded3, ISNULL(SUM(a.Gradepay), 0) AS Gradepay, ISNULL(SUM(a.gpfiv), 0) AS gpfiv, ISNULL(SUM(a.lic), 0) AS lic,ISNULL(SUM(a.gpf4adv), 0) AS gpf4adv,ISNULL(SUM(a.rdded), 0) AS rdded,ISNULL(SUM(a.socded), 0) AS sded FROM         pmdcalulatedsalary AS a INNER JOIN                     pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN                      Pay_Head ON a.headid = Pay_Head.headid INNER JOIN                      PMD_pay_Scale ON a.scaleid = PMD_pay_Scale.scaleid WHERE " + qr + " and  a.pftype=2";

                }

                if (option == 3)//ALL
                {
                    finalqr = "SELECT     Pay_Head.headname, s.poposting, a.idno, s.senno, a.gpfno, ISNULL(a.basicpay, 0) AS basicpay, ISNULL(a.dapay, 0) AS dapay, ISNULL(a.hra, 0) AS hra, ISNULL(a.cca,                       0) AS cca, ISNULL(a.othall5, 0) AS othall6, ISNULL(a.fixall2, 0) AS fixall2, ISNULL(a.gpf, 0) AS gpf, ISNULL(a.gvr, 0) AS gvr, ISNULL(a.hba1inst, 0) AS hba1inst,                       ISNULL(a.hba1iinst, 0) AS hba1iinst, ISNULL(a.elecbill, 0) AS elecbill, ISNULL(a.pli, 0) AS pli, ISNULL(a.incometax, 0) AS incometax, 0 AS totded, ISNULL(a.Society, 0) AS socded, s.name, ISNULL(a.plino, 0) AS plino, ISNULL(a.perpay, 0) AS perpay, ISNULL(a.othall1, 0) AS othall1, ISNULL(a.npaall, 0) AS npaall, ISNULL(a.othall4, 0)                       AS othall4, ISNULL(a.dearnesspay, 0) AS dearnesspay, ISNULL(a.fixall3, 0) AS fixall3, ISNULL(a.Gpfadv, 0) AS GpfA, ISNULL(a.hrr, 0) AS hrr, ISNULL(a.hba2inst, 0)                       AS hba2inst, ISNULL(a.hba2iinst, 0) AS hba2iinst, ISNULL(a.gisi, 0) AS gisi, ISNULL(a.ded1, 0) AS ded1, ISNULL(a.Licrd, 0) AS Licrd, s.post, ISNULL(a.sppay, 0)                       AS sppay, ISNULL(a.othall2, 0) AS othall2, ISNULL(a.salarrear, 0) AS salarrear, ISNULL(a.tpay, 0) AS hill, ISNULL(a.pensionpay, 0) AS pensionpay, ISNULL(a.salded, 0)                       AS salded, ISNULL(a.vehinst, 0) AS vehinst,ISNULL(a.vehiinst, 0) AS vehiinst, ISNULL(a.hba3inst, 0) AS hba3inst, ISNULL(a.hba3iinst, 0) AS hba3iinst, ISNULL(a.giss, 0) AS giss,                       ISNULL(a.ded2, 0) AS ded2, ISNULL(a.attendance, 0) AS attendance, ISNULL(a.othall3, 0) AS othall3, ISNULL(a.otharrear, 0) AS otharrear, ISNULL(a.othall5, 0)                       AS othall5, ISNULL(a.fixall1, 0) AS fixall1, 0 AS gpf4, ISNULL(a.vehinst, 0) AS vehinst, ISNULL(a.vehiinst, 0) AS vehiinst, ISNULL(a.corinst, 0) AS corinst, ISNULL(a.coriinst, 0) AS coriinst, 0 AS gistot,                       ISNULL(a.ded3, 0) AS ded3, a.remarks,a.note, Pay_Head.headname AS Expr1,                                        CAST(pmd_Pay_Scale.llimit AS varchar) + ' -' + CAST(pmd_Pay_Scale.ulimit AS varchar) AS payscale, ISNULL(a.Gradepay, 0) AS Gradepay, ISNULL(a.gpfiv, 0) AS gpfiv, ISNULL(a.lic, 0) AS lic, ISNULL(a.gpf4adv, 0) as gpf4adv,ISNULL(a.rdded, 0) as rdded,ISNULL(a.socded, 0) as sded ,ISNULL(a.pranr, 0) as pranr ,ISNULL(a.monthr, 0) as monthr  FROM         pmdcalulatedsalary AS a INNER JOIN                      pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN                      Pay_Head ON a.headid = Pay_Head.headid INNER JOIN                      pmd_Pay_Scale ON a.scaleid = pmd_Pay_Scale.scaleid  WHERE " + qr + " order by Pay_Head.headname,poposting,basicpay  ";
                    finalqr1 = "SELECT     COUNT(a.idno) AS noofemp, NULL AS senno, NULL AS gpfno, ISNULL(SUM(a.basicpay), 0) AS basicpay, ISNULL(SUM(a.dapay), 0) AS dapay, ISNULL(SUM(a.hra), 0)                       AS hra, ISNULL(SUM(a.cca), 0) AS cca, ISNULL(SUM(a.othall5), 0) AS othall6, ISNULL(SUM(a.fixall2), 0) AS fixall2, ISNULL(SUM(a.gpf), 0) AS gpf, ISNULL(SUM(a.gvr), 0)                       AS gvr, ISNULL(SUM(a.hba1inst), 0) AS hba1inst, ISNULL(SUM(a.hba1iinst), 0) AS hba1iinst, ISNULL(SUM(a.elecbill), 0) AS elecbill, ISNULL(SUM(a.pli), 0) AS pli,                       ISNULL(SUM(a.incometax), 0) AS incometax, 0 AS totded, ISNULL(SUM(a.Society), 0) AS socded, NULL AS name, 0 AS plino, ISNULL(SUM(a.perpay), 0) AS perpay,                       ISNULL(SUM(a.othall1), 0) AS othall1, ISNULL(SUM(a.npaall), 0) AS npaall, ISNULL(SUM(a.othall4), 0) AS othall4, ISNULL(SUM(a.dearnesspay), 0) AS dearnesspay,                       ISNULL(SUM(a.fixall3), 0) AS fixall3, ISNULL(SUM(a.Gpfadv), 0) AS GpfA, ISNULL(SUM(a.hrr), 0) AS hrr, ISNULL(SUM(a.hba2inst), 0) AS hba2inst,                       ISNULL(SUM(a.hba2iinst), 0) AS hba2iinst, ISNULL(SUM(a.gisi), 0) AS gisi, ISNULL(SUM(a.ded1), 0) AS ded1, ISNULL(SUM(a.Licrd), 0) AS Licrd, NULL AS post,                       ISNULL(SUM(a.sppay), 0) AS sppay, ISNULL(SUM(a.othall2), 0) AS othall2, ISNULL(SUM(a.salarrear), 0) AS salarrear, ISNULL(SUM(a.tpay), 0) AS hill,                       ISNULL(SUM(a.pensionpay), 0) AS pensionpay, ISNULL(SUM(a.salded), 0) AS salded, ISNULL(SUM(a.vehinst), 0) AS vehinst,ISNULL(SUM(a.vehiinst), 0) AS vehiinst, ISNULL(SUM(a.hba3inst), 0)                       AS hba3inst, ISNULL(SUM(a.hba3iinst), 0) AS hba3iinst, ISNULL(SUM(a.giss), 0) AS giss, ISNULL(SUM(a.ded2), 0) AS ded2, ISNULL(SUM(a.attendance), 0)                       AS attendance, ISNULL(SUM(a.othall3), 0) AS othall3, ISNULL(SUM(a.otharrear), 0) AS otharrear, ISNULL(SUM(a.othall5), 0) AS othall5, ISNULL(SUM(a.fixall1), 0) AS fixall1, 0 AS gpf4, ISNULL(SUM(a.vehinst), 0) AS vehinst, ISNULL(SUM(a.vehiinst), 0) AS vehiinst, ISNULL(SUM(a.corinst), 0) AS corinst, ISNULL(SUM(a.coriinst), 0) AS coriinst, SUM(a.gisi) + SUM(a.giss)                       AS gistot, ISNULL(SUM(a.ded3), 0) AS ded3, ISNULL(SUM(a.Gradepay), 0) AS Gradepay, ISNULL(SUM(a.gpfiv), 0) AS gpfiv, ISNULL(SUM(a.lic), 0) AS lic,ISNULL(SUM(a.gpf4adv), 0) AS gpf4adv,ISNULL(SUM(a.rdded), 0) AS rdded,ISNULL(SUM(a.socded), 0) AS sded FROM         pmdcalulatedsalary AS a INNER JOIN                     pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN                      Pay_Head ON a.headid = Pay_Head.headid INNER JOIN                      PMD_pay_Scale ON a.scaleid = PMD_pay_Scale.scaleid  WHERE " + qr + " ";
                }



            }
            else
            {
            }
            try
            {
                cl.ds = cl.DataFill(finalqr);
                int j;
                if (cl.ds.Tables[0].Rows.Count > 0)
                {
                    payheader();
                    string sec;
                    sec = "";
                    for (j = 0; j <= cl.ds.Tables[0].Rows.Count - 1; j++)
                    {
                        if (sec != cl.ds.Tables[0].Rows[j][57].ToString())
                        {
                            ///for head and Section
                            ///

                            TableRow rwHead = new TableRow();//Head Of Account...........................1st Line............
                            rwHead.Width = Unit.Percentage(100);
                            rwHead.BorderWidth = 1;
                            rwHead.BorderColor = System.Drawing.Color.SlateGray;
                            TableCell tcellrwHead = new TableCell();
                            tcellrwHead.Width = Unit.Percentage(100);
                            tcellrwHead.Attributes.Add("colspan", "17");
                            tcellrwHead.Text = "Head Of Account " + cl.ds.Tables[0].Rows[j]["headname"].ToString();
                            rwHead.Cells.Add(tcellrwHead);
                            Table1.Rows.Add(rwHead);
                            //////////
                            TableRow rwbr = new TableRow();
                            rwbr.Width = Unit.Percentage(100);
                            rwbr.BorderWidth = 1;
                            rwbr.BorderColor = System.Drawing.Color.SlateGray;
                            TableCell tcellrwbr = new TableCell();
                            tcellrwbr.Width = Unit.Percentage(100);
                            tcellrwbr.Attributes.Add("colspan", "17");
                            tcellrwbr.ForeColor = System.Drawing.Color.Black;
                            //tcellrwbr.Text = "-";
                            tcellrwbr.Text = "<hr>";
                            rwbr.Cells.Add(tcellrwbr);
                            Table1.Rows.Add(rwbr);
                        }
                        ///////////////
                        //for head and Section
                        TableRow rwpaysc = new TableRow();//payscale
                        rwpaysc.Width = Unit.Percentage(100);
                        rwpaysc.BorderWidth = 1;
                        rwpaysc.BorderColor = System.Drawing.Color.SlateGray;
                        TableCell tcellpaysc = new TableCell();
                        tcellpaysc.Attributes.Add("colspan", "17");
                        tcellpaysc.Width = Unit.Percentage(100);
                        tcellpaysc.Text = "Pay Scale " + cl.ds.Tables[0].Rows[j]["payscale"].ToString();
                        rwpaysc.Cells.Add(tcellpaysc);
                        Table1.Rows.Add(rwpaysc);

                        TableRow rw1 = new TableRow();
                        rw1.Width = Unit.Percentage(100);
                        rw1.BorderWidth = 1;
                        rw1.BorderColor = System.Drawing.Color.Black;
                        rw1.ForeColor = System.Drawing.Color.SlateGray;
                        TableCell tcellv0 = new TableCell();
                        tcellv0.BorderWidth = 1;
                        tcellv0.BorderColor = System.Drawing.Color.SlateGray;
                        tcellv0.Text = (j + 1).ToString() + "/" + cl.ds.Tables[0].Rows[j]["idno"].ToString();
                        rw1.Cells.Add(tcellv0);

                        TableCell tcellv1 = new TableCell();
                        tcellv1.BorderWidth = 1;
                        tcellv1.BorderColor = System.Drawing.Color.SlateGray;
                        tcellv1.Text = cl.ds.Tables[0].Rows[j]["gpfno"].ToString();
                        rw1.Cells.Add(tcellv1);




                        TableCell tcellv2 = new TableCell();
                        tcellv2.BorderWidth = 1;
                        tcellv2.BorderColor = System.Drawing.Color.SlateGray;
                        tcellv2.Text = cl.ds.Tables[0].Rows[j]["Gradepay"].ToString();//Garde
                        rw1.Cells.Add(tcellv2);

                        TableCell tcellv3 = new TableCell();
                        tcellv3.BorderWidth = 1;
                        tcellv3.BorderColor = System.Drawing.Color.SlateGray;
                        tcellv3.Text = cl.ds.Tables[0].Rows[j]["dapay"].ToString();//Da Pay
                        rw1.Cells.Add(tcellv3);

                        TableCell tcellv4 = new TableCell();
                        tcellv4.BorderWidth = 1;
                        tcellv4.BorderColor = System.Drawing.Color.SlateGray;
                        tcellv4.Text = cl.ds.Tables[0].Rows[j]["HRA"].ToString();//HRA
                        rw1.Cells.Add(tcellv4);

                        TableCell tcellv5 = new TableCell();
                        tcellv5.BorderWidth = 1;
                        tcellv5.BorderColor = System.Drawing.Color.SlateGray;
                        tcellv5.Text = cl.ds.Tables[0].Rows[j]["CCA"].ToString();//CCA
                        rw1.Cells.Add(tcellv5);

                        TableCell tcellv6 = new TableCell();
                        tcellv6.BorderWidth = 1;
                        tcellv6.BorderColor = System.Drawing.Color.SlateGray;
                        tcellv6.Text = cl.ds.Tables[0].Rows[j]["othall6"].ToString();//Oth All6
                        rw1.Cells.Add(tcellv6);

                        TableCell tcellv7 = new TableCell();
                        tcellv7.BorderWidth = 1;
                        tcellv7.BorderColor = System.Drawing.Color.SlateGray;
                        tcellv7.Text = cl.ds.Tables[0].Rows[j]["fixall2"].ToString();//Fixed All.2
                        rw1.Cells.Add(tcellv7);

                        ///"Gross Pay"
                        TableCell tcellv8 = new TableCell();
                        tcellv8.BorderWidth = 1;
                        tcellv8.BorderColor = System.Drawing.Color.SlateGray;
                        tcellv8.Text = Convert.ToString(Convert.ToDouble(cl.ds.Tables[0].Rows[j]["basicpay"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["Gradepay"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["DApay"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["HRA"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["CCA"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["othall6"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["fixall2"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["perpay"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["othall1"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["npaall"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["othall4"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["dearnesspay"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["fixall3"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["sppay"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["othall2"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["salarrear"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["hill"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["pensionpay"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["othall3"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["otharrear"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["othall5"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["fixall1"].ToString()) - Convert.ToDouble(cl.ds.Tables[0].Rows[j]["salded"].ToString()));
                        tcellv8.ForeColor = System.Drawing.Color.Black;
                        rw1.Cells.Add(tcellv8);

                        TableCell tcellv9 = new TableCell();
                        tcellv9.BorderWidth = 1;
                        tcellv9.BorderColor = System.Drawing.Color.SlateGray;
                        tcellv9.Text = cl.ds.Tables[0].Rows[j]["gpf"].ToString();//              
                        rw1.Cells.Add(tcellv9);

                        TableCell tcellv10 = new TableCell();
                        tcellv10.BorderWidth = 1;
                        tcellv10.BorderColor = System.Drawing.Color.SlateGray;
                        tcellv10.Text = cl.ds.Tables[0].Rows[j]["gvr"].ToString();
                        rw1.Cells.Add(tcellv10);

                        TableCell tcellv11 = new TableCell();
                        tcellv11.BorderWidth = 1;
                        tcellv11.BorderColor = System.Drawing.Color.SlateGray;
                        tcellv11.Text = cl.ds.Tables[0].Rows[j]["hba1inst"].ToString();
                        rw1.Cells.Add(tcellv11);

                        TableCell tcellv12 = new TableCell();
                        tcellv12.BorderWidth = 1;
                        tcellv12.BorderColor = System.Drawing.Color.SlateGray;
                        tcellv12.Text = cl.ds.Tables[0].Rows[j]["hba1iinst"].ToString();
                        rw1.Cells.Add(tcellv12);

                        TableCell tcellv13 = new TableCell();
                        tcellv13.BorderWidth = 1;
                        tcellv13.BorderColor = System.Drawing.Color.SlateGray;
                        tcellv13.Text = cl.ds.Tables[0].Rows[j]["pli"].ToString();
                        rw1.Cells.Add(tcellv13);

                        TableCell tcellv14 = new TableCell();
                        tcellv14.BorderWidth = 1;
                        tcellv14.BorderColor = System.Drawing.Color.SlateGray;
                        tcellv14.Text = cl.ds.Tables[0].Rows[j]["incometax"].ToString();
                        rw1.Cells.Add(tcellv14);

                        TableCell tcellv15 = new TableCell();
                        tcellv15.BorderWidth = 1;
                        tcellv15.BorderColor = System.Drawing.Color.SlateGray;
                        tcellv15.Text = cl.ds.Tables[0].Rows[j]["elecbill"].ToString();
                        //tcellv15.Text = cl.ds.Tables[0].Rows[j]["socded"].ToString();//Soc. Ded.             
                        rw1.Cells.Add(tcellv15);

                        TableCell tcellv16 = new TableCell();
                        tcellv16.BorderWidth = 1;
                        tcellv16.BorderColor = System.Drawing.Color.SlateGray;
                        tcellv16.Text = cl.ds.Tables[0].Rows[j]["sded"].ToString();

                        tcellv16.ForeColor = System.Drawing.Color.Black;
                        rw1.Cells.Add(tcellv16);

                        Table1.Rows.Add(rw1);
                        ///////////////////////////////////..................................2nd Line....................
                        TableRow rwvn = new TableRow();
                        rwvn.Width = Unit.Percentage(100);
                        rwvn.BorderWidth = 1;
                        rwvn.BorderColor = System.Drawing.Color.SlateGray;
                        rwvn.ForeColor = System.Drawing.Color.SlateGray;
                        TableCell tcellnv0 = new TableCell();
                        tcellnv0.Text = cl.ds.Tables[0].Rows[j]["name"].ToString();//Name
                        tcellnv0.BorderWidth = 1;
                        tcellnv0.BorderColor = System.Drawing.Color.SlateGray;
                        tcellnv0.ForeColor = System.Drawing.Color.Maroon;
                        rwvn.Cells.Add(tcellnv0);

                        TableCell tcellnv1 = new TableCell();
                        tcellnv1.Text = cl.ds.Tables[0].Rows[j]["plino"].ToString();//Pli No
                        tcellnv1.BorderWidth = 1;
                        tcellnv1.BorderColor = System.Drawing.Color.SlateGray;
                        rwvn.Cells.Add(tcellnv1);

                        TableCell tcellnv2 = new TableCell();
                        tcellnv2.Text = cl.ds.Tables[0].Rows[j]["perpay"].ToString();//Per. Pay
                        tcellnv2.BorderWidth = 1;
                        tcellnv2.BorderColor = System.Drawing.Color.SlateGray;
                        rwvn.Cells.Add(tcellnv2);

                        TableCell tcellnv3 = new TableCell();
                        tcellnv3.Text = cl.ds.Tables[0].Rows[j]["othall1"].ToString();//Oth Allw1//transport allow
                        tcellnv3.BorderWidth = 1;
                        tcellnv3.BorderColor = System.Drawing.Color.SlateGray;
                        rwvn.Cells.Add(tcellnv3);

                        TableCell tcellnv4 = new TableCell();
                        tcellnv4.Text = cl.ds.Tables[0].Rows[j]["npaall"].ToString();//NPA
                        tcellnv4.BorderWidth = 1;
                        tcellnv4.BorderColor = System.Drawing.Color.SlateGray;
                        rwvn.Cells.Add(tcellnv4);

                        TableCell tcellnv5 = new TableCell();
                        tcellnv5.Text = cl.ds.Tables[0].Rows[j]["othall4"].ToString();//Oth Allw4
                        tcellnv5.BorderWidth = 1;
                        tcellnv5.BorderColor = System.Drawing.Color.SlateGray;
                        rwvn.Cells.Add(tcellnv5);

                        TableCell tcellnv6 = new TableCell();
                        tcellnv6.Text = cl.ds.Tables[0].Rows[j]["dearnesspay"].ToString();//Dear.Pay
                        tcellnv6.BorderWidth = 1;
                        tcellnv6.BorderColor = System.Drawing.Color.SlateGray;
                        rwvn.Cells.Add(tcellnv6);

                        TableCell tcellnv7 = new TableCell();
                        tcellnv7.Text = cl.ds.Tables[0].Rows[j]["fixall3"].ToString();//Fixed All.3
                        tcellnv7.BorderWidth = 1;
                        tcellnv7.BorderColor = System.Drawing.Color.SlateGray;
                        rwvn.Cells.Add(tcellnv7);


                        TableCell tcellnv8 = new TableCell();
                        tcellnv8.Text = " ";
                        tcellnv8.BorderWidth = 1;
                        tcellnv8.BorderColor = System.Drawing.Color.SlateGray;
                        tcellnv8.ForeColor = System.Drawing.Color.Black;
                        rwvn.Cells.Add(tcellnv8);



                        TableCell tcellnv9 = new TableCell();
                        tcellnv9.Text = cl.ds.Tables[0].Rows[j]["GpfA"].ToString();//GpfA
                        tcellnv9.BorderWidth = 1;
                        tcellnv9.BorderColor = System.Drawing.Color.SlateGray;
                        rwvn.Cells.Add(tcellnv9);





                        TableCell tcellnv10 = new TableCell();
                        tcellnv10.Text = cl.ds.Tables[0].Rows[j]["hrr"].ToString();//Hrr
                        tcellnv10.BorderWidth = 1;
                        tcellnv10.BorderColor = System.Drawing.Color.SlateGray;
                        rwvn.Cells.Add(tcellnv10);

                        TableCell tcellnv11 = new TableCell();
                        tcellnv11.Text = cl.ds.Tables[0].Rows[j]["hba2inst"].ToString();//Hba2
                        tcellnv11.BorderWidth = 1;
                        tcellnv11.BorderColor = System.Drawing.Color.SlateGray;
                        rwvn.Cells.Add(tcellnv11);

                        TableCell tcellnv12 = new TableCell();
                        tcellnv12.Text = cl.ds.Tables[0].Rows[j]["hba2iinst"].ToString();//Hba2 Int.
                        tcellnv12.BorderWidth = 1;
                        tcellnv12.BorderColor = System.Drawing.Color.SlateGray;
                        rwvn.Cells.Add(tcellnv12);

                        TableCell tcellnv13 = new TableCell();
                        tcellnv13.Text = cl.ds.Tables[0].Rows[j]["gisi"].ToString();//Gis. I.F.
                        tcellnv13.BorderWidth = 1;
                        tcellnv13.BorderColor = System.Drawing.Color.SlateGray;
                        rwvn.Cells.Add(tcellnv13);

                        TableCell tcellnv14 = new TableCell();
                        //---tcellnv14.Text = cl.ds.Tables[0].Rows[j]["Licrd"].ToString();//Mis. Ded1
                        tcellnv14.Text = cl.ds.Tables[0].Rows[j]["pranr"].ToString();//Mis. Ded1
                        tcellnv14.BorderWidth = 1;
                        tcellnv14.BorderColor = System.Drawing.Color.SlateGray;
                        rwvn.Cells.Add(tcellnv14);

                        TableCell tcellnv15 = new TableCell();
                        //tcellnv15.Text = "";
                        tcellnv15.Text = Convert.ToString(Convert.ToDouble(cl.ds.Tables[0].Rows[j]["gpf"].ToString()) +
                            Convert.ToDouble(cl.ds.Tables[0].Rows[j]["gpfiv"].ToString()) +
                            Convert.ToDouble(cl.ds.Tables[0].Rows[j]["gpf4adv"].ToString()) +
                            Convert.ToDouble(cl.ds.Tables[0].Rows[j]["gvr"].ToString()) +
                            Convert.ToDouble(cl.ds.Tables[0].Rows[j]["hba1inst"].ToString()) +
                            Convert.ToDouble(cl.ds.Tables[0].Rows[j]["hba1iinst"].ToString()) +
                            Convert.ToDouble(cl.ds.Tables[0].Rows[j]["pli"].ToString()) +
                            Convert.ToDouble(cl.ds.Tables[0].Rows[j]["elecbill"].ToString()) +
                            Convert.ToDouble(cl.ds.Tables[0].Rows[j]["incometax"].ToString()) +
                            Convert.ToDouble(cl.ds.Tables[0].Rows[j]["GpfA"].ToString()) +
                            Convert.ToDouble(cl.ds.Tables[0].Rows[j]["hrr"].ToString()) +
                            Convert.ToDouble(cl.ds.Tables[0].Rows[j]["hba2inst"].ToString()) +
                            Convert.ToDouble(cl.ds.Tables[0].Rows[j]["hba2iinst"].ToString()) +
                            Convert.ToDouble(cl.ds.Tables[0].Rows[j]["gisi"].ToString()) +
                            Convert.ToDouble(cl.ds.Tables[0].Rows[j]["ded1"].ToString()) +
                            Convert.ToDouble(cl.ds.Tables[0].Rows[j]["Licrd"].ToString()) +
                            Convert.ToDouble(cl.ds.Tables[0].Rows[j]["vehinst"].ToString()) +
                            Convert.ToDouble(cl.ds.Tables[0].Rows[j]["hba3inst"].ToString()) +
                            Convert.ToDouble(cl.ds.Tables[0].Rows[j]["hba3iinst"].ToString()) +
                            Convert.ToDouble(cl.ds.Tables[0].Rows[j]["giss"].ToString()) +
                            Convert.ToDouble(cl.ds.Tables[0].Rows[j]["ded2"].ToString()) +
                            Convert.ToDouble(cl.ds.Tables[0].Rows[j]["vehiinst"].ToString()) +
                            Convert.ToDouble(cl.ds.Tables[0].Rows[j]["corinst"].ToString()) +
                            Convert.ToDouble(cl.ds.Tables[0].Rows[j]["coriinst"].ToString()) +
                            Convert.ToDouble(cl.ds.Tables[0].Rows[j]["ded3"].ToString()));

                        //tcellnv15.Text = cl.ds.Tables[0].Rows[j]["Lic"].ToString();//Lic/Rd 
                        tcellnv15.BorderWidth = 1;
                        tcellnv15.BorderColor = System.Drawing.Color.SlateGray;
                        tcellnv15.ForeColor = System.Drawing.Color.Black;
                        rwvn.Cells.Add(tcellnv15);

                        TableCell tcellnv16 = new TableCell();
                        tcellnv16.Text = cl.ds.Tables[0].Rows[j]["Lic"].ToString();//Lic/Rd 
                        tcellnv16.BorderWidth = 1;
                        tcellnv16.BorderColor = System.Drawing.Color.SlateGray;
                        rwvn.Cells.Add(tcellnv16);
                        Table1.Rows.Add(rwvn);
                        ////////////////////////////////////
                        TableRow rwnev = new TableRow();///............................3rd Line....................................
                        rwnev.Width = Unit.Percentage(100);
                        rwnev.BorderWidth = 1;
                        rwnev.BorderColor = System.Drawing.Color.SlateGray;
                        rwnev.ForeColor = System.Drawing.Color.SlateGray;

                        TableCell tcellnev0 = new TableCell();
                        tcellnev0.Text = cl.ds.Tables[0].Rows[j]["post"].ToString();//Designation
                        tcellnev0.BorderWidth = 1;
                        tcellnev0.BorderColor = System.Drawing.Color.SlateGray;
                        tcellnev0.ForeColor = System.Drawing.Color.Black;
                        rwnev.Cells.Add(tcellnev0);

                        TableCell tcellnev1 = new TableCell();
                        tcellnev1.Text = " ";
                        tcellnev1.BorderWidth = 1;
                        tcellnev1.BorderColor = System.Drawing.Color.SlateGray;
                        rwnev.Cells.Add(tcellnev1);

                        TableCell tcellnev2 = new TableCell();
                        tcellnev2.Text = cl.ds.Tables[0].Rows[j]["sppay"].ToString();//Spl.Pay
                        tcellnev2.BorderWidth = 1;
                        tcellnev2.BorderColor = System.Drawing.Color.SlateGray;
                        rwnev.Cells.Add(tcellnev2);

                        TableCell tcellnev3 = new TableCell();
                        tcellnev3.Text = cl.ds.Tables[0].Rows[j]["othall2"].ToString();//Oth Allw2
                        tcellnev3.BorderWidth = 1;
                        tcellnev3.BorderColor = System.Drawing.Color.SlateGray;
                        rwnev.Cells.Add(tcellnev3);

                        TableCell tcellnev4 = new TableCell();
                        tcellnev4.Text = cl.ds.Tables[0].Rows[j]["salarrear"].ToString();//Sal Arr
                        tcellnev4.BorderWidth = 1;
                        tcellnev4.BorderColor = System.Drawing.Color.SlateGray;
                        rwnev.Cells.Add(tcellnev4);

                        TableCell tcellnev5 = new TableCell();
                        tcellnev5.Text = cl.ds.Tables[0].Rows[j]["hill"].ToString();//Hill Allw
                        tcellnev5.BorderWidth = 1;
                        tcellnev5.BorderColor = System.Drawing.Color.SlateGray;
                        rwnev.Cells.Add(tcellnev5);

                        TableCell tcellnev6 = new TableCell();
                        tcellnev6.Text = cl.ds.Tables[0].Rows[j]["pensionpay"].ToString();//Pen.Pay
                        tcellnev6.BorderWidth = 1;
                        tcellnev6.BorderColor = System.Drawing.Color.SlateGray;
                        rwnev.Cells.Add(tcellnev6);

                        TableCell tcellnev7 = new TableCell();
                        tcellnev7.Text = cl.ds.Tables[0].Rows[j]["salded"].ToString();//Sal Ded************************
                        tcellnev7.BorderWidth = 1;
                        tcellnev7.BorderColor = System.Drawing.Color.SlateGray;
                        rwnev.Cells.Add(tcellnev7);


                        TableCell tcellnev8 = new TableCell();
                        tcellnev8.Text = " ";
                        tcellnev8.BorderWidth = 1;
                        tcellnev8.BorderColor = System.Drawing.Color.SlateGray;
                        tcellnev8.ForeColor = System.Drawing.Color.Black;
                        rwnev.Cells.Add(tcellnev8);


                        TableCell tcellnev9 = new TableCell();
                        tcellnev9.Text = cl.ds.Tables[0].Rows[j]["gpfiv"].ToString();//Gpf IV
                        tcellnev9.BorderWidth = 1;
                        tcellnev9.BorderColor = System.Drawing.Color.SlateGray;
                        rwnev.Cells.Add(tcellnev9);


                        TableCell tcellnev10 = new TableCell();//Veh. adv.
                        tcellnev10.Text = cl.ds.Tables[0].Rows[j]["vehinst"].ToString();
                        tcellnev10.BorderWidth = 1;
                        tcellnev10.BorderColor = System.Drawing.Color.SlateGray;
                        rwnev.Cells.Add(tcellnev10);

                        TableCell tcellnev11 = new TableCell();//Hba3
                        tcellnev11.Text = cl.ds.Tables[0].Rows[j]["hba3inst"].ToString();
                        tcellnev11.BorderWidth = 1;
                        tcellnev11.BorderColor = System.Drawing.Color.SlateGray;
                        rwnev.Cells.Add(tcellnev11);

                        TableCell tcellnev12 = new TableCell();//Hba3 Int.
                        tcellnev12.Text = cl.ds.Tables[0].Rows[j]["hba3iinst"].ToString();
                        tcellnev12.BorderWidth = 1;
                        tcellnev12.BorderColor = System.Drawing.Color.SlateGray;
                        rwnev.Cells.Add(tcellnev12);

                        TableCell tcellnev13 = new TableCell();//Gis. S.F
                        tcellnev13.Text = cl.ds.Tables[0].Rows[j]["giss"].ToString();
                        tcellnev13.BorderWidth = 1;
                        tcellnev13.BorderColor = System.Drawing.Color.SlateGray;
                        rwnev.Cells.Add(tcellnev13);

                        TableCell tcellnev14 = new TableCell();//Mis. Ded2
                        tcellnev14.Text = cl.ds.Tables[0].Rows[j]["ded2"].ToString();
                        tcellnev14.BorderWidth = 1;
                        tcellnev14.BorderColor = System.Drawing.Color.SlateGray;
                        rwnev.Cells.Add(tcellnev14);

                        TableCell tcellnev15 = new TableCell();
                        //tcellnev15.Text = ""; 
                        //tcellnev15.Text = cl.ds.Tables[0].Rows[j]["elecbill"].ToString(); 
                        tcellnev15.Text = Convert.ToString(Convert.ToDouble(tcellv8.Text) - Convert.ToDouble(tcellnv15.Text));
                        tcellnev15.BorderWidth = 1;
                        tcellnev15.ForeColor = System.Drawing.Color.Black;
                        tcellnev15.BorderColor = System.Drawing.Color.SlateGray;
                        rwnev.Cells.Add(tcellnev15);

                        TableCell tcellnev16 = new TableCell();
                        //tcellnev16.Text = "Net Pay";
                        tcellnev16.Text = Convert.ToString(Convert.ToDouble(tcellnev15.Text) - (Convert.ToDouble(tcellnv16.Text) + Convert.ToDouble(tcellv16.Text) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["rdded"].ToString())));

                        //tcellnev16.Text = "";
                        tcellnev16.BorderWidth = 1;
                        tcellnev16.BorderColor = System.Drawing.Color.SlateGray;
                        tcellnev16.ForeColor = System.Drawing.Color.Black;
                        rwnev.Cells.Add(tcellnev16);
                        Table1.Rows.Add(rwnev);
                        ///////////////////////////////////
                        TableRow rwnewv = new TableRow();//..................................4th Line............................................
                        rwnewv.Width = Unit.Percentage(100);
                        rwnewv.BorderWidth = 1;
                        rwnewv.BorderColor = System.Drawing.Color.SlateGray;
                        rwnewv.ForeColor = System.Drawing.Color.SlateGray;

                        TableCell tcellnewv0 = new TableCell();//Attendance
                        tcellnewv0.Text = cl.ds.Tables[0].Rows[j]["attendance"].ToString();
                        tcellnewv0.BorderWidth = 1;
                        tcellnewv0.BorderColor = System.Drawing.Color.SlateGray;
                        rwnewv.Cells.Add(tcellnewv0);


                        TableCell tcellnewv1 = new TableCell();
                        tcellnewv1.Text = cl.ds.Tables[0].Rows[j]["basicpay"].ToString(); // "Basic";
                        tcellnewv1.BorderWidth = 1;
                        tcellnewv1.BorderColor = System.Drawing.Color.SlateGray;
                        rwnewv.Cells.Add(tcellnewv1);


                        TableCell tcellnewv2 = new TableCell();
                        tcellnewv2.Text = Convert.ToString(Convert.ToDouble(cl.ds.Tables[0].Rows[j]["basicpay"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["Gradepay"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["perpay"].ToString()) + Convert.ToDouble(cl.ds.Tables[0].Rows[j]["sppay"].ToString())); // "Pay";
                        tcellnewv2.BorderWidth = 1;
                        tcellnewv2.BorderColor = System.Drawing.Color.SlateGray;
                        rwnewv.Cells.Add(tcellnewv2);

                        TableCell tcellnewv3 = new TableCell();//Oth Allw3
                        tcellnewv3.Text = cl.ds.Tables[0].Rows[j]["othall3"].ToString();
                        tcellnewv3.BorderWidth = 1;
                        tcellnewv3.BorderColor = System.Drawing.Color.SlateGray;
                        rwnewv.Cells.Add(tcellnewv3);

                        TableCell tcellnewv4 = new TableCell();//
                        tcellnewv4.Text = cl.ds.Tables[0].Rows[j]["otharrear"].ToString();
                        tcellnewv4.BorderWidth = 1;
                        tcellnewv4.BorderColor = System.Drawing.Color.SlateGray;
                        rwnewv.Cells.Add(tcellnewv4);

                        TableCell tcellnewv5 = new TableCell();//Oth Arr
                        tcellnewv5.Text = cl.ds.Tables[0].Rows[j]["othall5"].ToString();
                        tcellnewv5.BorderWidth = 1;
                        tcellnewv5.BorderColor = System.Drawing.Color.SlateGray;
                        rwnewv.Cells.Add(tcellnewv5);

                        TableCell tcellnewv6 = new TableCell();//Oth Allw5
                        tcellnewv6.Text = cl.ds.Tables[0].Rows[j]["fixall1"].ToString();
                        tcellnewv6.BorderWidth = 1;
                        tcellnewv6.BorderColor = System.Drawing.Color.SlateGray;
                        rwnewv.Cells.Add(tcellnewv6);

                        TableCell tcellnewv7 = new TableCell();
                        tcellnewv7.Text = " ";
                        tcellnewv7.BorderWidth = 1;
                        tcellnewv7.BorderColor = System.Drawing.Color.SlateGray;
                        rwnewv.Cells.Add(tcellnewv7);

                        TableCell tcellnewv8 = new TableCell();
                        tcellnewv8.Text = " ";
                        tcellnewv8.BorderWidth = 1;
                        tcellnewv8.BorderColor = System.Drawing.Color.SlateGray;
                        tcellnewv8.ForeColor = System.Drawing.Color.Black;
                        rwnewv.Cells.Add(tcellnewv8);


                        TableCell tcellnewv9 = new TableCell();
                        tcellnewv9.Text = cl.ds.Tables[0].Rows[j]["gpf4adv"].ToString();
                        tcellnewv9.BorderWidth = 1;
                        tcellnewv9.BorderColor = System.Drawing.Color.SlateGray;
                        rwnewv.Cells.Add(tcellnewv9);


                        TableCell tcellnewv10 = new TableCell();
                        tcellnewv10.Text = cl.ds.Tables[0].Rows[j]["vehiinst"].ToString();
                        tcellnewv10.BorderWidth = 1;
                        tcellnewv10.BorderColor = System.Drawing.Color.SlateGray;
                        rwnewv.Cells.Add(tcellnewv10);

                        TableCell tcellnewv11 = new TableCell();
                        tcellnewv11.Text = cl.ds.Tables[0].Rows[j]["corinst"].ToString();
                        tcellnewv11.BorderWidth = 1;
                        tcellnewv11.BorderColor = System.Drawing.Color.SlateGray;
                        rwnewv.Cells.Add(tcellnewv11);

                        TableCell tcellnewv12 = new TableCell();
                        tcellnewv12.Text = cl.ds.Tables[0].Rows[j]["coriinst"].ToString();
                        tcellnewv12.BorderWidth = 1;
                        tcellnewv12.BorderColor = System.Drawing.Color.SlateGray;
                        rwnewv.Cells.Add(tcellnewv12);

                        TableCell tcellnewv13 = new TableCell();// "Gis Total";
                        tcellnewv13.Text = Convert.ToString(Convert.ToDouble(cl.ds.Tables[0].Rows[j]["gisi"].ToString()) +
                            Convert.ToDouble(cl.ds.Tables[0].Rows[j]["giss"].ToString()));
                        tcellnewv13.ForeColor = System.Drawing.Color.SlateGray;
                        tcellnewv13.BorderWidth = 1;
                        tcellnewv13.BorderColor = System.Drawing.Color.SlateGray;
                        rwnewv.Cells.Add(tcellnewv13);

                        TableCell tcellnewv14 = new TableCell();
                        tcellnewv14.Text = cl.ds.Tables[0].Rows[j]["ded3"].ToString();
                        tcellnewv14.BorderWidth = 1;
                        tcellnewv14.BorderColor = System.Drawing.Color.SlateGray;
                        rwnewv.Cells.Add(tcellnewv14);

                        TableCell tcellnewv15 = new TableCell();//remarks
                        tcellnewv15.Text = cl.ds.Tables[0].Rows[j]["rdded"].ToString();
                        //tcellnewv15.Text = cl.ds.Tables[0].Rows[j]["remarks"].ToString();
                        tcellnewv15.BorderWidth = 1;
                        tcellnewv15.BorderColor = System.Drawing.Color.SlateGray;
                        rwnewv.Cells.Add(tcellnewv15);

                        TableCell tcellnewv16 = new TableCell();
                        //tcellnewv16.Text = cl.ds.Tables[0].Rows[j]["remarks"].ToString();
                        tcellnewv16.Text = cl.ds.Tables[0].Rows[j]["monthr"].ToString();

                        tcellnewv16.BorderWidth = 1;
                        tcellnewv16.BorderColor = System.Drawing.Color.SlateGray;
                        rwnewv.Cells.Add(tcellnewv16);
                        Table1.Rows.Add(rwnewv);

                        TableRow rwvX = new TableRow();
                        //rwvX.Width = Unit.Percentage(100);
                        rwvX.BorderWidth = 1;
                        rwvX.BorderColor = System.Drawing.Color.SlateGray;
                        TableCell tcellxv2 = new TableCell();


                        TableCell tcellnewv151 = new TableCell();//remarks

                        tcellnewv151.Text = "";
                        tcellnewv151.BorderWidth = 1;
                        tcellnewv151.BorderColor = System.Drawing.Color.SlateGray;
                        rwvX.Cells.Add(tcellnewv151);


                        TableCell tcellnewv152 = new TableCell();//remarks
                        tcellnewv152.Text = cl.ds.Tables[0].Rows[j]["note"].ToString();
                        tcellnewv152.Attributes.Add("colspan", "17");
                        tcellnewv152.Width = Unit.Percentage(100);
                        //tcellnewv152 = System.Drawing.FontStyle.Italic;
                        tcellnewv152.Font.Italic = true;
                        tcellnewv152.Font.Name = "Comic Sans MS";
                        tcellnewv152.ForeColor = System.Drawing.Color.SlateGray;
                        tcellnewv152.BorderColor = System.Drawing.Color.SlateGray;
                        rwvX.Cells.Add(tcellnewv152);


                        tcellxv2.Text = "<Br>";
                        rwvX.Cells.Add(tcellxv2);
                        Table1.Rows.Add(rwvX);
                        sec = cl.ds.Tables[0].Rows[j][57].ToString();
                    }
                    MSGLab.ForeColor = System.Drawing.Color.SlateGray;
                    MSGLab.Text = "";
                }
                else
                {
                    MSGLab.ForeColor = System.Drawing.Color.DarkRed;
                    MSGLab.Text = "No Record found....";//copy this text
                }
            }
            catch (Exception ex)
            {
                MSGLab.Text = ex.Message;
                //MSGLab.Text = finalqr;
            }
            finally { }
            sumsalary();
        }

        public void payheader()
        {
            TableRow rw = new TableRow();
            rw.Width = Unit.Percentage(100);
            rw.BorderWidth = 1;
            rw.BorderColor = System.Drawing.Color.SlateGray;

            TableCell tcell0 = new TableCell();
            tcell0.Text = "Sr.No./Comp.Id";
            tcell0.BorderWidth = 1;
            tcell0.BorderColor = System.Drawing.Color.SlateGray;
            tcell0.ForeColor = System.Drawing.Color.Maroon;
            rw.Cells.Add(tcell0);

            TableCell tcell1 = new TableCell();
            tcell1.Text = "Gpf No";
            tcell1.BorderWidth = 1;
            tcell1.BorderColor = System.Drawing.Color.SlateGray;
            tcell1.ForeColor = System.Drawing.Color.Maroon;
            rw.Cells.Add(tcell1);

            //TableCell tcell2 = new TableCell();
            //tcell2.Text = "Basic Pay";
            //tcell2.BorderWidth = 1;
            //tcell2.BorderColor = System.Drawing.Color.SlateGray;
            //rw.Cells.Add(tcell2);
            TableCell tcell2 = new TableCell();
            tcell2.Text = "GradePay";
            tcell2.BorderWidth = 1;
            tcell2.BorderColor = System.Drawing.Color.SlateGray;
            tcell2.ForeColor = System.Drawing.Color.Maroon;
            rw.Cells.Add(tcell2);

            TableCell tcell3 = new TableCell();
            tcell3.Text = "DA";
            tcell3.BorderWidth = 1;
            tcell3.BorderColor = System.Drawing.Color.SlateGray;
            tcell3.ForeColor = System.Drawing.Color.Maroon;
            rw.Cells.Add(tcell3);

            TableCell tcell4 = new TableCell();
            tcell4.Text = "Hra";
            tcell4.BorderWidth = 1;
            tcell4.BorderColor = System.Drawing.Color.SlateGray;
            tcell4.ForeColor = System.Drawing.Color.Maroon;
            rw.Cells.Add(tcell4);

            TableCell tcell5 = new TableCell();
            tcell5.Text = "CCA";
            tcell5.BorderWidth = 1;
            tcell5.BorderColor = System.Drawing.Color.SlateGray;
            tcell5.ForeColor = System.Drawing.Color.Maroon;
            rw.Cells.Add(tcell5);

            TableCell tcell6 = new TableCell();
            tcell6.Text = "Oth All6";
            tcell6.BorderWidth = 1;
            tcell6.BorderColor = System.Drawing.Color.SlateGray;
            tcell6.ForeColor = System.Drawing.Color.Maroon;
            rw.Cells.Add(tcell6);

            TableCell tcell7 = new TableCell();
            tcell7.Text = "Fixed All.2";
            tcell7.BorderWidth = 1;
            tcell7.BorderColor = System.Drawing.Color.SlateGray;
            tcell7.ForeColor = System.Drawing.Color.Maroon;
            rw.Cells.Add(tcell7);


            TableCell tcell8 = new TableCell();
            tcell8.Text = "Gross Pay";
            tcell8.BorderWidth = 1;
            tcell8.BorderColor = System.Drawing.Color.SlateGray;
            tcell8.ForeColor = System.Drawing.Color.Maroon;
            // tcell8.ForeColor = System.Drawing.Color.Black;
            rw.Cells.Add(tcell8);

            TableCell tcell9 = new TableCell();
            tcell9.Text = "GPF/Pran";
            tcell9.BorderWidth = 1;
            tcell9.BorderColor = System.Drawing.Color.SlateGray;
            tcell9.ForeColor = System.Drawing.Color.Maroon;
            rw.Cells.Add(tcell9);

            TableCell tcell10 = new TableCell();
            tcell10.Text = "Gvr";
            tcell10.BorderWidth = 1;
            tcell10.BorderColor = System.Drawing.Color.SlateGray;
            tcell10.ForeColor = System.Drawing.Color.Maroon;
            rw.Cells.Add(tcell10);

            TableCell tcell11 = new TableCell();
            tcell11.Text = "Hba";
            tcell11.BorderWidth = 1;
            tcell11.BorderColor = System.Drawing.Color.SlateGray;
            tcell11.ForeColor = System.Drawing.Color.Maroon;
            rw.Cells.Add(tcell11);

            TableCell tcell12 = new TableCell();
            tcell12.Text = "Hba Int.";
            tcell12.BorderWidth = 1;
            tcell12.BorderColor = System.Drawing.Color.SlateGray;
            tcell12.ForeColor = System.Drawing.Color.Maroon;
            rw.Cells.Add(tcell12);

            TableCell tcell13 = new TableCell();
            tcell13.Text = "Pli";
            tcell13.BorderWidth = 1;
            tcell13.BorderColor = System.Drawing.Color.SlateGray;
            tcell13.ForeColor = System.Drawing.Color.Maroon;
            rw.Cells.Add(tcell13);

            TableCell tcell14 = new TableCell();
            tcell14.Text = "I. Tax";
            tcell14.BorderWidth = 1;
            tcell14.BorderColor = System.Drawing.Color.SlateGray;
            tcell14.ForeColor = System.Drawing.Color.Maroon;
            rw.Cells.Add(tcell14);

            TableCell tcell15 = new TableCell();//socded................total ded
            tcell15.Text = "Ebill";
            tcell15.BorderWidth = 1;
            tcell15.BorderColor = System.Drawing.Color.SlateGray;
            tcell15.ForeColor = System.Drawing.Color.Maroon;
            rw.Cells.Add(tcell15);

            TableCell tcell16 = new TableCell();//total................socded
            tcell16.Text = "Soc Ded";
            tcell16.BorderWidth = 1;
            tcell16.BorderColor = System.Drawing.Color.SlateGray;
            tcell16.ForeColor = System.Drawing.Color.Maroon;
            rw.Cells.Add(tcell16);
            Table1.Rows.Add(rw);
            ////////////////////////////////////
            TableRow rwn = new TableRow();
            rwn.Width = Unit.Percentage(100);
            rwn.BorderWidth = 1;
            rwn.BorderColor = System.Drawing.Color.SlateGray;

            TableCell tcelln0 = new TableCell();
            tcelln0.Text = "Name";
            tcelln0.BorderWidth = 1;
            tcelln0.BorderColor = System.Drawing.Color.SlateGray;
            tcelln0.ForeColor = System.Drawing.Color.Maroon;
            //tcelln0.ForeColor = System.Drawing.Color.Black;
            rwn.Cells.Add(tcelln0);

            TableCell tcelln1 = new TableCell();
            tcelln1.Text = "Pli No";
            tcelln1.BorderWidth = 1;
            tcelln1.BorderColor = System.Drawing.Color.SlateGray;
            tcelln1.ForeColor = System.Drawing.Color.Maroon;
            rwn.Cells.Add(tcelln1);

            TableCell tcelln2 = new TableCell();
            tcelln2.Text = "Per. Pay";
            tcelln2.BorderWidth = 1;
            tcelln2.BorderColor = System.Drawing.Color.SlateGray;
            tcelln2.ForeColor = System.Drawing.Color.Maroon;
            rwn.Cells.Add(tcelln2);

            TableCell tcelln3 = new TableCell();
            tcelln3.Text = "Oth Allw1";
            tcelln3.BorderWidth = 1;
            tcelln3.BorderColor = System.Drawing.Color.SlateGray;
            tcelln3.ForeColor = System.Drawing.Color.Maroon;
            rwn.Cells.Add(tcelln3);

            TableCell tcelln4 = new TableCell();
            tcelln4.Text = "NPA";
            tcelln4.BorderWidth = 1;
            tcelln4.BorderColor = System.Drawing.Color.SlateGray;
            tcelln4.ForeColor = System.Drawing.Color.Maroon;
            rwn.Cells.Add(tcelln4);

            TableCell tcelln5 = new TableCell();
            tcelln5.Text = "Oth Allw4";
            tcelln5.BorderWidth = 1;
            tcelln5.BorderColor = System.Drawing.Color.SlateGray;
            tcelln5.ForeColor = System.Drawing.Color.Maroon;
            rwn.Cells.Add(tcelln5);

            TableCell tcelln6 = new TableCell();
            tcelln6.Text = "Dear.Pay";
            tcelln6.BorderWidth = 1;
            tcelln6.BorderColor = System.Drawing.Color.SlateGray;
            tcelln6.ForeColor = System.Drawing.Color.Maroon;
            rwn.Cells.Add(tcelln6);

            TableCell tcelln7 = new TableCell();
            tcelln7.Text = "Fixed All.3";
            tcelln7.BorderWidth = 1;
            tcelln7.BorderColor = System.Drawing.Color.SlateGray;
            tcelln7.ForeColor = System.Drawing.Color.Maroon;
            rwn.Cells.Add(tcelln7);


            TableCell tcelln8 = new TableCell();
            tcelln8.Text = " ";
            tcelln8.BorderWidth = 1;
            tcelln8.BorderColor = System.Drawing.Color.SlateGray;
            tcelln8.ForeColor = System.Drawing.Color.Maroon;
            //tcelln8.ForeColor = System.Drawing.Color.Black;
            rwn.Cells.Add(tcelln8);

            TableCell tcelln9 = new TableCell();
            tcelln9.Text = "GpfA/PranA";
            tcelln9.BorderWidth = 1;
            tcelln9.BorderColor = System.Drawing.Color.SlateGray;
            tcelln9.ForeColor = System.Drawing.Color.Maroon;
            rwn.Cells.Add(tcelln9);

            TableCell tcelln10 = new TableCell();
            tcelln10.Text = "HRR";
            tcelln10.BorderWidth = 1;
            tcelln10.BorderColor = System.Drawing.Color.SlateGray;
            tcelln10.ForeColor = System.Drawing.Color.Maroon;
            rwn.Cells.Add(tcelln10);

            TableCell tcelln11 = new TableCell();
            tcelln11.Text = "Hba2";
            tcelln11.BorderWidth = 1;
            tcelln11.BorderColor = System.Drawing.Color.SlateGray;
            tcelln11.ForeColor = System.Drawing.Color.Maroon;
            rwn.Cells.Add(tcelln11);

            TableCell tcelln12 = new TableCell();
            tcelln12.Text = "Hba2 Int.";
            tcelln12.BorderWidth = 1;
            tcelln12.BorderColor = System.Drawing.Color.SlateGray;
            tcelln12.ForeColor = System.Drawing.Color.Maroon;
            rwn.Cells.Add(tcelln12);

            TableCell tcelln13 = new TableCell();
            tcelln13.Text = "Gis. I.F.";
            tcelln13.BorderWidth = 1;
            tcelln13.BorderColor = System.Drawing.Color.SlateGray;
            tcelln13.ForeColor = System.Drawing.Color.Maroon;
            rwn.Cells.Add(tcelln13);

            TableCell tcelln14 = new TableCell();
            tcelln14.Text = "Mis. Ded1";
            tcelln14.BorderWidth = 1;
            tcelln14.BorderColor = System.Drawing.Color.SlateGray;
            tcelln14.ForeColor = System.Drawing.Color.Maroon;
            rwn.Cells.Add(tcelln14);

            TableCell tcelln15 = new TableCell();///////Lic/Rd..........""
            tcelln15.Text = "TotalDed";
            tcelln15.BorderWidth = 1;
            tcelln15.BorderColor = System.Drawing.Color.SlateGray;
            tcelln15.ForeColor = System.Drawing.Color.Maroon;
            rwn.Cells.Add(tcelln15);

            TableCell tcelln16 = new TableCell();
            tcelln16.Text = "Lic/Rd ";
            tcelln16.BorderWidth = 1;
            tcelln16.BorderColor = System.Drawing.Color.SlateGray;
            tcelln16.ForeColor = System.Drawing.Color.Maroon;
            rwn.Cells.Add(tcelln16);
            Table1.Rows.Add(rwn);

            ////////////////////////////////////
            TableRow rwne = new TableRow();
            rwne.Width = Unit.Percentage(100);
            rwne.BorderWidth = 1;
            rwne.BorderColor = System.Drawing.Color.SlateGray;
            //tcell0.ForeColor = System.Drawing.Color.Maroon;

            TableCell tcellne0 = new TableCell();
            tcellne0.Text = "Designation";
            tcellne0.BorderWidth = 1;
            tcellne0.BorderColor = System.Drawing.Color.SlateGray;
            tcellne0.ForeColor = System.Drawing.Color.Maroon;
            // tcellne0.ForeColor = System.Drawing.Color.Black;
            rwne.Cells.Add(tcellne0);

            TableCell tcellne1 = new TableCell();
            tcellne1.Text = " ";
            tcellne1.BorderWidth = 1;
            tcellne1.BorderColor = System.Drawing.Color.SlateGray;
            tcellne1.ForeColor = System.Drawing.Color.Maroon;
            rwne.Cells.Add(tcellne1);

            TableCell tcellne2 = new TableCell();
            tcellne2.Text = "Spl.Pay";
            tcellne2.BorderWidth = 1;
            tcellne2.BorderColor = System.Drawing.Color.SlateGray;
            tcellne2.ForeColor = System.Drawing.Color.Maroon;
            rwne.Cells.Add(tcellne2);

            TableCell tcellne3 = new TableCell();
            tcellne3.Text = "Oth Allw2";
            tcellne3.BorderWidth = 1;
            tcellne3.BorderColor = System.Drawing.Color.SlateGray;
            tcellne3.ForeColor = System.Drawing.Color.Maroon;
            rwne.Cells.Add(tcellne3);

            TableCell tcellne4 = new TableCell();
            tcellne4.Text = "Sal Arr";
            tcellne4.BorderWidth = 1;
            tcellne4.BorderColor = System.Drawing.Color.SlateGray;
            tcellne4.ForeColor = System.Drawing.Color.Maroon;
            rwne.Cells.Add(tcellne4);

            TableCell tcellne5 = new TableCell();
            tcellne5.Text = "TrpAll";
            tcellne5.BorderWidth = 1;
            tcellne5.BorderColor = System.Drawing.Color.SlateGray;
            tcellne5.ForeColor = System.Drawing.Color.Maroon;
            rwne.Cells.Add(tcellne5);

            TableCell tcellne6 = new TableCell();
            tcellne6.Text = "Pen.Pay";
            tcellne6.BorderWidth = 1;
            tcellne6.BorderColor = System.Drawing.Color.SlateGray;
            tcellne6.ForeColor = System.Drawing.Color.Maroon;
            rwne.Cells.Add(tcellne6);

            TableCell tcellne7 = new TableCell();
            tcellne7.Text = "Sal Ded";
            tcellne7.BorderWidth = 1;
            tcellne7.BorderColor = System.Drawing.Color.SlateGray;
            tcellne7.ForeColor = System.Drawing.Color.Maroon;
            rwne.Cells.Add(tcellne7);


            TableCell tcellne8 = new TableCell();
            tcellne8.Text = " ";
            tcellne8.BorderWidth = 1;
            tcellne8.BorderColor = System.Drawing.Color.SlateGray;
            tcellne8.ForeColor = System.Drawing.Color.Maroon;
            //tcellne8.ForeColor = System.Drawing.Color.Black;
            rwne.Cells.Add(tcellne8);

            TableCell tcellne9 = new TableCell();
            tcellne9.Text = "Gpf4";
            tcellne9.BorderWidth = 1;
            tcellne9.BorderColor = System.Drawing.Color.SlateGray;
            tcellne9.ForeColor = System.Drawing.Color.Maroon;
            rwne.Cells.Add(tcellne9);

            TableCell tcellne10 = new TableCell();
            tcellne10.Text = "VehAdv";
            tcellne10.BorderWidth = 1;
            tcellne10.BorderColor = System.Drawing.Color.SlateGray;
            tcellne10.ForeColor = System.Drawing.Color.Maroon;
            rwne.Cells.Add(tcellne10);

            TableCell tcellne11 = new TableCell();
            tcellne11.Text = "Hba3";
            tcellne11.BorderWidth = 1;
            tcellne11.BorderColor = System.Drawing.Color.SlateGray;
            tcellne11.ForeColor = System.Drawing.Color.Maroon;
            rwne.Cells.Add(tcellne11);

            TableCell tcellne12 = new TableCell();
            tcellne12.Text = "Hba3 Int.";
            tcellne12.BorderWidth = 1;
            tcellne12.BorderColor = System.Drawing.Color.SlateGray;
            tcellne12.ForeColor = System.Drawing.Color.Maroon;
            rwne.Cells.Add(tcellne12);

            TableCell tcellne13 = new TableCell();
            tcellne13.Text = "Gis. S.F";
            tcellne13.BorderWidth = 1;
            tcellne13.BorderColor = System.Drawing.Color.SlateGray;
            tcellne13.ForeColor = System.Drawing.Color.Maroon;
            rwne.Cells.Add(tcellne13);

            TableCell tcellne14 = new TableCell();
            tcellne14.Text = "Mis. Ded2";
            tcellne14.BorderWidth = 1;
            tcellne14.BorderColor = System.Drawing.Color.SlateGray;
            tcellne14.ForeColor = System.Drawing.Color.Maroon;
            rwne.Cells.Add(tcellne14);

            TableCell tcellne15 = new TableCell();//Ebill......netpay
            tcellne15.Text = "PayAfterDed";
            tcellne15.BorderWidth = 1;
            tcellne15.BorderColor = System.Drawing.Color.SlateGray;
            tcellne15.ForeColor = System.Drawing.Color.Maroon;
            rwne.Cells.Add(tcellne15);

            TableCell tcellne16 = new TableCell();
            tcellne16.Text = " Net Pay ";
            tcellne16.BorderWidth = 1;
            tcellne16.BorderColor = System.Drawing.Color.SlateGray;
            tcellne16.ForeColor = System.Drawing.Color.Maroon;
            rwne.Cells.Add(tcellne16);
            Table1.Rows.Add(rwne);

            //////////////////
            TableRow rwnew = new TableRow();
            rwnew.Width = Unit.Percentage(100);
            rwnew.BorderWidth = 1;
            rwnew.BorderColor = System.Drawing.Color.SlateGray;


            TableCell tcellnew0 = new TableCell();
            tcellnew0.Text = "Attendance";
            tcellnew0.BorderWidth = 1;
            tcellnew0.BorderColor = System.Drawing.Color.SlateGray;
            tcellnew0.ForeColor = System.Drawing.Color.Maroon;
            //  tcellnew0.ForeColor = System.Drawing.Color.Black;
            rwnew.Cells.Add(tcellnew0);

            TableCell tcellnew1 = new TableCell();
            tcellnew1.Text = "Basic";
            tcellnew1.BorderWidth = 1;
            tcellnew1.BorderColor = System.Drawing.Color.SlateGray;
            tcellnew1.ForeColor = System.Drawing.Color.Maroon;
            rwnew.Cells.Add(tcellnew1);

            TableCell tcellnew2 = new TableCell();
            tcellnew2.Text = "Pay";
            tcellnew2.BorderWidth = 1;
            tcellnew2.BorderColor = System.Drawing.Color.SlateGray;
            tcellnew2.ForeColor = System.Drawing.Color.Maroon;
            rwnew.Cells.Add(tcellnew2);

            TableCell tcellnew3 = new TableCell();
            tcellnew3.Text = "Oth Allw3";
            tcellnew3.BorderWidth = 1;
            tcellnew3.BorderColor = System.Drawing.Color.SlateGray;
            tcellnew3.ForeColor = System.Drawing.Color.Maroon;
            rwnew.Cells.Add(tcellnew3);

            TableCell tcellnew4 = new TableCell();
            tcellnew4.Text = "Oth Arr";
            tcellnew4.BorderWidth = 1;
            tcellnew4.BorderColor = System.Drawing.Color.SlateGray;
            tcellnew4.ForeColor = System.Drawing.Color.Maroon;
            rwnew.Cells.Add(tcellnew4);

            TableCell tcellnew5 = new TableCell();
            tcellnew5.Text = "Oth Allw5";
            tcellnew5.BorderWidth = 1;
            tcellnew5.BorderColor = System.Drawing.Color.SlateGray;
            tcellnew5.ForeColor = System.Drawing.Color.Maroon;
            rwnew.Cells.Add(tcellnew5);

            TableCell tcellnew6 = new TableCell();
            tcellnew6.Text = "Fixed Allw1";
            tcellnew6.BorderWidth = 1;
            tcellnew6.BorderColor = System.Drawing.Color.SlateGray;
            tcellnew6.ForeColor = System.Drawing.Color.Maroon;
            rwnew.Cells.Add(tcellnew6);

            TableCell tcellnew7 = new TableCell();
            tcellnew7.Text = " ";
            tcellnew7.BorderWidth = 1;
            tcellnew7.BorderColor = System.Drawing.Color.SlateGray;
            tcellnew7.ForeColor = System.Drawing.Color.Maroon;
            rwnew.Cells.Add(tcellnew7);

            TableCell tcellnew8 = new TableCell();
            tcellnew8.Text = " ";
            tcellnew8.BorderWidth = 1;
            tcellnew8.BorderColor = System.Drawing.Color.SlateGray;
            tcellnew8.ForeColor = System.Drawing.Color.Maroon;
            //tcellnew8.ForeColor = System.Drawing.Color.Black;
            rwnew.Cells.Add(tcellnew8);

            TableCell tcellnew9 = new TableCell();
            tcellnew9.Text = "Gpf4A";
            tcellnew9.BorderWidth = 1;
            tcellnew9.BorderColor = System.Drawing.Color.SlateGray;
            tcellnew9.ForeColor = System.Drawing.Color.Maroon;
            rwnew.Cells.Add(tcellnew9);

            TableCell tcellnew10 = new TableCell();
            tcellnew10.Text = "VehInt";
            tcellnew10.BorderWidth = 1;
            tcellnew10.BorderColor = System.Drawing.Color.SlateGray;
            tcellnew10.ForeColor = System.Drawing.Color.Maroon;
            rwnew.Cells.Add(tcellnew10);

            TableCell tcellnew11 = new TableCell();
            tcellnew11.Text = "CarAdv";
            tcellnew11.BorderWidth = 1;
            tcellnew11.BorderColor = System.Drawing.Color.SlateGray;
            tcellnew11.ForeColor = System.Drawing.Color.Maroon;
            rwnew.Cells.Add(tcellnew11);

            TableCell tcellnew12 = new TableCell();
            tcellnew12.Text = "CarInt";
            tcellnew12.BorderWidth = 1;
            tcellnew12.BorderColor = System.Drawing.Color.SlateGray;
            tcellnew12.ForeColor = System.Drawing.Color.Maroon;
            rwnew.Cells.Add(tcellnew12);

            TableCell tcellnew13 = new TableCell();
            tcellnew13.Text = "GisTotal";
            tcellnew13.BorderWidth = 1;
            tcellnew13.BorderColor = System.Drawing.Color.SlateGray;
            tcellnew13.ForeColor = System.Drawing.Color.Maroon;
            rwnew.Cells.Add(tcellnew13);

            TableCell tcellnew14 = new TableCell();
            tcellnew14.Text = "MisDed3";
            tcellnew14.BorderWidth = 1;
            tcellnew14.BorderColor = System.Drawing.Color.SlateGray;
            tcellnew14.ForeColor = System.Drawing.Color.Maroon;
            rwnew.Cells.Add(tcellnew14);

            TableCell tcellnew15 = new TableCell();//.....Remarks.........""
            tcellnew15.Text = "RDDed";
            tcellnew15.BorderWidth = 1;
            tcellnew15.BorderColor = System.Drawing.Color.SlateGray;
            tcellnew15.ForeColor = System.Drawing.Color.Maroon;
            rwnew.Cells.Add(tcellnew15);

            TableCell tcellnew16 = new TableCell();
            tcellnew16.Text = "Remarks ";
            tcellnew16.BorderWidth = 1;
            tcellnew16.BorderColor = System.Drawing.Color.SlateGray;
            tcellnew16.ForeColor = System.Drawing.Color.Maroon;
            rwnew.Cells.Add(tcellnew16);
            Table1.Rows.Add(rwnew);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

            Response.Clear();

            Response.Buffer = true;

            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");

            Response.Charset = "";

            Response.ContentType = "application/vnd.ms-excel";

            StringWriter sw = new StringWriter();

            HtmlTextWriter hw = new HtmlTextWriter(sw);

            salary();

            Table1.RenderControl(hw);



            //style to format numbers to string

            string style = @"<style> .textmode { mso-number-format:\@; } </style>";

            Response.Write(style);

            Response.Output.Write(sw.ToString());

            Response.Flush();

            Response.End();




        }
    }
}