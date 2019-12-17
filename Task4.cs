using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            string numberString;
            bool isNumberNegative = false;

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
                {
                    if (number < 0)
                        isNumberNegative = true;

                    break;
                }

                Console.WriteLine("|-Проверьте корректность введённых данных-|");
            }

            numberString = numberString.Replace("-", string.Empty);

            Console.Write("Преобразованное число: ");

            if (isNumberNegative)
                Console.Write("-");

            for (int i = numberString.Length - 1; i >= 0; i--)
            {
                if (numberString[i] == '0' && i == numberString.Length - 1)
                {
                    continue;
                }
                Console.Write(numberString[i]);
            }
            Console.WriteLine();
        }
    }
}
