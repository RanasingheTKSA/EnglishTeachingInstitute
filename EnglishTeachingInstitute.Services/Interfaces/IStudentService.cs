using System;
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
        ResponseModel DeleteStudent(int id);
        ResponseModel SaveStudentDetails(Student student);
        Student StudentForm(int id);
    }
}
