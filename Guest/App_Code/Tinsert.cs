using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
namespace Tinsert
{
    /// <summary>
    /// Summary description for Tinsert
    /// </summary>
    public class Tinsert
    {
        public SqlDataAdapter SQLDA;
        public SqlCommand SQLC;
        ClDatabase C = new ClDatabase();
        public Tinsert()
        {     
            //
            // TODO: Add constructor logic here
            //
        }
        public void Addsalarybasic(String name, DateTime DOB, String Fname, String Qualification, Double EmpMob, String email, String address, Double Msalary, String Eref, Double ErefMob, byte[] empph, DateTime doa, String Remark)
        {
            if (ConnectionState.Closed == C.upcon.State)
            {
                C.upcon.Open();
                object[] info ={ (object) name, (object) DOB, (object) Fname, (object) Qualification,(object) EmpMob,(object) email,(object) address,(object) Msalary,(object) Eref,(object) ErefMob, (object) empph,(object) doa,(object) Remark  };
                SQLC = new SqlCommand("BioD", C.upcon);
                SQLC.CommandType = CommandType.StoredProcedure;
                SQLC.Parameters.AddWithValue("@name", (object) name);
                SQLC.Parameters.AddWithValue("@DOB", (object)DOB);
                SQLC.Parameters.AddWithValue("@Fname", (object)Fname);
                SQLC.Parameters.AddWithValue("@Qualification", (object)Qualification);
                SQLC.Parameters.AddWithValue("@EmpMob", (object)EmpMob);
                SQLC.Parameters.AddWithValue("@email", (object)email);
                SQLC.Parameters.AddWithValue("@address", (object)address);
                SQLC.Parameters.AddWithValue("@Msalary", (object)Msalary);
                SQLC.Parameters.AddWithValue("@Eref", (object)Eref);
                SQLC.Parameters.AddWithValue("@ErefMob", (object)ErefMob);
                SQLC.Parameters.AddWithValue("@empph", (object)empph);
                SQLC.Parameters.AddWithValue("@doa", (object)doa);
                SQLC.Parameters.AddWithValue("@Remark", (object)Remark);                
                SQLC.ExecuteNonQuery();
                C.upcon.Close();               
            } 
            
        }
       
    }

}
