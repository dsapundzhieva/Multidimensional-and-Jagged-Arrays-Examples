using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        int matrixRows = int.Parse(Console.ReadLine());

        int[][] jaggedArray = new int[matrixRows][];

        for (int row = 0; row < jaggedArray.Length; row++)
        {
            jaggedArray[row] = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
        }

        string command;

        while ((command = Console.ReadLine()) != "END")
        {
            var cmdArgs = command.Split(" ");
            string cmdType = cmdArgs[0];

            if (cmdType == "Add")
            {
                int row = int.Parse(cmdArgs[1]);
                int column = int.Parse(cmdArgs[2]);
                int value = int.Parse(cmdArgs[3]);

                if (row >= 0 && row < jaggedArray.Length && column >= 0 && column < jaggedArray[row].Length)
                {
                    jaggedArray[row][column] += value;
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }
            }
            else if (cmdType == "Subtract")
            {
                int row = int.Parse(cmdArgs[1]);
                int column = int.Parse(cmdArgs[2]);
                int value = int.Parse(cmdArgs[3]);

                if (row >= 0 && row < jaggedArray.Length && column >= 0 && column < jaggedArray[row].Length)
                {
                    jaggedArray[row][column] -= value;
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }
            }
        }

        foreach (var item in jaggedArray)
        {
            Console.WriteLine(string.Join(" ", item));
        }
    }
}
