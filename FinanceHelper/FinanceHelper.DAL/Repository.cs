using FinanceHelper.Common;
using FinanceHelper.Common.Entity;
using System.Collections.Generic;
using System.Linq;

namespace FinanceHelper.DAL
{
    public class Repository : IRepository<Operation>
    {
        private readonly IOperationContext db;
        //private readonly IJsonRepository jsonRepository;

        public Repository(IOperationContext db)
        { 
            this.db = db;
            //this.jsonRepository = jsonRepository;
        }

        public void AddNewOperation(Operation operation)
        {
            //jsonRepository.AddNewOperation(operation);
            db.Operations.Add(operation);
        }

        public IEnumerable<Operation> GetIncome()
        {
            //return jsonRepository.GetIncome();
            return db.Operations?.Where(op => op.Sum > 0);
        }

        public IEnumerable<Operation> GetCosts()
        {
            //return jsonRepository.GetCosts();
            return db.Operations?.Where(op => op.Sum < 0);
        }

        public void ClearOperationData()
        {
            //jsonRepository.ClearOperationData();
            db.Operations.Clear();
        }
    }
}
