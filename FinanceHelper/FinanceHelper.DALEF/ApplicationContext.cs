using FinanceHelper.Common;
using FinanceHelper.Common.Entity;
using Microsoft.EntityFrameworkCore;
using System;

namespace FinanceHelper.DALEF
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Operation> Operations { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Config.connectionString);
        }
    }
}
