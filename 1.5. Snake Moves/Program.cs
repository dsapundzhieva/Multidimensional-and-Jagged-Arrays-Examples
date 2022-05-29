using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        var matrixSize = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

        char[] snakeMoves = Console.ReadLine().ToCharArray();

        char[,] matrix = new char[matrixSize[0], matrixSize[1]];

        int counter = 0;

        for (int row = 0; row < matrix.GetLength(0); row++)
        {

            if (row % 2 == 0)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = snakeMoves[counter];
                    counter++;
                    if (counter == snakeMoves.Length)
                    {
                        counter = 0;
                    }
                }
            }
            else
            {
                for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                {
                    matrix[row, col] = snakeMoves[counter];
                    counter++;
                    if (counter == snakeMoves.Length)
                    {
                        counter = 0;
                    }
                }
            }
        }

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row,col]);
            }
            Console.WriteLine();
        }

    }
}
