using FinanceHelper.Common.Entity;
using System;
using System.Collections.Generic;

namespace FinanceHelper.Common
{
    public interface IRepository<T>
    {
        void AddNewOperation(T operation);

        IEnumerable<Operation> GetIncome();

        IEnumerable<Operation> GetCosts();

        void ClearOperationData();
    }
}
