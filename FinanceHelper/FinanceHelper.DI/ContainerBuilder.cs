using FinanceHelper.BLL;
using FinanceHelper.Common;
using FinanceHelper.Common.Entity;
using FinanceHelper.DAL;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FinanceHelper.DI
{
    public class ContainerBuilder
    {
        public static IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<IDistributor, Distributor>();
            services.AddSingleton<IRepository<Operation>, Repository>();

            return services.BuildServiceProvider();
        }
    }
}
