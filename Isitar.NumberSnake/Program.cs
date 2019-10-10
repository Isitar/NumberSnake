using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Isitar.NumberSnake
{
    class Program
    {
        private static readonly int[,] Numbers = new int[10, 10]
        {
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            {1, 1, 23, 13, 6, 30, 19, 4, 18, 1},
            {1, 10, 28, 13, 9, 20, 5, 24, 21, 1},
            {1, 15, 31, 14, 24, 1, 22, 29, 26, 1},
            {1, 2, 5, 32, 27, 20, 15, 31, 30, 1},
            {1, 16, 8, 4, 22, 29, 21, 19, 25, 1},
            {1, 28, 17, 8, 7, 18, 17, 3, 11, 1},
            {1, 11, 6, 9, 16, 27, 32, 2, 12, 1},
            {1, 26, 3, 14, 12, 10, 7, 25, 33, 1},
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
        };

        static void Main(string[] args)
        {
            BackTrack(1, 1);
        }


        private static List<int> visited = new List<int>();

        static bool BackTrack(int x, int y)
        {
            visited.Add(Numbers[x, y]);

            if (CheckWinningCondition())
            {
                return true;
            }

            // check right
            var newX = x + 1;
            var newY = y;
            if (!visited.Contains(Numbers[newX, newY]))
            {
                if (BackTrack(newX, newY))
                {
                    return true;
                }
            }

            // check down
            newX = x;
            newY = y + 1;
            if (!visited.Contains(Numbers[newX, newY]))
            {
                if (BackTrack(newX, newY))
                {
                    return true;
                }
            }

            // check left
            newX = x - 1;
            newY = y;
            if (!visited.Contains(Numbers[newX, newY]))
            {
                if (BackTrack(newX, newY))
                {
                    return true;
                }
            }

            // check up
            newX = x;
            newY = y - 1;
            if (!visited.Contains(Numbers[newX, newY]))
            {
                if (BackTrack(newX, newY))
                {
                    return true;
                }
            }

            //unvisit
            visited.Remove(Numbers[x, y]);
            return false;
        }

        private static bool CheckWinningCondition()
        {
            if (!visited.Contains(33))
            {
                return false;
            }

            if (visited.Count == 33)
            {
                Console.WriteLine(string.Join(",", visited));
                return true;
            }

            return false;
        }
    }
}