using FinanceHelper.Common;
using FinanceHelper.Common.Entity;
using FinanceHelper.DAL;
using System.Collections.Generic;

namespace FinanceHelper.BLL
{
    public class Distributor : IDistributor
    {
        private readonly IRepository<Operation> db;

        public Distributor(IRepository<Operation> db)
        {
            this.db = db;
        }

        public void AddNewOperation(Operation operation)
        {
            if (!operation.IsOperationIncome)
            {
                operation.Sum = -operation.Sum;
            }

            db.AddNewOperation(operation);
        }

        public IEnumerable<Operation> GetIncome()
        {
            return db.GetIncome();
        }

        public IEnumerable<Operation> GetCosts()
        {
            return db.GetCosts();
        }

        public double GetMeanIncome()
        {
            return GetMean(db.GetIncome());
        }

        public double GetMeanCosts()
        {
            return GetMean(db.GetCosts());
        }

        public double GetDelta()
        {
            return GetMeanIncome() - GetMeanCosts();
        }

        private double GetMean(IEnumerable<Operation> operations)
        {
            double sum = 0;
            int count = 0;
            foreach (Operation op in operations)
            {
                sum += op.Sum;
                count++;
            }

            if (count != 0)
            {
                sum /= count;
            }

            return sum;
        }
    }
}
