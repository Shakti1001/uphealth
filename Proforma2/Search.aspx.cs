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
    public partial class Search : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        ArrayList idnumber;
        int i, j, k, strdoj, flag;
        string date, month, year, date1, month1, year1, dateofjoin, dob;
        String strdist, strcadre, strcateg, strlevel, strdegree, strsubject, strdob, sign, finalqry, strpost, strdegsub, strtrain;
        protected void Page_Load(object sender, EventArgs e)
        {
            cl.upcon.Open();
            
            Label3.Visible = false;
            Label4.Visible = false;
            Label5.Visible = false;
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
                //Districtdrp.Items.Insert(0, new ListItem("--select--"));
                //***********************************post********************
                cl.ds = cl.DataFill("SELECT * FROM post");
                for (j = 0; j <= cl.ds.Tables[0].Rows.Count - 1; j++)
                {
                    Postdrp.DataSource = cl.ds;
                    Postdrp.DataTextField = "newpostname";
                    Postdrp.DataValueField = "newpostid";
                    Postdrp.DataBind();
                    //Subject.Items.Add(cl.ds.Tables[0].Rows[j][1].ToString());
                }
                //********************Training**********************
                cl.ds = cl.DataFill("SELECT * FROM trainingid");
                for (j = 0; j <= cl.ds.Tables[0].Rows.Count - 1; j++)
                {
                    training.DataSource = cl.ds;
                    training.DataTextField = "trname";
                    training.DataValueField = "trid";
                    training.DataBind();
                    //Subject.Items.Add(cl.ds.Tables[0].Rows[j][1].ToString());
                }


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
                datedrp1.Items.Insert(0, new ListItem("Select", "00"));
                yeardrp1.Items.Insert(0, new ListItem("Select", "00"));
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
            if (Cadre.SelectedItem == null)
            {

            }
            else
            {
                SelCadre.Items.Insert(0, new ListItem(Cadre.SelectedItem.ToString(), Cadre.SelectedItem.Value.ToString()));
            }

        }
        protected void cadrem_Click(object sender, EventArgs e)
        {
            if (SelCadre.Items.Count == 0)
            { }
            else
            {
                SelCadre.Items.RemoveAt(SelCadre.SelectedIndex);
            }
        }
        protected void catadd_Click(object sender, EventArgs e)
        {
            //SelCategory.Items.Add(Category.SelectedItem.ToString());
            if (Category.SelectedItem == null)
            {

            }
            else
            {
                SelCategory.Items.Insert(0, new ListItem(Category.SelectedItem.ToString(), Category.SelectedItem.Value.ToString()));
            }
        }
        protected void catrem_Click(object sender, EventArgs e)
        {
            if (SelCategory.Items.Count == 0)
            { }
            else
            {
                SelCategory.Items.RemoveAt(SelCategory.SelectedIndex);
            }
        }
        protected void levadd_Click(object sender, EventArgs e)
        {
            //SelLevel.Items.Add(Level.SelectedItem.ToString());
            if (Level.SelectedItem == null)
            {

            }
            else
            {
                SelLevel.Items.Insert(0, new ListItem(Level.SelectedItem.ToString(), Level.SelectedItem.Value.ToString()));
            }
        }
        protected void levrem_Click(object sender, EventArgs e)
        {
            if (SelLevel.Items.Count == 0)
            { }
            else
            {
                SelLevel.Items.RemoveAt(SelLevel.SelectedIndex);
            }
        }
        protected void degadd_Click(object sender, EventArgs e)
        {
            // Seldegree.Items.Add(degree.SelectedItem.ToString());
            if (degree.SelectedItem == null)
            {

            }
            else
            {
                int count = Seldegree.Items.Count;
                Seldegree.Items.Insert(count, new ListItem(degree.SelectedItem.ToString(), degree.SelectedItem.Value.ToString()));
            }

        }
        protected void degrem_Click(object sender, EventArgs e)
        {
            if (Seldegree.Items.Count == 0)
            { }
            else
            {
                int index = Seldegree.SelectedIndex;
                if (Selsubject.Items.Count == Seldegree.Items.Count)
                {
                    Seldegree.Items.RemoveAt(index);
                    Selsubject.Items.RemoveAt(index);
                }
                else
                {
                    Seldegree.Items.RemoveAt(index);
                }
            }

        }
        protected void subadd_Click(object sender, EventArgs e)
        {
            // Selsubject.Items.Add(Subject.SelectedItem.ToString());
            if (Seldegree.Items.Count == 0 || Selsubject.Items.Count == Seldegree.Items.Count)
            {
                Label5.Visible = true;
                Label5.Text = "Select Degree for Specialization";
            }
            else
            {

                if (Subject.SelectedItem == null)
                {

                }
                else
                {
                    int count = Selsubject.Items.Count;
                    Selsubject.Items.Insert(count, new ListItem(Subject.SelectedItem.ToString(), Subject.SelectedItem.Value.ToString()));
                }
            }

        }
        protected void subrem_Click(object sender, EventArgs e)
        {
            if (Selsubject.Items.Count == 0)
            { }
            else
            {
                int index = Selsubject.SelectedIndex;
                Selsubject.Items.RemoveAt(index);
                Seldegree.Items.RemoveAt(index);

            }

        }
        protected void disadd_Click(object sender, EventArgs e)
        {
            if (Districtdrp.SelectedItem == null)
            {

            }
            else
            {
                SelDistrict.Items.Insert(0, new ListItem(Districtdrp.SelectedItem.ToString(), Districtdrp.SelectedItem.Value.ToString()));
            }
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
        protected void Postadd_Click(object sender, EventArgs e)
        {
            if (Postdrp.SelectedItem == null)
            {

            }
            else
            {
                SelPostdrp.Items.Insert(0, new ListItem(Postdrp.SelectedItem.ToString(), Postdrp.SelectedItem.Value.ToString()));
            }


        }
        protected void Postrem_Click(object sender, EventArgs e)
        {
            if (SelPostdrp.Items.Count == 0)
            { }
            else
            {
                SelPostdrp.Items.RemoveAt(SelPostdrp.SelectedIndex);
            }

        }
        protected void optdoj_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        protected void btnsearch_Click(object sender, EventArgs e)
        {
            /* date = datedrp.SelectedValue;
             month = mondrp.SelectedValue;
             year = yeardrp.SelectedValue;
             dob = date + "/" + month + "/" + year;
             strdob = dob;*/
            if (Seldegree.Items.Count >= 1 && Selsubject.Items.Count == 0)
            {
                Label5.Visible = true;
                Label5.Text = "Select Specialization for Degree ";
            }
            else
            {
                date1 = datedrp1.SelectedValue;
                month1 = mondrp1.SelectedValue;
                year1 = yeardrp1.SelectedValue;
                dateofjoin = year1 + month1 + date1;
                strdoj = Convert.ToInt32(dateofjoin);
                if ((SelDistrict.Items.Count == 0) && (SelPostdrp.Items.Count == 0) && (SelCadre.Items.Count == 0) && (SelCategory.Items.Count == 0) && (SelLevel.Items.Count == 0) && (strdoj == 0) && (Seldegree.Items.Count == 0) && (Selsubject.Items.Count == 0) && (Seltraining.Items.Count == 0))
                {
                    Label3.Visible = true;
                    Label3.Text = "Select Search Criteria";
                }
                else
                {
                    if (SelDistrict.Items.Count > 0)
                    {
                        strdist = "(";
                        for (int i = 0; i <= SelDistrict.Items.Count - 1; i++)
                        {
                            if (i > 0)
                            {
                                strdist = strdist + " or ";
                            }
                            strdist = strdist + "districtid=" + SelDistrict.Items[i].Value.ToString();

                        }
                        strdist = strdist + ")";
                    }
                    else
                    {
                        strdist = "";

                    }


                    if (Seltraining.Items.Count > 0)
                    {
                        strtrain = "(";
                        for (int i = 0; i <= Seltraining.Items.Count - 1; i++)
                        {
                            if (i > 0)
                            {
                                strtrain = strtrain + " or ";
                            }
                            strtrain = strtrain + "trid=" + Seltraining.Items[i].Value.ToString();

                        }
                        strtrain = strtrain + ")";
                    }
                    else
                    {
                        strtrain = "";

                    }

                    if (SelPostdrp.Items.Count > 0)
                    {
                        strpost = "(";
                        for (int i = 0; i <= SelPostdrp.Items.Count - 1; i++)
                        {
                            if (i > 0)
                            {
                                strpost = strpost + " or ";
                            }
                            strpost = strpost + "postid=" + SelPostdrp.Items[i].Value.ToString();

                        }
                        strpost = strpost + ")";
                    }
                    else
                    {
                        strpost = "";

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




                    if (SelCategory.Items.Count > 0)
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
                    if (SelLevel.Items.Count > 0)
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

                    ////////////////////////////////////

                    if (Seldegree.Items.Count > 0 && Selsubject.Items.Count > 0)
                    {
                        strdegsub = "(";

                        for (int i = 0; i <= Seldegree.Items.Count - 1; i++)
                        {
                            if (i > 0)
                            {
                                strdegsub = strdegsub + " or " + "(";
                            }
                            strdegsub = strdegsub + "qid=" + Seldegree.Items[i].Value.ToString();
                            strdegsub = strdegsub + "and sid=" + Selsubject.Items[i].Value.ToString() + ")";


                        }


                    }
                    else
                    {
                        strdegsub = "";

                    }

                    /*if (Selsubject.Items.Count > 0)
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
                    flag = 0;
                    finalqry = "";

                    if (strdist != "")
                    {
                        if (flag == 0)
                        {
                            finalqry = strdist;
                        }
                        else
                        {
                            finalqry = finalqry + "and" + strdist;
                        }
                        flag = 1;
                    }
                    if (strpost != "")
                    {
                        if (flag == 0)
                        {
                            finalqry = strpost;
                        }
                        else
                        {
                            finalqry = finalqry + "and" + strpost;
                        }
                        flag = 1;
                    }

                    if (strcadre != "")
                    {
                        if (flag == 0)
                        {
                            finalqry = strcadre;
                        }
                        else
                        {
                            finalqry = finalqry + "and" + strcadre;
                        }
                        flag = 1;
                    }

                    if (strtrain != "")
                    {
                        if (flag == 0)
                        {
                            finalqry = strtrain;
                        }
                        else
                        {
                            finalqry = finalqry + "and" + strtrain;
                        }
                        flag = 1;
                    }




                    if (strcateg != "")
                    {
                        if (flag == 0)
                        {
                            finalqry = strcateg;
                        }
                        else
                        {
                            finalqry = finalqry + "and" + strcateg;
                        }
                        flag = 1;

                    }


                    if (strlevel != "")
                    {
                        if (flag == 0)
                        {
                            finalqry = strlevel;
                        }
                        else
                        {
                            finalqry = finalqry + "and" + strlevel;
                        }
                        flag = 1;
                    }
                    if (strdegsub != "")
                    {
                        if (flag == 0)
                        {
                            finalqry = "(" + strdegsub + ")";
                        }
                        else
                        {
                            finalqry = finalqry + "and" + "(" + strdegsub + ")";
                        }
                        flag = 1;
                    }

                    if (strdoj != 0)
                    {
                        string dojstr = "dbo.datetoint(dojoining)";
                        sign = optdoj.SelectedItem.ToString();
                        if (flag == 0)
                        {
                            finalqry = dojstr + sign + strdoj;

                        }
                        else
                        {
                            //dojstr = "substring((Convert(Varchar, dojoining, 111)), 1, 4)" +"+"+ "substring((Convert(Varchar, dojoining, 111)), 6, 2)" +"+"+ "substring((Convert(Varchar, dojoining, 111)), 9, 2)"; 
                            dojstr = "and dbo.datetoint(dojoining)";
                            finalqry = finalqry + dojstr + sign + strdoj;

                        }
                    }



                    //  Label3.Visible = true;
                    // Label3.Text = finalqry;
                    /* if (strdegree != "")
                     {
                         finalqry = finalqry + "&nbsp;" + "and" + "&nbsp;" + strdegree;
                     }
                     if (strsubject != "")
                     {
                         finalqry = finalqry + "&nbsp;" + "and" + "&nbsp;" + strsubject;
                     }
                     //finalqry = strcadre +"&nbsp;" +"and"+"&nbsp;"+strcateg +"&nbsp;"+ "and"+"&nbsp;"+strlevel +"&nbsp;"+ "and"+"&nbsp;"+strdegree +"&nbsp;"+"and"+"&nbsp;"+ strsubject;*/
                    // Label3.Text = finalqry;*/

                    

                    if (strdegsub != "")
                    {
                        cl.ds = cl.DataFill("select idno, name,districtname, hname,Postname, lavel, cadrename, cadreid, postid,dojoining, catid, category,trname from SearchCurrent1 where " + finalqry + "  order by year(dojoining) desc ");
                    }
                    else
                    {
                        cl.ds = cl.DataFill("select idno, name,districtname,hname, Postname, lavel, cadrename, cadreid, postid, dojoining, catid, category,trname from SearchCurrent where " + finalqry + "  order by year(dojoining) desc");
                    }
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
                        tcell0.BackColor = System.Drawing.Color.Silver;

                        rw.Cells.Add(tcell0);

                        TableCell tcell9 = new TableCell();
                        tcell9.Text = "Idno";
                        tcell9.BorderWidth = 1;
                        tcell9.BorderColor = System.Drawing.Color.SlateGray;
                        tcell9.ForeColor = System.Drawing.Color.Navy;
                        tcell9.BackColor = System.Drawing.Color.Silver;

                        rw.Cells.Add(tcell9);

                        TableCell tcell1 = new TableCell();
                        tcell1.Text = "Name";
                        tcell1.BorderWidth = 1;
                        tcell1.BorderColor = System.Drawing.Color.SlateGray;
                        tcell1.ForeColor = System.Drawing.Color.Navy;
                        tcell1.BackColor = System.Drawing.Color.Silver;

                        rw.Cells.Add(tcell1);



                        TableCell tcell3 = new TableCell();
                        tcell3.Text = "Post";
                        tcell3.BorderWidth = 1;
                        tcell3.BorderColor = System.Drawing.Color.SlateGray;
                        tcell3.ForeColor = System.Drawing.Color.Navy;
                        tcell3.BackColor = System.Drawing.Color.Silver;

                        rw.Cells.Add(tcell3);

                        TableCell tcell4 = new TableCell();
                        tcell4.Text = "Placeofposting";
                        tcell4.BorderWidth = 1;
                        tcell4.BorderColor = System.Drawing.Color.SlateGray;
                        tcell4.ForeColor = System.Drawing.Color.Navy;
                        tcell4.BackColor = System.Drawing.Color.Silver;

                        rw.Cells.Add(tcell4);

                        TableCell tcell5 = new TableCell();
                        tcell5.Text = "CurrentDistrict";
                        tcell5.BorderWidth = 1;
                        tcell5.BorderColor = System.Drawing.Color.SlateGray;
                        tcell5.ForeColor = System.Drawing.Color.Navy;
                        tcell5.BackColor = System.Drawing.Color.Silver;
                        rw.Cells.Add(tcell5);



                        TableCell tcell7 = new TableCell();
                        tcell7.Text = "level";
                        tcell7.BorderWidth = 1;
                        tcell7.BorderColor = System.Drawing.Color.SlateGray;
                        tcell7.ForeColor = System.Drawing.Color.Navy;
                        tcell7.BackColor = System.Drawing.Color.Silver;

                        rw.Cells.Add(tcell7);

                        TableCell tcell8 = new TableCell();
                        tcell8.Text = "cadre";
                        tcell8.BorderWidth = 1;
                        tcell8.BorderColor = System.Drawing.Color.SlateGray;
                        tcell8.ForeColor = System.Drawing.Color.Navy;
                        tcell8.BackColor = System.Drawing.Color.Silver;

                        rw.Cells.Add(tcell8);

                        TableCell tcell2 = new TableCell();
                        tcell2.Text = "Category";
                        tcell2.BorderWidth = 1;
                        tcell2.BorderColor = System.Drawing.Color.SlateGray;
                        tcell2.ForeColor = System.Drawing.Color.Navy;
                        tcell2.BackColor = System.Drawing.Color.Silver;

                        rw.Cells.Add(tcell2);


                        TableCell tcell6 = new TableCell();
                        tcell6.Text = "DateOfJoining";
                        tcell6.BorderWidth = 1;
                        tcell6.BorderColor = System.Drawing.Color.SlateGray;
                        tcell6.ForeColor = System.Drawing.Color.Navy;
                        tcell6.BackColor = System.Drawing.Color.Silver;

                        rw.Cells.Add(tcell6);

                        TableCell tcell91 = new TableCell();
                        tcell91.Text = "Training";
                        tcell91.BorderWidth = 1;
                        tcell91.BorderColor = System.Drawing.Color.SlateGray;
                        tcell91.ForeColor = System.Drawing.Color.Navy;
                        tcell91.BackColor = System.Drawing.Color.Silver;

                        rw.Cells.Add(tcell91);



                        Table1.Rows.Add(rw);
                        for (j = 0, k = 0; j <= cl.ds.Tables[0].Rows.Count - 1; j++, k++)
                        {

                            // cl.ds = cl.DataFill("select idno, name,districtname, Postname, lavel,hname, cadrename, cadreid, postid, CONVERT(varchar(11),dojoining,106) as dojoining, catid, category from SearchQuery where " +finalqry+ " ");


                            TableRow rw1 = new TableRow();
                            rw1.BorderWidth = 1;
                            rw1.BorderColor = System.Drawing.Color.SlateGray;
                            rw1.ForeColor = System.Drawing.Color.Black;
                            rw1.BackColor = System.Drawing.Color.White;


                            TableCell tcellk1 = new TableCell();
                            tcellk1.BorderWidth = 1;
                            tcellk1.BorderColor = System.Drawing.Color.Black;
                            //tcellk1.ForeColor = System.Drawing.Color.Black;
                            tcellk1.Text = Convert.ToString(k + 1);
                            rw1.Cells.Add(tcellk1);

                            TableCell tcellk2 = new TableCell();
                            tcellk2.Text = cl.ds.Tables[0].Rows[j]["idno"].ToString();
                            tcellk2.BorderWidth = 1;
                            tcellk2.BorderColor = System.Drawing.Color.Black;
                            //tcellk2.ForeColor = System.Drawing.Color.Black;
                            //tcellk2.BackColor = System.Drawing.Color.White;
                            rw1.Cells.Add(tcellk2);

                            TableCell tcellk10 = new TableCell();
                            tcellk10.Text = cl.ds.Tables[0].Rows[j]["name"].ToString();
                            tcellk10.BorderWidth = 1;
                            tcellk10.BorderColor = System.Drawing.Color.Black;
                            //tcellk2.ForeColor = System.Drawing.Color.Black;
                            //tcellk2.BackColor = System.Drawing.Color.White;
                            rw1.Cells.Add(tcellk10);

                            TableCell tcellk4 = new TableCell();
                            tcellk4.BorderWidth = 1;
                            tcellk4.BorderColor = System.Drawing.Color.Black;
                            //tcellk4.ForeColor = System.Drawing.Color.Black;
                            //tcellk4.BackColor = System.Drawing.Color.White;
                            tcellk4.Text = cl.ds.Tables[0].Rows[j]["Postname"].ToString();
                            rw1.Cells.Add(tcellk4);

                            TableCell tcellk5 = new TableCell();
                            tcellk5.BorderWidth = 1;
                            tcellk5.BorderColor = System.Drawing.Color.Black;
                            // tcellk5.ForeColor = System.Drawing.Color.Black;
                            //tcellk5.BackColor = System.Drawing.Color.White;
                            tcellk5.Text = cl.ds.Tables[0].Rows[j]["hname"].ToString();
                            rw1.Cells.Add(tcellk5);

                            TableCell tcellk6 = new TableCell();
                            tcellk6.BorderWidth = 1;
                            tcellk6.BorderColor = System.Drawing.Color.Black;
                            //  tcellk6.ForeColor = System.Drawing.Color.Black;
                            //tcellk6.BackColor = System.Drawing.Color.White;
                            tcellk6.Text = cl.ds.Tables[0].Rows[j]["districtname"].ToString();
                            rw1.Cells.Add(tcellk6);

                            TableCell tcellk7 = new TableCell();
                            tcellk7.BorderWidth = 1;
                            tcellk7.BorderColor = System.Drawing.Color.Black;
                            // tcellk7.ForeColor = System.Drawing.Color.Black;
                            //tcellk7.BackColor = System.Drawing.Color.White;
                            tcellk7.Text = cl.ds.Tables[0].Rows[j]["lavel"].ToString();
                            rw1.Cells.Add(tcellk7);

                            TableCell tcellk8 = new TableCell();
                            tcellk8.BorderWidth = 1;
                            tcellk8.BorderColor = System.Drawing.Color.Black;
                            // tcellk8.ForeColor = System.Drawing.Color.Black;
                            //tcellk8.BackColor = System.Drawing.Color.White;
                            tcellk8.Text = cl.ds.Tables[0].Rows[j]["cadrename"].ToString();
                            rw1.Cells.Add(tcellk8);

                            TableCell tcellk9 = new TableCell();
                            tcellk9.BorderWidth = 1;
                            tcellk9.BorderColor = System.Drawing.Color.Black;
                            //tcellk9.ForeColor = System.Drawing.Color.Black;
                            //tcellk9.BackColor = System.Drawing.Color.White;
                            tcellk9.Text = cl.ds.Tables[0].Rows[j]["category"].ToString();
                            rw1.Cells.Add(tcellk9);

                            TableCell tcellk3 = new TableCell();
                            tcellk3.Text = cl.ds.Tables[0].Rows[j]["dojoining"].ToString();
                            tcellk3.BorderWidth = 1;
                            tcellk3.BorderColor = System.Drawing.Color.Black;
                            // tcellk3.ForeColor = System.Drawing.Color.Black;
                            // tcellk3.BackColor = System.Drawing.Color.White;
                            rw1.Cells.Add(tcellk3);


                            TableCell tcellk31 = new TableCell();
                            tcellk31.Text = cl.ds.Tables[0].Rows[j]["trname"].ToString();
                            tcellk31.BorderWidth = 1;
                            tcellk31.BorderColor = System.Drawing.Color.Black;
                            // tcellk3.ForeColor = System.Drawing.Color.Black;
                            // tcellk3.BackColor = System.Drawing.Color.White;
                            rw1.Cells.Add(tcellk31);

                            Table1.Rows.Add(rw1);
                            Table1.BorderColor = System.Drawing.Color.Black;
                            Table1.BorderWidth = 2;





                        }
                    }
                    else
                    {
                        Label4.Visible = true;
                        Label4.Text = "No Record Found As Per Your Search Criteria";
                    }
                }
            }



        }



        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            
        }
        protected void training_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (training.SelectedItem == null)
            {

            }
            else
            {
                Seltraining.Items.Insert(0, new ListItem(training.SelectedItem.ToString(), training.SelectedItem.Value.ToString()));
            }

        }
        protected void train_Click(object sender, EventArgs e)
        {

            if (Seltraining.Items.Count == 0)
            { }
            else
            {
                Seltraining.Items.RemoveAt(Seltraining.SelectedIndex);
            }
        }
    }
}