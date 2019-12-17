using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int[] numbersArray;

            while (true)
            {
                Console.WriteLine("Вы хотите самомстоятельно ввести массив?");

                string answer = Console.ReadLine().ToLower();

                if (answer == "нет" || answer == "ytn")
                {
                    numbersArray = new int[rnd.Next(5, 35)];

                    for (int i = 0; i < numbersArray.Length; i++)
                    {
                        numbersArray[i] = rnd.Next(-50, 50);
                    }

                    break;
                }
                else if (answer == "да" || answer == "lf")
                {
                    Console.Write("Введите длинну массива");
                    numbersArray = new int[ParseNumber<int>()];

                    for (int i = 0; i < numbersArray.Length; i++)
                    {
                        Console.WriteLine($"ent num {i + 1}");

                        numbersArray[i] = ParseNumber<int>();
                    }
                    break;
                }

                Console.WriteLine("Не удалось распознать команду");
            }

            Console.WriteLine("Исходный массив:");

            foreach (var n in numbersArray)
                Console.Write("{0, 3} ", n);
            Console.WriteLine();

            Console.WriteLine("Преобразованный массив:");

            foreach (var n in numbersArray)
                Console.Write("{0, 3} ", n * (-1));
            Console.WriteLine();
        }

        static T ParseNumber<T>() where T : struct
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