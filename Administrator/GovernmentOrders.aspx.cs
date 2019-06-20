using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;
using System.Windows.Forms;

namespace NewWebApp.Administrator
{
    public partial class GovernmentOrders : System.Web.UI.Page
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Visible = false;
            Label2.Visible = false;
            Table1.Visible = false;
            Table2.Visible = false;
           
        }






        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string file1 = FileUpload1.FileName;
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/PdfFile/"+file1));
               
                string Image = "~/PdfFile/" + file1.ToString();
                string name = TextBox1.Text;
                string desc1 = TextBox2.Text;
                string date1 = TextBox3.Text;

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString);
                SqlCommand cmd = new SqlCommand("insert into Feeds values(@Title,@Description,@Link,@PublishedDate)", con);
                
                cmd.Parameters.AddWithValue("@Title", name);
                cmd.Parameters.AddWithValue("@Link", Image);
                cmd.Parameters.AddWithValue("@Description", desc1);
                cmd.Parameters.AddWithValue("@PublishedDate", date1);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Label1.Visible = true;
                Label1.Text = "Image Uploaded";
                Response.Write("<script>alert('File Uploaded Successfully...');</script>");
                Label1.ForeColor = System.Drawing.Color.ForestGreen;
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
                

            }

            else
            {
                Response.Write("<script>alert('File could not be uploaded... Please try again');</script>");
                Label1.Visible = true;
                Label1.Text = "Please Upload your Image";
                Label1.ForeColor = System.Drawing.Color.Red;
            }  
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (FileUpload2.HasFile)
            {
                string file2 = FileUpload2.FileName;
                FileUpload2.PostedFile.SaveAs(Server.MapPath("~/TransferPdf/" + file2));

                string Image = "~/TransferPdf/" + file2.ToString();
                string name = TextBox4.Text;
                string desc1 = TextBox5.Text;
                string date1 = TextBox6.Text;

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString);
                SqlCommand cmd = new SqlCommand("insert into transfer values(@Title,@Description,@Link,@PublishedDate)", con);

                cmd.Parameters.AddWithValue("@Title", name);
                cmd.Parameters.AddWithValue("@Link", Image);
                cmd.Parameters.AddWithValue("@Description", desc1);
                cmd.Parameters.AddWithValue("@PublishedDate", date1);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Label2.Visible = true;
                Label2.Text = "Image Uploaded";
                Response.Write("<script>alert('File Uploaded Successfully...');</script>");
                Label2.ForeColor = System.Drawing.Color.ForestGreen;
                TextBox4.Text = "";
                TextBox5.Text = "";
                TextBox6.Text = "";


            }

            else
            {
                Response.Write("<script>alert('File could not be uploaded... Please try again');</script>");
                Label2.Visible = true;
                Label2.Text = "Please Upload your Image";
                Label2.ForeColor = System.Drawing.Color.Red;
            }  
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administrator/home.aspx");
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Table1.Visible = true;
            Table2.Visible = false;
        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Table2.Visible = true;
            Table1.Visible = false;
        }

       

    }
}
