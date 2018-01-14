using System;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;
using Dapper;

namespace mysql {
    class Program {
        static void Main (string[] args) {
            Encoding.RegisterProvider (CodePagesEncodingProvider.Instance);
            MySqlConnection con = new MySqlConnection ("server=10.0.0.110;database=student_db;uid=root;pwd=root;charset='gbk';SslMode=None");
            var list = con.Query<Student> ("select * from student_tb");
            foreach (var item in list) {
                Console.WriteLine ($"用户名：{item.Name} 链接：{item.Id}");
            }
            Console.ReadKey ();
        }
    }
}