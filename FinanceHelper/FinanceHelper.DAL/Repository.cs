using FinanceHelper.Common;
using System;
using FinanceHelper.Common.Entity;
using System.Collections.Generic;
using System.Linq;

namespace FinanceHelper.DAL
{
    public class Repository : IRepository<Operation>
    {
        private readonly OperationContext db;

        public Repository(OperationContext db)
        {
            this.db = db;
        }

        public void AddNewOperation(Operation operation)
        {
            db.Operations.Add(operation);
        }

        public IEnumerable<Operation> GetIncome()
        {
            return db.Operations.Where(op => op.Sum > 0);
        }
        
        public IEnumerable<Operation> GetCosts()
        {
            return db.Operations.Where(op => op.Sum < 0);
        }
    }
}
