using FinanceHelper.Common.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FinanceHelper.DAL
{
    public class OperationContext : IOperationContext
    {
        public List<Operation> Operations { get; set; }

        public OperationContext()
        {
            Operations = new List<Operation> { };
        }

        //public DbSet<Operation> Operations { get; set; }
    }
}
