using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int naturalNumber = 0;

            while (true)
            {
                Console.Write("Введите натуральное число: ");

                if (int.TryParse(Console.ReadLine(), out naturalNumber) && naturalNumber > 0)
                    break;

                Console.WriteLine("|-Проверьте корректность введённых данных-|");
            }

            Console.WriteLine($"Первые {naturalNumber} натуральных чётных чисел");
            
            for (int i = 2; i <= naturalNumber * 2; i = i + 2)
            {
                Console.Write($"{i} ");

                if (i % 25 == 0)        //Сделано, чтобы вывод был более структурированным
                    Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
