namespace Webapi_mysql_dockercompose.Models {
    public class Student {
        public Student () { }
        public Student (int id, string name) {
            this.Name = name;
            this.Id = id;
        }
        public string Name { get; set; }
        public int Id { get; set; }
    }
}