using System;

class Program
{
    unsafe static void Main()
    {
        int* rate = stackalloc int[256];

        for (int i = 0; i < 256; i++)
            rate[i] = 0;
        Console.Write("Введите количество строк: ");
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            Console.Write("Введите строку: ");
            string input = Console.ReadLine();

            foreach (char c in input)
            {
                if (c < 256)
                {
                    rate[c]++;
                }
            }
        }

        Console.WriteLine("Частоты символов:");
        for (int i = 0; i < 256; i++)
        {
            if (rate[i] > 0)
            {
                Console.WriteLine($"{(char)i}: {rate[i]}");
            }
        }
    }
}
