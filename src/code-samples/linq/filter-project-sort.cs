var adults = people
    .Where(person => person.Age >= 18)
    .OrderBy(person => person.LastName)
    .Select(person => person.FullName);
