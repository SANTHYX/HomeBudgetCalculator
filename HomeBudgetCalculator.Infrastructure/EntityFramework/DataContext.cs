using HomeBudgetCalculator.Core.Domains;
using Microsoft.EntityFrameworkCore;

namespace HomeBudgetCalculator.Infrastructure.EntityFramework
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-79T8SJO\\DAMIANEK; User Id=sa; Password=abcd1234; Database=HBCalculator",
                b => b.MigrationsAssembly("HomeBudgetCalculator.Infrastructure"));
        }
    }
}
