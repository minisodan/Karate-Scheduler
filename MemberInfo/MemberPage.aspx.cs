using System;
using System.Collections.Generic;
using System.Drawing;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSCI213.MemberInfo
{
    public partial class MemberPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\mason.myles\\Desktop\\213Assignment\\CSCI213\\App_Data\\KarateSchool.mdf;Integrated Security=True;Connect Timeout=30";
            LogonDataContext dbcon = new LogonDataContext(conn);
            Label1.Text = GetUserFullName(dbcon);

            if (Session.Count != 0)
            {
                if (HttpContext.Current.Session["UserType"].ToString().Trim() == "Instructor")
                {
                    Session.Clear();
                    Session.RemoveAll();
                    Session.Abandon();
                    Session.Abandon();
                    FormsAuthentication.SignOut();
                    Response.Redirect("Logon.aspx", true);
                }
            }

            int userId = GetUserID(dbcon);
            //grid view
            var grid = (from x in dbcon.Sections
                        from y in dbcon.Instructors
                        where x.Member_ID == userId
                        where y.InstructorID == x.Instructor_ID
                        select new
                        {
                            x.SectionName, 
                            y.InstructorFirstName,
                            y.InstructorLastName,
                            x.SectionStartDate,
                            x.SectionFee
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
            var userFName = (from x in dbcon.Members
                            where x.Member_UserID == userId
                             select x.MemberFirstName).Single();

            var userLName = (from x in dbcon.Members
                             where x.Member_UserID == userId
                             select x.MemberLastName).Single();

            return $"{userLName}, {userFName}";
        }

    }
}