using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        int matrixSize = int.Parse(Console.ReadLine());

        char[,] matrix = new char[matrixSize, matrixSize];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            char[] colElement = Console.ReadLine().ToCharArray();

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = colElement[col];
            }
        }

        char searchedChar = char.Parse(Console.ReadLine());
        int[] coordinates = new int[2];
        bool isOccur = false;

        for (int row = 0; row < matrix.GetLength(0); row++)
        {

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                char ch = matrix[row, col];

                if (searchedChar == ch)
                {
                    coordinates[0] = row;
                    coordinates[1] = col;
                    isOccur = true;
                    break;
                }
            }
            if (isOccur)
                break;
        }

        if (isOccur)
        {
            Console.WriteLine($"({string.Join(", ", coordinates)})");
        }
        else
        {
            Console.WriteLine($"{searchedChar} does not occur in the matrix");
        }
    }
}
