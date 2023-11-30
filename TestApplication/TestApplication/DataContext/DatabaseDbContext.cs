using Microsoft.EntityFrameworkCore;
using TestApplication.Models.Employee;

namespace TestApplication.DataContext
{
    public class DatabaseDbContext : DbContext
    {
        public DatabaseDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}
