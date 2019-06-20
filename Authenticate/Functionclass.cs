using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.UI.WebControls;

namespace NewWebApp.Authenticate
{
    public class Functionclass
    {
        public bool IllegalChars(TextBox txt)
        {
            // Declare variables 
            string[] sBadChars;
            int iCounter;
            string sBadCharsstring;
            // Set IllegalChars to False 
            bool IllegalChars = false;
            sBadCharsstring = "select,drop,;,--,insert,delete,xp_,%,&,\',\\,:,;,<,>,[,],?,`,|,declare,convert,script,create,view,update,sp_,exec,<script>";
            sBadChars = sBadCharsstring.Split(',');
            //   'Loop through array sBadChars using our counter & UBound function
            for (iCounter = 0; (iCounter <= sBadChars.GetUpperBound(0)); iCounter++)
            {
                // Use Function Instr to check presence of illegal character in our variable
                if (((txt.Text.IndexOf(sBadChars[iCounter]) + 1) > 0))
                {
                    IllegalChars = true;
                    txt.Text = "";
                }
            }
            return IllegalChars;
        }
    }
    
}