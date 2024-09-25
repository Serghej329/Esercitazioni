using Microsoft.EntityFrameworkCore;
class Database : DbContext
{
    public DbSet<User> Users { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder option)
    {
        option.UseSqlite("Data Source=db.db");
    }
}