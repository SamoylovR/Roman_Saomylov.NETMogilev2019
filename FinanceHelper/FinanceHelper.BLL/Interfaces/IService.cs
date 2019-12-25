using FinanceHelper.Common.Entity;
using System.Collections.Generic;

namespace FinanceHelper.BLL.Interfaces
{
    public interface IService<T>
    {
        void AddNewOperation(T operation);

        IEnumerable<Operation> GetIncome();

        IEnumerable<Operation> GetCosts();

        void ClearOperationData();
    }
}
