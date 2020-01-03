using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstArray = new int[5] { 7, 12, 1, 5, 0 };
            int[] secondArray = new int[4] { 1, 2, 3, 4 };
            int[] thirdArray = GetSumOfArray(firstArray, secondArray);

            Console.WriteLine("Результат сложения двух массивов");

            Console.Write("Первый: ");
            foreach (int f in firstArray)
                Console.Write($"{f} ");
            Console.WriteLine();

            Console.Write("Второй: ");
            foreach (int s in secondArray)
                Console.Write($"{s} ");
            Console.WriteLine();

            Console.Write("Результат: ");
            foreach (int t in thirdArray)
                Console.Write($"{t} ");
            Console.WriteLine("\n");

            int firstNumber = 45;
            int secondNumber = 25;
            int thirdNumber = Addition(firstNumber, secondNumber);

            Console.WriteLine("Результат сложения двух чисел");
            Console.WriteLine($"Первое число: {firstNumber}");
            Console.WriteLine($"Второе число: {secondNumber}");
            Console.WriteLine($"Результат: {thirdNumber}\n");

            Console.WriteLine("Результат сложения трёх чисел");
            Console.WriteLine($"Первое число: {firstNumber}");
            Console.WriteLine($"Второе число: {secondNumber}");
            Console.WriteLine($"Третье число: {thirdNumber}");
            Console.WriteLine($"Результат: {Addition(firstNumber, secondNumber, thirdNumber)}\n");

            double firstDoubleNumber = 4.6;
            double secondDoubleNumber = 2.3;

            Console.WriteLine("Результат сложения дробных чисел");
            Console.WriteLine($"Первое число: {firstDoubleNumber}");
            Console.WriteLine($"Второе число: {secondDoubleNumber}");
            Console.WriteLine($"Результат: {Addition(firstDoubleNumber, secondDoubleNumber)}\n");

            string firstString = "Hello";
            string secondString = "World";

            Console.WriteLine("Результат сложения двух строк");
            Console.WriteLine($"Первое число: {firstString}");
            Console.WriteLine($"Второе число: {secondString}");
            Console.WriteLine($"Результат: {Addition(firstString, secondString)}\n");
        }

        static int Addition(params int[] numbers) //позволяет складывать два и три целых числа
        {
            int sum = 0;

            foreach (int n in numbers)
                sum += n;

            return sum;
        }

        static double Addition(params double[] numbers) //Позволяет складывать три дробных числа
        {
            double sum = 0;

            foreach (double n in numbers)
                sum += n;

            return sum;
        }

        static string Addition(string firstString, string secondString) //Позволяет складывать две строки между собой
        {
            return String.Concat(firstString, secondString);
        }

        static int[] GetSumOfArray(int[] firstArray, int[] secondArray) //Позволяет складывать два массива
        {
            int minLength;
            int[] resultArray;

            if (firstArray.Length > secondArray.Length)
            {
                resultArray = new int[firstArray.Length];
                minLength = secondArray.Length;

                for (int i = minLength; i < resultArray.Length; i++)
                    resultArray[i] = firstArray[i];
            }
            else if (secondArray.Length > firstArray.Length)
            {
                resultArray = new int[secondArray.Length];
                minLength = firstArray.Length;

                for (int i = minLength; i < resultArray.Length; i++)
                    resultArray[i] = secondArray[i];
            }
            else
            {
                resultArray = new int[secondArray.Length];
                minLength = firstArray.Length;
            }

            for (int i = 0; i < minLength; i++)
                resultArray[i] = firstArray[i] + secondArray[i];

            return resultArray;
        }
    }
}
