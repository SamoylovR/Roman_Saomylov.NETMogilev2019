using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[5] { 5, 2, 3, 1, 4 };
            Console.WriteLine("Исходный массив:");
            foreach (int a in array) Console.Write($"{a} ");
            Console.WriteLine("\n");

            Console.WriteLine($"Минимальный объект массива: {GetMinInArray(array)}\n");
            Console.WriteLine($"Максимальный объект массива: {GetMaxInArray(array)}\n");
            Console.WriteLine($"Сумма элементов массива: {GetSumOfArray(array)}\n");
            Console.WriteLine($"Разница между максимальным и минимальным элементами массива: {GetDifference(array)}\n");

            EditArray(array);
            Console.WriteLine("Изменённый массив (четные увеличены на максимальный элемент, нечётные уменьшены на минимальный элемент):");
            foreach (int a in array) Console.Write($"{a} ");
            Console.WriteLine();
        }

        static T GetMinInArray<T>(T[] array) where T : struct
        {
            return array.Min();
        }

        static T GetMaxInArray<T>(T[] array) where T : struct
        {
            return array.Max();
        }

        static T GetSumOfArray<T>(T[] array) where T : struct
        {
            T answer = default(T);

            foreach (var a in array)
                answer += (dynamic)a;

            return answer;
        }

        static T GetDifference<T>(T[] array) where T : struct
        {
            T maxValue = GetMaxInArray(array);
            T minValue = GetMinInArray(array);

            return (dynamic)maxValue - minValue;
        }

        static void EditArray<T>(T[] array) where T : struct
        {
            T maxValue = GetMaxInArray(array);
            T minValue = GetMinInArray(array);

            for (int i = 0; i < array.Length; i++)
            {
                if ((dynamic)array[i] % 2 == 0)
                {
                    array[i] += (dynamic)maxValue;
                }
                else if((dynamic)array[i] % 2 == 1)  //Сделано, чтобы метод не реагировал на дробные числа
                {
                    array[i] -= (dynamic)minValue;
                }
            }
        }
    }
}
