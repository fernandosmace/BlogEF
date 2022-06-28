﻿using System;
using System.Linq;
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
            BlogDataContext.ConnectionString = config["DatabaseLocal:ConnectionString"];

            using var context = new BlogDataContext();

            // context.Users.Add(new User
            // {
            //     Bio = "9x Microsoft MVP",
            //     Email = "balta@balta.io",
            //     Image = "https://",
            //     Name = "André Baltieri",
            //     PasswordHash = "1234",
            //     Slug = "andre-baltieri"
            // });

            // context.SaveChanges();

            var user = context.Users.FirstOrDefault();

            var post = new Post
            {
                Author = user,
                Body = "Meu artigo",
                Category = new Category
                {
                    Name = "BackEnd",
                    Slug = "back-end"
                },
                CreateDate = DateTime.Now,
                // LastUpdateDate =
                Slug = "meu-artigo",
                Summary = "Neste artigo vamos conferir...",
                // Tags = null,
                Title = "Meu artigo"
            };

            context.Posts.Add(post);
            context.SaveChanges();
        }
    }
}
