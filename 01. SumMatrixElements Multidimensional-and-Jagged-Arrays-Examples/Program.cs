using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        int[] sizes = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
        int[,] matrix = new int[sizes[0], sizes[1]];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            int[] colInput = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = colInput[col];
            }
        }
        int sum = 0;
        foreach (var item in matrix)
        {
            sum += item;
        }
        Console.WriteLine($"{matrix.GetLength(0)}\n{matrix.GetLength(1)}");
        Console.WriteLine(sum);
    }
}
