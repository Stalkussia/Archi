using System;
using System.Globalization;
using System.IO;

namespace Patterngenerator;

class PatternGenerator
{
    public void GenerateTriangle(int size,StreamWriter writer)
    {
        Console.WriteLine("Generating Triangle Pattern:");
        Console.WriteLine();
        for (int i = 1; i <= size; i++)
        {
            string row = new string('*', i);
            Console.WriteLine(row);
            writer.WriteLine(row);
        }
        Console.WriteLine();
    }
    public void GenerateInvertedTriangle(int size,StreamWriter writer)
    {
        Console.WriteLine("Generating Inverted Triangle Pattern:");
        Console.WriteLine();
        for (int i = size; i >= 1; i--)
        {
            string row = new string('*', i);
            Console.WriteLine(row);
            writer.WriteLine(row);
        }
        Console.WriteLine();
    }
    public void GenerateInvertedPyramid(int size,StreamWriter writer)
    {
        Console.WriteLine("Generating Inverted Pyramid Pattern:");
        Console.WriteLine();
        int l = 0;
        for (int i = 2 * size - 1; i > 0; i -= 2)
        {
            string row = new string(' ', l) + new string('*', i);
            Console.WriteLine(row);
            writer.WriteLine(row);
            l += 1;
        }
        Console.WriteLine();
    }
    public void GeneratePyramid(int size,StreamWriter writer)
    {
        Console.WriteLine("Generating Pyramid Pattern:");
        Console.WriteLine();
        int l = size - 1;
        for (int i = 1; i <= size * 2 - 1; i += 2)
        {
            string row = new string(' ', l) + new string('*', i);
            Console.WriteLine(row);
            writer.WriteLine(row);
            l -= 1;
        }
        Console.WriteLine();
    }
    public void GenerateSquare(int size,StreamWriter writer)
    {
        Console.WriteLine("Generating Square Pattern:");
        Console.WriteLine();
        for (int i = 1; i <= size; i++)
        {
            String row = new string('*', size);
            Console.WriteLine(row);
            writer.WriteLine(row);
        }
        Console.WriteLine();
    }
    public static void Main(string[] args)
    {
        PatternGenerator generator = new PatternGenerator();
        Console.WriteLine("=== Pattern Generator ===");
        Console.WriteLine("1. Triangle");
        Console.WriteLine("2. Inverted Triangle");
        Console.WriteLine("3. Pyramid");
        Console.WriteLine("4. Inverted Pyramid");
        Console.WriteLine("5. Square");
        Console.WriteLine("6. Exit");

        
        int exit = 1;
        while (exit == 1)
        {

            Console.Write("Choose a pattern (1-6): ");
            string? patInput = Console.ReadLine();
            if (!int.TryParse(patInput, out int pattern) || pattern < 1 || pattern > 6)
            {
                Console.WriteLine("Invalid choice. Enter a number 1-6.");
                continue;
            }

            Console.Write("Enter the size of the Pattern: ");
            int size = int.Parse(Console.ReadLine()!);

            using (StreamWriter writer = new StreamWriter("patterns.txt", true))
            {
                switch (pattern)
                {
                    case 1: generator.GenerateTriangle(size,writer); break;
                    case 2: generator.GenerateInvertedTriangle(size,writer); break;
                    case 3: generator.GeneratePyramid(size,writer); break;
                    case 4: generator.GenerateInvertedPyramid(size,writer); break;
                    case 5: generator.GenerateSquare(size,writer); break;
                    case 6: exit = 2; Console.WriteLine("Exiting..."); break;
                    default: Console.WriteLine("Invalid Input"); break;
                }
            }
        }       
    }
}