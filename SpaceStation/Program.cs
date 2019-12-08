using System;
using System.Collections.Generic;

namespace SpaceStation
{
    class Program
    {
        static Dictionary<string, int[]> blackPositions;

        static int power = 0;

        static int[] playerPosition;

        static bool end = false;
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            string[,] field = ReadField(size);

            blackPositions = FindBlacks(field);



            while (end == false)
            {
                string direction = Console.ReadLine();

                MovePlayer(field, direction);

                if (power >= 50)
                {
                    Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
                    break;
                }

            }

            Console.WriteLine($"Star power collected: {power}");
            PrintField(field);
        }

        private static void PrintField(string[,] field)
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    Console.Write(field[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static void MovePlayer(string[,] field, string direction)
        {
            try
            {
                SetEmpty(field, playerPosition);
                if (direction == "right")
                {
                    playerPosition[1]++;
                }
                else if (direction == "left")
                {
                    playerPosition[1]--;
                }
                else if (direction == "up")
                {
                    playerPosition[0]--;
                }
                else if (direction == "down")
                {
                    playerPosition[0]++;
                }
                if (char.IsDigit(field[playerPosition[0], playerPosition[1]][0]))
                {
                    power += int.Parse(field[playerPosition[0], playerPosition[1]]);
                }
                if (field[playerPosition[0], playerPosition[1]] == "O")
                {
                    GoToTheBlackHole(field);
                }
                SetNewPosition(field, playerPosition);
            }
            catch (Exception)
            {
                Console.WriteLine("Bad news, the spaceship went to the void.");
                end = true;
            }
        }

        private static void GoToTheBlackHole(string[,] field)
        {
            int[] firstHole = blackPositions["first"];
            int[] secondHole = blackPositions["second"];
            SetEmpty(field, playerPosition);

            if (playerPosition[0] == firstHole[0] && playerPosition[1] == firstHole[1])
            {
                playerPosition[0] = secondHole[0];
                playerPosition[1] = secondHole[1];
            }
            else
            {
                playerPosition[0] = firstHole[0];
                playerPosition[1] = firstHole[1];
            }
        }

        private static void SetNewPosition(string[,] field, int[] pos)
        {
            field[pos[0], pos[1]] = "S";
        }

        private static void SetEmpty(string[,] field, int[] pos)
        {
            field[pos[0], pos[1]] = "-";
        }

        private static Dictionary<string, int[]> FindBlacks(string[,] field)
        {
            Dictionary<string, int[]> pos = new Dictionary<string, int[]>();
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j] == "O")
                    {
                        if (pos.Count == 0)
                        {
                            pos.Add("first", new int[] { i, j });
                        }
                        else
                        {
                            pos.Add("second", new int[] { i, j });
                        }
                    }
                    if (field[i, j] == "S")
                    {
                        playerPosition = new int[] { i, j };
                    }
                }
            }
            return pos;
        }

        private static string[,] ReadField(int size)
        {
            string[,] field = new string[size, size];

            for (int i = 0; i < size; i++)
            {
                string row = Console.ReadLine();
                for (int j = 0; j < size; j++)
                {
                    field[i, j] = row[j].ToString();
                }
            }

            return field;
        }
    }
}
