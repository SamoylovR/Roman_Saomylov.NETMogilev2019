using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int naturalNumber;

            while (true)
            {
                Console.Write("Введите натуральное число: ");

                naturalNumber = ParsNumber<int>();

                if(naturalNumber > 0)
                {
                    break;
                }
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
