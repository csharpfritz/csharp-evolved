using System;

public static class Program
{
    public static void Main()
    {
        try
        {
            try
            {
                throw new InvalidOperationException("Disk quota reached.");
            }
            catch (Exception ex) when (Log(ex, "nightly import"))
            {
                Console.WriteLine("This block never runs because the filter returned false.");
            }
        }
        catch (InvalidOperationException)
        {
            Console.WriteLine("The original exception keeps bubbling after logging.");
        }
    }

    private static bool Log(Exception ex, string operation)
    {
        Console.WriteLine(string.Format(
            "Logging {0}: {1} - {2}",
            operation,
            ex.GetType().Name,
            ex.Message));
        return false;
    }
}
