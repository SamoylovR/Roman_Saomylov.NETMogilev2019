using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4Task5
{
    class Program
    {
        enum Operation
        {
            Add = 1,
            Subtract,
            Multiply,
            Divide
        }
        static void Main(string[] args)
        {
            ConsoleKeyInfo keypress;
            while (true)
            {
                Console.WriteLine("Введите первое число");
                string firstNumberBeforePars = Console.ReadLine().Replace(",", ".");
                if (double.TryParse(firstNumberBeforePars, out double firstnumber))
                {
                    while (true)
                    {
                        Console.WriteLine("Введите второе число");
                        string secondNumberBeforePars = Console.ReadLine().Replace(",", ".");
                        if (double.TryParse(secondNumberBeforePars, out double secondNumber))
                        {
                            firstnumber = GetDoubleNumber(firstNumberBeforePars);
                            secondNumber = GetDoubleNumber(secondNumberBeforePars);
                            Console.WriteLine("Какую операцию хотите выполнить над данными числами?" +
                                "\n1 - сложение" +
                                "\n2 - вычитание" +
                                "\n3 - умножение" +
                                "\n4 - деление");
                            string operations = Console.ReadLine();
                            switch (operations)
                            {
                                case "1":
                                    MathOperations(firstnumber, secondNumber, Operation.Add);
                                    break;
                                case "2":
                                    MathOperations(firstnumber, secondNumber, Operation.Subtract);
                                    break;
                                case "3":
                                    MathOperations(firstnumber, secondNumber, Operation.Multiply);
                                    break;
                                case "4":
                                    MathOperations(firstnumber, secondNumber, Operation.Divide);
                                    break;
                                default:
                                    Console.WriteLine("Проверьте корректность данных");
                                    break;
                            }
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Проверьте корректность данных");
                        }
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Проверьте корректность данных");
                }


            }
            Console.WriteLine("\nВы хотите езнать количество дней в определённом месяце?");
            Console.WriteLine("\nДа - 1" +
                "\nДля выхода нажмите на любой другой символ");


            keypress = Console.ReadKey();
            if (keypress.KeyChar == '1')
            {
                NumberOfDaysInAMonth();
            }
        }
        private static void MathOperations(double firstNumber, double secondNumber, Operation operation)
        {
            double result = 0.0;

            switch (operation)
            {
                case Operation.Add:
                    result = firstNumber + secondNumber;
                    break;
                case Operation.Subtract:
                    result = firstNumber - secondNumber;
                    break;
                case Operation.Multiply:
                    result = firstNumber * secondNumber;
                    break;
                case Operation.Divide:
                    result = firstNumber / secondNumber;
                    break;
            }
            Console.WriteLine("Результат операции равен {0}", result);
        }
        private static double GetDoubleNumber(string element)
        {
            double doubleNumber;
            try
            {
                doubleNumber = double.Parse(element.Replace(",", "."));
            }
            catch
            {
                doubleNumber = double.Parse(element.Replace(".", ","));
            }
            return doubleNumber;
        }
        private static void NumberOfDaysInAMonth()
        {
            byte monthNumber, year;

            while (true)
            {
                Console.Write("Введите номер месяцa: ");

                bool convertResult = Byte.TryParse(Console.ReadLine(), out monthNumber);

                if (convertResult && monthNumber > 0 && monthNumber < 12)
                {
                    while (true)
                    {
                        Console.Write("Год високосный? Если да, введите 1, а если нет - 0: ");

                        bool innerConvertResult = Byte.TryParse(Console.ReadLine(), out year);

                        if (innerConvertResult && year != 0 && monthNumber != 1)
                            break;

                        Console.WriteLine("Некорректно введены данные");
                    }

                    break;
                }

                Console.WriteLine("Нет такого месяца, введите ещё раз");
            }

            switch (monthNumber)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12: Console.WriteLine("В этом месяце 31 день"); break;
                case 2:
                    if (year == 1)
                        Console.WriteLine("В этом месяце 29 дней");
                    else
                        Console.WriteLine("В этом месяце 28 дней");
                    break;
                case 4:
                case 6:
                case 9:
                case 11: Console.WriteLine("В этом месяце 30 дней"); break;
            }
        }
    }
}
