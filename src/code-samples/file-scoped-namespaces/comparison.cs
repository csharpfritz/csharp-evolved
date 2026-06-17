// TRADITIONAL BLOCK-SCOPED NAMESPACE (pre-C# 10.0)
/*
namespace MyApp.Services
{
    public class UserService
    {
        public void PrintUser(string name)
        {
            Console.WriteLine($"User: {name}");
        }
    }
}
*/

// FILE-SCOPED NAMESPACE (C# 10.0+)
namespace MyApp.Services;

public class UserService
{
    public void PrintUser(string name)
    {
        Console.WriteLine($"User: {name}");
    }
}

// Benefits:
// - Cleaner indentation
// - Simpler visual structure
// - Less nesting required
// - Modern, recommended approach
