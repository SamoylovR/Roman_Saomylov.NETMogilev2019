using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module5
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] mainMap = new char[12, 12];
            bool[,] trapMap = new bool[12, 12];
            bool[,] isTrapActive = new bool[12, 12];

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t!!!ДОБРО ПОЖАЛОВАТЬ!!!");
            Console.ResetColor();
            Console.WriteLine();

            Console.Write("Вы играете за");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" персонажа H ");
            Console.ResetColor();
            Console.Write("и ваша цель дойти до");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(" Принцессы Р ");
            Console.ResetColor();
            Console.WriteLine("не потеряв HP");
            Console.WriteLine("На карте расположены 10 ловушек урон которых распределён от 1 до 10\n");
            Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
            Console.ReadKey();
            Console.Clear();

            bool gameStatus = true;
            bool isHeroAlive = true;
            while (gameStatus)
            {
                FillMainMap(mainMap, out sbyte heroX, out sbyte heroY, out sbyte targetX, out sbyte targetY);
                FillTrapMap(trapMap, mainMap, isTrapActive);
                sbyte healthPoints = 10;

                while (isHeroAlive)
                {
                    RenderMap(mainMap, healthPoints);

                    ConsoleKeyInfo button = Console.ReadKey();
                    if (button.KeyChar == 'w' || button.KeyChar == '8' || button.KeyChar == 'ц' || button.Key == ConsoleKey.UpArrow)
                    {
                        StepProcess(-1, 0, ref heroX, ref heroY, mainMap, trapMap, isTrapActive);
                        CheckStep();
                    }
                    else if (button.KeyChar == 's' || button.KeyChar == '2' || button.KeyChar == 'ы' || button.Key == ConsoleKey.DownArrow)
                    {
                        StepProcess(1, 0, ref heroX, ref heroY, mainMap, trapMap, isTrapActive);
                        CheckStep();
                    }
                    else if (button.KeyChar == 'a' || button.KeyChar == '4' || button.KeyChar == 'ф' || button.Key == ConsoleKey.LeftArrow)
                    {
                        StepProcess(0, -1, ref heroX, ref heroY, mainMap, trapMap, isTrapActive);
                        CheckStep();
                    }
                    else if (button.KeyChar == 'd' || button.KeyChar == '6' || button.KeyChar == 'в' || button.Key == ConsoleKey.RightArrow)
                    {
                        StepProcess(0, 1, ref heroX, ref heroY, mainMap, trapMap, isTrapActive);
                        CheckStep();
                    }
                }

                Console.WriteLine("\tБудем играть ещё?");
                Console.WriteLine();
                Console.WriteLine("Нажмите клавишу Enter, если да");
                Console.WriteLine("Или введите Нет/Конец, если хотите выйти");
                Console.ResetColor();
                string answer = Console.ReadLine().ToLower();
                if (answer == "конец" || answer == "ytn" | answer == "нет")
                {
                    gameStatus = false;
                }
                else
                {
                    isHeroAlive = true;
                    Console.Clear();
                }

                void CheckStep()
                {
                    if (trapMap[heroY, heroX] && isTrapActive[heroY, heroX])
                    {
                        isTrapActive[heroY, heroX] = false;
                        Random rnd = new Random();
                        healthPoints -= (sbyte)rnd.Next(1, 10);
                        if (healthPoints <= 0)
                        {
                            isHeroAlive = false;
                            Console.Clear();
                            OpenMap(mainMap, trapMap);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\t***Ты проиграл***");
                            return;
                        }
                    }

                    if (heroY == targetY && heroX == targetX)
                    {
                        isHeroAlive = false;
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\t!!!***Ты выйграл***!!!");
                        Console.WriteLine();
                        return;
                    }
                }
            }
        }

        static void RenderMap(char[,] map, sbyte healthPoints)
        {
            Console.Clear();
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == 'H')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"{map[i, j]} ");
                        Console.ResetColor();
                    }
                    else if (map[i, j] == 'P')
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write($"{map[i, j]} ");
                        Console.ResetColor();
                    }
                    else if(map[i, j] == 'X')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"{map[i, j]} ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write($"{map[i, j]} ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine($"HP: {healthPoints}");
        }

        static void FillMainMap(char[,] map, out sbyte heroX, out sbyte heroY, out sbyte targetX, out sbyte targetY)
        {
            Random rnd = new Random();
            sbyte[] cordinate = new sbyte[] { 1, 10 };

            heroX = cordinate[rnd.Next(cordinate.Length)];
            heroY = cordinate[rnd.Next(cordinate.Length)];

            if (heroX == 1)
            {
                targetX = 10;
            }
            else
            {
                targetX = 1;
            }

            if (heroY == 1)
            {
                targetY = 10;
            }
            else
            {
                targetY = 1;
            }

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (j == 0 || j == 11 || i == 0 || i == 11)
                    {
                        map[i, j] = '#';
                    }
                    else
                    {
                        map[i, j] = ' ';
                    }

                    if (j == heroX && i == heroY)
                    {
                        map[i, j] = 'H';
                    }
                    else if (j == targetX && i == targetY)
                    {
                        map[i, j] = 'P';
                    }
                }
            }
        }

        static void FillTrapMap(bool[,] trapMap, char[,] mainMap, bool[,] isTrapActive)
        {
            for(int i = 0; i < trapMap.GetLength(0); i++)
            {
                for (int j = 0; j < trapMap.GetLength(1); j++)
                {
                    trapMap[i, j] = false;
                    isTrapActive[i, j] = true;
                }
            }

            Random rnd = new Random();
            for (int i = 0; i < 10;)
            {
                int trapX = rnd.Next(1, trapMap.GetLength(0) - 1);
                int trapY = rnd.Next(1, trapMap.GetLength(1) - 1);

                if (!trapMap[trapY, trapX] && mainMap[trapY, trapX] == ' ')
                {
                    trapMap[trapY, trapX] = true;
                    i++;
                }
            }
        }

        static void OpenMap(char[,] map, bool[,] trapMap)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (trapMap[i, j])
                    {
                        Console.Write("X ");
                    }
                    else
                    {
                        Console.Write($"{map[i, j]} ");
                    }
                }
                Console.WriteLine();
            }
        }

        static void StepProcess(sbyte changeYCordinate, sbyte changeXCordinate, ref sbyte heroX, ref sbyte heroY, char[,] map, bool[,] trapMap, bool[,] isTrapActive)
        {
            if (map[heroY + changeYCordinate, heroX + changeXCordinate] == '#')
            {
                return;
            }

            if (trapMap[heroY, heroX])
            {
                map[heroY, heroX] = 'X';
            }
            else
            {
                map[heroY, heroX] = '.';
            }

            heroY += changeYCordinate;
            heroX += changeXCordinate;
            map[heroY, heroX] = 'H';
        }
    }
}
