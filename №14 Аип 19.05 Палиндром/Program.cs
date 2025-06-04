using System;

class Program
{
    unsafe static void Main()
    {
        int size = ReadPositiveInt("Задайте размер массива: ");
        int* array = stackalloc int[size];
        Console.WriteLine($"Введите {size} чисел:");
        for (int i = 0; i < size; i++)
        {
            array[i] = ReadInt($"Число {i + 1}: ");
        }
        bool foundPalindrome = false;
        for (int i = 0; i < size; i++)
        {
            if (IsPalindrome(array[i]))
            {
                Console.WriteLine($"{array[i]} - палиндром");
                foundPalindrome = true;
            }
        }

        if (!foundPalindrome)
        {
            Console.WriteLine("Палиндромы не найдены");
        }
    }

    static int ReadInt(string prompt)
    {
        int result;
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (int.TryParse(input, out result))
                return result;
            Console.WriteLine("Введите корректное целое число (ошибка)");
        }
    }

    static int ReadPositiveInt(string prompt)
    {
        int result;
        while (true)
        {
            result = ReadInt(prompt);
            if (result > 0)
                return result;
            Console.WriteLine("Число должно быть положительным (ошибка)");
        }
    }

    static bool IsPalindrome(int num)
    {
        if (num < 0) return false;
        int reversed = 0;
        int original = num;

        while (num > 0)
        {
            int digit = num % 10;
            reversed = reversed * 10 + digit;
            num /= 10;
        }
        return original == reversed;
    }
}
