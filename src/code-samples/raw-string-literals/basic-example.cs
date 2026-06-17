// JSON without raw strings - requires escaping quotes
string jsonOld = "{\"name\": \"Alice\", \"age\": 30}";

// JSON with raw strings - clean and readable
string jsonNew = """
{
    "name": "Alice",
    "age": 30,
    "email": "alice@example.com"
}
""";

// SQL query with raw strings
string sqlQuery = """
SELECT u.Id, u.Name, u.Email
FROM Users u
WHERE u.Status = 'Active'
ORDER BY u.Name
""";

// Regex pattern with raw strings
string patternOld = "^\\w+@[\\w\\.]+\\.\\w+$";
string patternNew = """^\\w+@[\w\.]+\.\w+$""";

Console.WriteLine(jsonNew);
Console.WriteLine(sqlQuery);
