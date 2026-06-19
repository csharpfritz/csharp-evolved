using System;

int[] values = { 5, 10, 15, 20, 25, 30 };
Span<int> window = values.AsSpan(1, 3);

for (int i = 0; i < window.Length; i++)
{
    window[i] *= 2;
}

Console.WriteLine(string.Join(", ", values)); // 5, 20, 30, 40, 25, 30
