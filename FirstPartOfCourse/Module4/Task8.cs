using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4Task8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Решение уравнения sin(x) - cos(x) с точностью до 0.0001 методом бисекции с использованием рекурсии ");
            Console.WriteLine($"Результат --> x = {BisectionMethod(0, 100, 0.0001)}");
        }

        static double Function(double argument)
        {
            return Math.Sin(argument) - Math.Cos(argument);
        }

        static double BisectionMethod(double leftBorder, double rightBorder, double accuracy)
        {
            double center = (leftBorder + rightBorder) / 2;

            if (Function(center) > 0)
            {
                rightBorder = center;
            }
            else
            {
                leftBorder = center;
            }

            if (Math.Abs(Function(center)) > accuracy)
            {
                return BisectionMethod(leftBorder, rightBorder, accuracy);
            }

            return center;
        }
    }
}
