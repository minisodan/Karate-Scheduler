using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
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
            if (!IsPostBack)
            {
                var result = from item in dbcon.Instructors
                             orderby item.InstructorFirstName
                             select new { Instructor = item.InstructorFirstName, item.InstructorID };
                DropDownList5.DataTextField = "Instructor";
                DropDownList5.DataValueField = "InstructorId";

                DropDownList5.DataSource = result;
                DropDownList5.DataBind();

                var allMembers = from x in dbcon.Members
                                 select new { MemName = x.MemberFirstName + "  " + x.MemberLastName, x.Member_UserID };
                DropDownList6.DataTextField = "MemName";
                DropDownList6.DataValueField = "Member_UserID";
                DropDownList6.DataSource = allMembers;
                DropDownList6.DataBind();

                var allInstructors = from x in dbcon.Instructors
                                 select new { InsName = x.InstructorFirstName + "  " + x.InstructorLastName, x.InstructorID };
                DropDownList7.DataTextField = "InsName";
                DropDownList7.DataValueField = "InstructorID";
                DropDownList7.DataSource = allInstructors;
                DropDownList7.DataBind();
            }

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
                var memeberId = (from x in dbcon.NetUsers
                                 where x.UserName == userName.Text
                                 select x.UserID).Single();
                                int instructorId = getInstructorId(DropDownList5.SelectedValue, dbcon); 
                decimal sectionFee = Convert.ToInt32(TextBox14.Text);
                Section section = new Section();
                section.SectionName = DropDownList3.SelectedValue;
                section.SectionFee = sectionFee;
                section.Member_ID = memeberId;
                section.SectionStartDate = DateTime.Parse(TextBox6.Text);
                section.Instructor_ID = instructorId;

                Member mem = new Member();
                TextBox1.Text = memeberId.ToString();
                mem.Member_UserID = memeberId;
                mem.MemberFirstName = TextBox2.Text;
                mem.MemberLastName = TextBox3.Text;
                mem.MemberPhoneNumber = TextBox4.Text;
                mem.MemberDateJoined = DateTime.Parse(TextBox6.Text);

                TextBox6.Text = DateTime.UtcNow.ToString();
                mem.MemberEmail = TextBox5.Text;

                dbcon.Members.InsertOnSubmit(mem);
                dbcon.Sections.InsertOnSubmit(section);
                dbcon.SubmitChanges();
            }
        }

        private int getInstructorId(String dtr, LogonDataContext db)
        {
            int id = Convert.ToInt32(dtr); ;

            var memeberId = (from x in dbcon.NetUsers
                             where x.UserID == id
                             select x.UserID).Single();
            return memeberId;
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
                UpdateQuery();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Instructor instructor = new Instructor();

            var memeberId = (from x in dbcon.NetUsers
                             where x.UserName == userName.Text
                             select x.UserID).Single();
            instructor.InstructorID = memeberId;
            instructor.InstructorFirstName = TextBox8.Text;
            instructor.InstructorLastName = TextBox9.Text;
            instructor.InstructorPhoneNumber = TextBox10.Text;

            dbcon.Instructors.InsertOnSubmit(instructor);
            dbcon.SubmitChanges();
            UpdateQuery();
            updateAllDropDowns();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(DropDownList6.SelectedValue);

            var deletedNetUser = (from y in dbcon.NetUsers
                                  where y.UserID == id
                                  select y).SingleOrDefault();

            var deletedResult = (from x in dbcon.Members
                                 where x.Member_UserID == id
                                 select x).SingleOrDefault();

            if(deletedNetUser != null)
            {
                dbcon.NetUsers.DeleteOnSubmit(deletedNetUser);
            }

            if(deletedResult != null)
            {
                dbcon.Members.DeleteOnSubmit(deletedResult);
            }

            dbcon.SubmitChanges();
            UpdateQuery();
            updateAllDropDowns();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(DropDownList7.SelectedValue);

            var deletedNetUser = (from y in dbcon.NetUsers
                                  where y.UserID == id
                                  select y).SingleOrDefault();

            var deletedResult = (from x in dbcon.Instructors
                                 where x.InstructorID == id
                                 select x).SingleOrDefault();

            if(deletedNetUser != null)
            {
                dbcon.Instructors.DeleteOnSubmit(deletedResult);
            }

            if(deletedResult != null)
            {
                dbcon.NetUsers.DeleteOnSubmit(deletedNetUser);
            }

            dbcon.SubmitChanges();
            UpdateQuery();
            updateAllDropDowns();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            UpdateQuery();
        }

        private void UpdateQuery()
        {
            dbcon = new LogonDataContext(conn);

            var result = from item in dbcon.Members
                         select item;

            memberGridView.DataSource = result;
            memberGridView.DataBind();

            var result2 = from item in dbcon.Instructors
                          select item;

            InstructorsGridView.DataSource = result2;
            InstructorsGridView.DataBind();
        }

        private void updateAllDropDowns()
        {
            if(IsPostBack)
            {
                dbcon = new LogonDataContext(conn);
                var result = from item in dbcon.Instructors
                             orderby item.InstructorFirstName
                             select new { Instructor = item.InstructorFirstName, item.InstructorID };
                DropDownList5.DataTextField = "Instructor";
                DropDownList5.DataValueField = "InstructorId";

                DropDownList5.DataSource = result;
                DropDownList5.DataBind();

                var allMembers = from x in dbcon.Members
                                 select new { MemName = x.MemberFirstName + "  " + x.MemberLastName, x.Member_UserID };
                DropDownList6.DataTextField = "MemName";
                DropDownList6.DataValueField = "Member_UserID";
                DropDownList6.DataSource = allMembers;
                DropDownList6.DataBind();

                var allInstructors = from x in dbcon.Instructors
                                     select new { InsName = x.InstructorFirstName + "  " + x.InstructorLastName, x.InstructorID };
                DropDownList7.DataTextField = "InsName";
                DropDownList7.DataValueField = "InstructorID";
                DropDownList7.DataSource = allInstructors;
                DropDownList7.DataBind();
            }
        }

        private int getInstructorId(DropDownList dtr, LogonDataContext db)
        {
            int id = Convert.ToInt32(dtr.SelectedValue); ;

            var memeberId = (from x in db.NetUsers
                             where x.UserID == id
                             select x.UserID).Single();
            return memeberId;
        }
    }
}