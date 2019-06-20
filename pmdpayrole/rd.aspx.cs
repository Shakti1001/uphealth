using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewWebApp.pmdpayrole
{
    public partial class rd : System.Web.UI.Page
    {
        Class1 c = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                c.gv(GridView1, "SELECT     a.idno,  PMDpersonaldetails.name,a.gpfno,ISNULL(a.rdded, 0) AS rdded FROM         pmdcalulatedsalary AS a INNER JOIN Pay_Head ON a.headid = Pay_Head.headid INNER JOIN pmd_salaryselect AS s ON a.idno = s.idno INNER JOIN PMDpersonaldetails ON a.idno = PMDpersonaldetails.idno WHERE    ((a.ddoid = 123) AND (a.Syear = 2014) AND (a.Smonth = 12)) ");

                if (GridView1.Rows.Count > 0)
                {



                }
                else
                {
                    Label1.Text = "Record Not Found..............";

                }

            }

        }
    }
}