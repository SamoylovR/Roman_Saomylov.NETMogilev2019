using FinanceHelper.Common;
using FinanceHelper.Common.Entity;
using System.Collections.Generic;
using FinanceHelper.DALJson.Interfaces;

namespace FinanceHelper.BLL
{
    public class Distributor : IDistributor
    {
        private readonly IJsonRepository db;

        public Distributor(IJsonRepository db)
        {
            this.db = db;
        }

        public void AddNewOperation(Operation operation)
        {
            if (!operation.IsOperationIncome)
            {
                operation.Sum = -operation.Sum;
            }
            else 
            {
                operation.Tax = operation.Sum * 13 / 100;
                operation.Sum -= operation.Tax;
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

        public void ClearOperationData()
        {
            db.ClearOperationData();
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
            return GetMeanIncome() + GetMeanCosts();
        }

        private double GetMean(IEnumerable<Operation> operations)
        {
            double sum = 0;
            int count = 0;
            try
            {
                foreach (Operation op in operations)
                {
                    sum += op.Sum;
                    count++;
                }

                if (count != 0)
                {
                    sum /= count;
                }
            }
            catch 
            { }

            return sum;
        }
    }
}
