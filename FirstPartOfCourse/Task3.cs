using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfArray;

            while (true)
            {
                Console.Write("Введите количество чисел, которые вы хотите видеть в ряде Фибоначчи: ");

                sizeOfArray = ParsNumber<int>();

                if (sizeOfArray > 93)
                {
                    Console.WriteLine("Вы ввели слишком большое число, которое не получается корректно обработать");
                }
                else break;
            }

            long[] fibonacciNumbers = new long[sizeOfArray];

            fibonacciNumbers[1] = 1;

            for (int i = 2; i < sizeOfArray; i++)
            {
                fibonacciNumbers[i] = fibonacciNumbers[i - 1] + fibonacciNumbers[i - 2];
            }

            for (int i = 0; i < sizeOfArray; i++)
            {
                Console.Write("{0,20} | ", fibonacciNumbers[i]);

                if (i % 4 == 0 && i != 0)
                {
                    Console.WriteLine();
                }
            }
        }

        static T ParsNumber<T>() where T : struct
        {
            while (true)
            {
                var converter = TypeDescriptor.GetConverter(typeof(T));

                if (converter != null)
                {
                    string number = Console.ReadLine();
                    try
                    {
                        return (T)converter.ConvertFromString(number);
                    }
                    catch
                    {
                        Console.WriteLine("|-Проверьте корректность введённых данных-|");
                    }
                }
            }
        }
    }
}
