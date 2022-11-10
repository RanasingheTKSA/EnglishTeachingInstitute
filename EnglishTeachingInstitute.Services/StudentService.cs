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
        //Delete Student
        public bool DeleteStudent(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionName"].ToString();
            var SqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand("", SqlConnection);
            SqlConnection.Open();

            try
            {
                sqlCommand.CommandText = "DELETE FROM Student WHERE ID = @studentId";
                sqlCommand.Parameters.AddWithValue("@studentId", id);
                sqlCommand.ExecuteScalar();
            }
            catch(Exception ex) {
                return false;
            }
            finally
            {
                SqlConnection.Close();
            }
            return true;
        }

        //Get all student as a list
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

        public Student StudentFormFill(int id)
        {
            var student = new Student();
            var connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionName"].ToString();
            var SqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand("", SqlConnection);
            SqlDataReader Reader = null;
            SqlConnection.Open();

            try
            {
                sqlCommand.CommandText = "SELECT id, firstName, lastName, address, contactNo, birthday FROM Student WHERE id = @id";
                sqlCommand.Parameters.AddWithValue("@id", id);
                Reader = sqlCommand.ExecuteReader();

                while (Reader.Read())
                {
                    student.FirstName = Reader["firstName"].ToString();
                    student.LastName = Reader["lastName"].ToString();
                    student.Address = Reader["address"].ToString();
                    student.ContactNo = Reader["contactNo"].ToString();
                    student.BirthDay = Reader["birthday"].ToString();
                }

            }catch(Exception ex)
            {

            }
            return student;
        }
         
        public StudentUpdateAndSave studentUpdateAndSave(Student student)
        {
            var response = new StudentUpdateAndSave();

            var connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionName"].ToString();
            var SqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand("", SqlConnection);
            SqlDataReader Reader = null;
            SqlConnection.Open();

            try
            {
                if (student.Id > 0)
                {
                    sqlCommand.CommandText = "UPDATE Student SET firstName = @firstName, lastName = @lastName," +
                        "address = @address, birthday = @birthday, contactNo = @contactNumber WHERE id = @id";

                    sqlCommand.Parameters.AddWithValue("@id", student.Id);
                    sqlCommand.Parameters.AddWithValue("@firstName", student.FirstName);
                    sqlCommand.Parameters.AddWithValue("@lastName", student.LastName);
                    sqlCommand.Parameters.AddWithValue("@address", student.Address);
                    sqlCommand.Parameters.AddWithValue("@contactNo", student.ContactNo);
                    sqlCommand.Parameters.AddWithValue("@birthday", DateTime.Parse(student.BirthDay));
                }
                else
                {
                    sqlCommand.CommandText = "SELECT contactNo FROM Student WHERE contactNo = @contactNumber";
                    sqlCommand.Parameters.AddWithValue("@contactnumber", student.ContactNo);
                    Reader = sqlCommand.ExecuteReader();

                    Reader.Close();
                    sqlCommand.Parameters.Clear();

                    sqlCommand.CommandText = "INSERT INTO Student(firstName, lastName, address, contactNumber, birthday)" +
                        "VALUES (@firstName, @lastName, @address, @contactNo, @birthday)";

                    sqlCommand.Parameters.AddWithValue("@firstName", student.FirstName);
                    sqlCommand.Parameters.AddWithValue("@lastName", student.LastName);
                    sqlCommand.Parameters.AddWithValue("@address", student.Address);
                    sqlCommand.Parameters.AddWithValue("@contactNumber", student.ContactNo);
                    sqlCommand.Parameters.AddWithValue("@birthday", student.BirthDay);
                }
                sqlCommand.ExecuteScalar();
                response.IsSuceess = true;
            }
            catch(Exception ex)
            {

            }
            return response;
        }


    }
    public class StudentUpdateAndSave
    {
        public bool IsSuceess { get; set; }
    }
}
