using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewWebApp.payrole
{
    public partial class REPORT : System.Web.UI.Page
    {
        Class1 c = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //c.gv(GridView1, "SELECT districtname, MBBS, Medicine, Anaesthesia, Surgery, GynObs, Gynaecology, Paediatrics, Radiology, Orthopedics, Cardiology, ENT, SkinVD, PublicHealth, TBChestDis, Neurology, ChestDis FROM SPECILITYVIEW");
                //c.ddl5(district, "select * from hospitaldistrict order by districtname", "districtname", "districtid");
                //c.ddl5(hname, "select * from hospitalname order by hname", "hname", "sno");
                //c.ddl5(splztion, "select * from specialization order by  spname", "spname", "spid");

            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //if (district.SelectedIndex != 0)
            //{


            //    c.gv(GridView1, "SELECT districtname, Medicine, Anaesthesia, surgery, GynObs, Gynaecology, Paediatrics, Radiology, orthopedics, ENT, Cardiology, SkinVD, PublicHealth, MBBS FROM SPECILITYVIEW where districid=" + district.SelectedValue + "");




            //}
            //else
            //{
            //    c.gv(GridView1, "SELECT districtname, Medicine, Anaesthesia, surgery, GynObs, Gynaecology, Paediatrics, Radiology, orthopedics, ENT, Cardiology, SkinVD, PublicHealth, MBBS FROM SPECILITYVIEW");

            //}



            //if (splztion.SelectedIndex == 0 && hname.SelectedIndex == 0 && district.SelectedIndex == 0)
            //{
            //    c.gv(GridView1, "SELECT WORKINGDOCTOR.idno, WORKINGDOCTOR.name, personaldetails.name AS Expr1, WORKINGDOCTOR.did, WORKINGDOCTOR.sid, WORKINGDOCTOR.qid, WORKINGDOCTOR.Desigid, WORKINGDOCTOR.postid, WORKINGDOCTOR.districtid, WORKINGDOCTOR.poposting, hospitalname.hname, specialization.spname,  post.newpostname, hospitaldistrict.districtname, Qualification.QuaName FROM  WORKINGDOCTOR INNER JOIN personaldetails ON WORKINGDOCTOR.idno = personaldetails.idno INNER JOIN hospitalname ON WORKINGDOCTOR.poposting = hospitalname.sno INNER JOIN specialization ON WORKINGDOCTOR.sid = specialization.spid INNER JOIN post ON WORKINGDOCTOR.postid = post.newpostid INNER JOIN hospitaldistrict ON WORKINGDOCTOR.districtid = hospitaldistrict.districtid INNER JOIN Qualification ON WORKINGDOCTOR.qid = Qualification.QuaId WHERE(WORKINGDOCTOR.did <> N'MBBS')");

            //}
            //else
            //{
            //    if(splztion.SelectedIndex==0 && hname.SelectedIndex==0)
            //    {
            //        c.gv(GridView1, "SELECT WORKINGDOCTOR.idno, WORKINGDOCTOR.name, personaldetails.name AS Expr1, WORKINGDOCTOR.did, WORKINGDOCTOR.sid, WORKINGDOCTOR.qid, WORKINGDOCTOR.Desigid, WORKINGDOCTOR.postid, WORKINGDOCTOR.districtid, WORKINGDOCTOR.poposting, hospitalname.hname, specialization.spname,  post.newpostname, hospitaldistrict.districtname, Qualification.QuaName FROM  WORKINGDOCTOR INNER JOIN personaldetails ON WORKINGDOCTOR.idno = personaldetails.idno INNER JOIN hospitalname ON WORKINGDOCTOR.poposting = hospitalname.sno INNER JOIN specialization ON WORKINGDOCTOR.sid = specialization.spid INNER JOIN post ON WORKINGDOCTOR.postid = post.newpostid INNER JOIN hospitaldistrict ON WORKINGDOCTOR.districtid = hospitaldistrict.districtid INNER JOIN Qualification ON WORKINGDOCTOR.qid = Qualification.QuaId WHERE(WORKINGDOCTOR.did <> N'MBBS') and WORKINGDOCTOR.districtid=" + district.SelectedValue + "");
            //    }
            //    else
            //    {
            //        if (splztion.SelectedIndex == 0)
            //        {
            //            c.gv(GridView1, "SELECT WORKINGDOCTOR.idno, WORKINGDOCTOR.name, personaldetails.name AS Expr1, WORKINGDOCTOR.did, WORKINGDOCTOR.sid, WORKINGDOCTOR.qid, WORKINGDOCTOR.Desigid, WORKINGDOCTOR.postid, WORKINGDOCTOR.districtid, WORKINGDOCTOR.poposting, hospitalname.hname, specialization.spname,  post.newpostname, hospitaldistrict.districtname, Qualification.QuaName FROM  WORKINGDOCTOR INNER JOIN personaldetails ON WORKINGDOCTOR.idno = personaldetails.idno INNER JOIN hospitalname ON WORKINGDOCTOR.poposting = hospitalname.sno INNER JOIN specialization ON WORKINGDOCTOR.sid = specialization.spid INNER JOIN post ON WORKINGDOCTOR.postid = post.newpostid INNER JOIN hospitaldistrict ON WORKINGDOCTOR.districtid = hospitaldistrict.districtid INNER JOIN Qualification ON WORKINGDOCTOR.qid = Qualification.QuaId WHERE(WORKINGDOCTOR.did <> N'MBBS') and WORKINGDOCTOR.districtid=" + district.SelectedValue + " and hname=" + hname.SelectedValue + "");

            //        }
            //    }
            //}
        }
        protected void district_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            //c.gv1(GridView2,"SELECT * FROM (SELECT dono, spname FROM specializdoctor) AS s PIVOT (max(dono) FOR [spname] IN (MBBS, Medicine, Anaesthesia, GynObs, Gynaecology, Paediatrics, Radiology, Surgery,  Orthopedics, ENT, Opthalmology, SkinVD, TBChestDis, ChestDis, PublicHealth, SPM)) AS new");
            //c.gv(GridView1, "SELECT DistrictName, MBBS, Medicine, Anaesthesia, GynObs, Gynaecology, Paediatrics, Radiology, Surgery, Orthopedics, ENT, Opthalmology, SkinVD, TBChestDis,Pathology,ChestDis, PublicHealth, SPM FROM SPECILITYVIEW");

            c.gv(GridView1, "SELECT DistrictName, MBBS, Medicine, Anaesthesia, GynObs, Gynaecology, Paediatrics, Radiology, Surgery, Orthopedics, ENT, Opthalmology, SkinVD, TBChestDis, Pathology, ChestDis, PublicHealth, SPM FROM SPECILITYVIEW");

            //sp2.Visible = false;
            //sp3.Visible = false;
            //sp2.Enabled = false;
            //sp3.Enabled = false;


        }
        protected void Button1_Click1(object sender, EventArgs e)
        {
            //c.gv1(GridView2,"SELECT * FROM (SELECT     dono, spname FROM  specializdoctor) AS s PIVOT (max(dono) FOR [spname] IN (Anatomy, Cardiology, CardiacSurgery, ChestSurgery, Nephrology, Neurology, NeuroSurgery, PlasticSurgery, Psychiatry, PsychiatricMedicine, TropicalMedHeal, Urology, IndustrialHealth, Radiotherapy, Pharmacology, MedicalVirology)) AS new");

            c.gv(GridView1, "SELECT DistrictName, Anatomy, Cardiology, CardiacSurgery, ChestSurgery, Nephrology, Neurology, NeuroSurgery, PlasticSurgery, Psychiatry, PsychiatricMedicine, TropicalMedHeal, Urology, IndustrialHealth, Radiotherapy, Pharmacology, MedicalVirology FROM SP2");

            //sp1.Visible = false;
            //sp3.Visible = false;
            //sp1.Enabled = false;
            //sp3.Enabled = false;


        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            //c.gv1(GridView2,"SELECT * FROM (SELECT  dono,spname  FROM specializdoctor) AS s PIVOT (max(dono) FOR [spname] IN (Anatomy, Cardiology, CardiacSurgery, ChestSurgery, Nephrology, Neurology, NeuroSurgery, PlasticSurgery, Psychiatry, PsychiatricMedicine, TropicalMedHeal, Urology, IndustrialHealth, Radiotherapy, Pharmacology, MedicalVirology)) AS new");


            c.gv(GridView1, "SELECT DistrictName, Endocrinology, CommunityDentistry, DentalScience, Endodontics, Orthodontics, Prothodontics, Pedodontics, Periodontics, Physiology, OralPathology, OralMedecinRadiology, Jurisprudence FROM SP3");
            //sp2.Visible = false;
            //sp1.Visible = false;
            //sp2.Enabled = false;
            //sp1.Enabled = false;


        }
    }
}