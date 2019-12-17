using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstNumber = 10;
            double secondNumber = 5.5;
            double thirdNumber = 144.2;
            Console.WriteLine($"Увеличение трёх чисел ({firstNumber} | {secondNumber} | {thirdNumber}) на 10");
            IncreaseNumbersByTen(ref firstNumber, ref secondNumber, ref thirdNumber);
            Console.WriteLine($"Результат --> {firstNumber} | {secondNumber} | {thirdNumber}\n");

            double radius = 5.5;
            Console.WriteLine($"Нахождение площади круга и длинны окружности с радиусом {5.5}");
            FindCircleParameters(radius, out double square, out double length);
            Console.WriteLine($"Результат --> площадь круга - {Math.Round(square, 2)}, длина окуржности - {Math.Round(length, 2)}\n");

            double[] array = new double[6] { 2.5, 4.6, 7, 1, 4.2, 2 };
            Console.WriteLine($"Нахождение максимума, минимума и суммы элементов массива:");
            Console.Write("Массив => ");
            foreach (double a in array) 
            {
                Console.Write($" {a} |");
            }
            Console.WriteLine();
            FindArrayParameters(array, out double maxElement, out double minElement, out double sumOfElements);
            Console.WriteLine($"Результат --> максимальный элемент - {maxElement}, минимальный элемент - {minElement}, сумма элементов - {sumOfElements}");
        }

        static void IncreaseNumbersByTen<T>(ref T firstNumber, ref T secondNumber, ref T thirdNumber) where T : struct
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
        }

        static void FindCircleParameters<T>(T radius, out double square, out double length) where T : struct
        {
            double innerRadius;
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
                return;
            }
        }

        static void FindArrayParameters<T>(T[] array, out T maxElement, out T minElement, out T sumOfElements) where T : struct
        {
            maxElement = array.Max();
            minElement = array.Min();

            sumOfElements = default(T);
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
        }
    }
}
