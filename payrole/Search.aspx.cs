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

namespace NewWebApp.payrole
{
    public partial class Search : System.Web.UI.Page
    {
       ClDatabase cl = new ClDatabase();
    int i,j;
    string date, month, year,date1, month1, year1, dateofjoin,dob;
    String strdist,strcadre, strcateg, strlevel, strdegree, strsubject, strdob, strdoj,sign,finalqry;
    protected void Page_Load(object sender, EventArgs e)
    {
        cl.upcon.Open();
        Panel2.Visible = false;
        if (!IsPostBack)
        {
            //*************Cadre********************
            cl.ds = cl.DataFill("SELECT * FROM cadre");
            for (j = 0; j <= cl.ds.Tables[0].Rows.Count - 1; j++)
            {
                Cadre.DataSource = cl.ds;
                Cadre.DataTextField = "cadrename";
                Cadre.DataValueField = "cadreid";
                Cadre.DataBind();
                //Cadre.Items.Add(cl.ds.Tables[0].Rows[j][1].ToString());
            }
           // Cadre.Items.Insert(0, new ListItem("--select--"));

            //**************Category********************
            cl.ds = cl.DataFill("SELECT * FROM category");
            for (j = 0; j <= cl.ds.Tables[0].Rows.Count - 1; j++)
            {
                Category.DataSource = cl.ds;
                Category.DataTextField = "category";
                Category.DataValueField = "catid";
                Category.DataBind();
                //Category.Items.Add(cl.ds.Tables[0].Rows[j][1].ToString());
            }
            //Category.Items.Insert(0, new ListItem("--select--"));

            //****************Level*********************
            cl.ds = cl.DataFill("SELECT * FROM lavel");
            for (j = 0; j <= cl.ds.Tables[0].Rows.Count - 1; j++)
            {
                Level.DataSource = cl.ds;
                Level.DataTextField = "levelcode";
                Level.DataValueField = "levelid";
                Level.DataBind();
                //Level.Items.Add(cl.ds.Tables[0].Rows[j][1].ToString());
            }
            //Level.Items.Insert(0, new ListItem("--select--"));
            //***********************Qualification*************
            cl.ds = cl.DataFill("SELECT * FROM Qualification");
            for (j = 0; j <= cl.ds.Tables[0].Rows.Count - 1; j++)
            {
                degree.DataSource = cl.ds;
                degree.DataTextField = "QuaName";
                degree.DataValueField = "QuaId";
                degree.DataBind();
               // degree.Items.Add(cl.ds.Tables[0].Rows[j][1].ToString());
            }
           // degree.Items.Insert(0, new ListItem("--select--"));
            //******************Speciliatzation*****************
            cl.ds = cl.DataFill("SELECT * FROM specialization");
            for (j = 0; j <= cl.ds.Tables[0].Rows.Count - 1; j++)
            {
                Subject.DataSource = cl.ds;
                Subject.DataTextField = "spname";
                Subject.DataValueField = "spid";
                Subject.DataBind();
                //Subject.Items.Add(cl.ds.Tables[0].Rows[j][1].ToString());
            }
           // Subject.Items.Insert(0, new ListItem("--select--"));

            //*****************For District*******************88
            cl.ds = cl.DataFill("SELECT * FROM hospitaldistrict order by districtname");
            for (j = 0; j <= cl.ds.Tables[0].Rows.Count - 1; j++)
            {
                Districtdrp.DataSource = cl.ds;
                Districtdrp.DataTextField = "districtname";
                Districtdrp.DataValueField = "districtid";
                Districtdrp.DataBind();
                //Subject.Items.Add(cl.ds.Tables[0].Rows[j][1].ToString());
            }
            Districtdrp.Items.Insert(0, new ListItem("--select--"));
            //******************************date*************************
            for (i = 01; i <= 31; i++)
            {
                if (i <= 9)
                {
                    datedrp.Items.Add("0" + i.ToString());
                    datedrp1.Items.Add("0" + i.ToString());
                }
                else
                {
                    datedrp.Items.Add(i.ToString());
                    datedrp1.Items.Add(i.ToString());
                }
                
            }
            for (i = 1950; i <= 2015; i++)
            {
                yeardrp.Items.Add(i.ToString());
                yeardrp1.Items.Add(i.ToString());
            }
            datedrp1.Items.Insert(0, new ListItem("Select","-1"));
            yeardrp1.Items.Insert(0, new ListItem("Select", "-1"));
        }
        //**************************************************
       
       

        
    }
    protected void yeardrp_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void datedrp_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
  
