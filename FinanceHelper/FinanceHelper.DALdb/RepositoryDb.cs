using FinanceHelper.Common;
using FinanceHelper.Common.Entity;
using FinanceHelper.DALdb.Interfaces;
using System.Collections.Generic;
using System.Data;
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

                string sqlAdd = "AddOperation";

                SqlCommand addCommand = new SqlCommand(sqlAdd, connection);
                addCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter opSum = new SqlParameter
                {
                    ParameterName = "@sum",
                    Value = operation.Sum
                };
                addCommand.Parameters.Add(opSum);

                SqlParameter opName = new SqlParameter
                {
                    ParameterName = "@name",
                    Value = operation.Name
                };
                addCommand.Parameters.Add(opName);

                SqlParameter opTax = new SqlParameter
                {
                    ParameterName = "@tax",
                    Value = operation.Tax
                };
                addCommand.Parameters.Add(opTax);

                SqlParameter opIsOperationIncome = new SqlParameter
                {
                    ParameterName = "@IsOperationIncome",
                    Value = operation.IsOperationIncome
                };
                addCommand.Parameters.Add(opIsOperationIncome);

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
                reader.Close();
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
                reader.Close();
            }

            return operations;
        }
    }
}
