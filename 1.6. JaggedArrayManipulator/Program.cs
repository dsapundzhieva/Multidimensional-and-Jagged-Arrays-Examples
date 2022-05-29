using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[][] matrix = new int[n][];

        for (int row = 0; row < n; row++)
        {
            matrix[row] = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
        }

        for (int row = 0; row < n - 1; row++)
        {
            if (matrix[row].Length == matrix[row + 1].Length)
            {
                matrix[row] = matrix[row].Select(colEl => colEl * 2).ToArray();
                matrix[row + 1] = matrix[row + 1].Select(colEl => colEl * 2).ToArray();
            }
            else
            {
                matrix[row] = matrix[row].Select(colEl => colEl / 2).ToArray();
                matrix[row + 1] = matrix[row + 1].Select(colEl => colEl / 2).ToArray();
            }

        }

        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            var cmdArgs = command.Split(" ");
            string cmdType = cmdArgs[0];
            int row = int.Parse(cmdArgs[1]);
            int column = int.Parse(cmdArgs[2]);
            int value = int.Parse(cmdArgs[3]);

            if (cmdType == "Add")
            {
                if (IsValidCoordinates(row, column, n, matrix))
                {
                    matrix[row][column] += value;
                }
            }
            else if (cmdType == "Subtract")
            {
                if (IsValidCoordinates(row, column, n, matrix))
                {
                    matrix[row][column] -= value;
                }
            }
        }

        foreach (var item in matrix)
        {
            Console.WriteLine(string.Join(" ", item));
        }
    }

    private static bool IsValidCoordinates(int row, int column, int n, int[][] matrix)
    {
        if (row >= 0 && row < n && column >= 0 && column < matrix[row].Length)
        {
            return true;
        }
        return false;
    }
}
