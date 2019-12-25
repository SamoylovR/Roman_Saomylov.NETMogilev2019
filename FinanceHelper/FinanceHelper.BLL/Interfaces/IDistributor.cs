using FinanceHelper.BLL.Interfaces;
using FinanceHelper.Common.Entity;

namespace FinanceHelper.BLL
{
    public interface IDistributor : IService<Operation>
    {
        public double GetMeanIncome();

        public double GetMeanCosts();

        public double GetDelta();
    }
}
