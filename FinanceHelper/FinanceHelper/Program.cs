using System;
using System.Collections.Generic;
using FinanceHelper.BLL;
using FinanceHelper.Common;
using FinanceHelper.Common.Entity;
using FinanceHelper.DAL;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceHelper
{
    class Program
    {
        public static readonly IServiceProvider container = new ContainerBuilder().Build();

        static void Main(string[] args)
        {
            var distributor = container.GetService<IDistributor>();

            Console.WriteLine("\t\tДобро пожаловать в личный финансовый помощник\n" +
                "\tЗдесь Вы сможете записывать свои доходы и расходы\n" +
                "\tТакже Вам будет предоставляться статистика о совершённых операциях\n" +
                "\tУчёт ведётся в белорусских рублях (BYN)\n\n" +
                "Нажмите любую клавишу, чтобы продолжить...");

            Console.ReadKey();

            bool isProgramRunning = true;
            while (isProgramRunning)
            {
                RenderTable(/*distributor.GetIncome(), distributor.GetCosts()*/);
                ConsoleKeyInfo button = Console.ReadKey();

                if (button.KeyChar == '1')
                {
                    Console.Clear();

                    Console.Write("Название операции: ");
                    string name = Console.ReadLine();

                    double sum = 0;
                    Console.Write("Введите сумму дохода: ");
                    while (!double.TryParse(Console.ReadLine(), out sum))
                    {
                        Console.Write("Введите корректную сумму дохода: ");
                    }

                    Operation operation = new Operation();
                    operation.Name = name;
                    operation.Sum = sum;
                    distributor.AddNewOperation(operation);
                }
                else if(button.KeyChar == 2)
                {
                    Console.Clear();

                    Console.Write("Название операции: ");
                    string name = Console.ReadLine();

                    double sum = 0;
                    Console.Write("Введите сумму дохода: ");
                    while (!double.TryParse(Console.ReadLine(), out sum))
                    {
                        Console.Write("Введите корректную сумму дохода: ");
                    }

                    Operation operation = new Operation();
                    operation.Name = name;
                    operation.Sum = sum;
                    operation.IsOperationIncome = false;
                    distributor.AddNewOperation(operation);
                }
            }
        }

        static void RenderTable(/*IEnumerable<Operation> income, IEnumerable<Operation> costs*/)
        {
            Console.Clear();

            Console.WriteLine("Нажмите один из символов для совершения опрерации:\n" +
                "\t1 - добавить доход\n" +
                "\t2 - добавить расход\n");

            MakeUnderline();
            Console.WriteLine("\n| {0, 20} | {1, 15} || {2, 20} | {3, 15} |", "Name of Income", "BYN", "Name of Cost", "BYN");
            MakeUnderline();


            void MakeUnderline()
            {
                for (int i = 0; i < 42; i++)
                {
                    Console.Write("- ");
                }
            }
        }
    }
}
