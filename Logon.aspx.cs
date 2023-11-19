using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSCI213
{
    public partial class Logon : System.Web.UI.Page
    { 
        //Connect to the database
        LogonDataContext dbcon;
        string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\mason.myles\\Desktop\\213Assignment\\CSCI213\\App_Data\\KarateSchool.mdf;Integrated Security=True;Connect Timeout=30";
        protected void Page_Load(object sender, EventArgs e)
        {
               ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
               {
                   Path = "~/scripts/jquery-1.7.2.min.js",
                   DebugPath = "~/scripts/jquery-1.7.2.js",
                   CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.4.1.min.js",
                   CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.4.1.js"
               });
            //Initialize connection string

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            dbcon = new LogonDataContext(conn);
            string nUserName = Login1.UserName;
            string nPassword = Login1.Password;

            HttpContext.Current.Session["nUserName"] = nUserName;
            HttpContext.Current.Session["uPass"] = nPassword;

            //Search for the current User, validate UserName and Password
            NetUser myUser = (from x in dbcon.NetUsers
                              where x.UserName == HttpContext.Current.Session["nUserName"].ToString()
                              && x.UserPassword == HttpContext.Current.Session["uPass"].ToString()
                              select x).Single();

            if (myUser != null)
            {
                //Add UserID and User type to the Session
                HttpContext.Current.Session["userID"] = myUser.UserID;
                HttpContext.Current.Session["userType"] = myUser.UserType;

            }
            // if login is member bring to member page
            if(myUser != null && HttpContext.Current.Session["userType"].ToString().Trim() == "Member")
            {
                FormsAuthentication.RedirectFromLoginPage(HttpContext.Current.Session["nUserName"].ToString(), true);
                Response.Redirect("~/MemberInfo/MemberPage.aspx");
                FormsAuthentication.SetAuthCookie(Login1.UserName, true);
            }
            //if login is instructor bring to instructor page
            else if(myUser != null && HttpContext.Current.Session["userType"].ToString().Trim() == "Instructor")
            {
                FormsAuthentication.RedirectFromLoginPage(HttpContext.Current.Session["nUserName"].ToString(), true);
                Response.Redirect("~/InstructorInfo/InstructorPage.aspx");
                FormsAuthentication.SetAuthCookie(Login1.UserName, true);
            }
            // if login is admin bring to admin page
            else if(myUser != null && HttpContext.Current.Session["userType"].ToString().Trim() == "Administrator")
            {
                FormsAuthentication.RedirectFromLoginPage(HttpContext.Current.Session["nUserName"].ToString(), true);
                Response.Redirect("~/AdminInfo/AdminPage.aspx");
            }
            //else redirect back to logon page
            else
            {
                Response.Redirect("Logon.aspx", true);
            }
        }
    }
}