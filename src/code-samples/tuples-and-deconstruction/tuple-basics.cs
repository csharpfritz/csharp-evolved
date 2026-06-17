// Create a tuple
(string city, decimal temperature) reading = ("Seattle", 9.5m);

// Deconstruct the tuple
var (city, temp) = reading;
Console.WriteLine($"{city}: {temp}°C");

// Tuples with named elements
var person = (name: "Alice", age: 30, city: "NYC");
var (personName, personAge, personCity) = person;

// Tuple without named elements
var coordinates = (x: 10, y: 20);
var (x, y) = coordinates;
