using AspEntityFramework.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspEntityFramework.Repository
{
    public class BloggingContext:DbContext
    {
        public BloggingContext(DbContextOptions<BloggingContext> options)
       : base(options)
        { }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
