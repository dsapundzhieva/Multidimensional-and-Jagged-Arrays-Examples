using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        int[] sizeMatrix = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

        int[,] matrix = new int[sizeMatrix[0], sizeMatrix[1]];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            int[] colElement = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row,col] = colElement[col];
            }
        }

        int maxSum = int.MinValue;
        int[,] coordoinates = new int[2,2];

        for (int row = 1; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1)-1; col++)
            {
                int sum = matrix[row-1, col] + matrix[row-1, col+1]
                    + matrix[row, col] + matrix[row, col+1];

                if (sum > maxSum)
                {
                    maxSum = sum;
                    coordoinates[0,0] = matrix[row-1, col];
                    coordoinates[0,1] = matrix[row-1, col+1];
                    coordoinates[1,0] = matrix[row, col];
                    coordoinates[1,1] = matrix[row, col + 1];
                }
            }
        }

        for (int row = 0; row < coordoinates.GetLength(0); row++)
        {
            for (int col = 0; col < coordoinates.GetLength(1); col++)
            {
                Console.Write(coordoinates[row, col] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine(maxSum);
    }
}
