using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

        char[,] matrix = new char[int.Parse(input[0]), int.Parse(input[1])];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            char[] colEl = Console.ReadLine().ToCharArray();

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = colEl[col];
            }
        }

        Queue<char> commands = new Queue<char>(Console.ReadLine().ToCharArray());

        var playersCoordinates = FindPlayersPosition(matrix).Split(",");
        int currRow = int.Parse(playersCoordinates[0]);
        int currcol = int.Parse(playersCoordinates[1]);

        bool isPlayerDead = false;
        bool isPlayerWon = false;
        int[] coordinates = new int[2];

        while (true)
        {
            if (isPlayerDead)
            {
                coordinates[0] = currRow;
                coordinates[1] = currcol;
                break;
            }
            if (isPlayerWon)
            {
                coordinates[0] = currRow;
                coordinates[1] = currcol;
                break;
            }
            if (commands.Count <= 0)
            {
                break;
            }

            char currComand = commands.Dequeue();
            if (currComand == 'U')
            {
                if (currRow - 1 >= 0)
                {
                    if (matrix[currRow - 1, currcol] == '.')
                    {
                        matrix[currRow, currcol] = '.';
                        matrix[currRow - 1, currcol] = 'P';
                        currRow = currRow - 1;
                    }
                    else if (matrix[currRow - 1, currcol] == 'B')
                    {
                        currRow = currRow - 1;
                        isPlayerDead = true;
                    }
                }
                else
                {
                    matrix[currRow, currcol] = '.';
                    isPlayerWon = true;
                }
            }
            else if (currComand == 'D')
            {
                if (currRow + 1 < matrix.GetLength(0))
                {
                    if (matrix[currRow + 1, currcol] == '.')
                    {
                        matrix[currRow, currcol] = '.';
                        matrix[currRow + 1, currcol] = 'P';
                        currRow = currRow + 1;
                    }
                    else if (matrix[currRow + 1, currcol] == 'B')
                    {
                        currRow = currRow + 1;
                        isPlayerDead = true;
                    }
                }
                else
                {
                    matrix[currRow, currcol] = '.';
                    isPlayerWon = true;
                }
            }
            else if (currComand == 'L')
            {
                if (currcol - 1 >= 0)
                {
                    if (matrix[currRow, currcol - 1] == '.')
                    {
                        matrix[currRow, currcol] = '.';
                        matrix[currRow, currcol - 1] = 'P';
                        currcol = currcol - 1;
                    }
                    else if (matrix[currRow, currcol - 1] == 'B')
                    {
                        currcol = currcol - 1;
                        isPlayerDead = true;
                    }
                }
                else
                {
                    matrix[currRow, currcol] = '.';
                    isPlayerWon = true;
                }
            }
            else if (currComand == 'R')
            {
                if (currcol + 1 < matrix.GetLength(1))
                {
                    if (matrix[currRow, currcol + 1] == '.')
                    {
                        matrix[currRow, currcol] = '.';
                        matrix[currRow, currcol + 1] = 'P';
                        currcol = currcol + 1;
                    }
                    else if (matrix[currRow, currcol + 1] == 'B')
                    {
                        currcol = currcol + 1;
                        isPlayerDead = true;
                    }
                }
                else
                {
                    matrix[currRow, currcol] = '.';
                    isPlayerWon = true;
                }
            }

            string checkIfBunniMetPlayer = SpreadBunniesAndTakeDeadPlayersCoordinates(matrix);
            
            if (checkIfBunniMetPlayer != "" && !isPlayerDead)
            {
                var corrdinatesArgs = checkIfBunniMetPlayer.Split(",");
                currRow = int.Parse(corrdinatesArgs[0]);
                currcol = int.Parse(corrdinatesArgs[1]);
                isPlayerDead = true;
            }
        }

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row, col]);
            }
            Console.WriteLine();
        }

        if (isPlayerDead)
        {
            Console.WriteLine($"dead: {coordinates[0]} {coordinates[1]}");
        }
        else if (isPlayerWon)
        {
            Console.WriteLine($"won: {coordinates[0]} {coordinates[1]}");

        }
    }

    private static string SpreadBunniesAndTakeDeadPlayersCoordinates(char[,] matrix)
    {
        Queue<string> queue = new Queue<string>();

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] == 'B')
                {
                    queue.Enqueue($"{row},{col}");
                }
            }
        }
        string deadPlayerCoordinates = "";

        while (queue.Count > 0)
        {
            var coordinates = queue.Dequeue().Split(",");

            int rowIndex = int.Parse(coordinates[0]);
            int colIndex = int.Parse(coordinates[1]);
           
            if (rowIndex + 1 < matrix.GetLength(0) && matrix[rowIndex + 1, colIndex] != 'P')
            {
                matrix[rowIndex + 1, colIndex] = 'B';
            }
            else if (rowIndex + 1 < matrix.GetLength(0) && matrix[rowIndex + 1, colIndex] == 'P')
            {
                deadPlayerCoordinates = $"{rowIndex + 1}, {colIndex}";
                matrix[rowIndex + 1, colIndex] = 'B';
            }
            if (colIndex + 1 < matrix.GetLength(1) && matrix[rowIndex, colIndex + 1] != 'P')
            {
                matrix[rowIndex, colIndex + 1] = 'B';
            }
            else if (colIndex + 1 < matrix.GetLength(1) && matrix[rowIndex, colIndex + 1] == 'P')
            {
                deadPlayerCoordinates = $"{rowIndex}, {colIndex+1}";
                matrix[rowIndex, colIndex + 1] = 'B';
            }
            if (rowIndex - 1 >= 0 && matrix[rowIndex - 1, colIndex] != 'P')
            {
                matrix[rowIndex - 1, colIndex] = 'B';
            }
            else if (rowIndex - 1 >= 0 && matrix[rowIndex - 1, colIndex] == 'P')
            {
                deadPlayerCoordinates = $"{rowIndex - 1}, {colIndex}";
                matrix[rowIndex - 1, colIndex] = 'B';
            }
            if (colIndex - 1 >= 0 && matrix[rowIndex, colIndex - 1] != 'P')
            {
                matrix[rowIndex, colIndex - 1] = 'B';
            }
            else if (colIndex - 1 >= 0 && matrix[rowIndex, colIndex - 1] == 'P')
            {
                deadPlayerCoordinates = $"{rowIndex}, {colIndex - 1}";
                matrix[rowIndex, colIndex - 1] = 'B';
            }
        }
        return deadPlayerCoordinates;
    }

    private static string FindPlayersPosition(char[,] matrix)
    {
        string startPosition = "";

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] == 'P')
                {
                    startPosition = $"{row}, {col}";
                }
            }
        }
        return startPosition;
    }
}
