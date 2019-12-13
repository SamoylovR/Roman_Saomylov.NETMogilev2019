using FinanceHelper.Common.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FinanceHelper.DAL
{
    public class OperationContext : IOperationContext
    {
        public List<Operation> Operations { get; set; }

        //public OperationContext()
        //{
        //    Database.EnsureCreated();
        //}

        //public DbSet<Operation> Operations { get; set; }
    }
}
