using Microsoft.EntityFrameworkCore;
using projetoXYZ.Models;

namespace projetoXYZ.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
    }
}