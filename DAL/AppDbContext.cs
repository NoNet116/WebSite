using Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DAL;
public class AppDbContext : IdentityDbContext<User>
{
    public AppDbContext(Microsoft.EntityFrameworkCore.DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
        Console.WriteLine("Table created");
    }

}
