using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P06_Sneaking
{
    public class Engine
    {
        private char[][] room;

        private int numberRows = int.Parse(Console.ReadLine());

        public Engine()
        {
            this.room = new char[numberRows][];
        }
        public void Run()
        {
            this.InitializeMatrix();

            List<int> samPosition = this.SamPosition();
            int samRow = samPosition[0];
            int samCol = samPosition[1];

            string directions = Console.ReadLine();


            for (int i = 0; i < directions.Length; i++)
            {
                MoveEnemy();

                if(IsSamDead(ref samRow, ref samCol))
                {
                    Console.WriteLine($"Sam died at {samRow}, {samCol}");

                    break;
                }

                MoveSam(ref samRow, ref samCol, directions[i]);

                if(IsNikoladzeOnSameRow(ref samRow))
                {
                    Console.WriteLine($"Nikoladze killed!");

                    break;
                }
            }

            PrintMatrix();
        }

        private void InitializeMatrix()
        {
            for (int row = 0; row < numberRows; row++)
            {
                string input = Console.ReadLine();

                room[row] = input.ToCharArray();
            }
        }

        private void PrintMatrix()
        {
            for (int row = 0; row < numberRows; row++)
            {
                Console.WriteLine(string.Join("", room[row]));
            }
        }

        private List<int> SamPosition()
        {
            int samRow = -1;
            int samCol = -1;

            for (int row = 0; row < numberRows; row++)
            {
                for (int col = 0; col < room[row].Count(); col++)
                {
                    if (room[row][col] == 'S')
                    {
                        samRow = row;
                        samCol = col;
                    }
                }
            }

            return new List<int>() { samRow, samCol };
        }

        private void MoveEnemy()
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'b')
                    {
                        if (col < room[row].Count() - 1)
                        {
                            room[row][col] = '.';
                            room[row][col + 1] = 'b';
                            col++;
                        }
                        else
                        {
                            room[row][col] = 'd';
                        }
                    }
                    else if (room[row][col] == 'd')
                    {
                        if (col > 0)
                        {
                            room[row][col] = '.';
                            room[row][col - 1] = 'd';
                        }
                        else
                        {
                            room[row][col] = 'b';
                        }
                    }
                }
            }
        }

        private void MoveSam(ref int samRow,ref int samCol, char direction)
        {
            room[samRow][samCol] = '.';

            if (direction == 'U' && samRow > 0)
            {
                samRow--;
            }
            else if (direction == 'D' && samRow < numberRows - 1)
            {
                samRow++;
            }
            else if (direction == 'L' && samCol > 0)
            {
                samCol--;
            }
            else if (direction == 'R' && samCol < room[samRow].Length)
            {
                samCol++;
            }

            room[samRow][samCol] = 'S';
        }

        private bool IsSamDead(ref int samRow, ref int samCol)
        {
            bool result = false;

            if (Array.IndexOf(room[samRow], 'b') >= 0)
            {
                int index = Array.IndexOf(room[samRow], 'b');

                if (index < samCol)
                {
                    result = true;

                    room[samRow][samCol] = 'X';
                }
            }

            if (Array.IndexOf(room[samRow], 'd') >= 0)
            {
                int index = Array.IndexOf(room[samRow], 'd');

                if (index > samCol)
                {
                    result = true;

                    room[samRow][samCol] = 'X';
                }
            }

            return result;
        }

        private bool IsNikoladzeOnSameRow(ref int samRow)
        {
            bool result = false;

            if (Array.IndexOf(room[samRow], 'N') >= 0)
            {
                int index = Array.IndexOf(room[samRow], 'N');

                room[samRow][index] = 'X';

                result = true;
            }

            return result;
        }
    }
}
