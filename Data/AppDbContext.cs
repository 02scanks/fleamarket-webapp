using FleamarketApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : IdentityDbContext<User>
{
    // Db Sets
    public DbSet<Item> GlobalItems { get; set; }    // every item on site



    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
}