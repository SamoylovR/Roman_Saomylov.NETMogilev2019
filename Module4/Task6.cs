using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] integerArray = new int[5] { 1, 2, 3, 4, 5 };
            double[] doubleArray = new double[5] { 1.5, 2.3, 3.6, 4.1, 5.4 };
            string[] stringArray = new string[5] { "Hello", "* *", "Wor", "ld!", "Hi actually" };

            Console.WriteLine("Исходный массив дробных чисел:");
            foreach (var d in doubleArray)
                Console.Write($"{d} ");
            Console.WriteLine("\n");

            Console.WriteLine("Исходный массив целых чисел:");
            foreach (var i in integerArray)
                Console.Write($"{i} ");
            Console.WriteLine("\n");

            Console.WriteLine("Исходный массив строк:");
            foreach (var s in stringArray)
                Console.Write($"{s} ");
            Console.WriteLine("\n");

            GetArrayPlusFive(doubleArray);
            GetArrayPlusFive(integerArray);
            GetArrayPlusFive(stringArray);

            Console.WriteLine("Прибавление 5 к массиву дробных чисел:");
            foreach (var d in doubleArray)
                Console.Write($"{d} ");
            Console.WriteLine("\n");

            Console.WriteLine("Прибавление 5 к массиву целых чисел:");
            foreach (var i in integerArray)
                Console.Write($"{i} ");
            Console.WriteLine("\n");

            Console.WriteLine("Прибавление 5 к массиву строк:");
            foreach (var s in stringArray)
                Console.Write($"{s} ");
            Console.WriteLine("\n");
        }

        static void GetArrayPlusFive<T>(T[] array) where T: struct
        {
            T answer = default(T);

            for (int i = 0; i < array.Length; i++)
            {
                try 
                {
                    answer = (dynamic)array[i] + 5;
                }
                catch { }

                array[i] = answer;
            }
        }

        static void GetArrayPlusFive(string[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] += "5";
            }
        }
    }
}
