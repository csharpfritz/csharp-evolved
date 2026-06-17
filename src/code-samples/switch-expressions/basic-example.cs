// Traditional switch statement
string GetDayTypeOld(DayOfWeek day)
{
    switch (day)
    {
        case DayOfWeek.Saturday:
        case DayOfWeek.Sunday:
            return "Weekend";
        default:
            return "Weekday";
    }
}

// Switch expression (C# 8.0)
string GetDayType(DayOfWeek day) =>
    day switch
    {
        DayOfWeek.Saturday or DayOfWeek.Sunday => "Weekend",
        _ => "Weekday"
    };

Console.WriteLine(GetDayType(DayOfWeek.Monday));    // "Weekday"
Console.WriteLine(GetDayType(DayOfWeek.Saturday));  // "Weekend"
