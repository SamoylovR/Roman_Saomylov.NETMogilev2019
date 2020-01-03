using FinanceHelper.DI;
using FinanceHelper.UI;
using Microsoft.Extensions.DependencyInjection;
using System;

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
