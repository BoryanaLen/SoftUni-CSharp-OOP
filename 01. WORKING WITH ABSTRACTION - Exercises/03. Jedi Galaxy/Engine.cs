using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P03_JediGalaxy
{
    public class Engine
    {
        private int[,] matrix;

        private long totalSum;

        public void Run()
        {
            int[] dimensions = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            int numberRows = dimensions[0];
            int numberCols = dimensions[1];

            this.InitializeMatrix(numberRows, numberCols);

            string command = Console.ReadLine();

            while (command != "Let the Force be with you")
            {
                List<int> PlayerCoordinates = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                List<int> evilCoordinates = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                int evilRow = evilCoordinates[0];

                int evilCol = evilCoordinates[1];

                MoveEvil(evilRow, evilCol);


                int ivoRow = PlayerCoordinates[0];

                int ivoCol = PlayerCoordinates[1];

                MoveIvo(ivoRow, ivoCol);


                command = Console.ReadLine();
            }

            Console.WriteLine(totalSum);
        }

        private void InitializeMatrix(int rows, int cols)
        {
            matrix = new int[rows, cols];

            int value = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = value++;
                }
            }
        }

        private bool IsInBorder(int row, int col)
        {
            bool result = false;

            if (row >= 0 && row < matrix.GetLength(0)  && col >= 0 && col < matrix.GetLength(1))
            {
                result = true;
            }

            return result;
        }
        private void MoveIvo(int ivoRow, int ivoCol)
        {
            while (ivoRow >= 0 && ivoCol < matrix.GetLength(1))
            {
                if (IsInBorder(ivoRow, ivoCol))
                {
                    totalSum += matrix[ivoRow, ivoCol];
                }

                ivoRow--;
                ivoCol++;
            }
        }

        private void MoveEvil(int evilRow, int evilCol)
        {
            while (evilRow >= 0 && evilCol >= 0)
            {
                if (IsInBorder(evilRow, evilCol))
                {
                    matrix[evilRow, evilCol] = 0;
                }

                evilRow--;
                evilCol--;
            }
        }
    }
}
