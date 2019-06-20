<%@ Application Language="C#" %>


<script runat="server">

   
    void Application_Start(object sender, EventArgs e) 
    {
        ScriptManager.ScriptResourceMapping.AddDefinition("jquery",
   new ScriptResourceDefinition
   {
       Path = "~/scripts/jquery-1.7.2.min.js",
       DebugPath = "~/scripts/jquery-1.7.2.min.js",
       CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.4.1.min.js",
       CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.4.1.js"
   });
      
        // Code that runs on application startup
        System.Web.Routing.RouteTable.Routes.MapPageRoute("Index", "Home", "~/Website/index.aspx");
        System.Web.Routing.RouteTable.Routes.MapPageRoute("Login", "SignIn", "~/Authenticate/Login.aspx");
        System.Web.Routing.RouteTable.Routes.MapPageRoute("UserHome", "User/Index", "~/Website/index.aspx");
    }
    protected void Application_BeginRequest(object sender, EventArgs e)
    {
        var application = sender as HttpApplication;
        if (application != null && application.Context != null)
        {
            application.Context.Response.Headers.Remove("Server");
        }
    }
    protected void Application_PreSendRequestHeaders()
    {
        Response.Headers.Remove("X-Powered-By");
        Response.AppendHeader("Cache-Control", "no-cache");
  
        // Response.Headers.Remove("Server");
        Response.Headers.Set("Server", "Department of Medical Health & Family Welfare");
        Response.Headers.Remove("X-AspNet-Version");
        Response.Headers.Remove("X-AspNetMvc-Version");
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
         try
        {
            string path = "~/Log/" + DateTime.Today.ToString("dd-mm-yy") + ".txt";
            if (!System.IO.File.Exists(System.Web.HttpContext.Current.Server.MapPath(path)))
            {
                System.IO.File.Create(System.Web.HttpContext.Current.Server.MapPath(path)).Close();
            }
            using (System.IO.StreamWriter w = System.IO.File.AppendText(System.Web.HttpContext.Current.Server.MapPath(path)))
            {
                w.WriteLine("\r\nLog Entry : ");
                w.WriteLine("{0}", DateTime.Now.ToString(System.Globalization.CultureInfo.InvariantCulture));
                string err = "Error in: " + System.Web.HttpContext.Current.Request.Url.ToString() +
                              ". Error Message:" + Server.GetLastError() +"\n\n"+ Server.GetType() ;
                w.WriteLine(err);
                w.WriteLine("__________________________");
                w.Flush();
                w.Close();
            }
        }
        catch (Exception ex)
        {
           
        }
            // Code that runs when an unhandled error occurs

       
    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>
