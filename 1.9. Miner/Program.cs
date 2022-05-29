using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        Queue<string> commandsToMoveQueue = new Queue<string>(Console.ReadLine().Split(" "));

        string[,] matrix = new string[n, n];

        for (int row = 0; row < n; row++)
        {
            var colEl = Console.ReadLine().Split(' ').ToArray();

            for (int col = 0; col < n; col++)
            {
                matrix[row, col] = colEl[col];
            }
        }

        string[] startPosition = FindStartPosition(matrix, n).Split(",");

        int currRow = int.Parse(startPosition[0]);
        int currCol = int.Parse(startPosition[1]);

        bool isEndCommandReached = false;
        bool areТheМovementCommandsCompleted = false;
        bool areAllCoalsCollected = false;

        while (true)
        {
            if (commandsToMoveQueue.Count == 0)
            {
                areТheМovementCommandsCompleted = true;
                break;
            }

            int collectedCoals = CheckForCoals(matrix, n);
            
            if (collectedCoals == 0)
            {
                areAllCoalsCollected = true;
                break;
            }

            string currEl = matrix[currRow, currCol];

            string currCommand = commandsToMoveQueue.Dequeue();

            if (currCommand == "up" && currRow - 1 >= 0)
            {
                if (matrix[currRow - 1, currCol] == "c")
                {
                    matrix[currRow - 1, currCol] = "*";

                    currRow = currRow - 1;
                    continue;
                }
                else if (matrix[currRow - 1, currCol] == "*")
                {
                    currRow = currRow - 1;
                    continue;
                }
                else if (matrix[currRow - 1, currCol] == "e")
                {
                    currRow = currRow - 1;
                    isEndCommandReached = true;
                    break;
                }
                else if (matrix[currRow - 1, currCol] == "s")
                {
                    currRow = currRow - 1;
                }
            }
            else if (currCommand == "down" && currRow + 1 < n)
            {
                if (matrix[currRow + 1, currCol] == "c")
                {
                    matrix[currRow + 1, currCol] = "*";

                    currRow = currRow + 1;
                    continue;
                }
                else if (matrix[currRow + 1, currCol] == "*")
                {
                    currRow = currRow + 1;
                }
                else if (matrix[currRow + 1, currCol] == "e")
                {
                    currRow = currRow + 1;
                    isEndCommandReached = true;
                    break;
                }
                else if (matrix[currRow + 1, currCol] == "s")
                {
                    currRow = currRow + 1;
                }
            }
            else if (currCommand == "left" && currCol - 1 >= 0)
            {
                if (matrix[currRow, currCol - 1] == "c")
                {
                    matrix[currRow, currCol - 1] = "*";

                    currCol = currCol - 1;
                }
                else if (matrix[currRow, currCol - 1] == "*")
                {
                    currCol = currCol - 1;
                }
                else if (matrix[currRow, currCol - 1] == "e")
                {
                    currCol = currCol - 1;
                    isEndCommandReached = true;
                    break;
                }
                else if (matrix[currRow, currCol - 1] == "s")
                {
                    currCol = currCol - 1;

                }
            }
            else if (currCommand == "right" && currCol + 1 < n)
            {
                if (matrix[currRow, currCol + 1] == "c")
                {
                    matrix[currRow, currCol + 1] = "*";

                    currCol = currCol + 1;
                    continue;
                }
                else if (matrix[currRow, currCol + 1] == "*")
                {
                    currCol = currCol + 1;
                    continue;
                }
                else if (matrix[currRow, currCol + 1] == "e")
                {
                    currCol = currCol + 1;
                    isEndCommandReached = true;
                    break;
                }
                else if(matrix[currRow, currCol + 1] == "s")
                {
                    currCol = currCol + 1;
                }
            }
        }

        int totalCoalsLeft = CheckForCoals(matrix, n);

        if (areAllCoalsCollected || areТheМovementCommandsCompleted && totalCoalsLeft == 0)
        {
            Console.WriteLine($"You collected all coals! ({currRow}, {currCol})");
        }
        else if (isEndCommandReached)
        {
            Console.WriteLine($"Game over! ({currRow}, {currCol})");
        }
        else if (areТheМovementCommandsCompleted && totalCoalsLeft > 0)
        {

            Console.WriteLine($"{totalCoalsLeft} coals left. ({currRow}, {currCol})");
        }
    }

    private static int CheckForCoals(string[,] matrix, int n)
    {
        int coals = 0;
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                if (matrix[row, col] == "c")
                {
                    coals++;
                }
            }
        }
        return coals;
    }

    private static string FindStartPosition(string[,] matrix, int n)
    {
        string startPosition = "";

        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                if (matrix[row, col] == "s")
                {
                    startPosition = $"{row}, {col}";
                }
            }
        }
        return startPosition;
    }
}
