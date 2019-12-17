using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            double commonSquare = 0;
            byte numberOfSides = 0;
            string figure;

            while (true)
            {
                bool isInputDone = false;

                Console.Write("Ведите фигуру (или количество сторон фигуры),\n" +
                              "периметр или площадь котрой вы хотите посчитать\n" +
                              "[пока доступны только Круг, Четырёхугольник/4, Треугольник/3]: ");

                figure = Console.ReadLine();
                figure = figure.ToLower();

                if(figure == "треугольник" || figure == "3")
                {
                    figure = "Треугольник";
                    numberOfSides = 3;
                    isInputDone = true;
                }
                else if(figure == "четырёхугольник" || figure == "4")
                {
                    figure = "Четырёхугольник";
                    numberOfSides = 4;
                    isInputDone = true;
                }
                else if (figure == "круг")
                {
                    figure = "Круг";
                    numberOfSides = 1;
                    isInputDone = true;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("|- Проверьте корректность введёных данных -|");
                    Console.WriteLine();
                }

                if (isInputDone)
                {
                    Console.Clear();
                    Console.WriteLine($"Вы выбрали {figure}");
                    Console.WriteLine();

                    break;
                }
            }

            double[] sides = new double[numberOfSides];

            while (true)
            {
                for (int i = 0; i < numberOfSides; i++)
                {
                    if (numberOfSides == 1)
                    {
                        Console.WriteLine($"Введите радиус");
                    }
                    else
                    {
                        Console.WriteLine($"Введите {i + 1}-ю сторону");
                    }

                    while (true)
                    {
                        if (double.TryParse(Console.ReadLine(), out sides[i]) && sides[i] > 0)
                            break;

                        Console.WriteLine("Проверьте корректность введёных данных");
                    }
                }

                commonSquare = Square(sides);

                if (double.IsNaN(commonSquare) || commonSquare < 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Фигура с такими сторонами не существует, попробуйте снова");
                    Console.WriteLine();
                }
                else break;
            }

            Console.Write("Что вы хотите вычислить у данной фигуры?\n");
            while (true)
            {
                double perimetеr = 0;

                Console.WriteLine("[Площадь/1, Периметр/2]: ");

                string operation = Console.ReadLine();
                operation = operation.ToLower();

                if(operation == "площадь" || operation == "1")
                {
                    Console.Clear();
                    Console.WriteLine($"Площадь вашей фигуры равна - {Math.Round(commonSquare, 2)}");

                    break;
                }
                else if(operation == "периметр" || operation == "2")
                {
                    if(sides.Length == 1)
                    {
                        perimetеr = 2 * Math.PI * sides[0];
                    }
                    else
                    {
                        for (int i = 0; i < numberOfSides; i++)
                            perimetеr += sides[i];
                    }
                    
                    Console.Clear();
                    Console.WriteLine($"Периметр вашей фигуры равен - {perimetеr}");

                    break;
                }
                else
                {
                    Console.WriteLine("Не удалось распознать команду");
                }
            }

            Console.WriteLine();
            Console.WriteLine("У правильных фигур с такой же площадью, как у вашей, были бы следующие стороны: ");

            Console.WriteLine($"Треугольник - {Math.Round(Math.Sqrt(commonSquare * 4 / Math.Sqrt(3)), 2)}");
            Console.WriteLine($"Квадрат - {Math.Round(Math.Sqrt(commonSquare), 2)}");
            
            if (numberOfSides != 1)
            {
                Console.WriteLine($"Радиус круга - {Math.Round(Math.Sqrt(commonSquare / Math.PI), 2)}");
            }

            double Square(double[] array)
            {
                if (array.Length == 1)
                {
                    return Math.PI * Math.Pow(array[0], 2);
                }

                double halfPerimeter = 0;

                for (int i = 0; i < array.Length; i++)
                    halfPerimeter += array[i];

                halfPerimeter /= 2;

                double square = 1;

                for (int i = 0; i < array.Length; i++)
                    square *= halfPerimeter - array[i];

                square = Math.Sqrt(square);

                return square;
            }
        }
    }
}
