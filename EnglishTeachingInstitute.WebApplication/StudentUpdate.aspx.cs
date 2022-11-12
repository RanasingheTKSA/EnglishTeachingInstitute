using EnglishTeachingInstitute.Model;
using EnglishTeachingInstitute.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnglishTeachingInstitute.WebApplication
{
    public partial class StudentUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Request.QueryString["id"] == null ? 0 : int.Parse(Request.QueryString["id"]);
            if (!Page.IsPostBack)
            {
                if(id > 0)
                {
                    FillStudentFormData(id);
                }
            }

        }

        protected void FillStudentFormData(int id)
        {
            IStudentService studentService_ = new StudentService();
            var student = studentService_.StudentFormFill(id);

            TextFirstName.Text = student.FirstName;
            TextLastName.Text = student.LastName;
            TextAddress.Text = student.Address;
            TextContactNumber.Text = student.ContactNumber;
            TextBirthday.Text = student.BirthDay;
        }

        protected void SaveStudent(object sender, EventArgs e)
        {
            string message = string.Empty;
            string script = string.Empty;
            string url = string.Empty;

            var student = new Student();
            student.Id = Request.QueryString["id"] == null ? 0 : int.Parse(Request.QueryString["id"]);
            student.FirstName = TextFirstName.Text.Trim();
            student.LastName = TextLastName.Text.Trim();
            student.Address = TextAddress.Text.Trim();
            student.ContactNumber = TextContactNumber.Text.Trim();
            student.BirthDay = TextBirthday.Text.Trim();

            IStudentService studentService_ = new StudentService();
            var response = studentService_.SaveStudentDetails(student);

            if (response.IsSuceess)
            {
                message = student.Id == 0 ? response.Message : response.Message;
                url = "StudentListPage.aspx";
                script = "window.onload = function(){ alert('";
                script += message;
                script += "');";
                script += "window.location = '";
                script += url;
                script += "'; }";
                ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
            }
            if (!response.IsSuceess)
            {
                message = response.Message;
                url = "StudentUpdate.aspx";
                script = "window.onload = function(){ alert('";
                script += message;
                script += "');";
                script += "window.location = '";
                script += url;
                script += "'; }";
                ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
            }
        }
    }
}