using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Webapi_mysql_dockercompose.Models;

namespace Webapi_mysql_dockercompose.Controllers {
    [Route ("api/[controller]")]
    public class StudentsController : Controller {
        private IStudentRepository _studentRpo;
        public StudentsController (IStudentRepository studentRpo) {
            _studentRpo = studentRpo;
        }

        [HttpGet]
        public IEnumerable<Student> Get () {
            return _studentRpo.ListAll ();
        }

        private void CreateStudentsNotExits () {
            if (!_studentRpo.ListAll ().Any ()) { }
            _studentRpo.Add (new Student () { Name = "s1" });
            _studentRpo.Add (new Student () { Name = "s2" });
            _studentRpo.Add (new Student () { Name = "s3" });
        }
    }
}