using Microsoft.EntityFrameworkCore;
using projetoXYZ.Context.Interfaces;
using projetoXYZ.Models;

namespace projetoXYZ.Context
{
    public class AppDbContext : DbContext, IUnitOfWork
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }

        public async Task Save()
        {
            await base.SaveChangesAsync();
        }
    }
}