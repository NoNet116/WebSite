using DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL;
public class AppDbContext : IdentityDbContext<User>
{
    public DbSet<Article> Articles { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public AppDbContext(Microsoft.EntityFrameworkCore.DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

}
