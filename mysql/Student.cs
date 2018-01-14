namespace mysql {
    public class Student {
        //mysql 映射时，构造函数的顺序需要与表的列的顺序一致
        public Student ( int id,string name) {
            this.Name = name;
            this.Id = id;
        }
        public string Name { get; set; }
        public int Id { get; set; }
    }
}