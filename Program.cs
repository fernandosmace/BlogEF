using System;
using System.Linq;
using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Blog
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();

            BlogDataContext.ConnectionString = config["Database:ConnectionString"];

            using var context = new BlogDataContext();

            // var user = new User()
            // {
            //     Name = "André Baltieri",
            //     Slug = "andrebaltieri",
            //     Email = "andre@balta.io",
            //     Bio = "9x Microsoft MVP",
            //     Image = "http://",
            //     PasswordHash = "123098457"
            // };

            // var category = new Category()
            // {
            //     Name = "Backend",
            //     Slug = "backend"
            // };

            // var post = new Post()
            // {
            //     Title = "Meu primeiro post",
            //     Author = user,
            //     Category = category,
            //     Body = "<p>Hello World!</p>",
            //     Slug = "comecando-com-ef-core",
            //     Summary = "Neste artigo vamos aprender EF Core",
            //     CreateDate = DateTime.Now,
            //     LastUpdateDate = DateTime.Now
            // };

            // context.Posts.Add(post);
            // context.SaveChanges();

            var posts = context
                        .Posts
                        .AsNoTracking()
                        .Include(x => x.Author)
                        .Include(x => x.Category)
                        .OrderByDescending(x => x.LastUpdateDate)
                        .ToList();

            foreach (var post in posts)
                Console.WriteLine($"{post.Title} escrito por {post.Author?.Name}");
        }
    }
}
