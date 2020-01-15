using FinanceHelper.DI;
using FinanceHelper.UI;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleApplication console = new ContainerBuilder().Build().GetService<ConsoleApplication>();
            console.Run();
        }
    }
}
