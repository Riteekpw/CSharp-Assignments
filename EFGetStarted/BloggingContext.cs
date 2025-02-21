using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EFGetStarted
{

    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        
        public string ConnectionString { get; }

        public BloggingContext()
        {
         
            ConnectionString = @"Server=P2021-PC00312\SQLEXPRESS;Database=Blogging;Trusted_Connection=True;TrustServerCertificate=True";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(ConnectionString);
    }

    
   
}
