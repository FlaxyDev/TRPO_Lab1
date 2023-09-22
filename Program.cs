using System;
using System.Collections;
using System.Collections.Generic;

public class BStringCollection<T> : IEnumerable<T>
{
    private Hashtable hashtable;
    private SortedList<int, T> sortedList;

    public BStringCollection()
    {
        hashtable = new Hashtable();
        sortedList = new SortedList<int, T>();
    }

    // Додавання бітової стрічки до колекції
    public void Add(int key, T value)
    {
        hashtable[key] = value;
        sortedList.Add(key, value);
    }

    // Видалення бітової стрічки з колекції за ключем
    public void Remove(int key)
    {
        if (hashtable.ContainsKey(key))
        {
            hashtable.Remove(key);
            sortedList.Remove(key);
        }
    }

    // Отримання бітової стрічки за ключем
    public T Get(int key)
    {
        if (hashtable.ContainsKey(key))
        {
            return (T)hashtable[key];
        }
        else
        {
            return default(T);
        }
    }

    // Перегляд всіх бітових стрічок в колекції
    public void DisplayAll()
    {
        foreach (var entry in sortedList)
        {
            Console.WriteLine($"Key: {entry.Key}, Value: {entry.Value}");
        }
    }

    // Реалізація інтерфейсу IEnumerable<T> для ітерації через колекцію
    public IEnumerator<T> GetEnumerator()
    {
        return sortedList.Values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
class Program
{
    static void Main(string[] args)
    {
        BStringCollection<string> bStrings = new BStringCollection<string>();

        bStrings.Add(1, "One");
        bStrings.Add(3, "Three");
        bStrings.Add(2, "Two");

        Console.WriteLine("All BStrings:");
        bStrings.DisplayAll();

        Console.WriteLine("\nBString with key 2: " + bStrings.Get(2));

        bStrings.Remove(3);
        Console.WriteLine("\nAfter removing BString with key 3:");
        bStrings.DisplayAll();

        Console.WriteLine("\nIterating through BStrings:");
        foreach (var bString in bStrings)
        {
            Console.WriteLine(bString);
        }
    }
}
