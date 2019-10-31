using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstNumber = 10;
            double secondNumber = 5.5;
            double thirdNumber = 144.2;
            Console.WriteLine($"Увеличение трёх чисел ({firstNumber} | {secondNumber} | {thirdNumber}) на 10");
            (double, double, double) numbers = IncreaseNumbersByTen(firstNumber, secondNumber, thirdNumber);
            Console.WriteLine($"Результат --> {numbers.Item1} | {numbers.Item2} | {numbers.Item3}\n");

            double radius = 5.5;
            Console.WriteLine($"Нахождение площади круга и длинны окружности с радиусом {5.5}");
            (double, double) circle = FindCircleParameters(radius);
            Console.WriteLine($"Результат --> площадь круга - {Math.Round(circle.Item1, 2)}, длина окуржности - {Math.Round(circle.Item2, 2)}\n");

            double[] array = new double[6] { 2.5, 4.6, 7, 1, 4.2, 2 };
            Console.WriteLine($"Нахождение максимума, минимума и суммы элементов массива:");
            Console.Write("Массив => ");
            foreach (double a in array)
            {
                Console.Write($" {a} |");
            }
            Console.WriteLine();
            (double, double, double) arrayParameters = FindArrayParameters(array);
            Console.WriteLine($"Результат --> максимальный элемент - {arrayParameters.Item1}, минимальный элемент - {arrayParameters.Item2}, сумма элементов - {arrayParameters.Item3}");
        }

        static (double, double) FindCircleParameters<T>(T radius)
        {
            double innerRadius, square, length;
            try
            {
                innerRadius = (dynamic)radius;
                square = Math.PI * Math.Pow(innerRadius, 2);
                length = 2 * Math.PI * innerRadius;
            }
            catch
            {
                Console.WriteLine("|-Радиус не соответствует типу-|");
                square = 0;
                length = 0;
            }
            (double, double) circle = (square, length);

            return circle;
        }

        static (T, T, T) IncreaseNumbersByTen<T>(T firstNumber, T secondNumber, T thirdNumber) where T : struct
        {
            try
            {
                firstNumber += (dynamic)10;
                secondNumber += (dynamic)10;
                thirdNumber += (dynamic)10;
            }
            catch
            {
                Console.WriteLine("|-Ошибка-|");
            }

            (T, T, T) numbers = (firstNumber, secondNumber, thirdNumber);
            return numbers;
        }

        static (T, T, T) FindArrayParameters<T>(T[] array) where T : struct
        {
            T maxElement = array.Max();
            T minElement = array.Min();

            T sumOfElements = default(T);
            try
            {
                for (int i = 0; i < array.Length; i++)
                {
                    sumOfElements += (dynamic)array[i];
                }
            }
            catch
            {
                Console.WriteLine("|-Неверный тип массива-|");
            }

            (T, T, T) parameters = (maxElement, minElement, sumOfElements);
            return parameters;
        }
    }
}
