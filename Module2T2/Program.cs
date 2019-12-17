using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            byte age;

            while (true)
            {
                Console.Write("Введите Ваш возраст: ");

                if (byte.TryParse(Console.ReadLine(), out age) && age > 0)
                    break;

                Console.WriteLine("|- Проверьте корректность введённых данных -|");
            }

            if (age % 2 == 0 && age > 18)
            {
                Console.WriteLine("Поздравляем с 18-ти летием!");
            }
            else if (age % 2 == 1 && age < 18 && age > 13)
            {
                Console.WriteLine("Поздравляем с переходом в старшую школу!");
            }
            else
            {
                Console.WriteLine("Спасибо за авторизацию");
            }
        }
    }
}
