using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstNumber = 0, secondNumber = 0;

            while (true)
            {
                bool isParsingDone = false;
                Console.Write("Введите первое число: ");
                
                if(double.TryParse(Console.ReadLine().Replace(".", ","), out firstNumber))
                {
                    while (true)
                    {
                        Console.Write("Введите второе число: ");

                        if (double.TryParse(Console.ReadLine().Replace(".", ","), out secondNumber))
                        {
                            isParsingDone = true;
                            break;
                        }

                        Console.WriteLine("Проверьте корректность введённых данных");
                    }
                }

                if (isParsingDone)
                    break;

                Console.WriteLine("Проверьте корректность введённых данных");
            }
            Console.WriteLine();

            Console.WriteLine($"Первое число - {firstNumber}, а второе - {secondNumber}");

            double bufferdNumber = firstNumber;
            firstNumber = secondNumber;
            secondNumber = bufferdNumber;

            Console.WriteLine($"Теперь первое число - {firstNumber}, а второе - {secondNumber}");
        }
    }
}
