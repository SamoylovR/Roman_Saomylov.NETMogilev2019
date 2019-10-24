using System;
using System.Collections.Generic;
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
                    while (true)
                    {
                        Console.Write("Введите длинну массива, который вы хотите задать: ");

                        if (int.TryParse(Console.ReadLine(), out int length))
                        {
                            numbersArray = new int[length];
                            break;
                        }

                        Console.WriteLine("|-Проверьте корректность введённых данных-|");
                    }

                    for (int i = 0; i < numbersArray.Length; i++)
                    {
                        while (true)
                        {
                            Console.WriteLine($"Введите {i + 1}-й элемент");

                            if (int.TryParse(Console.ReadLine(), out numbersArray[i]))
                                break;

                            Console.WriteLine("|-Проверьте корректность введённых данных-|");
                        }
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
    }
}
