using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        int sizeMatrix = int.Parse(Console.ReadLine());

        int[,] matrix = new int[sizeMatrix, sizeMatrix];

        int sum = 0;

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            int[] colElements = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = colElements[col];
                if (row == col)
                {
                    sum += matrix[row, col];
                }
            }
        }
        Console.WriteLine(sum);
    }
}
