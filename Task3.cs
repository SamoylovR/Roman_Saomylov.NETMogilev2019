using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfArray = 0;

            while (true)
            {
                Console.Write("Введите количество цифр, которые вы хотите видеть в ряде Фибоначчи: ");

                if (int.TryParse(Console.ReadLine(), out sizeOfArray))
                {
                    if(sizeOfArray > 94)
                        Console.WriteLine("Вы ввели слишком большое число, которое мы не можем обработать");
                    else
                        break;
                }

                Console.WriteLine("|-Проверьте корректность введённых данных-|");
            }

            long[] fibonacciNumbers = new long[sizeOfArray];

            fibonacciNumbers[1] = 1;

            for (int i = 2; i < sizeOfArray; i++) 
            {
                fibonacciNumbers[i] = fibonacciNumbers[i - 1] + fibonacciNumbers[i - 2];
            }

            for(int i = 0; i < sizeOfArray; i++) 
                Console.Write($"{fibonacciNumbers[i]} ");
        }
    }
}
