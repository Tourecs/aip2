using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> linesToWrite = new List<string>();
        Console.WriteLine("Введите строки (после окончания введите пустую строку):");

        while (true)
        {
            string line = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(line))
            {
                break;
            }
            Console.WriteLine($"Введенная строка: {line}");
            if (CheckLine(line))
            {
                linesToWrite.Add(line);
            }
        }
        Console.WriteLine("\nСтроки с нечётными числами:");
        foreach (var line in linesToWrite)
        {
            Console.WriteLine(line);
        }
    }

    static bool CheckLine(string line)
    {
        string number = "";
        bool isChecking = false;

        foreach (char ch in line)
        {
            if (char.IsDigit(ch))
            {
                number += ch;
                isChecking = true;
            }
            else if (isChecking)
            {
                if (IsOdd(number))
                {
                    return true;
                }
                number = "";
                isChecking = false;
            }
        }
        return isChecking && IsOdd(number);
    }

    static bool IsOdd(string number)
    {
        return int.Parse(number) % 2 != 0;
    }
}
