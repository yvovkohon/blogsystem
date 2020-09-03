using BlogSystem.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogSystem.Models
{
    public class BlogSystemContext : DbContext
    {
        public BlogSystemContext(DbContextOptions<BlogSystemContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().ToTable("Posts");
            modelBuilder.Entity<Comment>().ToTable("Comments");
        }
    }
}