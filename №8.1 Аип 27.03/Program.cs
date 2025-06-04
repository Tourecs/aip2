using System;

class Program
{
    static void Main()
    {
        Func<int, int, int> sum = (a, b) => a + b;
        Func<int, int, int> subtract = (a, b) => a - b;
        Func<int, int, int> multiply = (a, b) => a * b;
        Func<int, int, double> divide = (a, b) =>
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Деление на ноль (ошибка)");
            }
            return (double)a / b;
        };
        Console.WriteLine("Результат суммы: " + sum(5, 3)); // 8
        Console.WriteLine("Результат азности: " + subtract(5, 3)); // 2
        Console.WriteLine("Результат произведения: " + multiply(5, 3)); // 15
        
        try
        {
            Console.WriteLine("Результат деления: " + divide(5, 0)); // Искл
        }
        catch (DivideByZeroException e)
        {
            Console.WriteLine(e.Message);
        }

        Console.WriteLine("Результат деления: " + divide(10, 2)); // 5
    }
}
