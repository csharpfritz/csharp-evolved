// Method returning multiple values
(string status, int errorCode) ValidateUser(string email)
{
    if (string.IsNullOrEmpty(email))
        return ("Invalid email", 400);
    
    if (!email.Contains("@"))
        return ("Email format incorrect", 422);
    
    return ("Valid", 200);
}

// Calling the method and deconstructing
var (status, code) = ValidateUser("user@example.com");
Console.WriteLine($"Status: {status}, Code: {code}");

// Or keep as tuple
var result = ValidateUser("invalid");
Console.WriteLine($"Status: {result.status}, Code: {result.errorCode}");
