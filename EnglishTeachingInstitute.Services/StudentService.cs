using EnglishTeachingInstitute.Model;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EnglishTeachingInstitute.Data;
using EnglishTeachingInstitute.Util;

namespace EnglishTeachingInstitute.Services.Interfaces
{
    public class StudentService : DatabaseConnection, IStudentService
    {
        public StudentService()
        {

        }
        
        //Delete Student
        public ResponseModel DeleteStudent(int id)
        {
            var response = new ResponseModel();
            SqlCommand sqlCommand = new SqlCommand("", connection);
            connection.Open();

            try
            {
                sqlCommand.CommandText = "DELETE FROM Student WHERE ID = @studentId";
                sqlCommand.Parameters.AddWithValue("@studentId", id);
                sqlCommand.ExecuteScalar();

                response.IsSuceess = true;
                response.Message = ApplicationConstant.STUDENT_DELETE_SUCCESSFULL_MESSAGE;
            }
            catch(Exception ex) {

                response.IsSuceess = false;
                response.Message = ApplicationConstant.COMMON_ERROR_OCCURE_EXCEPTION_MESSAGE;
            }
            finally
            {
                connection.Close();
            }
            return response;
        }

        //Get all student as a list
        public List<Student> GetStudents()
        {
            var sqlCommand = new SqlCommand("", connection);
            SqlDataReader Reader = null;
            connection.Open();
                         
            var studentList = new List<Student>();
            try
            {
                sqlCommand.CommandText = "SELECT * FROM Student ORDER BY createdTime DESC";
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
                        ContactNumber = Reader["contactNumber"].ToString(),
                        CreatedTime = DateTime.Parse(Reader["createdTime"].ToString()),
                    };
                    studentList.Add(studentDetails);
                }
            }
            catch(Exception ex) { 
            
            }
            finally
            {
                connection.Close();
            }

            return studentList;
        }

        public Student StudentForm(int id)
        {
            var student = new Student();
            var sqlCommand = new SqlCommand("", connection);
            SqlDataReader reader = null;
            connection.Open();

            try
            {
                sqlCommand.CommandText = "SELECT id, firstName, lastName, address, contactNumber, birthday FROM Student WHERE id = @id";
                sqlCommand.Parameters.AddWithValue("@id", id);
                reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    student.FirstName = reader["firstName"].ToString();
                    student.LastName = reader["lastName"].ToString();
                    student.Address = reader["address"].ToString();
                    student.ContactNumber = reader["contactNumber"].ToString();
                    student.BirthDay = reader["birthday"].ToString();
                }

            }catch(Exception ex)
            {

            }

            finally
            {
                connection.Close();
                reader.Close();
                sqlCommand.Parameters.Clear();
            }
            return student;
        }
         
        //update and insert
        public ResponseModel SaveStudentDetails(Student student)
        {
            var response = new ResponseModel();
            var contactNumber = string.Empty;
           
            SqlCommand sqlCommand = new SqlCommand("", connection);
            SqlDataReader Reader = null;
            connection.Open();

            try
            {
                if (student.Id > 0)
                {
                    sqlCommand.CommandText = "UPDATE Student SET firstName = @firstName, lastName = @lastName," +
                        "address = @address, birthday = @birthday, contactNumber = @contactNumber WHERE id = @id";

                    sqlCommand.Parameters.AddWithValue("@id", student.Id);
                    sqlCommand.Parameters.AddWithValue("@firstName", student.FirstName);
                    sqlCommand.Parameters.AddWithValue("@lastName", student.LastName);
                    sqlCommand.Parameters.AddWithValue("@address", student.Address);
                    sqlCommand.Parameters.AddWithValue("@contactNumber", student.ContactNumber);
                    sqlCommand.Parameters.AddWithValue("@birthday", DateTime.Parse(student.BirthDay));
                }
                else
                {
                    sqlCommand.CommandText = "SELECT contactNumber FROM Student WHERE contactNumber = @contactNumber";
                    sqlCommand.Parameters.AddWithValue("@contactnumber", student.ContactNumber);
                    Reader = sqlCommand.ExecuteReader();

                    while (Reader.Read()) 
                    {
                        contactNumber = Reader["contactNumber"].ToString();
                    }

                    if(contactNumber == student.ContactNumber)
                    {
                        response.IsSuceess = false;
                        response.Message = ApplicationConstant.PHONE_NUMBER_SUCCESSFULL_MESSAGE;

                        return response;
                    }

                    Reader.Close();
                    sqlCommand.Parameters.Clear();

                    sqlCommand.CommandText = "INSERT INTO Student(firstName, lastName, address, contactNumber, birthday, createdTime)" +
                        "VALUES (@firstName, @lastName, @address, @contactNumber, @birthday, @createdTime)";

                    sqlCommand.Parameters.AddWithValue("@firstName", student.FirstName);
                    sqlCommand.Parameters.AddWithValue("@lastName", student.LastName);
                    sqlCommand.Parameters.AddWithValue("@address", student.Address);
                    sqlCommand.Parameters.AddWithValue("@contactNumber", student.ContactNumber);
                    sqlCommand.Parameters.AddWithValue("@birthday", student.BirthDay);
                    sqlCommand.Parameters.AddWithValue("@createdTime", DateTime.UtcNow);
                }
                sqlCommand.ExecuteScalar();
                response.IsSuceess = true;
                response.Message = ApplicationConstant.NEW_MEMBER_SUCCESSFULL;
            }
            catch(Exception ex)
            {

            }

            finally
            {
                connection.Close();
                sqlCommand.Dispose();
            }
            return response;
        }

    }
   
}
