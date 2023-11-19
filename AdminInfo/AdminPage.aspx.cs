using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSCI213.AdminInfo
{
    public partial class AdminPage : System.Web.UI.Page
    {
        string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\mason.myles\\Desktop\\213Assignment\\CSCI213\\App_Data\\KarateSchool.mdf;Integrated Security=True;Connect Timeout=30";
        LogonDataContext dbcon;
        protected void Page_Load(object sender, EventArgs e)
        {
            dbcon = new LogonDataContext(conn);

            //show table of all members
            var member = (from x in dbcon.Members
                          select new
                          {
                              x.MemberFirstName, 
                              x.MemberLastName, 
                              x.MemberPhoneNumber,
                              x.MemberDateJoined
                          });
            memberGridView.DataSource = member;
            memberGridView.DataBind();

            //show table of all instructors
            var instructors = (from x in dbcon.Instructors
                               select new
                               {
                                   x.InstructorFirstName, 
                                   x.InstructorLastName
                               });
            InstructorsGridView.DataSource = instructors;
            InstructorsGridView.DataBind();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            dbcon = new LogonDataContext(conn);

            using (dbcon)
            {
                Member mem = new Member();
                mem.MemberFirstName = TextBox2.Text;
                mem.MemberLastName = TextBox3.Text;
                mem.MemberPhoneNumber = TextBox4.Text;
                mem.MemberDateJoined = DateTime.Parse(TextBox6.Text);
                mem.MemberEmail = TextBox5.Text;

                dbcon.Members.InsertOnSubmit(mem);
                dbcon.SubmitChanges();
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            dbcon = new LogonDataContext(conn);

            using (dbcon)
            {
                NetUser net = new NetUser();
                net.UserName = userName.Text;
                net.UserPassword = password.Text;
                net.UserType = DropDownList4.Text;

                dbcon.NetUsers.InsertOnSubmit(net);
                dbcon.SubmitChanges();
            }
        }
    }
}