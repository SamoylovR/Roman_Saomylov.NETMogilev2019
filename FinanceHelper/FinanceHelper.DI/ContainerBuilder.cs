using FinanceHelper.BLL;
using FinanceHelper.Common;
using FinanceHelper.Common.Entity;
using FinanceHelper.DAL;
using FinanceHelper.DALJson;
using FinanceHelper.DALJson.Interfaces;
using FinanceHelper.UI;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FinanceHelper.DI
{
    public class ContainerBuilder
    {
        public IServiceProvider Build()
        {
            var services = new ServiceCollection();

            services.AddTransient<IRepository<Operation>, Repository>();
            services.AddTransient<IDistributor, Distributor>();
            services.AddTransient<IOperationContext, OperationContext>();
            services.AddTransient<IJsonRepository, JsonRepository>();
            services.AddTransient<ConsoleApplication>();

            return services.BuildServiceProvider();
        }
    }
}
