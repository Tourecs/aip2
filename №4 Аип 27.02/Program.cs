using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Stack<int> stack = new Stack<int>();

        Console.WriteLine("Введите выражение в обратной польской нотации (например, '3 4 +'): ");
        string input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Ошибка: Ввод не может быть пустым");
            return;
        }

        string[] symbols = input.Split(' ');

        foreach (string symbol in symbols)
        {
            if (IsOperator(symbol))
            {
                if (stack.Count < 2)
                {
                    Console.WriteLine("Ошибка: Недостаточно операндов для выполнения операции");
                    return;
                }

                int op_2 = stack.Pop();
                int op_1 = stack.Pop();
                int result = MakeOperation(symbol, op_1, op_2);
                stack.Push(result);
            }
            else if (int.TryParse(symbol, out int number))
            {
                stack.Push(number);
            }
            else
            {
                Console.WriteLine($"Ошибка: '{symbol}' не является допустимым числом или оператором");
                return;
            }
        }

        if (stack.Count != 1)
        {
            Console.WriteLine("Ошибка: Некорректное выражение. Остались лишние операнды");
            return;
        }

        Console.WriteLine($"Итого: {stack.Pop()}");
    }

    static bool IsOperator(string symbol)
    {
        return symbol == "+" || symbol == "-" || symbol == "*" || symbol == "/";
    }

    static int MakeOperation(string operation, int op_1, int op_2)
    {
        return operation switch
        {
            "+" => op_1 + op_2,
            "-" => op_1 - op_2,
            "*" => op_1 * op_2,
            "/" => op_2 != 0 ? op_1 / op_2 : throw new DivideByZeroException("Ошибка: Деление на ноль"),
            _ => throw new ArgumentException($"Ошибка: Неподдерживаемая операция '{operation}'.")
        };
    }
}
