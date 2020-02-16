using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ZuzexTestProject.Domain.Model;

namespace ZuzexTestProject.Infrastructure.EF
{
    public class PostsContext : DbContext
    {
        public PostsContext(DbContextOptions<PostsContext> options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
    }
}
