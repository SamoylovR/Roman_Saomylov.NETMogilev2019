using FinanceHelper.BLL;
using FinanceHelper.Common;
using FinanceHelper.Common.Entity;
using FinanceHelper.DAL;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceHelper
{
    public class ContainerBuilder
    {
        public IServiceProvider Build()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IDistributor, Distributor>();
            services.AddSingleton<IRepository<Operation>, Repository>();

            return services.BuildServiceProvider();
        }
    }
}
