using FinanceHelper.Common.Entity;
using FinanceHelper.DALEF.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace FinanceHelper.DALEF
{
    public class EntityRepository : IEntityRepository
    {
        ApplicationContext db;

        public EntityRepository(ApplicationContext db)
        {
            this.db = db;
        }

        public void AddNewOperation(Operation operation)
        {
            db.Add(operation);
            db.SaveChanges();
        }

        public void ClearOperationData()
        {
        }

        public IEnumerable<Operation> GetCosts()
        {
            return db.Operations.Where(op => op.Sum < 0);
        }

        public IEnumerable<Operation> GetIncome()
        {
            return db.Operations.Where(op => op.Sum > 0);
        }
    }
}