    protected void datedrp1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void mondrp_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void mondrp1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void yeardrp1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void cadadd_Click(object sender, EventArgs e)
    {
        SelCadre.Items.Insert(0,new ListItem (Cadre.SelectedItem.ToString(),Cadre.SelectedItem.Value.ToString()));
        
    }
    protected void cadrem_Click(object sender, EventArgs e)
    {
        if (SelCadre.Items.Count==0)
        { }
        else
        {
            SelCadre.Items.RemoveAt(SelCadre.SelectedIndex);
        }
    }
    protected void catadd_Click(object sender, EventArgs e)
    {
        //SelCategory.Items.Add(Category.SelectedItem.ToString());
        SelCategory.Items.Insert(0, new ListItem(Category.SelectedItem.ToString(), Category.SelectedItem.Value.ToString()));
    }
    protected void catrem_Click(object sender, EventArgs e)
    {
        SelCategory.Items.RemoveAt(SelCategory.SelectedIndex);
    }
    protected void levadd_Click(object sender, EventArgs e)
    {
        //SelLevel.Items.Add(Level.SelectedItem.ToString());
        SelLevel.Items.Insert(0, new ListItem(Level.SelectedItem.ToString(), Level.SelectedItem.Value.ToString()));
    }
    protected void levrem_Click(object sender, EventArgs e)
    {
        SelLevel.Items.RemoveAt(SelLevel.SelectedIndex);
    }
    protected void degadd_Click(object sender, EventArgs e)
    {
       // Seldegree.Items.Add(degree.SelectedItem.ToString());
        Seldegree.Items.Insert(0, new ListItem(degree.SelectedItem.ToString(), degree.SelectedItem.Value.ToString()));

    }
    protected void degrem_Click(object sender, EventArgs e)
    {
        Seldegree.Items.RemoveAt(Seldegree.SelectedIndex);

    }
    protected void subadd_Click(object sender, EventArgs e)
    {
       // Selsubject.Items.Add(Subject.SelectedItem.ToString());
        Selsubject.Items.Insert(0, new ListItem(Subject.SelectedItem.ToString(), Subject.SelectedItem.Value.ToString()));
  
    }
    protected void subrem_Click(object sender, EventArgs e)
    {
        Selsubject.Items.RemoveAt(Selsubject.SelectedIndex);
       
    }


