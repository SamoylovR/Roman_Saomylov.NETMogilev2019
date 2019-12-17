using FinanceHelper.Common.Entity;
using FinanceHelper.DAL.Interfaces;
using System.Collections.Generic;
using System.IO;

namespace FinanceHelper.DAL
{
    public class JsonHandler : IJsonHandler
    {
        private static string filePath = "";

        StreamWriter streamWriter = new StreamWriter(filePath, false, System.Text.Encoding.Default);
        StreamReader streamReader = new StreamReader(filePath);

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
