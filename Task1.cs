using System;

namespace Module3Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = 0, secondNumber = 0;
            byte countNegative = 0;

            while (true)
            {
                bool isParsingDone = false;
                Console.Write("Введите первое число: ");

                if(int.TryParse(Console.ReadLine(), out firstNumber))
                {
                    if (firstNumber < 0)
                        countNegative++;

                    while (true)
                    {
                        Console.Write("Введите второе число: ");

                        if (int.TryParse(Console.ReadLine(), out secondNumber))
                        {
                            if (secondNumber < 0)
                                countNegative++;

                            isParsingDone = true;

                            break;
                        }

                        Console.WriteLine("|-Проверьте корректность введённых данных-|");
                    }
                }

                if (isParsingDone)
                    break;

                Console.WriteLine("|-Проверьте корректность введённых данных-|");
            }

            firstNumber = Math.Abs(firstNumber);
            secondNumber = Math.Abs(secondNumber);
            int answer = 0;

            for (int i = 0; i < secondNumber; i++)
            {
                answer += firstNumber;
            }

            if (countNegative == 1)
                answer = -answer;

            Console.WriteLine($"Ответ: {answer}");
        }
    }
}
