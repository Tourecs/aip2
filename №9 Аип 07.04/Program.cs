using System;
using System.Collections.Generic;

public class MyList<T>
{
    private List<T> elements = new List<T>();
    public void AddItem(T item)
    {
        elements.Add(item);
        Console.WriteLine($"Добавлен элемент: {item}");
    }
    public void RemoveItem(int index)
    {
        if (index >= 0 && index < elements.Count)
        {
            elements.RemoveAt(index);
            Console.WriteLine($"Элемент с индексом {index} удален");
        }
        else
        {
            Console.WriteLine("Неверный индекс (ошибка)");
        }
    }
    public T GetItem(int index)
    {
        if (index >= 0 && index < elements.Count)
        {
            return elements[index];
        }
        else
        {
            throw new IndexOutOfRangeException("Индекс вне диапазона (ошибка)");
        }
    }
    public int GetCount()
    {
        return elements.Count;
    }
}

class Program
{
    static void Main()
    {
        MyList<string> words = new MyList<string>();
        words.AddItem("omgtu");
        words.AddItem("best");

        Console.WriteLine("Элемент с индексом 0: " + words.GetItem(0));

        words.RemoveItem(1);

        MyList<int> numbers = new MyList<int>();
        numbers.AddItem(10);
        numbers.AddItem(20);

        Console.WriteLine("Элемент с индексом 1: " + numbers.GetItem(1));

        Console.WriteLine("Количество элементов в списке numbers: " + numbers.GetCount());
    }
}
