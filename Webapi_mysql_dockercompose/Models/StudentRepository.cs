using System.Collections.Generic;
using System.Linq;
using Webapi_mysql_dockercompose.Models;

namespace Webapi_mysql_dockercompose {
    public class StudentRepository : IStudentRepository {
        private StudentContext _studentDb;
        public StudentRepository (StudentContext studentDb) {
            this._studentDb = studentDb;
        }
        public void Add (Student s) {
            _studentDb.Students.Add (s);
            _studentDb.SaveChanges ();
        }

        public IEnumerable<Student> ListAll () {
            return _studentDb.Students.AsEnumerable<Student> ();
        }
    }
}