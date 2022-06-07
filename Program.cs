using System;
using Blog.Data;
using Blog.Models;
using Microsoft.Extensions.Configuration;

namespace Blog
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();

            BlogDataContext.ConnectionString = config["Database:ConnectionString"];

            using (var context = new BlogDataContext())
            {
                var tag = new Tag
                {
                    Name = "ASP.NET",
                    Slug = "aspnet"
                };

                context.Tags.Add(tag);
                context.SaveChanges();
            }
        }
    }
}
