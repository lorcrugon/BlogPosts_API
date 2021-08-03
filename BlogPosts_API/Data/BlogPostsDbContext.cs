using BlogPosts_API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogPosts_API.Data
{
    public class BlogPostsDbContext : DbContext
    {
        public DbSet<BlogPost> BlogPosts { get; set; }
    }
}