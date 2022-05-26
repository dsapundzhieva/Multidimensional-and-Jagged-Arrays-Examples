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
            string[] colElements = Console.ReadLine().Split(" ").ToArray();

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = colElements[col];
            }
        }

        string command;

        while ((command = Console.ReadLine()) != "END")
        {
            if (!IsValidCommand(command, matrix))
            {
                Console.WriteLine("Invalid input!");
            }
            else
            {
                var cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int row1 = int.Parse(cmdArgs[1]);
                int col1 = int.Parse(cmdArgs[2]);
                int row2 = int.Parse(cmdArgs[3]);
                int col2 = int.Parse(cmdArgs[4]);

                string firstElement = matrix[row1, col1];
                string secondElement = matrix[row2, col2];

                matrix[row1, col1] = secondElement;
                matrix[row2, col2] = firstElement;

                Print(matrix);
            }
        }
    }

    private static void Print(string[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row, col] + " ");
            }
            Console.WriteLine();
        }
    }

    private static bool IsValidCommand(string command, string[,] matrix)
    {
        var cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        string cmdType = cmdArgs[0];

        if (cmdType == "swap" && cmdArgs.Length == 5)
        {
            int row1 = int.Parse(cmdArgs[1]);
            int col1 = int.Parse(cmdArgs[2]);
            int row2 = int.Parse(cmdArgs[3]);
            int col2 = int.Parse(cmdArgs[4]);

            if (row1 >= 0 &&
            row1 < matrix.GetLength(0) &&
            col1 >= 0 && col1 < matrix.GetLength(1) &&
            row2 >= 0 && row2 < matrix.GetLength(0) &&
            col2 >= 0 && col2 < matrix.GetLength(1))
            {
                return true;
            }
            else
                return false;
        }
        else
        {
            return false;
        }
    }
}
