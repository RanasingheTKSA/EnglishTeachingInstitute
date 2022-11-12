﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnglishTeachingInstitute.Model;

namespace EnglishTeachingInstitute.Services.Interfaces
{
    public interface IStudentService
    {
        List<Student> GetStudents();
        bool DeleteStudent(int id);
        ResponseModel SaveStudentDetails(Student student);
        Student StudentFormFill(int id);
    }
}
