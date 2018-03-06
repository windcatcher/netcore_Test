using System.Collections.Generic;
using Webapi_mysql_dockercompose.Models;

namespace Webapi_mysql_dockercompose {
    public interface IStudentRepository {
        IEnumerable<Student> ListAll ();
        void Add (Student s);
    }
}