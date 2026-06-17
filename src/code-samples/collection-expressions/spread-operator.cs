int[] first = [1, 2, 3];
int[] second = [4, 5];
int[] third = [6];

// Combine collections with spread operator
int[] combined = [..first, ..second, ..third];
// Result: [1, 2, 3, 4, 5, 6]

Console.WriteLine(string.Join(", ", combined));
