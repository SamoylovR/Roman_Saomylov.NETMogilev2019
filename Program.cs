using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCompanies = 0;
            double taxPercent = 0;

            while (true)
            {
                bool isParsingDone = false;
                Console.Write("Введите количество компаний, работающих в стране: ");

                if (int.TryParse(Console.ReadLine(), out numberOfCompanies) && numberOfCompanies > 0)
                {
                    while (true)
                    {
                        Console.Write("Введите процент налога: ");
                        string taxString = Console.ReadLine();
                        taxString = taxString.Replace(" ", string.Empty).Replace('.', ',').Replace("%", string.Empty);

                        bool isSubmitionDone = false;

                        if (double.TryParse(taxString, out taxPercent) && taxPercent > 0)
                        {
                            if (taxPercent > 100)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Вы вводите процент, который будет превышать общий доход компании\n" +
                                    "Вы уверены в своих действиях?");

                                while (true)
                                {
                                    Console.Write("[Да/1, Нет/2]: ");

                                    string answer = Console.ReadLine().ToLower();

                                    if (answer == "нет" || answer == "2")
                                    {
                                        break;
                                    }
                                    else if (answer == "да" || answer == "1")
                                    {
                                        isParsingDone = true;
                                        isSubmitionDone = true;
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("|- Не удаётся распознать ответ -|");
                                    }                                  
                                }
                            }
                            else
                            {
                                isParsingDone = true;
                                break;
                            }
                        }

                        if (isSubmitionDone)
                            break;

                        Console.WriteLine("|- Проверьте корректность введённых данных -|");
                    }
                }

                if (isParsingDone)
                    break;

                Console.WriteLine("|- Проверьте корректность введённых данных -|");
            }

            taxPercent /= 100;

            Console.WriteLine($"Общий налог составляет {(500 * taxPercent) * numberOfCompanies}");
        }
    }
}
