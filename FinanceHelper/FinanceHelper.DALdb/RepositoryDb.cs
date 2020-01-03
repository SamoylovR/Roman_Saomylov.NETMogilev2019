using FinanceHelper.Common;
using FinanceHelper.Common.Entity;
using FinanceHelper.DALdb.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace FinanceHelper.DALdb
{
    public class RepositoryDb : IRepositoryDb
    {
        public void AddNewOperation(Operation operation)
        {
            using (SqlConnection connection = new SqlConnection(Config.connectionString))
            {
                connection.Open();
                string sqlAdd = $"Insert Into Operations (Sum, Name, Tax, IsOperationIncome) values ({operation.Sum}, '{operation.Name}', {operation.Tax}, {Convert.ToByte(operation.IsOperationIncome)})";
                SqlCommand addCommand = new SqlCommand(sqlAdd, connection);
                addCommand.ExecuteNonQuery();
            }
        }

        public void ClearOperationData()
        {

        }

        public IEnumerable<Operation> GetCosts()
        {
            using (SqlConnection connection = new SqlConnection(Config.connectionString))
            {
                connection.Open();
            }

            return null;
        }

        public IEnumerable<Operation> GetIncome()
        {
            using (SqlConnection connection = new SqlConnection(Config.connectionString))
            {
                connection.Open();

            }

            return null;
        }
    }
}
