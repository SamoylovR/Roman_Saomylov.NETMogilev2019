using FinanceHelper.BLL;
using FinanceHelper.Common.Entity;
using FinanceHelper.DI;
using FinanceHelper.UI;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace FinanceHelper
{
    class Program
    {
        public static readonly IServiceProvider container = new ContainerBuilder().Build();

        static void Main(string[] args)
        {
            ConsoleApplication console = container.GetService<ConsoleApplication>();
            console.Run();
        }        
    }
}
