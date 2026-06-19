using System;

if (int.TryParse("123", out int value))
{
    Console.WriteLine(value + 1);
}
else
{
    Console.WriteLine("Invalid number");
}
