using System;
using System.Collections.Generic;
using Forum_MVC.Models;
using Microsoft.EntityFrameworkCore;


namespace СookieAuth.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}