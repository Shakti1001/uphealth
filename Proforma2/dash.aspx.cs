using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace NewWebApp.Proforma2
{
    public partial class dash : System.Web.UI.Page
    {
        DB_Manager obj = new DB_Manager();
        protected void Page_Load(object sender, EventArgs e)
        {
            //fill_div();
            if (!Page.IsPostBack)
            {
                fill_div();
                mainpnl.Visible = false;
            }
            else
            {
            }
        }
        protected void fill_div()
        {
            string query = "SELECT divname FROM division order by divname";
            DataTable dt = new DataTable();
            dt = obj.Return_Dt(query);
            // ddl_div.Items.Clear();
            ddl_div.Items.Add("...Select Division...");
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ddl_div.Items.Add(dt.Rows[i][0].ToString());
                }
            }
        }
        protected void fill_dist(string div)
        {
            //string query = "SELECT hrcDistrict.district FROM hrcDivision INNER JOIN  hrcDistrict ON hrcDivision.divisionId = hrcDistrict.divisionId WHERE (hrcDivision.division = '" + div + "')";

            string query = "SELECT  division.divname, hospitaldistrict.districtname FROM  hospitaldistrict INNER JOIN division ON hospitaldistrict.divid = division.divid WHERE (division.divname = '" + div + "') order by hospitaldistrict.districtname";
            DataTable dt = new DataTable();
            dt = obj.Return_Dt(query);
            //ddl_dist.Items.Clear();
            ddl_dist.Items.Add("...Select District...");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddl_dist.Items.Add(dt.Rows[i][1].ToString());
            }
            //ddl_dist.Items.Add("All");
        }
        protected void fill_Facility(string dist)
        {
            //string query = "SELECT hrcFacility.facilityName FROM hrcDistrict INNER JOIN  hrcFacility ON hrcDistrict.district = hrcFacility.district WHERE (hrcFacility.district = '" + ddl_dist.SelectedValue.ToString() + "')";
            string query = "SELECT hospitaldistrict.districtname, hospitalname.hname,hospitalname.sno, hospitalname.htype FROM  hospitaldistrict INNER JOIN hospitalname ON hospitaldistrict.districtid = hospitalname.districtid WHERE (hospitaldistrict.districtname = '" + ddl_dist.SelectedValue.ToString() + "') order by hospitalname.hname";

            DataTable dt = new DataTable();
            dt = obj.Return_Dt(query);
            ddl_Facility.Items.Clear();
            ddl_Facility.DataSource = dt;
            ddl_Facility.DataValueField = "sno";
            ddl_Facility.DataTextField = "hname";
            ddl_Facility.DataBind();
            //ddl_Facility.Items.Add("...Select Facility...");
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    ddl_Facility.Items.Add(dt.Rows[i][1].ToString());
            //}
            //  ddl_Facility.Items.Add("All");
        }
        protected void ddl_div_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_dist.Items.Clear();
            fill_dist(ddl_div.SelectedValue.ToString());
            mainpnl.Visible = false;
            lbl_counter.Text = "";
            lbl_type.Text = "";
            lbl_FRU_Type.Text = "";
            clear_all();
        }
        protected void ddl_dist_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_month.SelectedIndex = 0;
            mainpnl.Visible = false;
            lbl_type.Text = "";
            lbl_FRU_Type.Text = "";
            clear_all();
            if (ddl_dist.SelectedValue.ToString() == "All")
            {
                //ddl_Facility.Items.Clear();
                //fill_Facility(ddl_dist.SelectedValue.ToString());
                //lbl_type.Text = "";
                //lbl_FRU_Type.Text = "";
                ddl_Facility.Enabled = false;
            }
            else
            {
                ddl_Facility.Enabled = true;
                ddl_Facility.Items.Clear();
                fill_Facility(ddl_dist.SelectedValue.ToString());
                lbl_type.Text = "";
                lbl_FRU_Type.Text = "";
            }
        }

        protected void fill_by_Divi1(string parameter, string parameter2, Label ctrl)
        {
            string query = "select SUM(cast(sanctioned as float)) as sanction,SUM(cast(" + ddl_month.SelectedItem.Text + " as float)) As April from hrcHealthReportCard where (indicatorSubId='" + parameter + "' or indicatorSubId='" + parameter2 + "') and facilityCode in (select facilityCode from hrcFacility where division='" + ddl_div.SelectedItem.Text + "' and (facilityType='CMO' or facilityType='District Hospital')) and year='2013-2014'";
            DataTable dt = obj.Return_Dt(query);
            if (dt != null)
            {
                ctrl.Text = dt.Rows[0][0].ToString();
            }

        }
        protected void fill_by_Divi(string parameter, string parameter2, Label ctrl)
        {
            string query = "select SUM(cast(sanctioned as float)) as sanction,SUM(cast(" + ddl_month.SelectedItem.Text + " as float)) As April from hrcHealthReportCard where (indicatorSubId='" + parameter + "' or indicatorSubId='" + parameter2 + "') and facilityCode in (select facilityCode from hrcFacility where division='" + ddl_div.SelectedItem.Text + "' and (facilityType='CMO' or facilityType='District Hospital')) and year='2013-2014'";
            DataTable dt = obj.Return_Dt(query);
            if (dt != null)
            {
                ctrl.Text = dt.Rows[0][1].ToString();
            }

        }
        protected void fill_by_Divi2(string parameter, string parameter2, Label ctrl, Label ctrl2)
        {
            string query = "select SUM(cast(sanctioned as float)) as sanction,SUM(cast(" + ddl_month.SelectedItem.Text + " as float)) As April from hrcHealthReportCard where (indicatorSubId='" + parameter + "' or indicatorSubId='" + parameter2 + "') and facilityCode in (select facilityCode from hrcFacility where division='" + ddl_div.SelectedItem.Text + "' and (facilityType='CMO' or facilityType='District Hospital')) and year='2013-2014'";
            DataTable dt = obj.Return_Dt(query);
            if (dt != null)
            {
                ctrl2.Text = dt.Rows[0][0].ToString();
                ctrl.Text = dt.Rows[0][1].ToString();
            }

        }
        protected void Fill_By_Facility()
        {
            string query = "";
            DataTable dt = new DataTable();
            lbl_counter.Text = "";
            //radio_DH.Checked = false;
            //if (radio_DH.Checked == true)
            //{
            //    query = "SELECT hrcDistrict.district, hrcFacility.facilityName, hrcHealthReportCard." + ddl_month.SelectedValue.ToString() + ",hrcIndicatorSub.IndicatorSubName,  hrcHealthReportCard.sanctioned FROM hrcDistrict INNER JOIN hrcFacility ON hrcDistrict.district = hrcFacility.district INNER JOIN hrcHealthReportCard ON hrcFacility.facilityCode = hrcHealthReportCard.facilityCode INNER JOIN hrcIndicatorSub ON hrcHealthReportCard.indicatorSubId = hrcIndicatorSub.indicatorSubId WHERE(hrcDistrict.district = '" + ddl_dist.SelectedValue.ToString() + "') AND (hrcIndicatorSub.facilityType = N'District Hospital') AND (hrcFacility.facilityName = '" + ddl_Facility.SelectedValue.ToString() + "')";
            //}
            //else
            //{
            //    query = "SELECT hrcDistrict.district, hrcFacility.facilityName, hrcHealthReportCard." + ddl_month.SelectedValue.ToString() + ",hrcIndicatorSub.IndicatorSubName,  hrcHealthReportCard.sanctioned FROM hrcDistrict INNER JOIN hrcFacility ON hrcDistrict.district = hrcFacility.district INNER JOIN hrcHealthReportCard ON hrcFacility.facilityCode = hrcHealthReportCard.facilityCode INNER JOIN hrcIndicatorSub ON hrcHealthReportCard.indicatorSubId = hrcIndicatorSub.indicatorSubId WHERE(hrcDistrict.district = '" + ddl_dist.SelectedValue.ToString() + "')  AND (hrcFacility.facilityName = '" + ddl_Facility.SelectedValue.ToString() + "')";
            //}

            //query = "SELECT hrcDistrict.district, hrcFacility.facilityName, hrcHealthReportCard." + ddl_month.SelectedValue.ToString() + ",hrcIndicatorSub.IndicatorSubName,  hrcHealthReportCard.sanctioned FROM hrcDistrict INNER JOIN hrcFacility ON hrcDistrict.district = hrcFacility.district INNER JOIN hrcHealthReportCard ON hrcFacility.facilityCode = hrcHealthReportCard.facilityCode INNER JOIN hrcIndicatorSub ON hrcHealthReportCard.indicatorSubId = hrcIndicatorSub.indicatorSubId WHERE(hrcDistrict.district = '" + ddl_dist.SelectedValue.ToString() + "')  AND (hrcFacility.facilityName = '" + ddl_Facility.SelectedValue.ToString() + "')";
            query = "SELECT hrcDistrict.district, hrcFacility.facilityName, hrcHealthReportCard." + ddl_month.SelectedValue.ToString() + ",hrcIndicatorSub.IndicatorSubName,  hrcHealthReportCard.sanctioned,hrcFacility.fru FROM hrcDistrict INNER JOIN hrcFacility ON hrcDistrict.district = hrcFacility.district INNER JOIN hrcHealthReportCard ON hrcFacility.facilityCode = hrcHealthReportCard.facilityCode INNER JOIN hrcIndicatorSub ON hrcHealthReportCard.indicatorSubId = hrcIndicatorSub.indicatorSubId WHERE(hrcDistrict.district = '" + ddl_dist.SelectedValue.ToString() + "')  AND (hrcFacility.facilityName = '" + ddl_Facility.SelectedValue.ToString() + "')";
            if (query != "")
            {
                dt = obj.Return_Dt(query);
            }
            if (dt != null)
            {
                //  pnl_display.Visible = true;
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i][3].ToString() == "Total Doctors")
                        {
                            if (dt.Rows[i][2].ToString() != "")
                            {
                                lbl_total_Sanc.Text = dt.Rows[i][4].ToString();
                            }
                            else
                            {
                                lbl_sur_posted.Text = "NA";
                            }
                        }

                        if (dt.Rows[i][3].ToString() == "Total Doctors")
                        {
                            if (dt.Rows[i][2].ToString() != "")
                            {
                                lbl_posted.Text = dt.Rows[i][2].ToString();
                                lnk_view.Visible = true;
                                if (Convert.ToInt32(lbl_sur_posted.Text) > Convert.ToInt32(lbl_posted.Text))
                                {
                                    //img_up.Visible = false;
                                    //img_down.Visible = true;
                                }
                                else //if (Convert.ToInt32(lbl_Sanc.Text) < Convert.ToInt32(lbl_posted.Text))
                                {
                                    //img_down.Visible = false;
                                    //img_up.Visible = true;
                                }
                                //else if (Convert.ToInt32(lbl_Sanc.Text) == Convert.ToInt32(lbl_posted.Text))
                                //{
                                //    img_down.Visible = false;
                                //    img_up.Visible = false; ;
                                //}
                            }
                            else
                            {
                                lbl_posted.Text = "NA";
                                //img_down.Visible = false;
                                //img_up.Visible = false;
                                lnk_view.Visible = false;
                            }
                        }
                        if (dt.Rows[i][3].ToString() == "OPD - New")
                        {
                            if (dt.Rows[i][2].ToString() != "")
                            {
                                lbl_OPD.Text = dt.Rows[i][2].ToString();
                            }
                            else
                            {
                                lbl_OPD.Text = "NA";
                            }
                        }
                        if (dt.Rows[i][3].ToString() == "Bed occupancy rate")
                        {
                            if (dt.Rows[i][2].ToString() != "")
                            {
                                lbl_Beds.Text = dt.Rows[i][2].ToString();
                            }
                            else
                            {
                                lbl_Beds.Text = "NA";
                            }
                        }
                        if (dt.Rows[i][3].ToString() == "OPD - Old")
                        {
                            if (dt.Rows[i][2].ToString() != "")
                            {
                                lbl_OPD_old.Text = dt.Rows[i][2].ToString();
                            }
                            else
                            {
                                lbl_OPD_old.Text = "NA";
                            }
                        }


                        if (dt.Rows[i][3].ToString() == "MTP")
                        {
                            if (dt.Rows[i][2].ToString() != "")
                            {
                                lbl_MTP.Text = dt.Rows[i][2].ToString();
                            }
                            else
                            {
                                lbl_MTP.Text = "NA";
                            }
                        }
                        if (dt.Rows[i][3].ToString() == "Maternal Deaths")
                        {
                            if (dt.Rows[i][2].ToString() != "")
                            {
                                lbl_mater_death.Text = dt.Rows[i][2].ToString();
                            }
                            else
                            {
                                lbl_mater_death.Text = "NA";
                            }
                        }
                        if (dt.Rows[i][3].ToString() == "Female Sterlization")
                        {
                            if (dt.Rows[i][2].ToString() != "")
                            {
                                lbl_female_ster.Text = dt.Rows[i][2].ToString();
                            }
                            else
                            {
                                lbl_female_ster.Text = "NA";
                            }
                        }

                        if (dt.Rows[i][3].ToString() == "IPD")
                        {
                            if (dt.Rows[i][2].ToString() != "")
                            {
                                lbl_IPD.Text = dt.Rows[i][2].ToString();
                            }
                            else
                            {
                                lbl_IPD.Text = "NA";
                            }
                        }

                        if (dt.Rows[i][5].ToString() == "Yes")
                        {
                            if (dt.Rows[i][5].ToString() != "")
                            {
                                lbl_FRU_Type.Text = "Yes";
                                lbl_type.Text = "FRU";
                            }
                            else
                            {
                                lbl_FRU_Type.Text = "";
                                lbl_type.Text = "";
                            }

                        }
                        else if (dt.Rows[i][5].ToString() == "No")
                        {
                            if (dt.Rows[i][5].ToString() != "")
                            {
                                lbl_FRU_Type.Text = "No";
                                lbl_type.Text = "FRU";
                            }
                            else
                            {
                                lbl_FRU_Type.Text = "";
                                lbl_type.Text = "";
                            }
                        }
                        else
                        {
                            lbl_FRU_Type.Text = "";
                            lbl_type.Text = "";
                        }





                        if (dt.Rows[i][3].ToString() == "General Surgeon")
                        {
                            if (dt.Rows[i][4].ToString() != "")
                            {
                                lbl_sur_sanc.Text = dt.Rows[i][4].ToString();
                            }
                            else
                            {
                                lbl_sur_sanc.Text = "NA";
                            }
                            if (dt.Rows[i][2].ToString() != "")
                            {
                                lbl_sur_posted.Text = dt.Rows[i][2].ToString();
                            }
                            else
                            {
                                lbl_sur_posted.Text = "NA";
                            }
                        }
                        if (dt.Rows[i][3].ToString() == "Anesthestists")
                        {
                            if (dt.Rows[i][2].ToString() != "")
                            {
                                lbl_anae_sanc.Text = dt.Rows[i][4].ToString();
                            }
                            else
                            {
                                lbl_anae_sanc.Text = "NA";
                            }
                            if (dt.Rows[i][2].ToString() != "")
                            {
                                lbl_anas_posted.Text = dt.Rows[i][2].ToString();
                            }
                            else
                            {
                                lbl_anas_posted.Text = "NA";
                            }
                        }
                        if (dt.Rows[i][3].ToString() == "Operation Theatre")
                        {
                            if (dt.Rows[i][2].ToString() != "")
                            {
                                lbl_OT.Text = dt.Rows[i][4].ToString();
                            }
                            else
                            {
                                lbl_OT.Text = "NA";
                            }
                        }

                        if (dt.Rows[i][3].ToString() == "Major surgery")
                        {
                            if (dt.Rows[i][2].ToString() != "")
                            {
                                lbl_major.Text = dt.Rows[i][2].ToString();
                            }
                            else
                            {
                                lbl_major.Text = "NA";
                            }
                        }
                        if (dt.Rows[i][3].ToString() == "Minor surgery")
                        {
                            if (dt.Rows[i][2].ToString() != "")
                            {
                                lbl_minor.Text = dt.Rows[i][2].ToString();
                            }
                            else
                            {
                                lbl_minor.Text = "NA";
                            }
                        }

                        if (dt.Rows[i][3].ToString() == "Gynaecologist")
                        {
                            if (dt.Rows[i][4].ToString() != "")
                            {
                                lbl_Gy_sanc.Text = dt.Rows[i][4].ToString();
                            }
                            else
                            {
                                lbl_Gy_sanc.Text = "NA";
                            }

                            if (dt.Rows[i][2].ToString() != "")
                            {
                                lbl_Gyn_posted.Text = dt.Rows[i][2].ToString();
                            }
                            else
                            {
                                lbl_Gyn_posted.Text = "NA";
                            }
                        }

                        if (dt.Rows[i][3].ToString() == "Normal Delivery")
                        {

                            if (dt.Rows[i][2].ToString() != "")
                            {
                                lbl_normal.Text = dt.Rows[i][2].ToString();
                            }
                            else
                            {
                                lbl_normal.Text = "NA";
                            }
                        }
                        if (dt.Rows[i][3].ToString() == "Cessarian Delivery")
                        {

                            if (dt.Rows[i][2].ToString() != "")
                            {
                                lbl_Ceser.Text = dt.Rows[i][2].ToString();
                            }
                            else
                            {
                                lbl_Ceser.Text = "NA";
                            }
                        }
                        if (dt.Rows[i][3].ToString() == "Radiologist")
                        {
                            if (dt.Rows[i][4].ToString() != "")
                            {
                                lbl_Rad_sanc.Text = dt.Rows[i][4].ToString();
                            }
                            else
                            {
                                lbl_Rad_sanc.Text = "NA";
                            }
                            if (dt.Rows[i][2].ToString() != "")
                            {
                                lbl_Rad_posted.Text = dt.Rows[i][2].ToString();
                            }
                            else
                            {
                                lbl_Rad_posted.Text = "NA";
                            }
                        }

                        if (dt.Rows[i][3].ToString() == "Xray Machines")
                        {

                            if (dt.Rows[i][4].ToString() != "")
                            {
                                lbl_Xray_Mc.Text = dt.Rows[i][4].ToString();
                            }
                            else
                            {
                                lbl_Xray_Mc.Text = "NA";
                            }
                        }

                        if (dt.Rows[i][3].ToString() == "Xray")
                        {
                            if (dt.Rows[i][2].ToString() != "")
                            {
                                lbl_Xrays.Text = dt.Rows[i][2].ToString();
                            }
                            else
                            {
                                lbl_Xrays.Text = "NA";
                            }
                        }
                        if (dt.Rows[i][3].ToString() == "USG Machines")
                        {

                            if (dt.Rows[i][4].ToString() != "")
                            {
                                lbl_USGMc.Text = dt.Rows[i][4].ToString();
                            }
                            else
                            {
                                lbl_USGMc.Text = "NA";
                            }
                        }

                        if (dt.Rows[i][3].ToString() == "USG")
                        {
                            if (dt.Rows[i][2].ToString() != "")
                            {
                                lbl_USG.Text = dt.Rows[i][2].ToString();
                            }
                            else
                            {
                                lbl_USG.Text = "NA";
                            }
                        }
                        if (dt.Rows[i][3].ToString() == "CT scan Machines")
                        {

                            if (dt.Rows[i][4].ToString() != "")
                            {
                                lbl_CTMc.Text = dt.Rows[i][4].ToString();
                            }
                            else
                            {
                                lbl_CTMc.Text = "NA";
                            }
                        }
                        if (dt.Rows[i][3].ToString() == "CT scan")
                        {
                            if (dt.Rows[i][2].ToString() != "")
                            {
                                lbl_CT_Scans.Text = dt.Rows[i][2].ToString();
                            }
                            else
                            {
                                lbl_CT_Scans.Text = "NA";
                            }
                        }
                        if (dt.Rows[i][3].ToString() == "Pathologist")
                        {
                            if (dt.Rows[i][4].ToString() != "")
                            {
                                lbl_Patho_sanc0.Text = dt.Rows[i][4].ToString();
                            }
                            else
                            {
                                lbl_Patho_sanc0.Text = "NA";
                            }
                            if (dt.Rows[i][2].ToString() != "")
                            {
                                lbl_Patho_posted.Text = dt.Rows[i][2].ToString();
                            }
                            else
                            {
                                lbl_Patho_posted.Text = "NA";
                            }
                        }

                        if (dt.Rows[i][3].ToString() == "Pathologist")
                        {
                            if (dt.Rows[i][4].ToString() != "")
                            {
                                lbl_Patho_sanc0.Text = dt.Rows[i][4].ToString();
                            }
                            else
                            {
                                lbl_Patho_sanc0.Text = "NA";
                            }
                            if (dt.Rows[i][2].ToString() != "")
                            {
                                lbl_Patho_posted.Text = dt.Rows[i][2].ToString();
                            }
                            else
                            {
                                lbl_Patho_posted.Text = "NA";
                            }
                        }

                        if (dt.Rows[i][3].ToString() == "Pathology")
                        {
                            if (dt.Rows[i][4].ToString() != "")
                            {
                                lbl_lab_test.Text = dt.Rows[i][2].ToString();
                            }
                            else
                            {
                                lbl_lab_test.Text = "NA";
                            }
                        }
                    }
                }
                else
                {
                    // pnl_display.Visible = false;
                }
            }
            //else
            //{
            //    pnl_display.Visible = false;
            //}
        }
        protected void fill_by_Dist(string parameter, Label ctrl)
        {
            string query = "SELECT DISTINCT hrcDivision.divisionId, hrcDivision.division, hrcFacility.facilityName, hrcDistrict.district, hrcHealthReportCard.indicatorSubId, hrcIndicatorSub.IndicatorSubName,hrcHealthReportCard." + ddl_month.SelectedValue.ToString() + ", hrcFacility.facilityType FROM hrcFacility INNER JOIN hrcHealthReportCard ON hrcFacility.facilityCode = hrcHealthReportCard.facilityCode INNER JOIN hrcDivision INNER JOIN hrcDistrict ON hrcDivision.divisionId = hrcDistrict.divisionId ON hrcFacility.district = hrcDistrict.district INNER JOIN hrcIndicatorSub ON hrcHealthReportCard.indicatorSubId = hrcIndicatorSub.indicatorSubId WHERE(hrcDistrict.district = '" + ddl_dist.SelectedValue.ToString() + "') AND (hrcIndicatorSub.IndicatorSubName = '" + parameter + "') ";
            DataTable dt = obj.Return_Dt(query);
            int a = 0;
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int counter = 0;
                    if (dt.Rows[i][6].ToString() != "")
                    {
                        counter++;
                        a = a + Convert.ToInt32(dt.Rows[i][6].ToString());
                    }
                    lbl_counter.Text = " &nbsp; No.of Facilities Reported:- " + Convert.ToString(counter + 1);
                }
            }
            ctrl.Text = a.ToString();
        }
        protected void fill_by_Dist_sanc(string parameter, Label ctrl)
        {
            string query = "SELECT DISTINCT hrcDivision.divisionId, hrcHealthReportCard.sanctioned, hrcDivision.division, hrcFacility.facilityName, hrcDistrict.district, hrcHealthReportCard.indicatorSubId, hrcIndicatorSub.IndicatorSubName,hrcHealthReportCard." + ddl_month.SelectedValue.ToString() + ", hrcFacility.facilityType FROM hrcFacility INNER JOIN hrcHealthReportCard ON hrcFacility.facilityCode = hrcHealthReportCard.facilityCode INNER JOIN hrcDivision INNER JOIN hrcDistrict ON hrcDivision.divisionId = hrcDistrict.divisionId ON hrcFacility.district = hrcDistrict.district INNER JOIN hrcIndicatorSub ON hrcHealthReportCard.indicatorSubId = hrcIndicatorSub.indicatorSubId WHERE(hrcDistrict.district = '" + ddl_dist.SelectedValue.ToString() + "') AND (hrcIndicatorSub.IndicatorSubName = '" + parameter + "') ";
            DataTable dt = obj.Return_Dt(query);
            int a = 0;
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int counter = 0;
                    if (dt.Rows[i][1].ToString() != "")
                    {
                        counter++;
                        a = a + Convert.ToInt32(dt.Rows[i][1].ToString());
                    }
                    ctrl.Text = Convert.ToString(counter + 1) + " &nbsp; Facilities has filled..";
                }
            }
            ctrl.Text = a.ToString();
        }
        protected void fill_by_Division(string parameter, Label ctrl)
        {
            string query = "SELECT DISTINCT hrcDivision.divisionId, hrcDivision.division, hrcFacility.facilityName, hrcDistrict.district, hrcHealthReportCard.indicatorSubId, hrcIndicatorSub.IndicatorSubName,hrcHealthReportCard." + ddl_month.SelectedValue.ToString() + ", hrcFacility.facilityType FROM hrcFacility INNER JOIN hrcHealthReportCard ON hrcFacility.facilityCode = hrcHealthReportCard.facilityCode INNER JOIN hrcDivision INNER JOIN hrcDistrict ON hrcDivision.divisionId = hrcDistrict.divisionId ON hrcFacility.district = hrcDistrict.district INNER JOIN hrcIndicatorSub ON hrcHealthReportCard.indicatorSubId = hrcIndicatorSub.indicatorSubId WHERE(hrcDistrict.district = '" + ddl_dist.SelectedValue.ToString() + "') AND (hrcIndicatorSub.IndicatorSubName = '" + parameter + "') ";
            DataTable dt = obj.Return_Dt(query);
            int a = 0;
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int counter = 0;
                    if (dt.Rows[i][6].ToString() != "")
                    {
                        counter++;
                        a = a + Convert.ToInt32(dt.Rows[i][6].ToString());
                    }
                    lbl_counter.Text = " &nbsp; No.of Facilities Reported:- " + Convert.ToString(counter + 1);
                }
            }
            ctrl.Text = a.ToString();
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string query = "SELECT facilityCode,facilityType,facilityName, division,district FROM hrcFacility where facilityName='" + ddl_Facility.SelectedValue.ToString() + "' ";
            DataTable dt = obj.Return_Dt(query);
            if (ddl_Facility.SelectedValue.ToString() != "...Select Facility...")
            {
                lbl_month.Text = "";
                if (dt != null)
                {
                    Session["FacilityCode"] = dt.Rows[0][0].ToString();
                    Session["Year"] = "2013-2014";
                    if (dt.Rows[0][1].ToString() == "District Hospital")
                    {
                        Response.Redirect("hrcweb/frmDHReport.aspx");
                    }
                    else if (dt.Rows[0][1].ToString() == "CMO")
                    {
                        Response.Redirect("hrcweb/frmCMOReport.aspx");
                    }
                }
                else
                    Response.Write("Server problem..");
            }
            else
            {
                lbl_month.Text = "Select the Facility";
            }
        }
        protected void ddl_Facility_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void lnk_Surg0_Click1(object sender, EventArgs e)
        {

        }
        protected void view_total_Click(object sender, EventArgs e)
        {

        }
        //protected void lnk_Surg_Click1(object sender, EventArgs e)
        //{
        //    //string query = "SELECT SN,CompID,Name,Post,DO_posting,DOB,F_Name,level  FROM [uphsspHRC].[dbo].[Docperformance] where facility_type='" + ddl_Facility.SelectedValue.ToString() + "' and post='Surgeon'";
        //    //DataTable dt = obj.Return_Dt_local(query);
        //    //grd_surgeon.DataSource = dt;
        //    //grd_surgeon.DataBind();
        //}
        protected void lnk_view_Click1(object sender, EventArgs e)
        {
            fill_all_Dr_in_grdview();
            grdall.Visible = true;
            grd_dtls.Visible = false;
            //grd_details.Visible = true;
        }
        //protected void grd_total_dr_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    GridViewRow row = grd_total_dr.SelectedRow;
        //    string compID = row.Cells[1].Text;
        //    fill_detls(compID, lbl_grdmsg,grd_details);

        //}
        protected void fill_grid_by_Desig(string desig)
        {
            string query = "select compID as 'Computer ID',Name,f_name as 'Father Name',  Post from doct_profile where facility_type='" + ddl_Facility.SelectedValue.ToString() + "' and post='" + desig + "'";
            DataTable dt = obj.Return_Dt(query);
            // grd_total_dr.SelectedIndex = -1;
            if (dt != null)
            {

                //grd_total_dr.DataSource = dt;
                //grd_total_dr.DataBind();
            }
        }
        protected void fill_all_Dr_in_grdview()
        {
            if (ddl_Facility.SelectedValue.ToString() != "")
            {
                // string query = "SELECT   c.idno as 'Compter ID',c.Name,  b.facilityname as 'Place of Posting', c.degree2 as Degree, e.newpostname as Designation  FROM CURRENTPOSTED A, HRCFACILITY B,hospitalname d, PERSONALDETAILS C, post e WHERE A.POPOSTING=B.NICHOSPITALID AND A.IDNO=C.IDNO and a.poposting=d.sno and e.newpostid = a.desigid  AND A.POPOSTING='" + ddl_Facility.SelectedValue.ToString() + "'  order by c.name";
                // string query = "SELECT   c.idno as 'Compter ID',c.Name,  b.facilityname as 'Place of Posting', c.degree2 as Degree, e.newpostname as Designation  FROM CURRENTPOSTED A, HRCFACILITY B,hospitalname d, PERSONALDETAILS C, post e WHERE A.POPOSTING=B.NICHOSPITALID AND A.IDNO=C.IDNO and a.poposting=d.sno and e.newpostid = a.desigid  AND A.POPOSTING='" + ddl_Facility.SelectedValue.ToString() + "' order by c.name";
                string query = " SELECT A.idno AS 'Computer ID', C.name AS Name, C.category, C.degree1 as Degree, post.newpostname as Designation FROM currentposted AS A INNER JOIN hrcFacility AS B ON A.poposting = B.NICHOSPITALID INNER JOIN personaldetails AS C ON A.idno = C.idno INNER JOIN post ON A.postid = post.newpostid WHERE(A.poposting = '" + ddl_Facility.SelectedValue.ToString() + "')";

                DataTable dt = obj.Return_Dt(query);
                if (dt != null)
                {
                    grdall.DataSource = dt;
                    grdall.DataBind();
                    grdall.SelectedIndex = -1;
                }
            }
            //else
            //    lbl_grdmsg.Text = "Select the Facility";
        }
        protected void Button1_Click1(object sender, EventArgs e)
        {
            fill_sanctioned_value(ddl_Facility.SelectedValue.ToString(), lbl_total_Sanc);
        }
        protected void lnk_Surg_Click2(object sender, EventArgs e)
        {
            fill_all_Dr_in_grdview();
        }
        protected void fill_detls(string compID, Label lbl, GridView detail)
        {
            detail.Visible = true;
            string query = "SELECT personaldetails.name as Name, dutytype.dutyname as Duty, SUM(mpr.cases) AS 'No of cases' FROM  mpr INNER JOIN dutytype ON mpr.dutyid = dutytype.dutyid INNER JOIN personaldetails ON mpr.compid = personaldetails.idno WHERE (mpr.compid = '" + compID + "') AND (MONTH(mpr.date) = '" + ddl_month.SelectedValue.ToString() + "') AND (YEAR(mpr.date) = '" + ddl_year.SelectedValue.ToString() + "')GROUP BY  dutytype.dutyname, personaldetails.name";
            DataTable dt = obj.Return_Dt1(query);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    lbl.Text = "";
                    detail.DataSource = dt;
                    detail.DataBind();
                }
                else
                {
                    lbl.Text = "MPR not filled";
                }
            }
        }
        protected void fill_sanctioned_value(string facility_name, Label lbl)
        {
            //string query = "SELECT SUM(hospitalrecord.posts) AS Total, hospitalname.hname FROM  hospitalrecord INNER JOIN hospitalname ON hospitalrecord.hnameid = hospitalname.htype GROUP BY hospitalname.hname HAVING (hospitalname.hname = N'S.R.N. Hospital Allahabad')";


            string query = "SELECT SUM(hospitalrecord.posts) AS Total, hospitalrecord.hnameid, hospitalname.hname, post.newpostname, hospitaldistrict.districtname, hospitalname.districtid FROM         hospitalrecord INNER JOIN hospitalname ON hospitalrecord.hnameid = hospitalname.htype INNER JOIN  post ON hospitalrecord.postid = post.newpostid INNER JOIN  hospitaldistrict ON hospitalname.districtid = hospitaldistrict.districtid GROUP BY hospitalrecord.posts, hospitalrecord.hnameid, hospitalname.hname, hospitalrecord.postid, post.newpostname, hospitaldistrict.districtname,  hospitalname.districtid HAVING      (hospitalname.hname = '" + facility_name + "') AND (hospitaldistrict.districtname = '" + ddl_dist.SelectedValue.ToString() + "')";
            DataTable dt = obj.Return_Dt(query);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    lbl.Text = dt.Rows[0][0].ToString();
                }
                else
                {
                    lbl.Text = "";
                }
            }

        }
        protected void FILL_POSTED_dr(string facility_code, LinkButton lbl)
        {
            string query = "SELECT COUNT(* )FROM CURRENTPOSTED A, HRCFACILITY B, PERSONALDETAILS C WHERE A.POPOSTING=B.NICHOSPITALID AND A.IDNO=C.IDNO AND A.POPOSTING='" + facility_code + "'";
            DataTable dt = obj.Return_Dt(query);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    lbl.Text = dt.Rows[0][0].ToString();
                }
                else
                {
                    lbl.Text = "NA";
                }
            }


        }
        protected void FILL_SANCTIONED(string facility_code, string desig, Label lbl)
        {
            string query = "select FACILITYNAME, FACILITYCODE, SANCTIONED from hrc_all WHERE INDICATORSUBNAME='" + desig + "' AND sno='" + facility_code + "'";
            DataTable dt = obj.Return_Dt(query);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0][2].ToString() != "")
                    {
                        lbl.Text = dt.Rows[0][2].ToString();
                    }
                    else
                    {
                        lbl.Text = "NA";
                    }
                }
                else
                {
                    lbl.Text = "NA";
                }
            }
        }
        protected void sanctioned_all_sugeon(string facility_code, Label lbl)
        {
            string query = " select sum(cast( sanctioned as float)) from  hrc_all WHERE INDICATORSUBNAME like '% surgeon' AND sno='" + facility_code + "'";
            DataTable dt = obj.Return_Dt(query);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    lbl.Text = dt.Rows[0][0].ToString();
                }
                else
                {
                    lbl.Text = "NA";
                }
            }

        }
        protected void FILL_all_dr(string facility_code, LinkButton lbl)
        {
            string query = "SELECT COUNT(* )FROM CURRENTPOSTED A, HRCFACILITY B, PERSONALDETAILS C WHERE A.POPOSTING=B.NICHOSPITALID AND A.IDNO=C.IDNO AND A.POPOSTING='" + facility_code + "'";
            DataTable dt = obj.Return_Dt(query);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    lbl.Text = dt.Rows[0][0].ToString();
                }
                else
                {
                    lbl.Text = "0";
                }
            }


        }
        protected void posted_all_sugeon(string facility_code, LinkButton lbl)
        {
            string query = " SELECT count(*) FROM CURRENTPOSTED A, HRCFACILITY B, PERSONALDETAILS C, post  d WHERE a.desigid=d.newpostid and A.POPOSTING=B.NICHOSPITALID AND A.IDNO=C.IDNO AND A.POPOSTING='" + facility_code + "' and d.newpostname like'%surgeon'";
            DataTable dt = obj.Return_Dt(query);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    lbl.Text = dt.Rows[0][0].ToString();
                }
                else
                {
                    lbl.Text = "NA";
                }
            }
        }
        protected void fill_posted_Dr(string facility_code, string desig, LinkButton lbl)
        {
            string query = "SELECT count(*) FROM CURRENTPOSTED A, HRCFACILITY B, PERSONALDETAILS C, post  d WHERE a.desigid=d.newpostid and A.POPOSTING=B.NICHOSPITALID AND A.IDNO=C.IDNO AND A.POPOSTING='" + facility_code + "' and d.newpostname ='" + desig + "'";
            DataTable dt = obj.Return_Dt(query);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    lbl.Text = dt.Rows[0][0].ToString();
                }
                else
                {
                    lbl.Text = "NA";
                }
            }
        }
        protected void show_alert(Label sanctioned, LinkButton posted, Image img, LinkButton lnk)
        {
            if (sanctioned.Text != "" & posted.Text != "")
            {
                //lnk.Visible = true;
                if (sanctioned.Text != null & posted.Text != null & sanctioned.Text != "NA" & posted.Text != "NA")
                {
                    if (Convert.ToInt32(sanctioned.Text) != Convert.ToInt32(posted.Text))
                    {
                        img.Visible = true;
                    }
                    else
                    {
                        img.Visible = false;
                    }
                }
                // lnk.Visible = false;
            }
        }
        protected void PERFORMANCE(string facility_code, string param, string month, Label lbl)
        {
            string query = "select indicatorsubName, sanctioned," + month + " from hrc_all   hrc_all WHERE INDICATORSUBNAME ='" + param + "' AND sno='" + facility_code + "'  and year='" + ddl_year.SelectedValue.ToString() + "'";
            DataTable dt = obj.Return_Dt(query);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0][2].ToString() != "")
                    {
                        lbl.Text = dt.Rows[0][2].ToString();
                    }
                    else
                    {
                        lbl.Text = "0";
                    }
                }
                else
                {
                    lbl.Text = "NA";
                }
            }
        }
        protected void infra_value(string facility_code, string infra_name, Label lbl)
        {
            string query = "select sanctioned from hrc_all WHERE INDICATORSUBNAME ='" + infra_name + "' AND sno='" + facility_code + "'";
            DataTable dt = obj.Return_Dt(query);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0][0].ToString() != "")
                    {
                        lbl.Text = dt.Rows[0][0].ToString();
                    }
                    else
                    {
                        lbl.Text = "0";
                    }
                }
                else
                {
                    lbl.Text = "NA";
                }
            }
        }
        protected void view_by_desig(string facility_code, string desig, GridView grd)
        {
            if (facility_code != "")
            {
                string query = "";
                //if (desig == "Surgeon")
                //{
                //    query = "SELECT  c.idno as 'Compter ID',c.Name,  b.facilityname as 'Place of Posting', c.degree2 as Degree, e.newpostname as Designation  FROM CURRENTPOSTED A, HRCFACILITY B,hospitalname d, PERSONALDETAILS C, post e WHERE A.POPOSTING=B.NICHOSPITALID AND A.IDNO=C.IDNO and a.poposting=d.sno and e.newpostid = a.desigid  AND A.POPOSTING='" + facility_code + "'and  e.newpostname='like %" + desig + "'";
                //}
                //else
                //{
                query = "SELECT   c.idno as 'Compter ID',c.Name,  c.degree2 as Degree, e.newpostname as Designation  FROM CURRENTPOSTED A, HRCFACILITY B,hospitalname d, PERSONALDETAILS C, post e WHERE A.POPOSTING=B.NICHOSPITALID AND A.IDNO=C.IDNO and a.poposting=d.sno and e.newpostid = a.desigid  AND A.POPOSTING='" + facility_code + "'and  e.newpostname='" + desig + "'";
                // }
                DataTable dt = obj.Return_Dt(query);
                if (dt != null)
                {
                    grd.DataSource = dt;
                    grd.DataBind();
                    grd.SelectedIndex = -1;
                }
            }
            //else
            //    lbl_grdmsg.Text = "Select the Facility";
        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            ////grdall.Visible = true;
            ////grd_dtls.Visible = false;
            ////   view_by_desig(ddl_Facility.SelectedValue.ToString(), "Gynaecologist", grdall);
            //view_by_desig(ddl_Facility.SelectedValue.ToString(), "Gynaecologist", grd_Gyna);

        }
        protected void radio_Click(object sender, EventArgs e)
        {
            grdall.Visible = true;
            grd_dtls.Visible = false;
            //view_by_desig(ddl_Facility.SelectedValue.ToString(), "Radiologist", grd_radio);
            view_by_desig(ddl_Facility.SelectedValue.ToString(), "Radiologist", grdall);
        }
        //protected void grd_Gyna_SelectedIndexChanged1(object sender, EventArgs e)
        //{
        //    GridViewRow row = grd_Gyna.SelectedRow;
        //    string compID = row.Cells[1].Text;
        //    fill_detls(compID, msg_Gyn,grd_gyna1);
        //}
        //protected void grd_radio_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    GridViewRow row = grd_radio.SelectedRow;
        //    string compID = row.Cells[1].Text;
        //    fill_detls(compID, msg_radio,grd_radio1);
        //}
        //protected void grd_patho_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    GridViewRow row = grd_patho.SelectedRow;
        //    string compID = row.Cells[1].Text;
        //    fill_detls(compID, msg_patho,grd_pahto1);
        //}
        protected void patho_Click(object sender, EventArgs e)
        {
            grdall.Visible = true;
            //view_by_desig(ddl_Facility.SelectedValue.ToString(), "Pathologist", grd_patho);
            view_by_desig(ddl_Facility.SelectedValue.ToString(), "Pathologist", grdall);
        }
        //protected void grd_anas_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //  //  GridViewRow row = grd_anas.SelectedRow;
        //    string compID = row.Cells[1].Text;
        //    fill_detls(compID, msg_anae,grd_ana1);
        //}
        protected void anaes_Click(object sender, EventArgs e)
        {
            grdall.Visible = true;
            //view_by_desig(ddl_Facility.SelectedValue.ToString(), "Anaesthetist ", grd_anas);
            view_by_desig(ddl_Facility.SelectedValue.ToString(), "Anaesthetist ", grdall);
            grd_dtls.Visible = false;
        }
        protected void surgeon_Click(object sender, EventArgs e)
        {
            // view_by_desig(ddl_Facility.SelectedValue.ToString(), "Surgeon ", grd_anas);
        }
        protected void grd_surg3_SelectedIndexChanged(object sender, EventArgs e)
        {
            // view_by_desig(ddl_Facility.SelectedValue.ToString(), "Surgeon ", grd_anas);
        }
        protected void grd_surg_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GridViewRow row = grdsurg.SelectedRow;
            //string compID = row.Cells[1].Text;
            //fill_detls(compID, msg_surg,grdsurg1);
        }
        protected void surgeon_Click1(object sender, EventArgs e)
        {
            grdall.Visible = true;
            grd_dtls.Visible = false;
            //view_surgeon(ddl_Facility.SelectedValue.ToString(), grd_anas);
            if (ddl_Facility.SelectedValue.ToString() != "")
            {

                string query = "SELECT c.idno as 'Compter ID',c.Name, c.degree2 as Degree, e.newpostname as Designation  FROM CURRENTPOSTED A, HRCFACILITY B,hospitalname d, PERSONALDETAILS C, post e WHERE A.POPOSTING=B.NICHOSPITALID AND A.IDNO=C.IDNO and a.poposting=d.sno and e.newpostid = a.desigid  AND A.POPOSTING='" + ddl_Facility.SelectedValue.ToString() + "'and  e.newpostname like '% surgeon'";
                DataTable dt = obj.Return_Dt(query);
                if (dt != null)
                {
                    //grdsurg.DataSource = dt;
                    //grdsurg.DataBind();
                    //grd.SelectedIndex = -1;

                    grdall.DataSource = dt;
                    grdall.DataBind();
                    grdall.SelectedIndex = -1;
                }
            }
            //else
            //    lbl_grdmsg.Text = "Select the Facility";
        }
        protected void clear_all()
        {
            grdall.Visible = false;
            grd_dtls.Visible = false;

            //grd_Gyna.Visible = false;
            //grd_gyna1.Visible = false;

            //grd_patho.Visible = false;
            //grd_pahto1.Visible = false;

            //grd_radio.Visible = false;
            //grd_radio1.Visible = false;

            //grdsurg1.Visible = false;
            //grdsurg.Visible = false;

            //grd_total_dr.Visible = false;
            //grd_details.Visible = false;

        }
        protected void ddl_Facility_SelectedIndexChanged1(object sender, EventArgs e)
        {
            clear_all();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //if (Convert.ToInt32(ddl_month.SelectedValue.ToString()) < 4 & ddl_year.SelectedValue.ToString() == "2013-2014")
            //{
            //    lbl_month.Text = "Data is not Available for this month";
            //    mainpnl.Visible = false;
            //}
            //else if (Convert.ToInt32(ddl_month.SelectedValue.ToString()) >= System.DateTime.Now.Month & ddl_year.SelectedValue.ToString()=="2014-2015")//System.DateTime.Now.Year)
            //{
            //    lbl_month.Text = "Incorrect month..";
            //    mainpnl.Visible = false;
            //}
            //else
            //{
            if (ddl_month.SelectedValue.ToString() != "Select Month")
            {
                mainpnl.Visible = true;
                lblMPR_msg.Text = "";
                lbl_month.Text = "";
                clear_all();
                if (ddl_Facility.SelectedValue.ToString() != "All")
                {
                    FILL_POSTED_dr(ddl_Facility.SelectedValue.ToString(), lbl_posted);
                    FILL_all_dr(ddl_Facility.SelectedValue.ToString(), lbl_posted);
                    fill_posted_Dr(ddl_Facility.SelectedValue.ToString(), "Anaesthetist", lbl_anas_posted);
                    fill_posted_Dr(ddl_Facility.SelectedValue.ToString(), "Gynaecologist", lbl_Gyn_posted);
                    fill_posted_Dr(ddl_Facility.SelectedValue.ToString(), "Radiologist", lbl_Rad_posted);
                    fill_posted_Dr(ddl_Facility.SelectedValue.ToString(), "Pathologist", lbl_Patho_posted);
                    posted_all_sugeon(ddl_Facility.SelectedValue.ToString(), lbl_sur_posted);

                    FILL_SANCTIONED(ddl_Facility.SelectedValue.ToString(), "Total doctors", lbl_total_Sanc);
                    FILL_SANCTIONED(ddl_Facility.SelectedValue.ToString(), "Anesthestists", lbl_anae_sanc);
                    FILL_SANCTIONED(ddl_Facility.SelectedValue.ToString(), "Gynaecologist", lbl_Gy_sanc);
                    FILL_SANCTIONED(ddl_Facility.SelectedValue.ToString(), "Pathologist", lbl_Patho_sanc0);
                    FILL_SANCTIONED(ddl_Facility.SelectedValue.ToString(), "Radiologist", lbl_Rad_sanc);
                    ////////////////////////////////////////////////////////////////////////////////////////
                    FILL_SANCTIONED(ddl_Facility.SelectedValue.ToString(), "Generator", lbl_generator);
                    FILL_SANCTIONED(ddl_Facility.SelectedValue.ToString(), "Ambulances", lbl_ambulances);
                    FILL_SANCTIONED(ddl_Facility.SelectedValue.ToString(), "Blood Bank", lbl_Bloodbnk);
                    ////////////////////////////////////////////////////////////////////////////////////////
                    sanctioned_all_sugeon(ddl_Facility.SelectedValue.ToString(), lbl_sur_sanc);
                    PERFORMANCE(ddl_Facility.SelectedValue.ToString(), "OPD - New", ddl_month.SelectedItem.ToString(), lbl_OPD);
                    PERFORMANCE(ddl_Facility.SelectedValue.ToString(), "OPD - Old", ddl_month.SelectedItem.ToString(), lbl_OPD_old);
                    PERFORMANCE(ddl_Facility.SelectedValue.ToString(), "IPD", ddl_month.SelectedItem.ToString(), lbl_IPD);
                    PERFORMANCE(ddl_Facility.SelectedValue.ToString(), "Major surgery", ddl_month.SelectedItem.ToString(), lbl_major);
                    PERFORMANCE(ddl_Facility.SelectedValue.ToString(), "Minor surgery", ddl_month.SelectedItem.ToString(), lbl_minor);
                    PERFORMANCE(ddl_Facility.SelectedValue.ToString(), "Normal Delivery", ddl_month.SelectedItem.ToString(), lbl_normal);
                    PERFORMANCE(ddl_Facility.SelectedValue.ToString(), "Cessarian Delivery", ddl_month.SelectedItem.ToString(), lbl_Ceser);
                    PERFORMANCE(ddl_Facility.SelectedValue.ToString(), "MTP", ddl_month.SelectedItem.ToString(), lbl_MTP);
                    PERFORMANCE(ddl_Facility.SelectedValue.ToString(), "Maternal Deaths", ddl_month.SelectedItem.ToString(), lbl_mater_death);
                    PERFORMANCE(ddl_Facility.SelectedValue.ToString(), "Pathology", ddl_month.SelectedItem.ToString(), lbl_lab_test);
                    PERFORMANCE(ddl_Facility.SelectedValue.ToString(), "Xray", ddl_month.SelectedItem.ToString(), lbl_Xrays);
                    PERFORMANCE(ddl_Facility.SelectedValue.ToString(), "CT scan", ddl_month.SelectedItem.ToString(), lbl_CT_Scans);
                    PERFORMANCE(ddl_Facility.SelectedValue.ToString(), "Female Sterlization", ddl_month.SelectedItem.ToString(), lbl_female_ster);
                    PERFORMANCE(ddl_Facility.SelectedValue.ToString(), "USG", ddl_month.SelectedItem.ToString(), lbl_USG);
                    PERFORMANCE(ddl_Facility.SelectedValue.ToString(), "Female Sterlization", ddl_month.SelectedItem.ToString(), lbl_female_ster);
                    PERFORMANCE(ddl_Facility.SelectedValue.ToString(), "Female Sterlization", ddl_month.SelectedItem.ToString(), lbl_female_ster);
                    infra_value(ddl_Facility.SelectedValue.ToString(), "Xray Machines", lbl_Xray_Mc);
                    infra_value(ddl_Facility.SelectedValue.ToString(), "Bed occupancy rate", lbl_Beds);
                    infra_value(ddl_Facility.SelectedValue.ToString(), "Operation Theatre", lbl_OT);
                    infra_value(ddl_Facility.SelectedValue.ToString(), "USG Machines", lbl_USGMc);
                    infra_value(ddl_Facility.SelectedValue.ToString(), "CT scan Machines", lbl_CTMc);
                    ///////////////////////////////////////////////////////////////////////////////////////////////
                    infra_value(ddl_Facility.SelectedValue.ToString(), "Generator", lbl_generator0);
                    infra_value(ddl_Facility.SelectedValue.ToString(), "Ambulances", lbl_ambulances0);
                    infra_value(ddl_Facility.SelectedValue.ToString(), "Blood Bank", lbl_Bloodbnk0);
                    PERFORMANCE(ddl_Facility.SelectedValue.ToString(), "Indents against Rate Contract", ddl_month.SelectedItem.ToString(), lblMed_raised);
                    PERFORMANCE(ddl_Facility.SelectedValue.ToString(), "Indents against Rate Contract for which supply not completed or made", ddl_month.SelectedItem.ToString(), lblMed_pend);
                    PERFORMANCE(ddl_Facility.SelectedValue.ToString(), "Indents made for Local Purchase", ddl_month.SelectedItem.ToString(), lblMed_local);
                    ///////////////////////////////////////////////////////////////////////////////////////////////

                    //infra_value(ddl_Facility.SelectedValue.ToString(), "Xray", lbl_Xray_Mc);
                    show_alert(lbl_anae_sanc, lbl_anas_posted, img_alert_anae, anaes);
                    show_alert(lbl_total_Sanc, lbl_posted, img_alert_dr, lnk_view);
                    show_alert(lbl_Gy_sanc, lbl_Gyn_posted, img_alert_Gy, gyna);
                    show_alert(lbl_Rad_sanc, lbl_Rad_posted, img_alert_Radio, radio);
                    show_alert(lbl_Patho_sanc0, lbl_Patho_posted, img_alert_path, patho);
                }
                else
                {
                    Fill_By_Facility();
                }
                //}
                //else
                //{
                //    lbl_month.Text = "Select the Month......";
                //}
            }
        }
        protected void view_surgeon(string facility_code, GridView grd)
        {
            if (facility_code != "")
            {

                string query = "SELECT   c.idno as 'Compter ID',c.Name,  c.degree2 as Degree, e.newpostname as Designation  FROM CURRENTPOSTED A, HRCFACILITY B,hospitalname d, PERSONALDETAILS C, post e WHERE A.POPOSTING=B.NICHOSPITALID AND A.IDNO=C.IDNO and a.poposting=d.sno and e.newpostid = a.desigid  AND A.POPOSTING='" + facility_code + "'and  e.newpostname like '% surgeon'";
                DataTable dt = obj.Return_Dt(query);
                if (dt != null)
                {
                    grd.DataSource = dt;
                    grd.DataBind();
                    grd.SelectedIndex = -1;
                }
            }
        }


        protected void gyna_Click(object sender, EventArgs e)
        {

        }
        protected void grdall_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = grdall.SelectedRow;
            string compID = row.Cells[1].Text;
            fill_detls(compID, lblMPR_msg, grd_dtls);

        }

        protected void get_budget(string indi_code, Label lbl, string facility, string month)
        {
            string query = "SELECT hrcHealthReportCard.id, hrcHealthReportCard.indicatorSubId, hrcHealthReportCard." + month + ", hrcFacility.facilityName, hrcFacility.NICHOSPITALID FROM hrcHealthReportCard INNER JOIN hrcFacility ON hrcHealthReportCard.facilityCode = hrcFacility.facilityCode WHERE ( hrcHealthReportCard.indicatorSubId ='" + indi_code + "') and nichospitalid='" + facility + "'";

            DataTable dt = obj.Return_Dt(query);
            if (dt != null)
            {
                lbl.Text = dt.Rows[0][2].ToString();
            }
            else
                lbl.Text = "NA";
        }
        protected void lbl_Patho_posted_Click(object sender, EventArgs e)
        {
            grdall.Visible = true;
            //view_by_desig(ddl_Facility.SelectedValue.ToString(), "Pathologist", grd_patho);
            view_by_desig(ddl_Facility.SelectedValue.ToString(), "Pathologist", grdall);
        }
        protected void check_Date_Year()
        {
            int month = System.DateTime.Now.Month;
            int year = System.DateTime.Now.Year;
            if (Convert.ToInt32(ddl_year.SelectedValue.ToString()) > year & Convert.ToInt32(ddl_month.SelectedValue.ToString()) > month)
            {
                lbl_month.Text = "select correct year";
                ddl_year.Focus();
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //string str = ddl_month.SelectedItem.ToString();
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    e.Row.Attributes["onclick"] = "openWin('" + e.Row.Cells[1].Text +"&Year="+ ddl_year.SelectedValue.ToString()+"&Month="+ ddl_month.SelectedValue.ToString()+"')";
            //    e.Row.Attributes["style"] = "cursor:pointer";
            //}
        }
        protected void lbl_posted_Click(object sender, EventArgs e)
        {
            fill_all_Dr_in_grdview();
            grdall.Visible = true;
            grd_dtls.Visible = false;
        }
        protected void lbl_Gyn_posted_Click(object sender, EventArgs e)
        {
            grdall.Visible = true;
            grd_dtls.Visible = false;
            view_by_desig(ddl_Facility.SelectedValue.ToString(), "Gynaecologist", grdall);
        }
        protected void lbl_Rad_posted_Click(object sender, EventArgs e)
        {
            grdall.Visible = true;
            grd_dtls.Visible = false;
            view_by_desig(ddl_Facility.SelectedValue.ToString(), "Radiologist", grdall);
        }
        protected void lbl_anas_posted_Click(object sender, EventArgs e)
        {
            grdall.Visible = true;
            view_by_desig(ddl_Facility.SelectedValue.ToString(), "Anaesthetist ", grdall);
            grd_dtls.Visible = false;
        }
        protected void lbl_sur_posted_Click(object sender, EventArgs e)
        {
            grdall.Visible = true;
            grd_dtls.Visible = false;
            if (ddl_Facility.SelectedValue.ToString() != "")
            {

                string query = "SELECT c.idno as 'Compter ID',c.Name, c.degree2 as Degree, e.newpostname as Designation  FROM CURRENTPOSTED A, HRCFACILITY B,hospitalname d, PERSONALDETAILS C, post e WHERE A.POPOSTING=B.NICHOSPITALID AND A.IDNO=C.IDNO and a.poposting=d.sno and e.newpostid = a.desigid  AND A.POPOSTING='" + ddl_Facility.SelectedValue.ToString() + "'and  e.newpostname like '%surgeon'";
                DataTable dt = obj.Return_Dt(query);
                if (dt != null)
                {
                    grdall.DataSource = dt;
                    grdall.DataBind();
                    grdall.SelectedIndex = -1;
                }
            }
        }
        protected void grdall_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string str = ddl_month.SelectedItem.ToString();
            string y = ddl_year.SelectedValue.ToString();
            int year = 0;
            if (str == "January" | str == "February" | str == "March")
            {
                year = Convert.ToInt32(y.Substring(0, 4));
                year = year + 1;
            }
            else
            {
                year = Convert.ToInt32(y.Substring(0, 4));
            }


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = "openWin('" + e.Row.Cells[1].Text + "&Year=" + year + "&Month=" + ddl_month.SelectedValue.ToString() + "')";
                e.Row.Attributes["style"] = "cursor:pointer";
            }
        }

        protected void LinkButton1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/Proforma2/RepOption.aspx");
        }

    }
}