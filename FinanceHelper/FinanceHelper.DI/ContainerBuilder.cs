using FinanceHelper.BLL;
using FinanceHelper.Common;
using FinanceHelper.Common.Entity;
using FinanceHelper.DAL;
using FinanceHelper.DALADO;
using FinanceHelper.DALADO.Interfaces;
using FinanceHelper.DALEF;
using FinanceHelper.DALEF.Interfaces;
using FinanceHelper.DALJson;
using FinanceHelper.DALJson.Interfaces;
using FinanceHelper.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FinanceHelper.DI
{
    public class ContainerBuilder
    {
        public IServiceProvider Build()
        {
            var services = new ServiceCollection();

            services.AddTransient<IRepository<Operation>, OperationRepository>();
            services.AddTransient<IDistributor, Distributor>();
            services.AddTransient<IOperationContext, OperationContext>();
            services.AddTransient<IJsonRepository, JsonRepository>();
            services.AddTransient<IAdoRepository, AdoRepository>();
            services.AddTransient<IEntityRepository, EntityRepository>();
            services.AddSingleton<ConsoleApplication>();

            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(Config.connectionString));

            return services.BuildServiceProvider();
        }
    }
}