    protected void btnsearch_Click(object sender, EventArgs e)
    {
       /* date = datedrp.SelectedValue;
        month = mondrp.SelectedValue;
        year = yeardrp.SelectedValue;
        dob = date + "/" + month + "/" + year;
        strdob = dob;*/
         
        date1 = datedrp1.SelectedValue;
        month1 = mondrp1.SelectedValue;
        year1 = yeardrp1.SelectedValue;
        dateofjoin = date1 + "/" + month1 + "/" + year1;
        strdoj = dateofjoin;
     
        if (SelDistrict.Items.Count > 0)
        {
              strdist = "(";
            for (int i = 0; i <= SelDistrict.Items.Count - 1; i++)
            {
                if (i > 0)
                {
                      strdist =   strdist + " or ";
                }
                  strdist =   strdist + "cadre=" + SelDistrict.Items[i].Value.ToString();

            }
              strdist =   strdist + ")";
        }
        else
        {
              strdist = "";

        }

        if (SelCadre.Items.Count > 0)
        {
            strcadre = "(";
            for (int i = 0; i <= SelCadre.Items.Count - 1; i++)
            {
                if (i > 0)
                {
                    strcadre = strcadre + " or ";
                }
                strcadre = strcadre + "cadreid=" + SelCadre.Items[i].Value.ToString();

            }
            strcadre = strcadre + ")";
        }
        else
        {
            strcadre = "";
        
        }

        if (SelCategory.Items.Count>0)
        {
            strcateg = "(";
            for (int i = 0; i <= SelCategory.Items.Count - 1; i++)
            {
                if (i > 0)
                {
                    strcateg = strcateg + " or ";
                }
                strcateg = strcateg + "catid=" + SelCategory.Items[i].Value.ToString();

            }
            strcateg = strcateg + ")";
        }
        else
        {
            strcateg = "";

        }
        if (SelLevel.Items.Count>0)
        {
            strlevel = "(";
            for (int i = 0; i <= SelLevel.Items.Count - 1; i++)
            {
                if (i > 0)
                {
                    strlevel = strlevel + " or ";
                }
                strlevel = strlevel + "lavel=" + SelLevel.Items[i].Value.ToString();

            }
            strlevel = strlevel + ")";
        }
        else
        {
            strlevel = "";

        }

        /*if (Seldegree.Items.Count>0)
        {
            strdegree = "(";
            for (int i = 0; i <= Seldegree.Items.Count - 1; i++)
            {
                if (i > 0)
                {
                    strdegree = strdegree + " or ";
                }
                strdegree = strdegree + "qid=" + Seldegree.Items[i].Value.ToString();

            }
            strdegree = strdegree + ")";
        }
        else
        {
            strdegree = "";

        }
        if (Selsubject.Items.Count>0)
        {
            strsubject = "(";
            for (int i = 0; i <= Selsubject.Items.Count - 1; i++)
            {
                if (i > 0)
                {
                    strsubject = strsubject + " or ";
                }
                strsubject = strsubject + "sid=" + Selsubject.Items[i].Value.ToString();

            }
            strsubject = strsubject + ")";
        }
        else
        {
            strsubject = "";

        }*/
       
        if (strcadre != "")
        {
            finalqry = strcadre;
        }
        if (strcadre != "")
        {
            if (strcateg != "")
            {
                finalqry = finalqry+"and"+ strcateg;
            }


            if (strlevel != "")
            {
                finalqry = finalqry + "and" +  strlevel;
            }
            if (dateofjoin == "-1/-1/-1")
            {
                strdoj = "";
            }
            else
            {   sign = optdoj.SelectedItem.ToString();
                strdoj= "and" + "dojoining" +sign+ dateofjoin;
            
            }
          
        }
        else 
        {
            if (strcateg != "")
            {
                finalqry = finalqry +  strcateg;
            }
           

            if (strlevel != "")
            {
                if (strcateg != "")
                {
                    finalqry = finalqry +  "and" + strlevel;
                }
                else
                {
                    finalqry = finalqry + strlevel;
                }
              
            }
            if (dateofjoin == "-1/-1/-1")
            {
                strdoj = "";
            }
            else
            {
                sign = optdoj.SelectedItem.ToString();
                strdoj =  "and" +  "dojoining" + sign + dateofjoin;

            }
        }
        finalqry = finalqry +strdoj ;
        Label3.Text = finalqry;
       /* Panel1.Visible = false;
        Panel2.Visible = true;
        cl.ds = cl.DataFill("select name,PostingDistrict, Postname, lavel, Cadre, cadreid, PostingPlace,  postid, Qualification, Specialization,CONVERT(varchar(11),dojoining,106) as dojoining, catid, spid, QuaId,category from dynamicQ1 where " + finalqry + "  order by lavel ");

        if (cl.ds.Tables[0].Rows.Count > 0)
        {

            TableRow rw = new TableRow();
            rw.BorderWidth = 1;
            rw.BorderColor = System.Drawing.Color.SlateGray;
            rw.Style["Font-Size"] = "Medium";

            TableCell tcell0 = new TableCell();
            tcell0.Text = "Sr.No.";
            tcell0.BorderWidth = 1;
            tcell0.BorderColor = System.Drawing.Color.SlateGray;
            tcell0.ForeColor = System.Drawing.Color.Navy;
            tcell0.BackColor = System.Drawing.Color.White;

            rw.Cells.Add(tcell0);


            TableCell tcell1 = new TableCell();
            tcell1.Text = "Name";
            tcell1.BorderWidth = 1;
            tcell1.BorderColor = System.Drawing.Color.SlateGray;
            tcell1.ForeColor = System.Drawing.Color.Navy;
            tcell1.BackColor = System.Drawing.Color.White;

            rw.Cells.Add(tcell1);

          

            TableCell tcell3 = new TableCell();
            tcell3.Text = "Post";
            tcell3.BorderWidth = 1;
            tcell3.BorderColor = System.Drawing.Color.SlateGray;
            tcell3.ForeColor = System.Drawing.Color.Navy;
            tcell3.BackColor = System.Drawing.Color.White;

            rw.Cells.Add(tcell3);

            TableCell tcell4 = new TableCell();
            tcell4.Text = "Placeofposting";
            tcell4.BorderWidth = 1;
            tcell4.BorderColor = System.Drawing.Color.SlateGray;
            tcell4.ForeColor = System.Drawing.Color.Navy;
            tcell4.BackColor = System.Drawing.Color.White;

            rw.Cells.Add(tcell4);

            TableCell tcell5 = new TableCell();
            tcell5.Text = "CurrentDistrict";
            tcell5.BorderWidth = 1;
            tcell5.BorderColor = System.Drawing.Color.SlateGray;
            tcell5.ForeColor = System.Drawing.Color.Navy;
            tcell5.BackColor = System.Drawing.Color.White;
            rw.Cells.Add(tcell5);

          

            TableCell tcell7 = new TableCell();
            tcell7.Text = "level";
            tcell7.BorderWidth = 1;
            tcell7.BorderColor = System.Drawing.Color.SlateGray;
            tcell7.ForeColor = System.Drawing.Color.Navy;
            tcell7.BackColor = System.Drawing.Color.White;

            rw.Cells.Add(tcell7);

            TableCell tcell8 = new TableCell();
            tcell8.Text = "cadre";
            tcell8.BorderWidth = 1;
            tcell8.BorderColor = System.Drawing.Color.SlateGray;
            tcell8.ForeColor = System.Drawing.Color.Navy;
            tcell8.BackColor = System.Drawing.Color.White;

            rw.Cells.Add(tcell8);
           
            TableCell tcell2 = new TableCell();
            tcell2.Text = "Category";
            tcell2.BorderWidth = 1;
            tcell2.BorderColor = System.Drawing.Color.SlateGray;
            tcell2.ForeColor = System.Drawing.Color.Navy;
            tcell2.BackColor = System.Drawing.Color.White;

            rw.Cells.Add(tcell2);
           

            TableCell tcell6 = new TableCell();
            tcell6.Text = "DateOfJoining";
            tcell6.BorderWidth = 1;
            tcell6.BorderColor = System.Drawing.Color.SlateGray;
            tcell6.ForeColor = System.Drawing.Color.Navy;
            tcell6.BackColor = System.Drawing.Color.White;

            rw.Cells.Add(tcell6);


            Table1.Rows.Add(rw);
            for (j = 0; j <= cl.ds.Tables[0].Rows.Count - 1; j++)
            {

                TableRow rw1 = new TableRow();
                rw1.BorderWidth = 1;
                rw1.BorderColor = System.Drawing.Color.SlateGray;
                rw1.ForeColor = System.Drawing.Color.Maroon;
                rw1.BackColor = System.Drawing.Color.White;


                TableCell tcellk1 = new TableCell();
                tcellk1.BorderWidth = 1;
                tcellk1.BorderColor = System.Drawing.Color.Black;
                tcellk1.ForeColor = System.Drawing.Color.Black;
                tcellk1.Text = Convert.ToString(j + 1);
                rw1.Cells.Add(tcellk1);

                TableCell tcellk2 = new TableCell();
                tcellk2.Text = cl.ds.Tables[0].Rows[j]["name"].ToString();
                tcellk2.BorderWidth = 1;
                tcellk2.BorderColor = System.Drawing.Color.Black;
                tcellk2.ForeColor = System.Drawing.Color.Black;
                //tcellk2.BackColor = System.Drawing.Color.White;
                rw1.Cells.Add(tcellk2);

                TableCell tcellk4 = new TableCell();
                tcellk4.BorderWidth = 1;
                tcellk4.BorderColor = System.Drawing.Color.Black;
                tcellk4.ForeColor = System.Drawing.Color.Black;
                //tcellk4.BackColor = System.Drawing.Color.White;
                tcellk4.Text = cl.ds.Tables[0].Rows[j]["Postname"].ToString();
                rw1.Cells.Add(tcellk4);

                TableCell tcellk5 = new TableCell();
                tcellk5.BorderWidth = 1;
                tcellk5.BorderColor = System.Drawing.Color.Black;
                tcellk5.ForeColor = System.Drawing.Color.Black;
                //tcellk5.BackColor = System.Drawing.Color.White;
                tcellk5.Text = cl.ds.Tables[0].Rows[j]["PostingPlace"].ToString();
                rw1.Cells.Add(tcellk5);

                TableCell tcellk6 = new TableCell();
                tcellk6.BorderWidth = 1;
                tcellk6.BorderColor = System.Drawing.Color.Black;
                tcellk6.ForeColor = System.Drawing.Color.Black;
                //tcellk6.BackColor = System.Drawing.Color.White;
                tcellk6.Text = cl.ds.Tables[0].Rows[j]["PostingDistrict"].ToString();
                rw1.Cells.Add(tcellk6);

                TableCell tcellk7 = new TableCell();
                tcellk7.BorderWidth = 1;
                tcellk7.BorderColor = System.Drawing.Color.Black;
                tcellk7.ForeColor = System.Drawing.Color.Black;
                //tcellk7.BackColor = System.Drawing.Color.White;
                tcellk7.Text = cl.ds.Tables[0].Rows[j]["lavel"].ToString();
                rw1.Cells.Add(tcellk7);
                
                TableCell tcellk8 = new TableCell();
                tcellk8.BorderWidth = 1;
                tcellk8.BorderColor = System.Drawing.Color.Black;
                tcellk8.ForeColor = System.Drawing.Color.Black;
                //tcellk8.BackColor = System.Drawing.Color.White;
                tcellk8.Text = cl.ds.Tables[0].Rows[j]["Cadre"].ToString();
                rw1.Cells.Add(tcellk8);

                TableCell tcellk9 = new TableCell();
                tcellk9.BorderWidth = 1;
                tcellk9.BorderColor = System.Drawing.Color.Black;
                tcellk9.ForeColor = System.Drawing.Color.Black;
                //tcellk9.BackColor = System.Drawing.Color.White;
                tcellk9.Text = cl.ds.Tables[0].Rows[j]["category"].ToString();
                rw1.Cells.Add(tcellk9);

                TableCell tcellk3 = new TableCell();
                tcellk3.Text = cl.ds.Tables[0].Rows[j]["dojoining"].ToString();
                tcellk3.BorderWidth = 1;
                tcellk3.BorderColor = System.Drawing.Color.Black;
                tcellk3.ForeColor = System.Drawing.Color.Black;
                // tcellk3.BackColor = System.Drawing.Color.White;
                rw1.Cells.Add(tcellk3);

                Table1.Rows.Add(rw1);
                Table1.BorderColor = System.Drawing.Color.Black;
                Table1.BorderWidth = 2;


            }*/
            /*if (strdegree != "")
            {
                finalqry = finalqry + "&nbsp;" + "and" + "&nbsp;" + strdegree; 
            }
            if (strsubject != "")
            {
                finalqry = finalqry + "&nbsp;" + "and" + "&nbsp;" + strsubject; 
            }
            //finalqry = strcadre +"&nbsp;" +"and"+"&nbsp;"+strcateg +"&nbsp;"+ "and"+"&nbsp;"+strlevel +"&nbsp;"+ "and"+"&nbsp;"+strdegree +"&nbsp;"+"and"+"&nbsp;"+ strsubject;*/
            // Label3.Text = finalqry;



        } 
  
    protected void optdoj_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void disadd_Click(object sender, EventArgs e)
    {
        SelDistrict.Items.Insert(0, new ListItem(Districtdrp.SelectedItem.ToString(), Districtdrp.SelectedItem.Value.ToString()));
    }
    protected void disremove_Click(object sender, EventArgs e)
    {
        if (SelDistrict.Items.Count == 0)
        { }
        else
        {
            SelDistrict.Items.RemoveAt(SelDistrict.SelectedIndex);
        }
    }
    }
}