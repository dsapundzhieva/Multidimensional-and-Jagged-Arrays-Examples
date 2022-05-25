﻿using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        int[] matrixSize = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

        int[,] matrix = new int[matrixSize[0], matrixSize[1]];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            int[] colElements = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int sum = 0;

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = colElements[col];
            }
        }

        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            int sum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                sum += matrix[row, col];
            }
            Console.WriteLine(sum);
        }
    }
}
