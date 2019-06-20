using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


    public class DataLayer
    {
        static string myConnectionString;
        static SqlConnection conn;


        static DataLayer()
        {
            myConnectionString = "Data Source=10.135.0.98;initial catalog=healthpis; user id=healthpis;password=Te^3*71ts;Connection TimeOut=7000";
        }

        public DataLayer()
        {
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
            }
            catch
            {

            }
        }


        public DataTable ExecuteSqlTable(string sql)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }



        public DataTable GetEmpDetails(string id)
        {
            string sql = "";
            DataTable dt = new DataTable();
            try
            {
                sql = "select idno as ComputerID,newpostname as Post,designame as Designation,hname as HospitalName,doposting as DateOFPosting,dorelieve as DateOfReliving,districtname as DistrictName from dbo.postingdetails join post on postid=post.newpostid join dbo.hospitaldistrict on hospitaldistrict.districtid=postingdetails.districtid join dbo.hospitalname on hospitalname.sno=postingdetails.poposting join dbo.designation on designation.Desigid=postingdetails.Desigid where idno='" + id + "' order by DateOFPosting";
                dt = ExecuteSqlTable(sql);
            }
            catch
            {
                dt = null;
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                    conn.Close(); 
            }
            return dt;
        }

    }
