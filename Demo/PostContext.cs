using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Demo
{
     public class PostContext:DbContext
    {
        public DbSet<Post> Posts { get; set; }


        public string ConnectionString { get; }

        public PostContext()
        {

            ConnectionString = @"Server=P2021-PC00312\SQLEXPRESS;Database=Posts;Trusted_Connection=True;TrustServerCertificate=True";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(ConnectionString);
    }

}
}
