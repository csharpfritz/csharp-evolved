using System;
using static Guard;

public static class Program
{
    public static void Main()
    {
        string userName = "Ada";
        int retryCount = 42;

        EnsureHasValue(userName, "userName");
        EnsurePositive(retryCount, "retryCount");
        Console.WriteLine("Validation passed.");
    }
}

public static class Guard
{
    public static void EnsureHasValue(string value, string parameterName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("A value is required.", parameterName);
        }
    }

    public static void EnsurePositive(int value, string parameterName)
    {
        if (value <= 0)
        {
            throw new ArgumentOutOfRangeException(parameterName, "The value must be positive.");
        }
    }
}
