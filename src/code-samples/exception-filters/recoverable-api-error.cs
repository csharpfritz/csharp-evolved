using System;

public sealed class ApiException : Exception
{
    public ApiException(int statusCode, string message) : base(message)
    {
        StatusCode = statusCode;
    }

    public int StatusCode { get; }
}

public static class Program
{
    public static void Main()
    {
        Console.WriteLine(ReadProfile());
    }

    private static string ReadProfile()
    {
        try
        {
            throw new ApiException(404, "Profile was not found.");
        }
        catch (ApiException ex) when (ex.StatusCode == 404)
        {
            return "Use cached profile until the user signs in again.";
        }
    }
}
