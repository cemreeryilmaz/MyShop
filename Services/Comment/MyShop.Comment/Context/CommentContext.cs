using Microsoft.EntityFrameworkCore;
using MyShop.Comment.Entities;

namespace MyShop.Comment.Context
{
    public class CommentContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1442;initial Catalog=CommentDb;User=sa;Password=123456aA*;TrustServerCertificate=True");
        }

        public DbSet<UserComment> UserComments { get; set; }
    }
}
