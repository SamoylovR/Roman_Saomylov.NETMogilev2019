using FinanceHelper.Common;
using FinanceHelper.Common.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace FinanceHelper.DALdb
{
    public class Repository : IRepository<Operation>
    {
        SqlConnection connection = new SqlConnection(Config.connectionString);

        public void AddNewOperation(Operation operation)
        {
            connection.Open();
        }

        public void ClearOperationData()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Operation> GetCosts()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Operation> GetIncome()
        {
            throw new NotImplementedException();
        }
    }
}
