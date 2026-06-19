using System;

class Program
{
    static void ForEachName(string[] names, Action<string> handleName)
    {
        foreach (string name in names)
        {
            handleName(name);
        }
    }

    static void Main()
    {
        string[] names = { "Ana", "Lee", "Sam" };
        ForEachName(names, name => Console.WriteLine("Hello, " + name));
    }
}
