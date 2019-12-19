using FinanceHelper.Common.Entity;
using FinanceHelper.DAL.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace FinanceHelper.DAL
{
    public class JsonHandler : IJsonHandler
    {
        private static string filePath = @"../Operations/Operations.json";

        public void AddNewOperation(Operation operation)
        {
            List<Operation> operations = ReadOperations();
            try
            {
                operations.Add(operation);
            }
            catch
            {
                operations = new List<Operation> { operation };
            }

            string json = JsonSerializer.Serialize(operations);

            if(!File.Exists(filePath))
            {
                File.Create(filePath);
            }

            File.WriteAllText(filePath, json);
        }

        public IEnumerable<Operation> GetCosts()
        {
            IEnumerable<Operation> operations = ReadOperations();

            return operations?.Where(op => op.Sum < 0);
        }

        public IEnumerable<Operation> GetIncome()
        {
            IEnumerable<Operation> operations = ReadOperations();            

            return operations?.Where(op => op.Sum > 0);
        }

        public void ClearOperationData()
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }
            else
            {
                File.WriteAllText(filePath, "");
            }
        }

        private List<Operation> ReadOperations()
        {
            List<Operation> operations = null;

            using (StreamReader streamReader = new StreamReader(filePath))
            {
                var str = streamReader.ReadToEnd();
                
                try
                {
                    operations = JsonSerializer.Deserialize<List<Operation>>(str);
                }
                catch
                { }
            }

            return operations;
        }
    }
}
