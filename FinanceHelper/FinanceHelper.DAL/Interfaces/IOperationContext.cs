using FinanceHelper.Common.Entity;
using System.Collections.Generic;

namespace FinanceHelper.DAL
{
    public interface IOperationContext
    {
        List<Operation> Operations { get; set; }
    }
}
