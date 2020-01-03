using FinanceHelper.UI;

namespace FinanceHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleApplication console = container.GetService<ConsoleApplication>();
            console.Run();
        }
    }
}
