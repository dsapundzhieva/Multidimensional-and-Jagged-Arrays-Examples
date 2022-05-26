using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        int[] matrixSize = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

        string[,] matrix = new string[matrixSize[0], matrixSize[1]];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            string[] colElements = Console.ReadLine().Split(' ').ToArray();

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = colElements[col];
            }
        }

        int countSquares = 0;

        for (int row = 0; row < matrix.GetLength(0) - 1; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 1; col++)
            {
                if (matrix[row, col] == matrix[row, col + 1] && matrix[row, col] == matrix[row + 1, col + 1] && matrix[row, col] == matrix[row + 1, col])
                {
                    countSquares++;
                }
            }
        }

        Console.WriteLine(countSquares);
    }
}
