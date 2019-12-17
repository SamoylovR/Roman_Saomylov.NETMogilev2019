using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3Task7
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int[] numbersArray;

            while (true)
            {
                Console.WriteLine("Хотите ли вы самостоятельно ввести массив? [Да/Нет]");

                string answer = Console.ReadLine().ToLower();

                if (answer == "нет" || answer == "ytn")
                {
                    numbersArray = new int[rnd.Next(5, 50)];

                    for (int i = 0; i < numbersArray.Length; i++)
                    {
                        numbersArray[i] = rnd.Next(-50, 50);
                    }

                    break;
                }
                else if (answer == "да" || answer == "lf")
                {
                    Console.Write("Введите длинну массива, который вы хотите задать: ");

                    numbersArray = new int[ParseNumber<int>()];

                    for (int i = 0; i < numbersArray.Length; i++)
                    {
                        Console.Write($"Введите {i + 1}-й элемент: ");
                        numbersArray[i] = ParseNumber<int>();
                    }
                    break;
                }

                Console.WriteLine("|-Проверьте корректность введённых данных-|");
            }

            Console.WriteLine("Ваш массив");

            foreach (var n in numbersArray)
                Console.Write($"{n} ");
            Console.WriteLine();
            Console.WriteLine("Вывод чисел: ");

            bool isNumbersOut = false;

            for (int i = 1; i < numbersArray.Length; i++)
            {
                if (numbersArray[i] > numbersArray[i - 1])
                {
                    Console.Write($"{numbersArray[i]} ");
                    isNumbersOut = true;
                }
            }

            if (!isNumbersOut)
            {
                Console.WriteLine("В данном масиве не было заданных случаев");
            }
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
