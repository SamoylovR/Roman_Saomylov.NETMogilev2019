using FinanceHelper.Common.Entity;
using FinanceHelper.DAL.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FinanceHelper.DAL
{
    public class JsonHandler : IJsonHandler
    {
        private static string filePath = @"../Operations/Operations.json";

        

        public void AddNewOperation(Operation operation)
        {
            string json = JsonConvert.SerializeObject(operation, Formatting.Indented);
            using (StreamWriter streamWriter = new StreamWriter(filePath, false, System.Text.Encoding.Default))
            {
                streamWriter.WriteLine(json);
            }
        }

        public IEnumerable<Operation> GetCosts()
        {
            IEnumerable<Operation> operations;

            using (StreamReader streamReader = new StreamReader(filePath))
            {
                operations = JsonConvert.DeserializeObject<IEnumerable<Operation>>(streamReader.ReadToEnd());
            }

            return operations.Where(op => op.Sum < 0);

            Operation op;
            using (StreamReader streamReader = new StreamReader(filePath))
            {
                op = JsonConvert.DeserializeObject<Operation>(streamReader.ReadToEnd());
            }
            Console.WriteLine($"{op.Id}, {op.Sum}, {op.Name}, {op.IsOperationIncome}");

            return null;
        }

        public IEnumerable<Operation> GetIncome()
        {
            IEnumerable<Operation> operations;

            using (StreamReader streamReader = new StreamReader(filePath))
            {
                operations = JsonConvert.DeserializeObject<IEnumerable<Operation>>(streamReader.ReadToEnd());
            }

            return operations.Where(op => op.Sum > 0);


            Operation op;
            using (StreamReader streamReader = new StreamReader(filePath))
            {
                op = JsonConvert.DeserializeObject<Operation>(streamReader.ReadToEnd());
            }
            Console.WriteLine($"{op.Id}, {op.Sum}, {op.Name}, {op.IsOperationIncome}");
            return null;
        }
    }
}
