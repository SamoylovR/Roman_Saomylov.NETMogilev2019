using FinanceHelper.Common;
using FinanceHelper.Common.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceHelper.BLL
{
    public interface IDistributor : IRepository<Operation>
    {
        public double GetMeanIncome();

        public double GetMeanCosts();

        public double GetDelta();
    }
}
