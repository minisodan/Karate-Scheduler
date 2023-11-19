using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSCI213.InstructorInfo
{
    public partial class InstructorPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\mason.myles\\Desktop\\213Assignment\\CSCI213\\App_Data\\KarateSchool.mdf;Integrated Security=True;Connect Timeout=30";
            LogonDataContext dbcon = new LogonDataContext(conn);
            Label1.Text = GetUserFullName(dbcon);

            if (Session.Count != 0)
            {
                if (HttpContext.Current.Session["userType"].ToString().Trim() == "Member")
                {
                    Session.Clear();
                    Session.RemoveAll();
                    Session.Abandon();
                    Session.Abandon();
                    FormsAuthentication.SignOut();
                    Response.Redirect("Logon.aspx", true);
                }
            }

            int userID = GetUserID(dbcon);

            //grid view
            var grid = (from x in dbcon.Sections
                        from y in dbcon.Members
                        from z in dbcon.Instructors
                        where z.InstructorID == userID
                        where x.Member_ID == y.Member_UserID
                        select new
                        {
                            x.SectionName,
                            y.MemberFirstName,
                            y.MemberLastName
                        });

            GridView1.DataSource = grid;
            GridView1.DataBind();
        }

        private int GetUserID(LogonDataContext dbcon)
        {
            string userName = User.Identity.Name;

            var userID = (from x in dbcon.NetUsers
                          where x.UserName == userName
                          select x.UserID).Single();

            return Convert.ToInt32(userID);
        }

        private string GetUserFullName(LogonDataContext dbcon)
        {
            int userId = GetUserID(dbcon);
            var userFName = (from x in dbcon.Instructors
                             where x.InstructorID == userId
                             select x.InstructorFirstName).Single();

            var userLName = (from x in dbcon.Instructors
                             where x.InstructorID == userId
                             select x.InstructorLastName).Single();

            return $"{userLName}, {userFName}";
        }
    }
}