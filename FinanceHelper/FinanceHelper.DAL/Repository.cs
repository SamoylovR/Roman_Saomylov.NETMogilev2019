using FinanceHelper.Common.Entity;
using FinanceHelper.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace FinanceHelper.DAL
{
    public class OperationRepository : IOperationRepository
    {
        private readonly IOperationContext db;

        public OperationRepository(IOperationContext db)
        { 
            this.db = db;
        }

        public void AddNewOperation(Operation operation)
        {
            db.Operations.Add(operation);
        }

        public IEnumerable<Operation> GetIncome()
        {
            return db.Operations?.Where(op => op.Sum > 0);
        }

        public IEnumerable<Operation> GetCosts()
        {
            return db.Operations?.Where(op => op.Sum < 0);
        }

        public void ClearDataOfOperation()
        {
            db.Operations?.Clear();
        }
    }
}
