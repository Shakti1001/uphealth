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
using System.Data.SqlClient;


namespace NewWebApp.Administrator
{
    public partial class DATAMANIPULATION : System.Web.UI.Page
    {
        ClDatabase cl = new ClDatabase();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (IsPostBack)
            //{
            //    txtConnectionString.Text = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("CON").ConnectionString();
            //    txtmyKey.Text = System.Web.Configuration.WebConfigurationManager.AppSettings("con");
            //}


        }
        protected void Button1_Click(object sender, EventArgs e)
        {

        }
        protected void SELTAB_Click(object sender, EventArgs e)
        {
            cl.ds = cl.DataFill("SELECT * from sysobjects where xtype='U' and uid=1");
            if (cl.ds.Tables[0].Rows.Count > 0)
            {
                cl.ds = cl.DataFill("SELECT * from sysobjects where xtype='U' ");//and uid=1
                dd.DataSource = cl.ds;
                dd.DataTextField = "name";
                dd.DataValueField = "id";
                dd.DataBind();
                dd.Items.Insert(0, new ListItem("--select--"));
            }
            this.LCHOW.Text = "";
            TANDUMES.Text = "";
        }
        protected void dd_SelectedIndexChanged(object sender, EventArgs e)
        {
            TANDUMES.Text = "YOU have select the table name : " + this.dd.SelectedItem.Text;
        }

        protected void CHOW_Click(object sender, EventArgs e)
        {
            if (dd.SelectedIndex != 0)
            {
                cl.cmd = cl.InsertDB("sp_changeobjectowner '" + this.dd.SelectedItem.Text + "','" + this.ddu.SelectedItem.Text + "'");
                this.LCHOW.Text = "Owner change Successfully";
            }
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            this.Label2.Text = this.txtConnectionString.Text;
        }
        protected void Button3_Click(object sender, EventArgs e)
        {

            //Dim myConfiguration As Configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
            ////'myConfiguration.ConnectionStrings.ConnectionStrings("CON").ConnectionString = txtConnectionString.Text
            //myConfiguration.ConnectionStrings.ConnectionStrings("CON").ConnectionString = Label2.Text;
            //myConfiguration.ConnectionStrings.ConnectionStrings("CON").ProviderName = "System.Data.SqlClient";
            ////'myConfiguration.AppSettings.Settings.Item("myKey").Value = txtmyKey.Text
            //myConfiguration.AppSettings.Settings.Item("con").Value = Label2.Text;
            ////'myConfiguration.AppSettings.Settings.Item("myKey").
            //myConfiguration.Save();
        }
        public void st()
        {
            //        As I mentioned above, we need to use sp_change_users_login to identify and fix orphaned users. But sp_change_users_login has the following limitations:

            //- It can only show orphaned users from the current database.

            //- It will not report orphaned users belonging to Windows accounts. (In this case, it is better to drop the user using sp_revokedbaccess, and readd the user using sp_grantdbaccess)

            //- It will not report/fix orphaned dbo user (Orphaned dbo user can be fixed by using sp_changedbowner. This will change/update the owner of a database and associate the owning login to the dbo user).

            //To overcome the above problems, I wrote my own stored procedure ShowOrphanUsers, that loops through all the databases and identifies all orphaned users. ShowOrphanUsers output contains two columns: The database name and the orphaned user name. We use it extensively at my work place, whenever we build new servers, or move databases between different servers and domains. It takes no input parameters. It is tested on SQL Server 2000. To get this working on SQL Server 7.0, simply remove all references to COLLATE and compile the procedure. By default, this procedure will not check the following databases for orphaned users: master, model, tempdb, msdb, distribution, pubs and northwind. If you wish to verify any of these databases, simply remove that database name from the NOT IN list, by editing the stored procedure. As the name ShowOrphanUsers indicates, it only shows the list of orphaned users! You will still have to use sp_change_users_login to fix these orphaned users. 

            //Here is the stored procedure code: 

            //CREATE PROC dbo.ShowOrphanUsers
            //AS
            //BEGIN
            //    CREATE TABLE #Results
            //    (
            //        [Database Name] sysname COLLATE Latin1_General_CI_AS, 
            //        [Orphaned User] sysname COLLATE Latin1_General_CI_AS
            //    )

            //    SET NOCOUNT ON	

            //    DECLARE @DBName sysname, @Qry nvarchar(4000)

            //    SET @Qry = ''
            //    SET @DBName = ''

            //    WHILE @DBName IS NOT NULL
            //    BEGIN
            //        SET @DBName = 
            //                (
            //                    SELECT MIN(name) 
            //                    FROM master..sysdatabases 
            //                    WHERE 	name NOT IN 
            //                        (
            //                         'master', 'model', 'tempdb', 'msdb', 
            //                         'distribution', 'pubs', 'northwind'
            //                        )
            //                        AND DATABASEPROPERTY(name, 'IsOffline') = 0 
            //                        AND DATABASEPROPERTY(name, 'IsSuspect') = 0 
            //                        AND name > @DBName
            //                )

            //        IF @DBName IS NULL BREAK

            //        SET @Qry = '	SELECT ''' + @DBName + ''' AS [Database Name], 
            //                CAST(name AS sysname) COLLATE Latin1_General_CI_AS  AS [Orphaned User]
            //                FROM ' + QUOTENAME(@DBName) + '..sysusers su
            //                WHERE su.islogin = 1
            //                AND su.name <> ''guest''
            //                AND NOT EXISTS
            //                (
            //                    SELECT 1
            //                    FROM master..sysxlogins sl
            //                    WHERE su.sid = sl.sid
            //                )'

            //        INSERT INTO #Results EXEC (@Qry)
            //    END

            //    SELECT * 
            //    FROM #Results 
            //    ORDER BY [Database Name], [Orphaned User]
            //END


            //Note: I referred to the system table sysxlogins through out this article, but this system table is not documented. Querying the system tables is not a recommended approach, but if you do want to query sysxlogins, query syslogins instead, which is a view on top of sysxlogins and is documented.
        }


        protected void DATAD_Click(object sender, EventArgs e)
        {
            cl.ds = cl.DataFill("SELECT * from sysobjects where xtype='u' and uid=1");
            if (cl.ds.Tables[0].Rows.Count > 0)
            {
                GridView1.Visible = true;
                GridView1.DataBind();

            }
            else
            {
                GridView1.Visible = false;
                GridView1.Dispose();
            }
        }

        protected void SELUSR_Click(object sender, EventArgs e)
        {
            cl.ds = cl.DataFill("SELECT * from sysusers  ");//and uid=1 where xtype='U'
            if (cl.ds.Tables[0].Rows.Count > 0)
            {
                ddu.DataSource = cl.ds;
                ddu.DataTextField = "name";
                ddu.DataValueField = "uid";
                ddu.DataBind();
                dd.Items.Insert(0, new ListItem("--select--"));
            }

            this.LCHOW.Text = "";
            TANDUMES.Text = "";
        }
        protected void HD_Click(object sender, EventArgs e)
        {
            GridView1.Visible = false;
            GridView1.Dispose();
        }
        protected void ddu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddu.SelectedIndex != 0 && dd.SelectedIndex != 0)
            {
                TANDUMES.Text = "YOU have select the table name : " + this.dd.SelectedItem.Text + " and User name :" + this.ddu.SelectedItem.Text;
            }
        }
    }
}