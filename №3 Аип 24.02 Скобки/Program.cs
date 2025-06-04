using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Строка пуста");
            return;
        }

        Stack<char> bracketsStack = new Stack<char>();
        foreach (char currentChar in input)
        {
            if (currentChar == '(' || currentChar == '[' || currentChar == '{')
            {
                bracketsStack.Push(currentChar);
            }
            else if (currentChar == ')' || currentChar == ']' || currentChar == '}')
            {
                if (bracketsStack.Count == 0)
                {
                    Console.WriteLine("Скобки расставлены неправильно");
                    return;
                }

                char lastOpenBracket = bracketsStack.Pop();
                if (!IsMatchingBracket(lastOpenBracket, currentChar))
                {
                    Console.WriteLine("Скобки расставлены неправильно");
                    return;
                }
            }
        }

        Console.WriteLine(bracketsStack.Count == 0 ? "Скобки расставлены правильно" : "Скобки расставлены неправильно");
    }

    static bool IsMatchingBracket(char open, char close)
    {
        return (open == '(' && close == ')') ||
               (open == '[' && close == ']') ||
               (open == '{' && close == '}');
    }
}
