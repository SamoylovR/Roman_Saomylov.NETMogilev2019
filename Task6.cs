using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int[] numbersArray;

            while (true)
            {
                Console.WriteLine("d u w t e a");

                string answer = Console.ReadLine().ToLower();

                if (answer == "нет" || answer == "ytn")
                {
                    numbersArray = new int[rnd.Next(5, 50)];

                    for (int i = 0; i < numbersArray.Length; i++)
                    {
                        numbersArray[i] = rnd.Next(-50, 50);
                    }

                    break;
                }
                else if (answer == "да" || answer == "lf")
                {
                    while (true)
                    {
                        Console.Write("en t length");

                        if (int.TryParse(Console.ReadLine(), out int length))
                        {
                            numbersArray = new int[length];
                            break;
                        }

                        Console.WriteLine("err");
                    }

                    for (int i = 0; i < numbersArray.Length; i++)
                    {
                        while (true)
                        {           
                            Console.WriteLine($"ent num {i + 1}");

                            if (int.TryParse(Console.ReadLine(), out numbersArray[i]))
                                break;

                            Console.WriteLine("err");
                        }
                    }
                    break;
                }

                Console.WriteLine("err");
            }

            Console.WriteLine("ifrst array");

            foreach (var n in numbersArray)
                Console.Write($"{n} ");
            Console.WriteLine();

            Console.WriteLine("second");

            foreach (var n in numbersArray)
                Console.Write($"{n * (-1)} ");
            Console.WriteLine();
        }
    }
}
