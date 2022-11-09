using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTeachingInstitute.Model
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string BirthDay { get; set; }
        public string Gender { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
