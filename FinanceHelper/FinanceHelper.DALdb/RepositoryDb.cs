using FinanceHelper.Common;
using FinanceHelper.Common.Entity;
using FinanceHelper.DALdb.Interfaces;
using System;
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
                //string sqlGetCosts = $"Select * From Operations Where Sum < 0";
                string sqlGetCosts = $"GetCosts";

                SqlCommand costsCommand = new SqlCommand(sqlGetCosts, connection);
                costsCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = costsCommand.ExecuteReader();

                DataTable dataTable = new DataTable();
                dataTable.Load(reader);

                foreach (DataRow row in dataTable.Rows)
                {
                    Operation operation = new Operation
                    {
                        Name = row["Name"].ToString(),
                        Sum = Convert.ToDouble(row["Sum"])
                    };

                    operations.Add(operation);
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
                //string sqlGetIncome = $"Select * From Operations Where Sum > 0";
                string sqlGetIncome = $"GetIncome";

                SqlCommand incomeCommand = new SqlCommand(sqlGetIncome, connection);
                incomeCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = incomeCommand.ExecuteReader();

                DataTable dataTable = new DataTable();
                dataTable.Load(reader);

                foreach (DataRow row in dataTable.Rows)
                {
                    Operation operation = new Operation
                    {
                        Name = row["Name"].ToString(),
                        Tax = Convert.ToDouble(row["Tax"]),
                        Sum = Convert.ToDouble(row["Sum"])
                    };

                    operations.Add(operation);
                }

                reader.Close();
            }

            return operations;
        }
    }
}
