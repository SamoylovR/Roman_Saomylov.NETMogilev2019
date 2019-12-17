using FinanceHelper.Common.Entity;
using FinanceHelper.DAL.Interfaces;
using System.Collections.Generic;

namespace FinanceHelper.DAL
{
    public class JsonHandler : IJsonHandler
    {
        public void AddNewOperation(Operation operation)
        {
            
        }

        public IEnumerable<Operation> GetCosts()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Operation> GetIncome()
        {
            throw new System.NotImplementedException();
        }
    }
}
