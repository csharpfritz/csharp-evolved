// Raw string with interpolation
string name = "Alice";
int age = 30;
string email = "alice@example.com";

// Combine raw strings with interpolation ($)
string jsonResponse = $$"""
{
    "name": "{{name}}",
    "age": {{age}},
    "email": "{{email}}"
}
""";

// Dynamic SQL query with safe parameter substitution
string userId = "42";
string sqlQuery = $$"""
SELECT * FROM Orders
WHERE UserId = {{userId}}
AND OrderDate >= DATEADD(day, -30, GETDATE())
""";

Console.WriteLine(jsonResponse);
Console.WriteLine(sqlQuery);
