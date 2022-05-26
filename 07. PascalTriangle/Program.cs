using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

internal class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        BigInteger [][] pascalTriangle = new BigInteger[n][];

        for (int row = 0; row < pascalTriangle.Length; row++)
        {
            pascalTriangle[row] = new BigInteger[row + 1];
            pascalTriangle[row][0] = 1;
          
            for (int col = 1; col < row; col++)
            {
                pascalTriangle[row][col] = pascalTriangle[row - 1][col-1] + pascalTriangle[row - 1][col];
            }
            pascalTriangle[row][row] = 1;
        }

        foreach (var item in pascalTriangle)
        {
            Console.WriteLine(string.Join(" ", item));
        }
    }
}
