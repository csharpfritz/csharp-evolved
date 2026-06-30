C# 6.0 added `using static`, which lets you import the static members of a type into the current file. The most familiar examples use `System.Math`, `System.Console`, or assertion helpers, but the same idea can also make a small domain helper API feel less ceremonial.

It is a readability feature, not a performance feature. Use it where the source type remains obvious from the surrounding code.
