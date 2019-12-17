using System;
using System.ComponentModel;

namespace Module3Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isAnswerNegative = false;

            Console.Write("Введите певрое число: ");
            int firstNumber = ParseNumber<int>();
            if(firstNumber < 0)
            {
                isAnswerNegative = true;
            }

            Console.Write("Введите второе число: ");
            int secondNumber = ParseNumber<int>();
            if(secondNumber < 0 && isAnswerNegative == false)
            {
                isAnswerNegative = true;
            }
            else
            {
                isAnswerNegative = false;
            }

            Console.WriteLine($"{firstNumber} * {secondNumber}");
            firstNumber = Math.Abs(firstNumber);
            secondNumber = Math.Abs(secondNumber);
            int answer = 0;

            for (int i = 0; i < secondNumber; i++)
            {
                answer += firstNumber;
            }

            if (isAnswerNegative == true)
                answer = -answer;

            Console.WriteLine($"Ответ: {answer}");
        }

        static T ParseNumber<T>() where T : struct
        {
            while (true)
            {
                var converter = TypeDescriptor.GetConverter(typeof(T));

                if (converter != null)
                {
                    string number = Console.ReadLine();
                    try
                    {
                        return (T)converter.ConvertFromString(number);
                    }
                    catch 
                    {
                        Console.WriteLine("|-Введите число-|");
                    }
                }
            }
        }
    }
}
