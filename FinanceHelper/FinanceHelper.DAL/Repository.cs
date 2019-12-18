using FinanceHelper.Common;
using FinanceHelper.Common.Entity;
using FinanceHelper.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace FinanceHelper.DAL
{
    public class Repository : IRepository<Operation>
    {
        private readonly IOperationContext db;
        private readonly IJsonHandler jsonHandler;

        public Repository(IOperationContext db, IJsonHandler jsonHandler)
        { 
            this.db = db;
            this.jsonHandler = jsonHandler;
        }

        public void AddNewOperation(Operation operation)
        {
            db.Operations.Add(operation);
            jsonHandler.AddNewOperation(operation);
        }

        public IEnumerable<Operation> GetIncome()
        {
            return jsonHandler.GetIncome();
        }
        
        public IEnumerable<Operation> GetCosts()
        {
            return jsonHandler.GetCosts(); ;
        }
    }
}
