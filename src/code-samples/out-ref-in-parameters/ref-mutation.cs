using System;

static void Increment(ref int number)
{
    number++;
}

int count = 10;
Increment(ref count);
Console.WriteLine(count); // 11
