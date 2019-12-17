using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4Task7
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstArray = new int[5] { 1, 5, 6, 4, 7 };
            GetSortedArray<int>(firstArray);

            double[] secondArray = new double[5] { 1.2, 5.7, 5.4, 4.1, 7.6 };
            GetSortedArray<double>(secondArray, true);

            Console.Write($"Обычно отсортированный целочисленный массив - ");
            for (int i = 0; i < firstArray.Length; i++)
            {
                Console.Write($"{firstArray[i]} | ");
            }
            Console.WriteLine();

            Console.Write($"Обратно отсортированный массив дробных чисел - ");
            for (int i = 0; i < secondArray.Length; i++)
            {
                Console.Write($"{secondArray[i]} | ");
            }
            Console.WriteLine();
        }

        static void GetSortedArray<T>(T[] array, bool IsSortReverse = false) where T : struct
        {
            Array.Sort(array);

            if (IsSortReverse)
            {
                Array.Reverse(array);
            }
        }
    }
}
