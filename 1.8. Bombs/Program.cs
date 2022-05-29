using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        int[,] matrix = new int[n, n];

        for (int row = 0; row < n; row++)
        {
            int[] colEl = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            for (int col = 0; col < n; col++)
            {
                matrix[row, col] = colEl[col];
            }
        }

        Queue<string> inputCoordinatesQueue = new Queue<string>(Console.ReadLine().Split(" "));

        ExplodeBombs(matrix, inputCoordinatesQueue, n);

        int sum = 0;
        int aliveCells = 0;

        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                if (matrix[row, col] > 0)
                {
                    aliveCells++;
                    sum += matrix[row, col];
                }
            }
        }

        Console.WriteLine($"Alive cells: {aliveCells}");
        Console.WriteLine($"Sum: {sum}");

        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                Console.Write(matrix[row, col] + " ");
            }
            Console.WriteLine();
        }
    }

    private static void ExplodeBombs(int[,] matrix, Queue<string> inputCoordinatesQueue, int n)
    {
        while (inputCoordinatesQueue.Count > 0)
        {
            string[] currCoordinates = inputCoordinatesQueue.Dequeue().Split(",");
            int currRow = int.Parse(currCoordinates[0]);
            int currCol = int.Parse(currCoordinates[1]);

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    int currValue = matrix[currRow, currCol];

                    if (row == currRow && col == currCol && currValue > 0)
                    {
                        if (row - 1 >= 0 && matrix[currRow - 1, currCol] > 0)
                        {
                            matrix[currRow - 1, currCol] -= currValue;
                        }
                        if (row - 1 >= 0 && col - 1 >= 0 && matrix[currRow - 1, currCol - 1] > 0)
                        {
                            matrix[currRow - 1, currCol - 1] -= currValue;
                        }
                        if (col - 1 >= 0 && matrix[currRow, currCol - 1] > 0)
                        {
                            matrix[currRow, currCol - 1] -= currValue;
                        }
                        if (row + 1 < n && col - 1 >= 0 && matrix[currRow + 1, currCol - 1] > 0)
                        {
                            matrix[currRow + 1, currCol - 1] -= currValue;
                        }
                        if (row + 1 < n && matrix[currRow + 1, currCol] > 0)
                        {
                            matrix[currRow + 1, currCol] -= currValue;
                        }
                        if (row + 1 < n && col + 1 < n && matrix[currRow + 1, currCol + 1] > 0)
                        {
                            matrix[currRow + 1, currCol + 1] -= currValue;
                        }
                        if (col + 1 < n && matrix[currRow, currCol + 1] > 0)
                        {
                            matrix[currRow, currCol + 1] -= currValue;
                        }
                        if (row - 1 >= 0 && col + 1 < n && matrix[currRow - 1, currCol + 1] > 0)
                        {
                            matrix[currRow - 1, currCol + 1] -= currValue;
                        }
                        matrix[currRow, currCol] = 0;
                    }

                }
            }
        }
    }
}
