using System;
using System.Collections.Generic;
using System.Linq;

namespace P03_JediGalaxy
{
    class Program
    {
        static void Main()
        {
            int[] dimestions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int x = dimestions[0];
            int y = dimestions[1];

            int[,] matrix = new int[x, y];

            int value = 0;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    matrix[i, j] = value++;
                }
            }

            string command = Console.ReadLine();

            long sum = 0;

            while (command != "Let the Force be with you")
            {
                List<int> ivoS = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();
                List<int> evil = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                matrix = MoveEvil(evil, matrix);

                sum += MoveIvo(ivoS, matrix);

                command = Console.ReadLine();
            }

            Console.WriteLine(sum);
        }

        public static bool IsInBorder(int row, int col, int x, int y)
        {
            bool result = false;

            if (row >= 0 && row < x && col >= 0 && col < y)
            {
                result = true;
            }

            return result;
        }
        public static long MoveIvo(List<int> coordinates, int[,] matrix)
        {
            long sum = 0;
            int row = coordinates[0];
            int col = coordinates[1];


            while (row >= 0 && col < matrix.GetLength(1))
            {
                if(IsInBorder(row, col, matrix.GetLength(0), matrix.GetLength(1)))
                {
                    sum += matrix[row, col];
                }

                row--;
                col++;
            }

            return sum;
        }

        public static int[,] MoveEvil(List<int> coordinates, int[,] matrix)
        {
            int row = coordinates[0];
            int col = coordinates[1];

            while (row >= 0 && col >= 0)
            {
                if (IsInBorder(row, col, matrix.GetLength(0), matrix.GetLength(1)))
                {
                    matrix[row, col] = 0;
                }
           
                row--;
                col--;
            }

            return matrix;
        }
    }
}
