using System;
using static System.Math;

public static class Program
{
    public static void Main()
    {
        double a = 3;
        double b = 4;
        double hypotenuse = Sqrt((a * a) + (b * b));

        Console.WriteLine(hypotenuse);
    }
}
