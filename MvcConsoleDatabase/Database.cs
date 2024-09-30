// Database.cs
using Microsoft.EntityFrameworkCore;
class Database : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Subscription> Subscriptions { get; set; }
    public DbSet<Transition> Transitions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder option)
    {
        option.UseSqlite("Data Source=db.db");
    }
}

