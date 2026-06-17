// Usings.cs (or Program.cs) - define global using statements
global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Text.Json;
global using System.Threading.Tasks;

// Now any other file in the project can use these namespaces
// without repeating the using statements

// Example.cs (no using statements needed)
namespace MyApp;

public class UserService
{
    public async Task<List<User>> GetUsersAsync()
    {
        // Can use List<T>, Task, etc. without local using statements
        return new List<User>();
    }
}

public record User(int Id, string Name);
