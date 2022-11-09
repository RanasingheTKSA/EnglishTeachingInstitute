using EnglishTeachingInstitute.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnglishTeachingInstitute.WebApplication
{
    public partial class StudentListPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!this.IsPostBack)
            {
                this.GetStudentDetails();
            }
        }

        public void GetStudentDetails()
        {
            IStudentService studentService_ = new StudentService();
            var student = studentService_.GetStudents();

            GridStudentList.DataSource = student;
            GridStudentList.DataBind();
        }

        protected void GridPageIndexChange(object sender, GridViewPageEventArgs e)
        {
            GridStudentList.PageIndex = e.NewPageIndex;
            this.GetStudentDetails();
        }

       
    }
}