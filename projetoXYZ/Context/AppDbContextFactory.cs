using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace projetoXYZ.Context
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer("Data Source=BRUNO-PC\\SQLEXPRESS;Initial Catalog=ProjetoXYZDB;Integrated Security=True");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
