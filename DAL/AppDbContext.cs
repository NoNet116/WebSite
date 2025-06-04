using DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DAL;
public class AppDbContext : IdentityDbContext<User>
{
    public AppDbContext(Microsoft.EntityFrameworkCore.DbContextOptions<AppDbContext> options) : base(options)
    {
        Console.BackgroundColor = ConsoleColor.Yellow;
        Console.WriteLine("T E S T");
        Console.BackgroundColor = ConsoleColor.Black;
        Database.EnsureCreated();
    }

}
