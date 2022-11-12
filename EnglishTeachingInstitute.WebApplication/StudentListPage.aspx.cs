﻿using EnglishTeachingInstitute.Services.Interfaces;
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

        protected void btn_update_click(object sender, EventArgs e)
        {
            var id = int.Parse((sender as Button).CommandArgument);
            Response.Redirect("StudentUpdate.aspx?id=" + id);
        }

        protected void btn_delete_click(object sender, EventArgs e)
        {
            var studentId = int.Parse((sender as Button).CommandArgument);
            IStudentService studentService_ = new StudentService();
            var response = studentService_.DeleteStudent(studentId);

            if (response)
            {
                string message = "Student deleted successfully ";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "');";
                script += "window.location = '";
                script += "'; }";
                ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);

                this.GetStudentDetails();
            }
        }

        protected void btn_register_click(object sender, EventArgs e)
        {
            Response.Redirect("StudentUpdate.aspx?id=" + 0);
        }
    }
}