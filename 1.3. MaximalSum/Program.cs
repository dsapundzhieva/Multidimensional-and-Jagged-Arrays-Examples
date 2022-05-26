using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        int[] matrixSize = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        double[,] matrix = new double[matrixSize[0], matrixSize[1]];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            double[] colElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = colElements[col];
            }
        }

        double maxSum = 0;
        //string coordinates = "";

        double[] firstRow = new double[3];
        double[] secondRow = new double[3];
        double[] thirdRow = new double[3];


        for (int row = 0; row < matrix.GetLength(0)-2; row++)
        {
            for (int col = 0; col < matrix.GetLength(1)-2; col++)
            {
                double sum = matrix[row, col] + matrix[row, col+1] + matrix[row, col+2]
                    + matrix[row+1, col] + matrix[row+1, col+1] + matrix[row+1, col+2]
                    + matrix[row+2, col] + matrix[row+2, col+1] + matrix[row+2, col+2];

                if (sum > maxSum)
                {
                    maxSum = sum;

                    firstRow = new double[] { matrix[row, col], matrix[row, col + 1], matrix[row, col + 2] };
                    secondRow = new double[] { matrix[row + 1, col], matrix[row + 1, col + 1], matrix[row + 1, col + 2] };
                    thirdRow = new double[] { matrix[row + 2, col], matrix[row + 2, col + 1], matrix[row + 2, col + 2] };
                    //coordinates = matr=ix[row, col] + " " + matrix[row, col + 1] + " " + matrix[row, col + 2] + "\n"
                    //            + matrix[row + 1, col] + " " + matrix[row + 1, col + 1] + " " + matrix[row + 1, col + 2] + "\n"
                    //            + matrix[row + 2, col] + " " + matrix[row + 2, col + 1] + " "+ matrix[row + 2, col + 2];
                }
            }
        }

        Console.WriteLine($"Sum = {maxSum}");
        Console.Write($"{string.Join(" ", firstRow)}\n{string.Join(" ", secondRow)}\n{string.Join(" ", thirdRow)}");
    }
}
