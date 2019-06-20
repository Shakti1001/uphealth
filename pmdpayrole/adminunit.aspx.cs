using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace NewWebApp.pmdpayrole
{
    public partial class adminunit : System.Web.UI.Page
    {
        Class1 c = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                c.ddl(DropDownList1, "select * from hospitalname where ddoid=" + Session["iduser"] + " order by hname", "hname", "sno");


            }
        }


        private void PopulateHobbies()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager
                        .ConnectionStrings["uphsdpcon"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select sno,hname, (hname+' - '+isnull(convert(varchar(50), adminunit),0)) as itemname from hospitalname where ddoid=" + Session["iduser"] + " order by hname";
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            ListItem item = new ListItem();
                            item.Text = sdr["itemname"].ToString();
                            item.Value = sdr["sno"].ToString();
                            //item.Selected = Convert.ToBoolean(sdr["IsSelected"]);
                            CheckBoxList1.Items.Add(item);
                        }
                    }
                    conn.Close();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                c.con.Open();
                //Label2.Text = CheckBoxList1.SelectedItem.ToString();

                //c.cmd.CommandText = "update hospitalname set adminunit='"+DropDownList1.SelectedValue+"' where sno='"++"'";

                foreach (ListItem item in CheckBoxList1.Items)
                {
                    if (item.Selected)
                    {
                        string selectedValue = item.Value;

                        //Label2.Text = selectedValue;
                        c.cmd.CommandText = "update hospitalname set adminunit='" + DropDownList1.SelectedValue + "' where sno='" + selectedValue + "'";
                        c.cmd.ExecuteNonQuery();
                        Label2.Text = "Save Successfully......";


                    }


                }
                //if(CheckBoxList1.SelectedItem)
                //{

                //    Label2.Text = "Please Select Item First......";

                //}




            }
            catch
            {



            }
            finally
            {

                c.con.Close();

            }
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if(DropDownList1.SelectedIndex=)
            //{

            CheckBoxList1.Items.Clear();

            Button1.Visible = true;
            Label1.Visible = true;
            CheckBoxList1.Visible = true;
            PopulateHobbies();

            //}

        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/pmdpayrole/hospitalname.aspx");
        }
       

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/pmdpayrole/pmdSaldetH.aspx");
        }
    }
}