using System;

public static class Program
{
    public static void Main()
    {
        int[] scores = new[] { 78, 84, 91 };
        ref int bestScore = ref FindLargest(scores);
        bestScore += 5;

        Console.WriteLine(string.Join(", ", scores));
    }

    private static ref int FindLargest(int[] values)
    {
        int largestIndex = 0;

        for (int index = 1; index < values.Length; index++)
        {
            if (values[index] > values[largestIndex])
            {
                largestIndex = index;
            }
        }

        return ref values[largestIndex];
    }
}
