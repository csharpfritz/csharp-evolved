using System;

string csv = "alpha,beta,gamma";
ReadOnlySpan<char> text = csv.AsSpan();
int separatorIndex = text.IndexOf(',');

ReadOnlySpan<char> firstToken = text[..separatorIndex];
ReadOnlySpan<char> remainder = text[(separatorIndex + 1)..];

Console.WriteLine(firstToken.ToString()); // alpha
Console.WriteLine(remainder.ToString());  // beta,gamma
