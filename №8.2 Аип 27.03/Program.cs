using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<string> words = new List<string> { "dog", "monkey", "tiger", "mouse", "cat" };
        var wordsStartingWithM = words.Where(word => word.StartsWith("m"));

        foreach (var word in wordsStartingWithM)
        {
            Console.WriteLine(word);
        }
    }
}
