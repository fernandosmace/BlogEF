using System;
using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Blog.Data
{
    public class BlogDataContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }

        public static string ConnectionString = "";
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer($"{ConnectionString}");
    }
}