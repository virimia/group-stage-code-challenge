using CodeChallenge.WebApi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeChallenge.WebApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Country> Countries { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<GroupDraw> GroupDraws { get; set; }
}
