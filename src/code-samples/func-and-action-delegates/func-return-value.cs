using System;

class Program
{
    static int Apply(int left, int right, Func<int, int, int> operation)
    {
        return operation(left, right);
    }

    static void Main()
    {
        int sum = Apply(10, 5, (x, y) => x + y);
        int product = Apply(10, 5, (x, y) => x * y);

        Console.WriteLine(sum);      // 15
        Console.WriteLine(product);  // 50
    }
}
