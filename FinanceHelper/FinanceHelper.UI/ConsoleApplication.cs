using FinanceHelper.BLL;
using FinanceHelper.Common.Entity;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace FinanceHelper.UI
{
    public class ConsoleApplication
    {
        private readonly IDistributor distributor;

        public ConsoleApplication(IDistributor distributor)
        {
            this.distributor = distributor;
        }

        public void Run()
        {
            Console.WriteLine("\t\tДобро пожаловать в личный финансовый помощник\n" +
                "\tЗдесь Вы сможете записывать свои доходы и расходы\n" +
                "\tТакже Вам будет предоставляться статистика о совершённых операциях\n" +
                "\tУчёт ведётся в белорусских рублях (BYN)\n\n" +
                "Нажмите любую клавишу, чтобы продолжить...");

            Console.ReadKey();

            while (true)
            {
                RenderTable(distributor.GetIncome(), distributor.GetCosts());

                CheckButton(distributor);
            }
        }

        void RenderTable(IEnumerable<Operation> income, IEnumerable<Operation> costs)
        {
            Console.Clear();

            Console.WriteLine("Нажмите один из символов для совершения опрерации:\n" +
                "\t1 - добавить доход\n" +
                "\t2 - добавить расход\n" +
                "\tF2 - посмотреть средние значения операций\n" +
                "\tF3 - посмотреть дельту\n" +
                "\tF4 - очистить список");


            if (income != null && costs != null)
            {
                MakeUnderline();
                Console.WriteLine("\n|| {0, 20} | {1, 15} || {2, 15}", "Name of Income", "BYN", "Tax, BYN");
                MakeUnderline();

                foreach (var inc in income)
                {
                    Console.WriteLine("\n|| {0, 20} | {1, 15} || {2, 15}", inc.Name, inc.Sum, inc.Tax);
                    MakeUnderline();
                }
                Console.WriteLine("\n\n");


                MakeUnderline();
                Console.WriteLine("\n|| {0, 20} | {1, 15} ||", "Name of Cost", "BYN");
                MakeUnderline();

                foreach (var cost in costs)
                {
                    Console.WriteLine("\n|| {0, 20} | {1, 15} ||", cost.Name, cost.Sum);
                    MakeUnderline();
                }
            }
            else 
            {
                MakeUnderline();
                Console.WriteLine("\n\tДанных пока нет");
                MakeUnderline();
            }
            void MakeUnderline()
            {
                for (int i = 0; i < 22; i++)
                {
                    Console.Write("- ");
                }
            }
        }

        public void CheckButton(IDistributor distributor)
        {
            ConsoleKeyInfo button = Console.ReadKey();

            if (button.Key == ConsoleKey.NumPad1 || button.KeyChar == '1')
            {
                Operation operation = MakeOperation("Доход");
                distributor.AddNewOperation(operation);
            }
            else if (button.Key == ConsoleKey.NumPad2 || button.KeyChar == '2')
            {
                Operation operation = MakeOperation("Расход");
                operation.IsOperationIncome = false;
                distributor.AddNewOperation(operation);
            }
            else if (button.Key == ConsoleKey.F2)
            {
                Console.WriteLine($"\nСредняя сумма траты составляет - {Math.Round(distributor.GetMeanCosts(), 2)}\n" +
                    $"Средняя сумма дохода составляет - {Math.Round(distributor.GetMeanIncome(), 2)}\n\n" +
                    $"Для возобновления работы программы нажмите любую клавишу...");

                Console.ReadKey();
            }
            else if (button.Key == ConsoleKey.F3)
            {
                Console.WriteLine($"\nДельта - {Math.Round(distributor.GetDelta(), 2)}\n\n" +
                    $"Для возобновления работы программы нажмите любую клавишу...");
                Console.ReadKey();
            }
            else if(button.Key == ConsoleKey.F4)
            {
                distributor.ClearOperationData();
            }
        }

        public Operation MakeOperation(string typeOfOperation)
        {
            Console.Clear();
            Console.Write($"{typeOfOperation}\nНазвание операции: ");

            string name = Console.ReadLine();
            double sum = 0;

            Console.Write("Введите сумму операции: ");

            while (!double.TryParse(Console.ReadLine(), out sum))
            {
                Console.Write("Введите корректную сумму операции: ");
            }

            Operation operation = new Operation
            {
                Name = name,
                Sum = sum
            };

            return operation;
        }
    }
}
