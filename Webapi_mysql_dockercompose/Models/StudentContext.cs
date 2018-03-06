using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace Webapi_mysql_dockercompose.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {
            
        }
         public virtual DbSet<Student> Students { get; set; }
    }
}