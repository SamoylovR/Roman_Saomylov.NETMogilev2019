using System;
using FinanceHelper.BLL;
using FinanceHelper.Common;
using FinanceHelper.Common.Entity;
using FinanceHelper.DAL;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = ConfigureServices();

            Console.WriteLine("\t\tДобро пожаловать в личный финансовый помощник\n" +
                "\tЗдесь Вы сможете записывать свои доходы и расходы\n" +
                "\tТакже Вам будет предоставляться статистика о совершённых операциях\n" +
                "\tУчёт ведётся в белорусских рублях (BYN)\n\n" +
                "Нажмите любую клавишу, чтобы продолжить...");

            Console.ReadKey();

            bool isProgramRunning = true;
            while (isProgramRunning)
            {
                RenderTable();
                ConsoleKeyInfo button = Console.ReadKey();

                if (button.KeyChar == 1)
                {
                    //Add income
                }
                else if(button.KeyChar == 2)
                {
                    //Add cost and change bool value
                }
            }
        }

        private static IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<IDistributor, Distributor>();
            services.AddSingleton<IRepository<Operation>, Repository>();

            return services.BuildServiceProvider();
        }

        static void RenderTable()
        {
            Console.Clear();

            Console.WriteLine("Нажмите один из символов для совершения опрерации:\n" +
                "1 - добавить доход\n" +
                "2 - добавить расход\n");

            MakeUnderline();
            Console.WriteLine("\n| {0, 20} | {1, 15} || {2, 20} | {3, 15} |", "Name of Income", "BYN", "Name of Cost", "BYN");

            void MakeUnderline()
            {
                for (int i = 0; i < 42; i++)
                {
                    Console.Write("_ ");
                }
            }
        }
    }
}
