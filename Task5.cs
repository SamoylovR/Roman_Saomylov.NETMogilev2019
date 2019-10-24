using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            string numberString;

            while (true)
            {
                double number = 0;
                Console.WriteLine("Введите число, преобразование которого вы хотите увидеть");

                numberString = Console.ReadLine().Replace(",", ".");

                try
                {
                    number = Convert.ToDouble(numberString);
                }
                catch
                {
                    numberString = numberString.Replace(".", ",");
                }

                if (double.TryParse(numberString, out number))
                    break;                

                Console.WriteLine("|-Проверьте корректность введённых данных-|");
            }

            byte numberToRemove;

            while (true)
            {
                Console.Write("Введите цифру, котрую вы хотите убрать: ");

                if (byte.TryParse(Console.ReadLine(), out numberToRemove) && numberToRemove < 10)
                    break;

                Console.WriteLine("|-Проверьте корректность введённых данных-|");
            }

            Console.WriteLine($"{numberString.Replace(numberToRemove.ToString(), string.Empty)}");
        }
    }
}
