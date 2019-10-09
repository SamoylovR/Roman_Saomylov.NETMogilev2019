using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module1Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            byte a = 10;
            byte b = 20;
            Console.WriteLine($"Значение a = {a}, занчение b = {b}");
            Swap(ref a, ref b);

            Console.WriteLine($"Значение a = {a}, занчение b = {b}");

            void Swap( ref byte x, ref byte y)
            {
                Console.WriteLine("Method Swap");

                byte bufferNumber = x;
                x = y;
                y = bufferNumber;
            }
        }
    }
}
