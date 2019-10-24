using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3Task8
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfArray = 0;

            while (true)
            {
                Console.WriteLine("Введите размерность массива, который вы хотите увидеть: ");

                if (int.TryParse(Console.ReadLine(), out sizeOfArray) && sizeOfArray > 0)
                    break;


                Console.WriteLine("|-Проверьте корректность введённых данных-|");
            }

            int[,] spiral = new int[sizeOfArray, sizeOfArray];

            int size = sizeOfArray;

            int currentNumber = 1;
            int widthBorder;
            int heightBorder;
            int commonBorder = 0;

            while (currentNumber <= Math.Pow(size, 2))
            {
                widthBorder = commonBorder;

                for (heightBorder = commonBorder; heightBorder < sizeOfArray; heightBorder++)
                    spiral[widthBorder, heightBorder] = currentNumber++;

                heightBorder = sizeOfArray - 1;

                for (widthBorder = commonBorder + 1; widthBorder < sizeOfArray; widthBorder++)
                    spiral[widthBorder, heightBorder] = currentNumber++;

                widthBorder = sizeOfArray - 1;

                for (heightBorder = sizeOfArray - 2; heightBorder >= commonBorder; heightBorder--)
                    spiral[widthBorder, heightBorder] = currentNumber++;

                heightBorder = commonBorder;

                for (widthBorder = sizeOfArray - 2; widthBorder > commonBorder; widthBorder--)
                    spiral[widthBorder, heightBorder] = currentNumber++;

                sizeOfArray--;
                commonBorder++;
            }

            Console.WriteLine($"Спиральный массив {size}x{size}");

            for (int i = 0; i < size; i++) 
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write("{0,3} ", spiral[i, j]);
                }
                Console.WriteLine();
            }

        }
    }
}
