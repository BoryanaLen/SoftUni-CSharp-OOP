using System;
using System.Collections.Generic;
using System.Linq;

namespace P06_Sneaking
{
    class Sneaking
    {
        static char[][] room;

        static int numberRows;
        static void Main()
        {
            numberRows = int.Parse(Console.ReadLine());

            room = new char[numberRows][];

            for (int row = 0; row < numberRows; row++)
            {
                string input = Console.ReadLine();

                room[row] = input.ToCharArray();
            }

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

            string directions = Console.ReadLine();

            bool isDead = false;

            for (int i = 0; i < directions.Length; i++)
            {
                room = MoveEnemy(room);

                if (Array.IndexOf(room[samRow], 'b') >= 0)
                {
                    int index = Array.IndexOf(room[samRow], 'b');

                    if (index < samCol)
                    {
                        isDead = true;

                        break;
                    }
                }

                if (Array.IndexOf(room[samRow], 'd') >= 0)
                {
                    int index = Array.IndexOf(room[samRow], 'd');

                    if (index > samCol)
                    {
                        isDead = true;

                        break;
                    }
                }

                List<int> newPositin = MoveSam(room, samRow, samCol, directions[i]);

                if(IsInBorder(newPositin[0], newPositin[1], room, numberRows))
                {
                    room[samRow][samCol] = '.';

                    samRow = newPositin[0];

                    samCol = newPositin[1];

                    room[samRow][samCol] = 'S';

                }


                if(Array.IndexOf(room[samRow], 'N') >= 0)
                {
                    int index = Array.IndexOf(room[samRow], 'N');

                    Console.WriteLine($"Nikoladze killed!");

                    room[samRow][index] = 'X';

                    break;
                }
            }

            if (isDead)
            {
                Console.WriteLine($"Sam died at {samRow}, {samCol}");

                room[samRow][samCol] = 'X';
            }

            for (int row = 0; row < numberRows; row++)
            {
                Console.WriteLine(string.Join("",room[row]));
            }
        }

        public static bool IsInBorder(int row, int col , char[][] room, int numberRows)
        {
            bool result = false;

            if(row >= 0 && row < numberRows && col >= 0 && col < room[row].Length)
            {
                result = true;
            }

            return result;
        }

        public static char[][] MoveEnemy(char[][] room)
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

            return room;
        }

        public static List<int> MoveSam(char[][] room, int samRow, int samCol, char direction)
        {
            if(direction == 'U')
            {
                samRow--;
            }
            else if (direction == 'D')
            {
                samRow++;
            }
            else if(direction == 'L')
            {
                samCol--;
            }
            else if(direction == 'R')
            {
                samCol++;
            }

            return new List<int>() { samRow, samCol };
        }
    }
}
