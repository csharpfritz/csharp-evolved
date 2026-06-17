// UserService.cs - using file-scoped namespace (C# 10.0)
namespace MyApp.Services;

public class UserService
{
    public void PrintUser(string name)
    {
        Console.WriteLine($"User: {name}");
    }
}

// Logger.cs - using file-scoped namespace
namespace MyApp.Services;

public class Logger
{
    public void Log(string message)
    {
        Console.WriteLine($"[LOG] {message}");
    }
}
