using FinanceHelper.Common;
using FinanceHelper.Common.Entity;
using Microsoft.EntityFrameworkCore;

namespace FinanceHelper.DALEF
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Operation> Operations { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
