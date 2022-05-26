using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        int[,] matrix = new int[n, n];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            int[] colElement = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = colElement[col];
            }
        }

        int sumPrimaryDiagonal = 0;
        int sumSecondaryDiagonal = 0;

        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                if (row == col)
                {
                    sumPrimaryDiagonal += matrix[row, col];
                }

                if (row + col == n - 1)
                {
                    sumSecondaryDiagonal += matrix[row, col];
                }
            }
        }

        Console.WriteLine(Math.Abs(sumPrimaryDiagonal - sumSecondaryDiagonal));

    }
}
