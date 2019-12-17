using FinanceHelper.Common.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceHelper.DAL
{
    public interface IOperationContext
    {
        List<Operation> Operations { get; set; }
    }
}
