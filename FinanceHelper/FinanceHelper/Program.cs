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
<<<<<<< HEAD
            ConsoleApplication console = container.GetService<ConsoleApplication>();
            console.Run();
        }
=======
<<<<<<< HEAD
            ConsoleApplication console = container.GetService<ConsoleApplication>();
            console.Run();
        }
=======
           ConsoleApplication console = container.GetService<ConsoleApplication>();
           console.Run();
        }        
>>>>>>> e388b9922d111a302ccb01030f36b9c1e96cb863
>>>>>>> 63d0d0d50b303d0bfc8ac157560861290a6fd9c7
    }
}
