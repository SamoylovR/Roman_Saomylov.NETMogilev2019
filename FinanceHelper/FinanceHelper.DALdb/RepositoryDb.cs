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
                string sqlAdd = $"Insert Into Operations (Sum, Name, Tax, IsOperationIncome) " +
                                $"values ({operation.Sum}, '{operation.Name}', {operation.Tax}, {Convert.ToByte(operation.IsOperationIncome)})";

                SqlCommand addCommand = new SqlCommand(sqlAdd, connection);
                addCommand.ExecuteNonQuery();
            }
        }

        public void ClearOperationData()
        {

        }

        public IEnumerable<Operation> GetCosts()
        {
            List<Operation> operations = new List<Operation> { };

            using (SqlConnection connection = new SqlConnection(Config.connectionString))
            {
                connection.Open();
                string sqlGetCosts = $"Select * From Operations Where Sum < 0";

                SqlCommand costsCommand = new SqlCommand(sqlGetCosts, connection);
                SqlDataReader reader = costsCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        operations.Add(new Operation
                        {
                            Sum = reader.GetDouble(1),
                            Name = reader.GetString(2)
                        });
                    }
                }
            }

            return operations;
        }

        public IEnumerable<Operation> GetIncome()
        {
            List<Operation> operations = new List<Operation> { };

            using (SqlConnection connection = new SqlConnection(Config.connectionString))
            {
                connection.Open();
                string sqlGetCosts = $"Select * From Operations Where Sum > 0";

                SqlCommand costsCommand = new SqlCommand(sqlGetCosts, connection);
                SqlDataReader reader = costsCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        operations.Add(new Operation
                        {
                            Sum = reader.GetDouble(1),
                            Name = reader.GetString(2),
                            Tax = reader.GetDouble(3)
                        });
                    }
                }
            }

            return operations;
        }
    }
}
