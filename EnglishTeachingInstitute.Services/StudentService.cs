using EnglishTeachingInstitute.Model;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EnglishTeachingInstitute.Services.Interfaces
{
    public class StudentService : IStudentService
    {
        public List<Student> GetStudents()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionName"].ToString();
            var SqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand("", SqlConnection);
            SqlDataReader Reader = null;
            SqlConnection.Open();

            var studentList = new List<Student>();
            try
            {
                sqlCommand.CommandText = "SELECT * FROM Student";
                Reader = sqlCommand.ExecuteReader();

                while (Reader.Read()) 
                {
                    var studentDetails = new Student
                    {
                        Id = int.Parse(Reader["id"].ToString()),
                        FirstName = Reader["firstName"].ToString(),
                        LastName = Reader["lastName"].ToString(),
                        Address = Reader["address"].ToString(),
                        BirthDay = Reader["birthday"].ToString(),
                        ContactNo = Reader["contactNumber"].ToString(),
                        //CreatedTime = DateTime.Parse(mySqlDataReader["createdTime"].ToString()),

                    };
                    studentList.Add(studentDetails);
                }
            }
            catch(Exception ex) { 
            
            }
            return studentList;
        }
    }
}
